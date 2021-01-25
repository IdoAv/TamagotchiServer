using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamagotchiBL.Models;

namespace TamagotchiWebService.DataTransferObjects
{
    public class AnimalDTO
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public DateTime AnimalBirthDate { get; set; }
        public double AnimalWeight { get; set; }
        public double AnimalAge { get; set; }
        public int AnimalHunger { get; set; }
        public int AnimalCleaness { get; set; }
        public int AnimalHappiness { get; set; }
        public string StatusName { get; set; }
        public string LifeCycleName { get; set; }
        public int PlayerId { get; set; }

        public AnimalDTO() { }
        public AnimalDTO(Animal a)
        {
            this.AnimalId = a.AnimalId;
            this.AnimalName = a.AnimalName;
            this.AnimalBirthDate = a.AnimalBirthDate;
            this.AnimalWeight = a.AnimalWeight;
            this.AnimalAge = a.AnimalAge;
            this.AnimalHappiness = a.AnimalHappiness;
            this.AnimalHunger = a.AnimalHunger;
            this.AnimalCleaness = a.AnimalCleaness;
            this.StatusName = a.Status.StatusName;
            this.LifeCycleName = a.LifeCycle.LifeCycleName;
            this.PlayerId = a.PlayerId;
        }
    }
}
