using AuthServer.Application.Configurations;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using AuthServer.Application.Interfaces.Services;
using AuthServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;


namespace AuthServer.Persistence.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;


        private readonly CustomTokenOption _customTokenOption;

        public TokenService(UserManager<User> userManager, IOptions<CustomTokenOption> options)
        {
            _userManager = userManager;
            _customTokenOption = options.Value;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }

        private async Task<IEnumerable<Claim>> GetClaims(User user, List<string> audiences)
        {
            var userRoles = await _userManager.GetRolesAsync(user);


            var userClaimList = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            userClaimList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            userClaimList.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            return userClaimList;
        }

        public async Task<CreateTokenByUserCommandResponse> CreateToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_customTokenOption.AccessTokenExpiration);
            var refleshTokenExpiration = DateTime.Now.AddMinutes(_customTokenOption.RefreshTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_customTokenOption.SecurityKey);
            var audiences = _customTokenOption.Audiences;
            var issuerToken = _customTokenOption.Issuer;

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                 issuer: issuerToken,
                 expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: await GetClaims(user, audiences),
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var getTokenByUserQueryResponse = new CreateTokenByUserCommandResponse(token, accessTokenExpiration, CreateRefreshToken(), refleshTokenExpiration);

            return getTokenByUserQueryResponse;
        }
    }
}