using System;
using System.Collections.Generic;
using System.Text;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player.AiStrategies
{
    internal class StrategiesFactory
    {
        public static IAiStrategy CreateStrategy(AiMode mode, GameGrid gameGrid)
        {
            return mode switch
            {
                AiMode.Easy => new EasyAiStrategy(gameGrid),
                AiMode.Medium => throw new NotImplementedException(),
                AiMode.Hard => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }
    }
}
