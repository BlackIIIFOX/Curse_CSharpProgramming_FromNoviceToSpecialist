using System;
using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section3
{
    internal class Section3Exercise3 : IExercise
    {
        private const int MaxNumbers = 10;

        public Task DoExercise()
        {
            var countNumbers = 0;
            var numbers = new int[MaxNumbers];
            var sum = 0;

            while (countNumbers < MaxNumbers)
            {
                Console.WriteLine("Введите число:");
                int newNumber;
                if (!int.TryParse(Console.ReadLine(), out newNumber))
                {
                    Console.WriteLine("Это не число.");
                    continue;
                }

                if (newNumber == 0)
                {
                    Console.WriteLine("Ввод чисел завершен.");
                    break;
                }

                if (newNumber % 3 != 0)
                {
                    Console.WriteLine("Число не кратно 3.");
                    continue;
                }

                if (newNumber < 0)
                {
                    Console.WriteLine("Число отрицательное.");
                    continue;
                }

                numbers[countNumbers] = newNumber;
                countNumbers++;

                sum += newNumber;
            }

            if (countNumbers == 0)
            {
                Console.WriteLine("Вы должны были ввести хотя бы одно число для нахождения среднего");
                return Task.CompletedTask;
            }

            Console.WriteLine($"Среднее: {sum / countNumbers}");
            return Task.CompletedTask;
        }
    }
}
