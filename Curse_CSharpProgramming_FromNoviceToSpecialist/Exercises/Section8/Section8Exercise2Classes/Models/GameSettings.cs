using System;
using System.Collections.Generic;
using System.Text;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models
{
    internal class GameSettings
    {
        public int MaxAttempts { get; set; } = 5;
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; } = 10;
    }
}
