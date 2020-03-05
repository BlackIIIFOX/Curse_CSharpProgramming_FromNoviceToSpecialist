using System;
using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section3
{
    internal class Section3Exercise1 : IExercise
    {
        public Task DoExercise()
        {
            Console.WriteLine("Введите первое число:");
            var number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            var number2 = int.Parse(Console.ReadLine());

            var max = number1 > number2 ? number1 : number2;
            Console.WriteLine($"Максимальное число {max}");
            return Task.CompletedTask;
        }
    }
}
