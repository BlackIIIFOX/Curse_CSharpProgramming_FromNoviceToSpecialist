using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player.AiStrategies
{
    internal class StrategiesFactory
    {
        public static IAiStrategy CreateStrategy(AiMode mode, SticksGame game)
        {
            return mode switch
            {
                AiMode.Easy => new EasyAiStrategy(game),
                AiMode.Medium => throw new NotImplementedException(),
                AiMode.Hard => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }
    }
}
