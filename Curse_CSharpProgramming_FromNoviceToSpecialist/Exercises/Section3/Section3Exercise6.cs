using System;
using System.Collections.Generic;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section3
{
    internal class Section3Exercise6 : IExercise
    {
        private static readonly Dictionary<char, int> RomanNumbers = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public void DoExercise()
        {
            // 1393
            //string romanNumber = "MXCDIII";
            string romanNumber = Console.ReadLine();

            try
            {
                Console.WriteLine(RomanToArabicNumberConverter(romanNumber));
            }
            catch (Exception)
            {
                Console.WriteLine("Не может быть преобразовано в арабское число");
            }
        }

        private int RomanToArabicNumberConverter(string romanNumber)
        {
            int lastNumber = RomanNumbers[romanNumber[romanNumber.Length - 1]];
            int arabicNumber = lastNumber;

            for (int i = romanNumber.Length - 2; i >= 0; i--)
            {
                int newValue = RomanNumbers[romanNumber[i]];

                if (newValue >= lastNumber)
                {
                    arabicNumber += newValue;
                }
                else
                {
                    arabicNumber -= newValue;
                }

                lastNumber = newValue;
            }

            return arabicNumber;
        }
    }
}
