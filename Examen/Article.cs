using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Examen
{
    public class Article
    {   
        public int? id { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string? icon { get; set; }
        public string author { get; set; } = string.Empty;
        public DateTime date { get; set; }
    }
}
