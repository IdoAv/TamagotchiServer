using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamagotchiBL.Models
{
    public partial class Player
    {
        public bool AnimalExist(int id) => this.Animals
            .Any(a => a.AnimalId == id);
        public List<Animal> GetAnimals() => this.Animals
            .ToList();
        public Animal GetAnimal(int id) => this.Animals
            .FirstOrDefault(a => a.AnimalId == id);
    
    }
}
