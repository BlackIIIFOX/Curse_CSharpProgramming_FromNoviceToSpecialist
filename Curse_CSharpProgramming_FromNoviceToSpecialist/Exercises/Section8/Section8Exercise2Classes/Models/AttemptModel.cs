using System;
using System.Collections.Generic;
using System.Text;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models
{
    internal class AttemptModel
    {
        public int NumAttempt { get; }

        public int Number { get; }

        public GuessingStates Result { get; }

        public AttemptModel(int numAttempt, int number, GuessingStates result)
        {
            NumAttempt = numAttempt;
            Number = number;
            Result = result;
        }
    }
}
