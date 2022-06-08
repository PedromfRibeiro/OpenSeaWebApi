using OpenSeaWebApi.DTOs;
using OpenSeaWebApi.Models;
using AutoMapper;

namespace OpenSeaWebApi.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // <From, To>
        #region AppUser
        CreateMap<UserDto, AppUser>();
        CreateMap<AppUser, UserDto>();

        CreateMap<RegisterDto, AppUser>();
        CreateMap<AppUser, RegisterDto>();

        CreateMap<UserUpdateDto, AppUser>();
        CreateMap<AppUser, UserUpdateDto>();

        CreateMap<ConfigUserDto, AppUserConfig>();
        CreateMap<AppUserConfig, ConfigUserDto>();

        CreateMap<LoginDto, AppUser>();
        #endregion
    }
}
