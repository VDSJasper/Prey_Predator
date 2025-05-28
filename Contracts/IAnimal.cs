using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prey_Predator.Contracts
{
    internal interface IAnimal : IDisplayable
    {
        public Position Position { get; }
        public bool IsDead { get; set; }

        public void Move();

        public IAnimal TryBreed();
    }
}
