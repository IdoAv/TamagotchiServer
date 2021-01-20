using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiBL.Models
{
    public partial class Function
    {
        public Function()
        {
            HistoryOfFunctions = new HashSet<HistoryOfFunction>();
            InverseFunctionOfNavigation = new HashSet<Function>();
        }

        [Key]
        public int FunctionId { get; set; }
        [Required]
        [StringLength(50)]
        public string FunctionName { get; set; }
        public int? HungerImpact { get; set; }
        public int? CleanessImpact { get; set; }
        public int? HappinessImpact { get; set; }
        public double? GainWeight { get; set; }
        public int? FunctionOf { get; set; }

        [ForeignKey(nameof(FunctionOf))]
        [InverseProperty(nameof(Function.InverseFunctionOfNavigation))]
        public virtual Function FunctionOfNavigation { get; set; }
        [InverseProperty(nameof(HistoryOfFunction.Function))]
        public virtual ICollection<HistoryOfFunction> HistoryOfFunctions { get; set; }
        [InverseProperty(nameof(Function.FunctionOfNavigation))]
        public virtual ICollection<Function> InverseFunctionOfNavigation { get; set; }
    }
}
