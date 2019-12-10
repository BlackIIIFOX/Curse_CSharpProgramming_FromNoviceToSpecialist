using System;
using System.Collections.Generic;
using System.Text;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models
{
    internal class GameSettings : ICloneable
    {
        public int MaxAttempts { get; set; } = 5;
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; } = 10;
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
