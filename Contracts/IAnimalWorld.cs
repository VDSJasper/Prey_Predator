using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prey_Predator.Contracts
{
    internal interface IAnimalWorld
    {
        public IList<IAnimal> AllAnimals { get; }

        public int CurrentRoundNumber { get; }

        public void AddAnimal(IAnimal animal);

        public void ProcessRound();
    }
}
