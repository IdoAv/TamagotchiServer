using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamagotchiBL.Models;

namespace TamagotchiWebService.DataTransferObjects
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string PlayerEmail { get; set; }
        public string PlayerUserName { get; set; }
        public string PlayerGender { get; set; }
        public DateTime? PlayerBirthDate { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public int? PlayerActiveAnimal { get; set; }
        public string PlayerPassword { get; set; }

        public PlayerDTO() { }
        public PlayerDTO(Player player)
        {
            this.PlayerId = player.PlayerId;
            this.PlayerEmail = player.PlayerEmail;
            this.PlayerUserName = player.PlayerUserName;
            this.PlayerGender = player.PlayerGender;
            this.PlayerBirthDate = player.PlayerBirthDate;
            this.PlayerFirstName = player.PlayerFirstName;
            this.PlayerActiveAnimal = player.PlayerActiveAnimal;
            this.PlayerLastName = player.PlayerFirstName;
            this.PlayerPassword = player.PlayerPassword;
        }
    }
}
