using System;
using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section3
{
    internal class Section3Exercise5 : IExercise
    {
        public Task DoExercise()
        {
            int countTry = 0;
            while (true)
            {
                if (countTry == 3)
                {
                    Console.WriteLine("The number of available tries have been exceeded.");
                }

                Console.WriteLine("Введите логин:");
                var login = Console.ReadLine();

                Console.WriteLine("Введите пароль:");
                var password = Console.ReadLine();

                if (login.Equals("johnsilver") && password.Equals("qwerty"))
                {
                    Console.WriteLine("Enter the System.");
                    break;
                }
                else
                {
                    Console.WriteLine("Некорретный логин или пароль.");
                }

                countTry++;
            }
            return Task.CompletedTask;
        }
    }
}
