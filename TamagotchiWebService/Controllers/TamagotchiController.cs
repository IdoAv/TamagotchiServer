using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamagotchiBL.Models;

namespace TamagotchiWebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TamagotchiController : Controller
    {
        private TamagotchiContext context;

        public TamagotchiController(TamagotchiContext context)
        {
            this.context = context;
        }

        [Route("Test")]
        [HttpGet]
        public string Test()
        {
            return "it works";
        }
    }
}
