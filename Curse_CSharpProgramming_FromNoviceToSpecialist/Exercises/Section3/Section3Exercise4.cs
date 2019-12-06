using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section3
{
    internal class Section3Exercise4 : IExercise
    {
        public void DoExercise()
        {
            Console.WriteLine("Введите число, факториал которого необходимо вычислить:");

            int n;
            if (!Int32.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Это не число.");
                return;
            }

            if (n < 0)
            {
                Console.WriteLine("Число должно быть положительным.");
                return;
            }

            Console.WriteLine($"Факториал {n} = {GetFactorial(n)}");
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
