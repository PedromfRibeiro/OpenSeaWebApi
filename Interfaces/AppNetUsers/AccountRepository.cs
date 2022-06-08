using Microsoft.AspNetCore.Identity;
using OpenSeaWebApi.DTOs;
using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Interfaces;

public interface IAccountRepository
{
    Task<AppUser> GetUser(string username);
    Task<AppUser> GetNormalizedUserName(string Normalized);
    Task<AppUser> GetNormalizedEmail(string Normalized);

    Task<IdentityResult> Create(AppUser userx, string password);
    Task<SignInResult> Login(AppUser userx, string password,bool Lockdown);
}