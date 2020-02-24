using System;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                ExerciseFactory.ExerciseCreate("Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise4").DoExercise();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}