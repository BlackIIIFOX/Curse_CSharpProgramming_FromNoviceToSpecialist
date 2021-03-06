﻿using System;
using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section1
{
    internal class Section1Exercise1 : IExercise
    {
        public Task DoExercise()
        {
            Console.Write("UserName = ");
            var userName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine($"Hello, {userName}");

            Console.Write("X = ");
            var x = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Enter X."));
            Console.WriteLine("");

            Console.Write("Y = ");
            var y = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Enter Y"));
            Console.WriteLine("");

            var tmp = x;
            x = y;
            y = tmp;

            Console.WriteLine($"X: {x}, Y: {y}");

            Console.Write("Number = ");
            Console.WriteLine($"Numbers of digits: {Console.ReadLine().Length}");
            return Task.CompletedTask;
        }
    }
}
