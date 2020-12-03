using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[Authorize]


    public class SecretController : ControllerBase
    {

        [Route("/secret")]
        [Authorize]
        public string Index()
        {
            var claims = User.Claims.ToList();
            return "secret message from HomeBudget.API";
        }
    }
}