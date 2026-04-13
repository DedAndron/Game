using System;
using System.Collections.Generic;
using System.Text;

namespace SystemPrograming
{
    public class Client
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Client(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
