using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player.AiStrategies
{
    internal class EasyAiStrategy : IAiStrategy
    {
        private readonly SticksGame _game;
        private readonly Random _random;

        public EasyAiStrategy(SticksGame game)
        {
            _random = new Random(DateTime.Now.Millisecond);
            _game = game;
        }

        public int MakeTurn()
        {
            var canTakeMax = _game.RemainingSticksNumber > 3 ? 3 : _game.RemainingSticksNumber;
            return _random.Next(1, canTakeMax + 1);
        }
    }
}