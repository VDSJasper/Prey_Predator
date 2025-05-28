using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prey_Predator.Contracts;

namespace Prey_Predator
{
    internal class AnimalWorld : IAnimalWorld
    {
        private Canvas _canvas;
        private IList<IAnimal> _allAnimals;

        public IList<IAnimal> AllAnimals { get; }
        public int CurrentRoundNumber { get; private set; }

        public AnimalWorld(Canvas canvas) 
        {
            _canvas = canvas;
            _allAnimals = new List<IAnimal>();
            AllAnimals = _allAnimals;
        }

        public void AddAnimal(IAnimal animal) 
        {
            AllAnimals.Add(animal);
            _allAnimals = AllAnimals;
            animal.DisplayOn(_canvas);
        }
        public void ProcessRound()
        {
            List<IAnimal> _babyAnimals = new List<IAnimal>();
            List<IAnimal> _deadAnimals = new List<IAnimal>();
            CurrentRoundNumber++;

            foreach (Animal animal in AllAnimals)
            {
                animal.Move();

                if (animal is LadyBug)
                { 
                    LadyBug ladyBug = (LadyBug) animal;
                    ladyBug.Hunt(_allAnimals);
                }

                if (animal.IsDead)
                {
                    _deadAnimals.Add(animal);
                }

                if (animal.TryBreed() != null)
                {
                    Animal baby = (Animal)animal.TryBreed();
                    _babyAnimals.Add(baby);
                }
            }

            foreach (Animal dead in _deadAnimals)
            {
                dead.StopDisplaying();
                AllAnimals.Remove(dead);
                _allAnimals = AllAnimals;
            }

            foreach (Animal baby in _babyAnimals)
            {
                AddAnimal(baby);
            }
        }
    }
}
