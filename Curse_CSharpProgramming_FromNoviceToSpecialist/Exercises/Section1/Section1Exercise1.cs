using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section1
{
    internal class Section1Exercise1 : IExercise
    {
        public void DoExercise()
        {
            Console.Write("UserName = ");
            string userName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine($"Hello, {userName}");

            Console.Write("X = ");
            var x = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.Write("Y = ");
            var y = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            var tmp = x;
            x = y;
            y = tmp;

            Console.WriteLine($"X: {x}, Y: {y}");

            Console.Write("Number = ");
            Console.WriteLine($"Numbers of digits: {Console.ReadLine().Length}");
        }
    }
}
