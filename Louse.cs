using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Prey_Predator.Contracts;

namespace Prey_Predator
{
    internal class Louse : Animal
    {
        private const int MaxAge = 6;
        private const int HatchTime = 2;

        public Louse() : base(MaxAge, new SolidColorBrush(Colors.GreenYellow))
        { }

        private Louse(Position position) : base(MaxAge, new SolidColorBrush(Colors.GreenYellow), position)
        { }

        public override IAnimal TryBreed() 
        {
            if (_age % HatchTime == 0)
            {
                Louse baby = new Louse(this.Position);
                return baby;
            }
            else 
            {
                return null;
            }
        }
    }
}
