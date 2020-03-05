using System;
using System.Threading.Tasks;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.EventHandlers;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9
{
    internal class Section9Exercise1 : IExercise
    {
        public async Task DoExercise()
        {
            IPlayer player = new Player("Paul", InputCountSticksToTake);
            var sticksGame = new SticksGame(player);
            sticksGame.ErrorTakenSticksEventHandler += ErrorTakenSticksEventHandler;
            sticksGame.PlayerTakenSticksEventHandler += PlayerTakenSticksEventHandler;
            sticksGame.GameIsEndEventHandler += GameIsEndEventHandler;

            Console.WriteLine($"Game is start. Total sticks: {sticksGame.TotalSticksNumber}. First turn: {sticksGame.TurnPlayer.Login}.");
            await sticksGame.StartGameAsync();
        }

        private void GameIsEndEventHandler(object sender, GameEndEventArgs e)
        {
            Console.WriteLine($"Game is end! {e.Winner.Login} win!");
        }

        private void PlayerTakenSticksEventHandler(object sender, StatusGameEventArgs e)
        {
            Console.WriteLine($"{e.TurnPlayer.Login} taken {e.PlayerTaken} sticks. {e.RemainingSticks} of {e.TotalSticks}");
        }

        private void ErrorTakenSticksEventHandler(object sender, StatusGameEventArgs e)
        {
            Console.WriteLine($"{e.TurnPlayer.Login} can't take {e.PlayerTaken} sticks. {e.RemainingSticks} of {e.TotalSticks}");
        }

        Task<int> InputCountSticksToTake()
        {
            Console.WriteLine("Take a stick.");
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("You entered not a number.");
            }

            return Task.FromResult(value);
        }
    }
}
