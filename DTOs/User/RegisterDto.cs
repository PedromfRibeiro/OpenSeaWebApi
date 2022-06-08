using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.DTOs;

public class RegisterDto
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? password { get; set; }
    public string? name { get; set; }
    public string? contact { get; set; }
    public string? PhoneNumber { get; set; }
    public string? observations { get; set; }

}
