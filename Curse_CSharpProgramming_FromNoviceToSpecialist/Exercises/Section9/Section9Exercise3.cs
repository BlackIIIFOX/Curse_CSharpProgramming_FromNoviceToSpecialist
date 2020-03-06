using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise3Classes;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise3Classes.Enums;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9
{
    internal class Section9Exercise3 : IExercise
    {
        private const string PathToFileQuestions = @"Exercises\Section9\Section9Exercise3Classes\Resources\Questions.csv";

        public async Task DoExercise()
        {
            var game = new TrueOrFalseGame(new Player("Paul", Answer, NotificationPlayer), PathToFileQuestions);
            await game.StartGame();
            var gameResult = game.GameStatus == GameStatuses.IsWin ? "Win" : "Lose";
            
            Console.WriteLine();
            Console.WriteLine($"Game is {gameResult}. Used {game.CurrentAttempt} of {game.MaxAttempts} attempts.");
        }

        private static Task NotificationPlayer(bool resultAnswer, string explanation)
        {
            var text = resultAnswer ? "You are right" : "You are mistaken";
            Console.WriteLine($"{text}. {explanation}");
            return Task.CompletedTask;
        }

        private static Task<bool> Answer(string question)
        { 
            Console.WriteLine();
            Console.WriteLine(question);
            Console.WriteLine("Is true? [Y/N]");

            return Task.FromResult(Console.ReadLine() == "Y");
        }
    }
}
