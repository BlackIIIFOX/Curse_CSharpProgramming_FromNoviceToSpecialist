using System;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player.AiStrategies;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player
{
    internal class AiPlayer : IPlayer
    {
        private readonly GameGrid _gameGrid;
        private IAiStrategy _strategy;

        public AiPlayer(AiMode aiMode, GameGrid gameGrid)
        {
            _gameGrid = gameGrid;
            _strategy = StrategiesFactory.CreateStrategy(aiMode, gameGrid);
            Login = $"{aiMode}Robot";
        }

        public string Login { get; }

        public int MakeTurn()
        {
            return _strategy.MakeTurn();
        }
    }
}