using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceCoastWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get(int seconds)
        {
            await Task.Delay(seconds * 1000);
            return DateTime.Now.ToString();
        }
    }
}
