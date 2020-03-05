using System;
using System.Threading.Tasks;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist
{
    public class Program
    {
        public static async Task Main()
        {
            try
            {
                await ExerciseFactory.ExerciseCreate("Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise2").DoExercise();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}