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

        [Route("UserNameExist")]
        [HttpGet]
        public bool UserNameExist([FromQuery] string userName)
        {
            bool exist = context.PlayerExistByUserName(userName);
            if (exist)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return true;
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return false;
        }
        [Route("EmailExist")]
        [HttpGet]
        public bool EmailExist([FromQuery] string email)
        {
            bool exist = context.PlayerExistByEmail(email);
            if (exist)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return true;
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return false;
        }
        [Route("Register")]
        [HttpPost]
        public void Register([FromBody] PlayerDTO player)
        {
            Player p = new Player()
            {
                PlayerEmail = player.PlayerEmail,
                PlayerPassword = player.PlayerPassword,
                PlayerFirstName = player.PlayerFirstName,
                PlayerLastName = player.PlayerLastName,
                PlayerBirthDate = player.PlayerBirthDate,
                PlayerActiveAnimal = player.PlayerActiveAnimal,
                PlayerGender = player.PlayerGender,
                PlayerId = player.PlayerId,
                PlayerUserName = player.PlayerUserName
            };
            context.Register(p);
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
        }
    }
}
