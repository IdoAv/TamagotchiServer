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
        [Route("Login")]
        [HttpPost]
        public PlayerDTO Login([FromBody] UserDTO user)
        {
            Player player = context.LogIn(user.Email, user.Password);
            if (player != null)
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
        [Route("GetAnimals")]
        [HttpGet]
        public List<AnimalDTO> GetAnimals()
        {
            PlayerDTO player = HttpContext.Session.GetObject<PlayerDTO>("loggedIn");
            if (player != null)
            {
                List<AnimalDTO> animals = new List<AnimalDTO>();
                foreach (Animal a in context.LogIn(player.PlayerEmail, player.PlayerPassword).GetAnimals())
                {
                    animals.Add(new AnimalDTO(a));
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return animals;
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return null;
        }
    }
}
