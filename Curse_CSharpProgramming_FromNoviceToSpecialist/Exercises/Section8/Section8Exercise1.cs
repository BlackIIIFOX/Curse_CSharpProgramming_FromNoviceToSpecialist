using System;
using System.Collections.Generic;
using System.Text;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8
{
    internal class Section8Exercise1 : IExercise
    {
        public void DoExercise()
        {
            var cmlx1 = new Complex(5, 6);
            var cmlx2 = new Complex(30.1, 1.123);
            Console.WriteLine(cmlx1.Plus(cmlx2));
            Console.WriteLine(cmlx1.Minus(cmlx2));
        }

        #region Classes

        public class Complex
        {
            public Complex(double realPart, double imaginartPart)
            {
                RealPart = realPart;
                ImaginaryPart = imaginartPart;
            }

            public double RealPart { get; }

            public double ImaginaryPart { get; }

            public Complex Plus(Complex @value)
            {
                if (@value == null)
                {
                    throw new ArgumentNullException("The passed complex value is null.");
                }

                return new Complex(this.RealPart + @value.RealPart, this.ImaginaryPart + @value.ImaginaryPart);
            }

            public Complex Minus(Complex @value)
            {
                if (@value == null)
                {
                    throw new ArgumentNullException("The passed complex value is null.");
                }

                return new Complex(this.RealPart - @value.RealPart, this.ImaginaryPart - @value.ImaginaryPart);
            }

            public override string ToString()
            {
                return $"RealPart = {RealPart}, ImaginaryPart = {ImaginaryPart}";
            }
        }

        #endregion
    }
}
