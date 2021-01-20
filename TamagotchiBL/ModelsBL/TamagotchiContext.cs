using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamagotchiBL.Models
{
    public partial class TamagotchiContext
    {
        public void Register(Player p)
        {
            this.Players.Add(p);
            this.SaveChanges();
        }
        public Player LogIn(string email, string password) => this.Players
            .FirstOrDefault(p => p.PlayerEmail == email && p.PlayerPassword == password);

        public List<Function> GetFirstFunctions() => this.Functions
            .Where(f => f.FunctionOf == null)
            .ToList();
        public Function GetFirstFunction(int id) => this.Functions
            .Where(f => f.FunctionOf == null)
            .FirstOrDefault(f => f.FunctionId == id);
        public bool ExistInFirstFunctions(int id) => this.Functions
            .Any(f => f.FunctionId == id);
        public bool PlayerExistByEmail(string email) => this.Players
            .Any(p => p.PlayerEmail == email);
        public bool PlayerExistByUserName(string userName) => this.Players
            .Any(p => p.PlayerUserName == userName);
        public void AddHistoryOfFunctions(Animal a, Function f)
        {
            HistoryOfFunction h = new HistoryOfFunction()
            {
                Animal = a,
                Function = f,
                Age = (int)a.AnimalAge,
                AnimalCleaness = a.AnimalCleaness,
                AnimalHappiness = a.AnimalHappiness,
                AnimalHunger = a.AnimalHunger,
                AnimalWeight = a.AnimalWeight,
                LifeCycle = a.LifeCycle
            };
            this.HistoryOfFunctions.Add(h);        }
    }
}
