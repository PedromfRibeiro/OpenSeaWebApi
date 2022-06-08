using Microsoft.AspNetCore.Mvc;
using OpenSeaWebApi.Models;
using OpenSeaWebApi.DTOs;
using OpenSeaWebApi.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace OpenSeaWebApi.Controllers;

public class AccountController : BaseApiController
{
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    public readonly IAppUserRepository _appUserRepository;
    public readonly IAccountRepository _AccountRepository;
    public readonly IConfiguration _configuration;
    public readonly ILogger<AccountController> _logger;


    public AccountController(
        UserManager<AppUser> userManager,
        IAppUserRepository appUserRepository,
        IAccountRepository accountRepository,
        ILogger<AccountController> logger,
        ITokenService tokenService,
        IConfiguration config,
        IMapper mapper)
    {
        _appUserRepository = appUserRepository;
        _AccountRepository = accountRepository;
        _userManager = userManager;
        _tokenService = tokenService;
        _configuration = config;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Registers an User
    /// </summary>
    /// <param name="register"> The arguments to register the user </param>
//    [Authorize]
    [HttpPost, Route("register")]
    public async Task<ActionResult> Register(RegisterDto register)
    {
        var x = await _AccountRepository.GetNormalizedUserName(register.UserName.ToUpper());
        if (x != null)
            return BadRequest("The User already exists in the system");

        var User = new AppUser();
        _mapper.Map(register, User);

        User.UserConfigs = new AppUserConfig { itemsPerPage = 10, isDarkTheme = false };
        User.CreateTime = DateTime.Now;

        var result = await _AccountRepository.Create(User, _configuration["Default_password"]);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        var token = await _userManager.GeneratePasswordResetTokenAsync(User);

        return Ok(token);
    }



    /// <summary>
    /// Resets the user password
    /// </summary>
    /// <param name="userEmail"> Email to send the new reset token to </param>
//    [Authorize]
    [HttpPost, Route("resetPassword")]
    public async Task<ActionResult> ResetPassword(string userEmail)
    {
        var user = await _AccountRepository.GetNormalizedEmail(userEmail);
        if (user == null)
            return NotFound();
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        return Ok(token);
    }

    /// <summary>
    /// Logs in a User
    /// </summary>
    /// <param name="loginDto"> Login Arguments </param>
    [HttpPost, Route("login")]
    public async Task<ActionResult<LoginDto>> Login(LoginDto loginDto)
    {
        AppUser user = await _AccountRepository.GetNormalizedUserName(loginDto.Username.ToUpper());

        if (user == null)
            return BadRequest("Sign in unsuccessful.");
        if (user.FirstLogin == true)
            return BadRequest("Password change required.");
        //Save the last login before making a new login and updating it
        var lastLogin = user.LastLogin;

        Microsoft.AspNetCore.Identity.SignInResult result = await _AccountRepository.Login(user, loginDto.password, false);

        if (!result.Succeeded)
            return Unauthorized();

        UserDto response = new UserDto();
        _mapper.Map(user, response);
        response.LastLogin = lastLogin;

        //response.Token = _tokenService.CreateToken(user);
        response.UserConfig = await _appUserRepository.SearchConfigUserAsync(response);

        var jwttoken = _tokenService.CreateToken(user, response.Id.ToString());
        response.Token = jwttoken;

        return Ok(response);
    }
    #region Update

    /// <summary>
    /// Redefines the password for an account
    /// </summary>
    /// <param name="email"> The email of the account </param>
    /// <param name="token"> The token emailed to the user </param>
    /// <param name="newPassword"> The password to update to </param>
    /// <returns></returns>
    [HttpGet, Route("RedefinePassword")]
    public async Task<ActionResult<IdentityResult>> RedefinePassword(string email, string token, string newPassword)
    {
        AppUser user = null;
        if (!string.IsNullOrEmpty(email))
            user = await _AccountRepository.GetNormalizedEmail(email.ToUpper());

        if (user == null)
            return NotFound();

        // If we dont do this first and the update of "FirstLogin" fails the user will never get access to the account and the password will be change.
        // Thus, we need to change the variable first then the password.
        user.FirstLogin = false;
        _appUserRepository.UpdateUser(user);

        if (await _appUserRepository.SaveAllAsync() == true)
        {
            IdentityResult result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (result.Succeeded == true)
                return Ok(result);
            else { return Unauthorized(result); }
        }
        return Unauthorized();
    }
    /// <summary>
    /// Updates the password of a user
    /// </summary>
    /// <param name="User"> The arguments to update the password </param>
//    [Authorize]
    [HttpPut("changePassword")]
    public async Task<ActionResult> UpdateUserPassword(LoginDto User)
    {
        AppUser user = await _AccountRepository.GetNormalizedUserName(User.Username.ToUpper());

        if (user != null)
        {
            var result = await _userManager.ChangePasswordAsync(user, User.password, User.password);
            if (result.Succeeded)
            {
                return Ok();
            }
        }
        return BadRequest("Password not updated");

    }
    #endregion
    #region Delete
    /// <summary>
    /// Deletes a user
    /// </summary>
    /// <param name="username"> The username of the user to delete </param>
//    [Authorize]
    [HttpDelete("{username}")]
    public async Task<ActionResult> DeleteUser(string username)
    {
        var user = await _appUserRepository.GetUserByUsernameAsync(username);

        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok(user);
            }
        }
        return BadRequest(username + " not Deleted");

    }
    #endregion
}