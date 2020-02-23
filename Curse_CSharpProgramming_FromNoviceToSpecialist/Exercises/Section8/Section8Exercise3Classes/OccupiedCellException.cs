using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes
{
    internal class OccupiedCellException : Exception
    {
        public OccupiedCellException(string s) : base(s)
        {
        }
    }
}