using System;
using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player
{
    internal class Player : IPlayer
    {
        private readonly Func<Task<int>> _inputCountSticksToTake;

        public Player(string login, Func<Task<int>> inputCountSticksToTake)
        {
            _inputCountSticksToTake = inputCountSticksToTake;
            Login = login;
        }

        public string Login { get; }

        public Task<int> MakeTurn()
        {
            return _inputCountSticksToTake.Invoke();
        }
    }
}