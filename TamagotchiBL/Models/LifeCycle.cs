using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiBL.Models
{
    [Table("LifeCycle")]
    public partial class LifeCycle
    {
        public LifeCycle()
        {
            Animals = new HashSet<Animal>();
            HistoryOfFunctions = new HashSet<HistoryOfFunction>();
        }

        [Key]
        public int LifeCycleId { get; set; }
        [Required]
        [StringLength(20)]
        public string LifeCycleName { get; set; }
        public int LifeCycleAge { get; set; }

        [InverseProperty(nameof(Animal.LifeCycle))]
        public virtual ICollection<Animal> Animals { get; set; }
        [InverseProperty(nameof(HistoryOfFunction.LifeCycle))]
        public virtual ICollection<HistoryOfFunction> HistoryOfFunctions { get; set; }
    }
}
