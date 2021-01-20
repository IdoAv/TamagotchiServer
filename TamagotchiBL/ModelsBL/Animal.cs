 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamagotchiBL.Models
{
    public partial class Animal
    {
        public List<HistoryOfFunction> GetHistoryOfFunctions() => this.HistoryOfFunctions
            .ToList();
        public void ApplyFunction(Function f)
        {
            try
            {
                this.AnimalHunger += f.HungerImpact.Value;
            }
            catch (Exception e)
            {
                if (this.AnimalHunger + f.HungerImpact.Value > 100)
                    this.AnimalHunger = 100;
                else
                    this.AnimalHunger = 0;
            }


            try
            {
                this.AnimalCleaness += f.CleanessImpact.Value;
            }
            catch (Exception e)
            {
                if (this.AnimalCleaness + f.CleanessImpact.Value > 100)
                    this.AnimalCleaness = 100;
                else
                    this.AnimalCleaness = 0;
            }

            try
            {
                this.AnimalHappiness += f.HungerImpact.Value;
            }
            catch (Exception e)
            {
                if (this.AnimalHappiness + f.HappinessImpact.Value > 100)
                    this.AnimalHappiness = 100;
                else
                    this.AnimalCleaness = 0;
            }

            this.AnimalWeight += f.GainWeight.Value;
            if (this.AnimalWeight + f.GainWeight.Value < 0)
                this.AnimalWeight = 0;
            
            
        }
    }
}
