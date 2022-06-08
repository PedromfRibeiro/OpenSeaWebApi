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
        [NonAction]
        public byte[] ResizeImage(byte[] byteImageIn)
        {
            byte[] currentByteImageArray = byteImageIn;
            double scale = 1f;
            MemoryStream inputMemoryStream = new MemoryStream(byteImageIn);
            Image fullsizeImage = Image.FromStream(inputMemoryStream);
            while (currentByteImageArray.Length > 50000)
            {
                Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size((int)(fullsizeImage.Width * scale), (int)(fullsizeImage.Height * scale)));
                MemoryStream resultStream = new MemoryStream();
                fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);
                currentByteImageArray = resultStream.ToArray();
                resultStream.Dispose();
                resultStream.Close();
                scale -= 0.05f;
            }
            return currentByteImageArray;
        }

    }
}