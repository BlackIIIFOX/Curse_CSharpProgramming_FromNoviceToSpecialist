using System;
using System.Threading.Tasks;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8
{
    internal class Section8Exercise2 : IExercise
    {
        public Task DoExercise()
        {
            var game = new GameGuessTheNumber(new Player("Paul"));
            game.Play();
            return Task.CompletedTask;
        }
    }
}
