using Newtonsoft.Json;
using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.DTOs;

    public class UtilizadorDto
    {   
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int id { get; set; }
        public string? name { get; set; }
        public string? contact { get; set; }
        public byte[]? image_small { get; set; }
        public string? PhoneNumber { get; set;}
        public string? observations { get; set; }
        //public Company company_id { get; set; }
        //IdentityUser Fields
        public string? UserName { get; set;}
        public string? Email { get; set; }
    }
