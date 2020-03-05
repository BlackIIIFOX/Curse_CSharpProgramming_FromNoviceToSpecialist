using System;
using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section3
{
    internal class Section3Exercise4 : IExercise
    {
        public Task DoExercise()
        {
            Console.WriteLine("Введите число, факториал которого необходимо вычислить:");

            int n;
            if (!Int32.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Это не число.");
                return Task.CompletedTask;
            }

            if (n < 0)
            {
                Console.WriteLine("Число должно быть положительным.");
                return Task.CompletedTask;
            }

            Console.WriteLine($"Факториал {n} = {GetFactorial(n)}");
            return Task.CompletedTask;
        }

        private long GetFactorial(int n)
        {
            long factorial = 1;

            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
