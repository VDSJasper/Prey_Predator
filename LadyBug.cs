using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Prey_Predator.Contracts;

namespace Prey_Predator
{
    internal class LadyBug : Animal, IPredator
    {
        private const int MaxAge = 16;
        private const int HatchTime = 4;
        private int _roundsWithoutFood;
        public LadyBug() : base(MaxAge, new SolidColorBrush(Colors.Red)) 
        {
            
        }
        public LadyBug(Position position) : base(MaxAge, new SolidColorBrush(Colors.Red), position)
        {

        }
        public override IAnimal TryBreed()
        {
            if (_age % HatchTime == 0)
            {
                LadyBug baby = new LadyBug(this.Position);
                return baby;
            }
            else
            {
                return null;
            }
        }
        public bool CanEat(IAnimal prey)
        { 
            prey.IsDead = true;
            return true;
        }
        public void Hunt(IList<IAnimal> allAnimals)
        { 
            int predatorX = this.Position.X;
            int predatorY = this.Position.Y;
            int preyX;
            int preyY;
            bool hasEaten = false;

            foreach (Animal prey in allAnimals)
            {
                if (prey is Louse)
                {
                    preyX = prey.Position.X;
                    preyY = prey.Position.Y;
                    double distance = Math.Sqrt(Math.Pow(predatorX - preyX, 2) + Math.Pow(predatorY - preyY, 2));
                    if (distance < 3)
                    {
                        hasEaten = CanEat(prey);
                    }
                }
            }

            if (!hasEaten)
            {
                _roundsWithoutFood++;
                if (_roundsWithoutFood >= 3)
                { 
                    this.IsDead = true;
                }
            }
            else 
            {
                _roundsWithoutFood = 0;
            }
        }
    }
}
