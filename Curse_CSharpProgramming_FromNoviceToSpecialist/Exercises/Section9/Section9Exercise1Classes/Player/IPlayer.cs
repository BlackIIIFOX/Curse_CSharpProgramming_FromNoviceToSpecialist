using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player
{
    internal interface IPlayer
    {
        string Login { get; }

        /// <summary>
        /// Make player turn.
        /// </summary>
        /// <returns>Position turn.</returns>
        Task<int> MakeTurn();
    }
}
