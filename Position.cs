using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prey_Predator
{
    internal class Position
    {
        private const int MaxValue = 15;
        private const int MinValue = 0;
        public int X { get; set; }
        public int Y { get; set; }

        public void MoveUp() 
        {
            if (X > MinValue)
            {
                X--;
            }
        }
        public void MoveDown()
        {
            if (X < MaxValue)
            {
                X++;
            }
        }
        public void MoveLeft()
        {
            if (Y > MinValue)
            {
                Y--;
            }
        }
        public void MoveRight()
        {
            if (Y < MaxValue)
            {
                Y++;
            }
        }
    }
}
