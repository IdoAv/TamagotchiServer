using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamagotchiBL.Models;
using TamagotchiWebService.DataTransferObjects;

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

        [Route("Login")]
        [HttpPost]
        public PlayerDTO Login([FromBody] UserDTO user)
        {
            Player player = context.LogIn(user.Email, user.Password);
            if(player != null)
            {
                PlayerDTO playerDTO = new PlayerDTO(player);
                HttpContext.Session.SetObject("loggedIn", playerDTO);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return playerDTO;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;

            }
        }
        [Route("Logout")]
        [HttpGet]
        public void Logout()
        {
            PlayerDTO player = HttpContext.Session.GetObject<PlayerDTO>("loggedIn");
            if (player != null)
            {
                context.SaveChanges();
                HttpContext.Session.Clear();
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
        }
    }
}
