using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamagotchiBL.Models
{
    public partial class Function
    {
        public override string ToString()
        {
            if (this.FunctionOfNavigation == null)
                return this.FunctionName;
            return $"{this.FunctionName} - {this.FunctionOfNavigation}";
        }

        public List<Function> GetFunctions() => this.InverseFunctionOfNavigation
            .ToList();

        public bool Exist(int id) => this.InverseFunctionOfNavigation
            .Any(f => f.FunctionId == id);

        public Function GetFunction(int id) => this.InverseFunctionOfNavigation
            .FirstOrDefault(f => f.FunctionId == id);
        public bool IsCategory() => this.InverseFunctionOfNavigation.Count != 0;
    }
}
