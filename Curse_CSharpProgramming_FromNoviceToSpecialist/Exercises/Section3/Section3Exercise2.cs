using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section3
{
    internal class Section3Exercise2 : IExercise
    {
        public void DoExercise()
        {
            Console.WriteLine("Кол-во чисел Фибоначчи:");
            var n = Int32.Parse(Console.ReadLine());
            n++;

            var array = new int[n];

            array[0] = 0;

            if (n > 1)
            {
                array[1] = 1;
            }

            for (int i = 2; i < n; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
        }
    }
}
