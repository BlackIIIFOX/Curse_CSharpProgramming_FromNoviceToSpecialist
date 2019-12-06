using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises
{
    internal class ExerciseFactory
    {
        public static IExercise ExerciseCreate(string exerciseClassName)
        {
            Console.WriteLine(exerciseClassName);
            var t = Type.GetType(exerciseClassName);

            if (t == null)
            {
                throw new ArgumentException($"Exercise <{exerciseClassName}> not found.");
            }

            return (IExercise) Activator.CreateInstance(t);
        }
    }
}