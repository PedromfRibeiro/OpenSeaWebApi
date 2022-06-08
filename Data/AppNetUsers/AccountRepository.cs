using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenSeaWebApi.Interfaces;
using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Data;

public class AccountRepository : IAccountRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    #region Read's
    public async Task<AppUser> GetUser(string username)
    {
        return await _userManager.Users.Where(x => x.UserName == username).SingleOrDefaultAsync();
    }
    public async Task<AppUser> GetNormalizedUserName(string Normalized)
    {
        return await _userManager.Users.Where(x => x.NormalizedUserName == Normalized).SingleOrDefaultAsync();
    }
    public async Task<AppUser> GetNormalizedEmail(string Normalized)
    {
        return await _userManager.Users.Where(x => x.NormalizedEmail == Normalized).SingleOrDefaultAsync();
    }
    #endregion
    #region Create
    public async Task<IdentityResult> Create(AppUser User, string password)
    {
        return await _userManager.CreateAsync(User, password);
    }
    #endregion
    #region Operations

    public async Task<SignInResult> Login(AppUser user, string password, bool Lockdown)
    {
        var result = await _signInManager.CheckPasswordSignInAsync(user, password, Lockdown);
        if (result.Succeeded)
        {
            user.LastLogin = DateTime.Now;
            var res = await _userManager.UpdateAsync(user);
        }
        return result;
    }
    #endregion
}
