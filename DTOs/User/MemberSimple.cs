using System.ComponentModel.DataAnnotations;

namespace OpenSeaWebApi.DTOs;

    public class MemberSimpleDto
{
    public int id { get; set; }
    [Required]
    public string? name { get; set; }
    [Required]
    public string? UserName { get; set; }
    public string? contact { get; set; }
    public int? company_id { get; set; }
    //IdentityUser Fields
    [Required]
    public string? Email { get; set; }
}
