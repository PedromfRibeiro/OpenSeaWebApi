using System.Drawing;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenSeaWebApi.Data;
using OpenSeaWebApi.Interfaces;

namespace OpenSeaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {        
    }
}