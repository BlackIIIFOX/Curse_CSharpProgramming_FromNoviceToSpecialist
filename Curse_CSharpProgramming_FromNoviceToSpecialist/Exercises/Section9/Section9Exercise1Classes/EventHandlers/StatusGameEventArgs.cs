using System;
using System.Collections.Generic;
using System.Text;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.EventHandlers
{
    internal class StatusGameEventArgs : EventArgs
    {
        public IPlayer TurnPlayer { get; set; }
        public int TotalSticks { get; set; }
        public int RemainingSticks { get; set; }
        public int PlayerTaken { get; set; }
    }
}
