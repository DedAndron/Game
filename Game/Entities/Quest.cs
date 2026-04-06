using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    public class Quest
    {
        public string Title { get; set; }
        public int DifficultyLevel { get; set; }
        public int Bonus { get; set; }
        public TimeSpan Duration { get; set; }
        public Quest(string title, int difficultyLevel, int bonus, int durationHours)
        {
            Title = title;
            DifficultyLevel = difficultyLevel;
            Bonus = bonus;
            Duration = TimeSpan.FromSeconds(durationHours);
        }
    }
}
