using System.Collections.Generic;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise4Classes.Enums;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise4Classes.Interfaces
{
    internal interface IHangmanGame
    {
        GameStatuses GameStatus { get; }
        int MaximumTotalAttempts { get; }
        int AttemptsUsed { get; }
        int WordLength { get; }
        IReadOnlyDictionary<int, char> GuessedLetter { get; }
        IReadOnlyCollection<char> TriedLetters { get; }

        /// <summary>
        /// Try to guess the letter.
        /// </summary>
        /// <param name="letter">Letter.</param>
        /// <returns>The letter was indicated in an attempt.</returns>
        bool TryToGuessLetter(char letter);

        void ResetGame();

        /// <summary>
        /// Return word if game end or throw.
        /// </summary>
        /// <returns></returns>
        string GetWordIfGameEnd();
    }
}
