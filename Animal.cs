﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Prey_Predator.Contracts;

namespace Prey_Predator
{
    internal abstract class Animal : IAnimal
    {
        private static Random _random = new Random();
        protected int _age = 0;
        private int _maxAge;
        private SolidColorBrush _color;
        private Ellipse _animal;
        private int _size = 5;
        private int _distance = 10;
        private Canvas? Canvas { get; set; }
        protected Animal(int maxAge, SolidColorBrush color)
        {
            _animal = new Ellipse();
            _maxAge = maxAge;
            _color = color;
            IsDead = false;
            Position _randomPosition = new Position();
            _randomPosition.X = _random.Next(_randomPosition.Range[0], _randomPosition.Range[1] + 1);
            _randomPosition.Y = _random.Next(_randomPosition.Range[0], _randomPosition.Range[1] + 1);
            Position = _randomPosition;
        }
        protected Animal(int maxAge, SolidColorBrush color, Position position) : this(maxAge, color)
        {
            Position = position;
        }

        public Position Position { get; private set; }
        public bool IsDead { get; set; }

        public void DisplayOn(Canvas canvas)
        {
            Canvas = canvas;
            _animal.Fill = _color;
            _animal.Margin = new Thickness(Position.X * _distance, Position.Y * _distance, 0, 0);
            _animal.Width = _size;
            _animal.Height = _size;

            Canvas.Children.Add(_animal);
        }

        public void StopDisplaying()
        {
            Canvas?.Children.Remove(_animal);
        }

        public void UpdateDisplay()
        {
            _animal.Margin = new Thickness(Position.X * _distance, Position.Y * _distance, 0, 0);
        }
        public void Move()
        {
            _age++;
            if (_age > _maxAge)
            {
                IsDead = true;
            }

            int moveDirection = _random.Next(0, 4);
            switch (moveDirection)
            {
                case 0:
                    Position.MoveDown();
                    break;
                case 1:
                    Position.MoveUp();
                    break;
                case 2:
                    Position.MoveLeft();
                    break;
                case 3:
                    Position.MoveRight();
                    break;
            }
            UpdateDisplay();
        }

        public abstract IAnimal TryBreed();
    }
}
