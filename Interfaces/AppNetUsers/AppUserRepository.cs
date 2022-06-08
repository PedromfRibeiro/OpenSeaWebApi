using System.Collections.Generic;
using System.Threading.Tasks;
using OpenSeaWebApi.DTOs;
using OpenSeaWebApi.Helpers;
using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Interfaces
{
    public interface IAppUserRepository
    {
    //C(reate) R(ead) U(pdate) D(elete)
    //Create
    
    //Read
        Task<UserDto> GetUserAsync(string username);
        Task<UserDto> GetByIdUserAsync(string id);

        Task<PagedList  <UserDto>> GetUsersAsync(PaginationParams userParams);
        Task<List<MemberSimpleDto>> GetListUsersAsync();
        Task<IEnumerable<UserDto>> SearchUserAsync(MemberDto utilizador);        //Search
        Task<ConfigUserDto> SearchConfigUserAsync(UserDto utilizador);
        Task<AppUser> GetUserByUsernameAsync(string UserName);
        Task<AppUser> GetUtilizadorByIdAsync(int id);

        //         Task<Utilizador> GetUtilizadorByUsernameAsync(string username);
        //         Task<PagedList<MemberDto>> GetMembersAsync(PaginationParams userParams);
        //         Task<MemberDto> GetMemberAsync(string username);
    //Update
        void UpdateUser(AppUser appUser);
        void UserSettings(AppUserConfig config);
        //     //Delete
        //         void Delete(Utilizador utilizador);

    //Functions
        Task<bool> SaveAllAsync();
    }
    
}



