using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiBL.Models
{
    [Index(nameof(Age), Name = "HistoryOfFunctionsAgeIndex")]
    [Index(nameof(LifeCycleId), Name = "HistoryOfFunctionsLifeCycleIndex")]
    public partial class HistoryOfFunction
    {
        public int FunctionId { get; set; }
        [Key]
        [Column("AnimalID")]
        public int AnimalId { get; set; }
        public int Age { get; set; }
        public int LifeCycleId { get; set; }
        public double? AnimalWeight { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime FunctionDate { get; set; }
        public int AnimalHunger { get; set; }
        public int AnimalCleaness { get; set; }
        public int AnimalHappiness { get; set; }

        [ForeignKey(nameof(AnimalId))]
        [InverseProperty("HistoryOfFunctions")]
        public virtual Animal Animal { get; set; }
        [ForeignKey(nameof(FunctionId))]
        [InverseProperty("HistoryOfFunctions")]
        public virtual Function Function { get; set; }
        [ForeignKey(nameof(LifeCycleId))]
        [InverseProperty("HistoryOfFunctions")]
        public virtual LifeCycle LifeCycle { get; set; }
    }
}
