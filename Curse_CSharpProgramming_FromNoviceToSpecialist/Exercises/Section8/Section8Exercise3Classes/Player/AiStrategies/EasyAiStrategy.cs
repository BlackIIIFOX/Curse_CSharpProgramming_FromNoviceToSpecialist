using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player.AiStrategies
{
    internal class EasyAiStrategy : BaseAiStrategy
    {
        public EasyAiStrategy(GameGrid gameGrid) : base(gameGrid)
        {
        }

        public override int MakeTurn()
        {
            while (true)
            {
                var randomIndex = new Random().Next(1, 10);
                var owner = _gameGrid.GetOwnerCell(randomIndex - 1);
                if (_gameGrid.CountFreeCells == 0 || owner == null)
                {
                    return randomIndex;
                }
            }
        }
    }
}