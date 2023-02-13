using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using AuthServer.Application.CQRS.User.Commands.CreateUser;
using AuthServer.Application.CQRS.User.Queries.GetUserByName;
using AuthServer.Domain.Entities;
using AutoMapper;

namespace AuthServer.Application.Mapping
{
    internal class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateUserCommand, CreateUserCommandResponse>().ReverseMap();
            CreateMap<CreateTokenByUserCommand, User>().ReverseMap();
            CreateMap<CreateUserCommandResponse, User>().ReverseMap();
            CreateMap<CreateTokenByRefreshTokenCommandResponse, CreateTokenByUserCommandResponse>().ReverseMap();
            CreateMap<GetUserByNameQueryResponse, User>().ReverseMap();
        }
    }
}
