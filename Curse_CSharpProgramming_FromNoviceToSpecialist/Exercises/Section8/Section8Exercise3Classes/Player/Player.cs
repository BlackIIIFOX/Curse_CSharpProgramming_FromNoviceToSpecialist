using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player
{
    internal class Player : IPlayer
    {
        public Player(string login)
        {
            Login = login;
        }

        public string Login { get; }

        public int MakeTurn()
        {
            while (true)
            {
                var turn = Console.ReadLine();

                if (!int.TryParse(turn, out var indexMarkupCell) || indexMarkupCell < 1 || indexMarkupCell > 9)
                {
                    Console.WriteLine($"\"{turn}\" is not a cell number");
                }
                else
                {
                    return indexMarkupCell;
                }

            }
        }
    }
}