using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PlantHere.Application.Utilities
{
    public static class SignUtility
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
