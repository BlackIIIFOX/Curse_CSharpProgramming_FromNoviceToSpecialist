using System;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8
{
    internal class Section8Exercise2 : IExercise
    {
        public void DoExercise()
        {
            var game = new GameGuessTheNumber(new Player("Paul"));
            game.Play();
        }
    }
}
