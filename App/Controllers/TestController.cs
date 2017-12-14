using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("test/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var dict = new Dictionary<string, string> {["kek"] = "lol", ["lol"] = "kek"};
            return Ok(dict);
        }
    }
}
