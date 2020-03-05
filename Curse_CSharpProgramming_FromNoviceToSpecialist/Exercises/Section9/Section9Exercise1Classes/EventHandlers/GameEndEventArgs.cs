using System;
using System.Collections.Generic;
using System.Text;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.EventHandlers
{
    internal class GameEndEventArgs : EventArgs
    {
        public IPlayer Winner { get; set; }
    }
}
