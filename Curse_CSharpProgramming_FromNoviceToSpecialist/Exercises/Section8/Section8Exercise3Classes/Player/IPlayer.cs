﻿using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player
{
    internal interface IPlayer
    {
        string Login { get; }

        /// <summary>
        /// Make player turn.
        /// </summary>
        /// <returns>Position turn.</returns>
        int MakeTurn();
    }
}
