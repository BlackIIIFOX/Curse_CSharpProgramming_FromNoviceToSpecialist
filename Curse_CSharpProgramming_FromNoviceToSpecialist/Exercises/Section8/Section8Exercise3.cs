using System;
using System.Threading.Tasks;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8
{
    internal class Section8Exercise3 : IExercise
    {
        public Task DoExercise()
        {
            var game = new TicTacToeGame(new Player("Paul"));
            game.StartGame();
            return Task.CompletedTask;
        }
    }
}
