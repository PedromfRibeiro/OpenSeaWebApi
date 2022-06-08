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

        CreateMap<StandardAsset,CustomAsset>();        
        CreateMap<CustomAsset,StandardAsset>();

        CreateMap<StandardAssetContract,CustomAssetContract>();        
        CreateMap<CustomAssetContract,StandardAssetContract>();

        CreateMap<StandardAssetEvent,CustomAssetEvent>();        
        CreateMap<CustomAssetEvent,StandardAssetEvent>();

        CreateMap<StandardCollection,CustomCollection>();        
        CreateMap<CustomCollection,StandardCollection>();

        CreateMap<StandardDisplayData,CustomDisplayData>();        
        CreateMap<CustomDisplayData,StandardDisplayData>();

        CreateMap<StandardEvent,CustomEvent>();        
        CreateMap<CustomEvent,StandardEvent>();

        CreateMap<StandardFromAccount,CustomFromAccount>();        
        CreateMap<CustomFromAccount,StandardFromAccount>();

        CreateMap<StandardOwner,CustomOwner>();        
        CreateMap<CustomOwner,StandardOwner>();

        CreateMap<StandardPaymentToken,CustomPaymentToken>();        
        CreateMap<CustomPaymentToken,StandardPaymentToken>();

        CreateMap<StandardRoot,CustomRoot>();        
        CreateMap<CustomRoot,StandardRoot>();

        CreateMap<StandardSeller,CustomSeller>();        
        CreateMap<CustomSeller,StandardSeller>();
        
        CreateMap<StandardToAccount,CustomToAccount>();        
        CreateMap<CustomToAccount,StandardToAccount>();

        CreateMap<StandardUser,CustomUser>();        
        CreateMap<CustomUser,StandardUser>();

    }
}
