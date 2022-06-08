using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations; using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace OpenSeaWebApi.DTOs;

public class UserUpdateDto
{
    public string name { get; set; }
    public string contact { get; set; }
    public string observations { get; set; }
    public int? company_id { get; set; }
    //IdentityUser Fields
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
