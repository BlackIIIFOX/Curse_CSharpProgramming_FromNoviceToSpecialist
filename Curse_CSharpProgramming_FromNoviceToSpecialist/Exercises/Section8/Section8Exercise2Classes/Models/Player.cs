using System;
using System.Collections.Generic;
using System.Text;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models
{
    internal class Player : BasePlayer
    {
        public Player(string name) : base(name)
        {
        }

        public override void PickNumber()
        {
            Console.WriteLine($"{PlayerName} Pick a number:");
            GuessedNumber = EnterNumber();
            Console.WriteLine($"{PlayerName} picked a number");
        }

        protected override int EnterNumber()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine($"{PlayerName} entered not a number.");
            }

            return number;
        }
    }
}
