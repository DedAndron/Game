using Game.Entities;

namespace Game
{
    internal class Program
    {
        private static readonly DateTime StartTime = DateTime.UtcNow;

        static async Task Main(string[] args)
        {
            var bob = new Hero("Bob", health: 100, power: 90);
            var alice = new Hero("Alice", health: 100, power: 130);

            var dragonsCave = new Quest("Dragon's Cave", difficultyLevel: 120, bonus: 220, durationHours: 5)
            {
                Duration = TimeSpan.FromMilliseconds(4500)
            };

            var magesTower = new Quest("Mage's Tower", difficultyLevel: 80, bonus: 150, durationHours: 2)
            {
                Duration = TimeSpan.FromMilliseconds(1243)
            };

            var questTasks = new List<Task<string>>
            {
                RunQuestWithTimeoutAsync(bob, dragonsCave, TimeSpan.FromSeconds(3)),
                RunQuestWithTimeoutAsync(alice, magesTower, TimeSpan.FromSeconds(3))
            };

            var allQuests = Task.WhenAll(questTasks);

            var pending = new List<Task<string>>(questTasks);
            while (pending.Count > 0)
            {
                var completedTask = await Task.WhenAny(pending);
                pending.Remove(completedTask);

                var result = await completedTask;
                PrintWithTimestamp(result);
            }

            await allQuests;
        }

        private static async Task<string> RunQuestWithTimeoutAsync(Hero hero, Quest quest, TimeSpan timeout)
        {
            PrintWithTimestamp($"{hero.Name} went to the \"{quest.Title}\"");

            using var cts = new CancellationTokenSource(timeout);
            try
            {
                await Task.Delay(quest.Duration, cts.Token);
                hero.Gold += quest.Bonus;

                return $"{hero.Name} completed the \"{quest.Title}\" - VICTORY! (+{quest.Bonus} gold)";
            }
            catch (OperationCanceledException) when (cts.IsCancellationRequested)
            {
                return $"{hero.Name} retreated from the \"{quest.Title}\" (timeout)";
            }
        }

        private static void PrintWithTimestamp(string message)
        {
            var elapsed = DateTime.UtcNow - StartTime;
            Console.WriteLine($"[{elapsed:mm\\:ss\\.fff}] {message}");
        }
    }
}