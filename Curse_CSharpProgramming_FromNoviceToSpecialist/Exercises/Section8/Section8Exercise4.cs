using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise4Classes;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise4Classes.Enums;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise4Classes.Interfaces;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8
{
    internal class Section8Exercise4 : IExercise
    {
        public Task DoExercise()
        {
            IHangmanGame hangmanGame = new HangmanGame();

            hangmanGame.ResetGame();
            Console.WriteLine($"A {hangmanGame.WordLength}-letter word is made up.");

            while (hangmanGame.GameStatus == GameStatuses.InProgress)
            {
                Console.Write($"{Environment.NewLine}Put a letter: ");
                var letter = Console.ReadKey().KeyChar;
                Console.Write(Environment.NewLine);

                if (hangmanGame.TryToGuessLetter(letter))
                {
                    Console.WriteLine("The letter is open.");
                    Console.WriteLine(GetPrintableWord(hangmanGame));
                }
                else
                {
                    Console.WriteLine($"Wrong Guesses: {hangmanGame.AttemptsUsed} of {hangmanGame.MaximumTotalAttempts}");
                    Console.WriteLine($"Tried letters: {GetPrintableTriedLetters(hangmanGame)}");
                }
            }

            Console.WriteLine(hangmanGame.GameStatus == GameStatuses.IsWin
                ? "You win."
                : $"You lose. The word is \"{hangmanGame.GetWordIfGameEnd()}\"");

            Console.ReadLine();
            return Task.CompletedTask;
        }

        private string GetPrintableTriedLetters(IHangmanGame hangmanGame)
        {
            return string.Join("", hangmanGame.TriedLetters.Distinct().OrderBy(x => x));
        }

        private string GetPrintableWord(IHangmanGame hangmanGame)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < hangmanGame.WordLength; i++)
            {
                sb.Append(hangmanGame.GuessedLetter.TryGetValue(i, out var letter) ? letter.ToString() : "-");
            }

            return sb.ToString();
        }
    }
}
