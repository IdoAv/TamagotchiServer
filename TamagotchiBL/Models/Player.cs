using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiBL.Models
{
    [Index(nameof(PlayerEmail), Name = "UniqueEmail", IsUnique = true)]
    [Index(nameof(PlayerUserName), Name = "UniqueUserName", IsUnique = true)]
    public partial class Player
    {
        public Player()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int PlayerId { get; set; }
        [Required]
        [StringLength(30)]
        public string PlayerEmail { get; set; }
        [Required]
        [StringLength(30)]
        public string PlayerUserName { get; set; }
        public int? PlayerActiveAnimal { get; set; }
        [StringLength(10)]
        public string PlayerGender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PlayerBirthDate { get; set; }
        [Required]
        [StringLength(20)]
        public string PlayerFirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string PlayerLastName { get; set; }
        [Required]
        [StringLength(30)]
        public string PlayerPassword { get; set; }

        [ForeignKey(nameof(PlayerActiveAnimal))]
        [InverseProperty(nameof(Animal.PlayerNavigation))]
        public virtual Animal PlayerActiveAnimalNavigation { get; set; }
        [InverseProperty(nameof(Animal.Player))]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
