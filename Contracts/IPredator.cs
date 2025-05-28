using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prey_Predator.Contracts
{
    internal interface IPredator : IAnimal
    {
        public bool CanEat(IAnimal prey);
        public void Hunt(IList<IAnimal> allAnimals);
    }
}
