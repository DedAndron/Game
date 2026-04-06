using Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Services
{
    public class PlayGame
    {
        public async Task RunQuestAsync(Hero hero, Quest quest, CancellationToken ct)
        {
            Console.WriteLine($"Starting quest: {quest.Title}");
            Console.WriteLine($"Hero: {hero.Name}, Health: {hero.Health}, Power: {hero.Power}");
            Console.WriteLine($"Quest Difficulty: {quest.DifficultyLevel}, Bonus: {quest.Bonus}, Duration: {quest.Duration}");
            await Task.Delay(quest.Duration, ct);
            if (hero.Power >= quest.DifficultyLevel)
            {
                Console.WriteLine($"Quest completed successfully! Bonus earned: {quest.Bonus}");
                hero.Gold += quest.Bonus;
                hero.Power += quest.DifficultyLevel / 2;
            }
            else
            {
                Console.WriteLine("Quest failed. Hero takes damage.");
                hero.Health -= 10;
            }
            Console.WriteLine($"Hero's current status - Health: {hero.Health}, Power: {hero.Power}");
        }
    }
}
