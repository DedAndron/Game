using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    public class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Power { get; set; }
        public decimal Gold { get; set; } = 0;
        public Hero(string name, int health, int power)
        {
            Name = name;
            Health = health;
            Power = power;
        }

    }
}
