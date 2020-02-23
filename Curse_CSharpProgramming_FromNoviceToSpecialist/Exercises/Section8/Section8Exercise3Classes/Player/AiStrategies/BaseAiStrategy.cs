namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player.AiStrategies
{
    internal abstract class BaseAiStrategy : IAiStrategy
    {
        protected GameGrid _gameGrid { get; }

        protected BaseAiStrategy(GameGrid gameGrid)
        {
            _gameGrid = gameGrid;
        }

        public abstract int MakeTurn();
    }
}