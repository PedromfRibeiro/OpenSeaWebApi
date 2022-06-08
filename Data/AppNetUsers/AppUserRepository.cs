using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenSeaWebApi.DTOs;
using OpenSeaWebApi.Helpers;
using OpenSeaWebApi.Interfaces;
using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Data
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public AppUserRepository(DataContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        //C(reate) R(ead) U(pdate) D(elete)

        //Read
        public async Task<UserDto> GetUserAsync(string username)
        {
            return await _userManager.Users .Where(x => x.UserName == username)
                                     .Include(c => c.UserConfigs)
                                     .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                                     .SingleOrDefaultAsync();
        }
        
        public async Task<UserDto> GetByIdUserAsync(string id)
        {
            return await _userManager.Users
                                     .Where(x => x.Id ==  int.Parse(id))
                                     .Include(c => c.UserConfigs)
                                     .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                                     .SingleOrDefaultAsync();        }

        public async Task<PagedList<UserDto>> GetUsersAsync(PaginationParams userParams)
        {
            var query = _userManager.Users
                            .OrderBy(u => u.Id)
                            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                            .AsNoTracking();
                           
            return await PagedList<UserDto>.CreateAsync(query,userParams.PageNumber,userParams.PageSize,userParams.FilterOptions2);
        }

        public async Task<List<MemberSimpleDto>> GetListUsersAsync()
        {
            return await _context.db_AppUser
                                 .ProjectTo<MemberSimpleDto>(_mapper.ConfigurationProvider)
                                 .ToListAsync();        
        }

        public async Task<IEnumerable<UserDto>> SearchUserAsync(MemberDto user)
        {
            return await _userManager.Users
                       .Where(x => x.UserName.Contains(user.username))
                       .Where(x => x.name.Contains(user.name))
                       .Where(x => x.PhoneNumber.Contains(user.PhoneNumber))
                       .Where(x => x.Email.Contains(user.email))
                       .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                       .ToListAsync();
        }

        public async Task<ConfigUserDto> SearchConfigUserAsync(UserDto utilizador)
        {
        
                return await _context.db_configUser
                                     .Where(x => x.AppUser.Id == utilizador.Id)
                                     .ProjectTo<ConfigUserDto>(_mapper.ConfigurationProvider)
                                     .SingleAsync();
        }

        public async Task<AppUser> GetUtilizadorByIdAsync(int id)
        {
            return await _context.db_AppUser.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string UserName)
        {   
            return await _context.db_AppUser.SingleOrDefaultAsync(x => x.UserName == UserName);
        }
        //Update
        public void UpdateUser(AppUser appUser)
        {
            _context.Entry(appUser).State = EntityState.Modified;
        }

        public void UserSettings(AppUserConfig config)
        {
            _context.Entry(config).State = EntityState.Modified;
        }

        //Functions
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}