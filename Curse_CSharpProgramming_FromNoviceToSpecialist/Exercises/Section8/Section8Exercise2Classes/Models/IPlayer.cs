using System;
using System.Collections.Generic;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models
{
    internal abstract class BasePlayer
    {
        protected readonly List<AttemptModel> _attempts = new List<AttemptModel>();

        public int GuessedNumber { get; protected set; }

        public string PlayerName { get; }

        public int AttemptsUsed { get; protected set; }

        internal BasePlayer(string name)
        {
            PlayerName = name ?? throw new ArgumentException("Name does not entered.");
        }

        public int TryGuessNumber()
        {
            AttemptsUsed++;
            return EnterNumber();
        }

        public GuessingStates SuggestNumber(int number)
        {
            if (number > GuessedNumber)
            {
                return GuessingStates.NumberIsLess;
            }

            if (number < GuessedNumber)
            {
                return GuessingStates.NumberIsMore;
            }

            return GuessingStates.NumberIsEqual;
        }

        public void AppendResultAttempt(AttemptModel attempt)
        {
            _attempts.Add(attempt);
        }

        public abstract void PickNumber();

        protected abstract int EnterNumber();
    }
}
