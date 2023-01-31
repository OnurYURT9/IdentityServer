using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyIdentityServer.API2.Models;

namespace UdemyIdentityServer.API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        [Authorize]
        public IActionResult GetPicture()
        {
            var pictures = new List<Picture>()
            {
                new Picture{Id=1,Name="Doğa Resmi",Url="doğaresmi.jpg"},
                new Picture{Id=2,Name="İnek Resmi",Url="doğaresmi.jpg"},
                new Picture{Id=3,Name="Fil Resmi",Url="doğaresmi.jpg"},
                new Picture{Id=4,Name="Fare Resmi",Url="doğaresmi.jpg"},
                new Picture{Id=5,Name="Köpek Resmi",Url="doğaresmi.jpg"}
            };
            return Ok(pictures);
        }
    }
}
