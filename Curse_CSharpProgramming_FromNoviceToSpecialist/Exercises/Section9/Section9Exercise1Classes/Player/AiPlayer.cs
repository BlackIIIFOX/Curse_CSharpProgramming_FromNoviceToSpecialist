using System.Threading.Tasks;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player.AiStrategies;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player
{
    internal class AiPlayer : IPlayer
    {
        private readonly SticksGame _game;
        private readonly IAiStrategy _strategy;

        public AiPlayer(AiMode aiMode, SticksGame game)
        {
            _game = game;
            _strategy = StrategiesFactory.CreateStrategy(aiMode, _game);
            Login = $"{aiMode}Robot";
        }

        public string Login { get; }

        public Task<int> MakeTurn()
        {
            return Task.FromResult(_strategy.MakeTurn());
        }
    }
}