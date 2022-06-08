using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using OpenSeaWebApi.Models;
using OpenSeaWebApi.Helpers;
using OpenSeaWebApi.Interfaces;
using OpenSeaWebApi.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

using OpenSeaWebApi.DTOs;
using OpenSeaWebApi.Data;

namespace OpenSeaWebApi.Controllers;
public class AppUserController : BaseApiController
{
    public readonly IAppUserRepository _appUserRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly DataContext _dataContext;


    public AppUserController(IAppUserRepository appUserRepository,
                             IMapper mapper,
                             UserManager<AppUser> userManager,
                             ITokenService tokenService,
                             DataContext dataContext)
    {
        _userManager = userManager;
        _mapper = mapper;
        _appUserRepository = appUserRepository;
        _tokenService = tokenService;
        _dataContext = dataContext;
    }

    #region Read
    /// <summary>
    /// A simple list of users
    /// </summary>
    /// <param name="userParams"> The pagination arguments</param>
    /// <returns> A paginated list of users </returns>
//    [Authorize]
    [HttpGet]
    public async Task<ActionResult<SimpleUserDto>> GetUsers([FromQuery] PaginationParams userParams)
    {
        var users = await _appUserRepository.GetUsersAsync(userParams);
        Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);
        return Ok(users);
    }
    /// <summary>
    /// Info about a simple user
    /// </summary>
    /// <param name="username"> The username of the user to get </param>
    /// <returns> A simple User </returns>
//    [Authorize]
    [HttpGet("{username}")]
    public async Task<ActionResult<SimpleUserDto>> GetUser(string username)
    {
        var user = new UserDto();
        if (IsDigitsOnly(username))
        {
            user = await _appUserRepository.GetByIdUserAsync(username);
        }
        else { user = await _appUserRepository.GetUserAsync(username); }
        if (user == null) return BadRequest("User not found");
        
        return Ok(user);
    }

    /// <summary>
    /// Get a simplified version of the user
    /// </summary>
    /// <returns> Information about the user </returns>
//    [Authorize]
    [HttpGet("/api/AppUser/info")]
    public async Task<ActionResult<SimpleUserDto>> GetUserInformation()
    {
      
        var username = User.Claims.ToList().First();
        //var userId = User.Claims.ToList()[1];
        
        var user = await _appUserRepository.GetUserAsync(username.Value);

        if(user == null) return BadRequest("User not found");

        return Ok(user);
    }
    #endregion

    #region Update
    /// <summary>
    /// Updates a user
    /// </summary>
    /// <param name="userUpdateDto"> User parameters to update </param>
//    [Authorize]
    [HttpPut]
    public async Task<ActionResult> EditUser(UserUpdateDto userUpdateDto)
    {
        var user = await _appUserRepository.GetUserByUsernameAsync(userUpdateDto.UserName);
        if (user != null)
        {
            _mapper.Map(userUpdateDto, user);
            _appUserRepository.UpdateUser(user);
            if (await _appUserRepository.SaveAllAsync())
            {
                _mapper.Map(user, userUpdateDto);
                return Ok(userUpdateDto);
            }
        }
        return BadRequest("User " + userUpdateDto?.UserName + " not updated");
    }
    
    #endregion

    /// <summary>
    /// Checks if a string is made of digits
    /// </summary>
    /// <param name="str"> String to check </param>
    /// <returns> True if its made of digits </returns>
    [NonAction]
    bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
}