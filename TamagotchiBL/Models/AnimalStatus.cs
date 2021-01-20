using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiBL.Models
{
    [Table("AnimalStatus")]
    public partial class AnimalStatus
    {
        public AnimalStatus()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int StatusId { get; set; }
        [Required]
        [StringLength(20)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(Animal.Status))]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
