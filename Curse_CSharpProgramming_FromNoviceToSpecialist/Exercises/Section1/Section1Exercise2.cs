using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section1
{
    internal class Section1Exercise2 : IExercise
    {
        // Стороны треугольника
        private double a, b, c;

        private void RequestSides()
        {
            RequestSide(nameof(a), ref a);
            RequestSide(nameof(b), ref b);
            RequestSide(nameof(c), ref c);
        }

        private void RequestSide(string nameSide, ref double valueSet)
        {
            Console.Write($"Side {nameSide} = ");
            valueSet = double.Parse(Console.ReadLine());
            Console.WriteLine(string.Empty);
        }

        private double CalculateHeron()
        {
            double p = a + b + c;
            return Math.Sqrt(p / 2 * (p / 2 - a) * (p / 2 - b) * (p / 2 - c));
        }

        public void DoExercise()
        {
            RequestSides();
            Console.WriteLine($"S = {CalculateHeron()}");
        }
    }
}
