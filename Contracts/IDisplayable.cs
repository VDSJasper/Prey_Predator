﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Prey_Predator.Contracts
{
    internal interface IDisplayable
    {
        public void DisplayOn(Canvas canvas);

        public void StopDisplaying();

        public void UpdateDisplay();
    }
}
