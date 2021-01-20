using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiBL.Models
{
    public partial class Animal
    {
        public Animal()
        {
            HistoryOfFunctions = new HashSet<HistoryOfFunction>();
        }

        [Key]
        public int AnimalId { get; set; }
        [Required]
        [StringLength(10)]
        public string AnimalName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AnimalBirthDate { get; set; }
        public double AnimalWeight { get; set; }
        public double AnimalAge { get; set; }
        public int AnimalHunger { get; set; }
        public int AnimalCleaness { get; set; }
        public int AnimalHappiness { get; set; }
        public int PlayerId { get; set; }
        public int StatusId { get; set; }
        public int LifeCycleId { get; set; }

        [ForeignKey(nameof(LifeCycleId))]
        [InverseProperty("Animals")]
        public virtual LifeCycle LifeCycle { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("Animals")]
        public virtual Player Player { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(AnimalStatus.Animals))]
        public virtual AnimalStatus Status { get; set; }
        [InverseProperty("PlayerActiveAnimalNavigation")]
        public virtual Player PlayerNavigation { get; set; }
        [InverseProperty(nameof(HistoryOfFunction.Animal))]
        public virtual ICollection<HistoryOfFunction> HistoryOfFunctions { get; set; }
    }
}
