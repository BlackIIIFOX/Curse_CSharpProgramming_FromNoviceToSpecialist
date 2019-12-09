using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models
{
    internal abstract class BasePlayer
    {
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
            else
            {
                if (number < GuessedNumber)
                {
                    return GuessingStates.NumberIsMore;
                }
                else
                {
                    return GuessingStates.NumberIsEqual;
                }
            }
        }

        public abstract void PickNumber();

        protected abstract int EnterNumber();
    }
}
