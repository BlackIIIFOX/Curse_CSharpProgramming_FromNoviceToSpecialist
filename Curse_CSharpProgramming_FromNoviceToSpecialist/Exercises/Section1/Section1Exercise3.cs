using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section1
{
    internal class Section1Exercise3 : IExercise
    {
        private string _lastName, _firstName;
        private int _age;
        private double _bodyMassIndex, _weight, _height;

        private void RequestValue<T>(string nameValue, ref T @value)
        {
            Console.Write($"{nameValue} = ");
            if (@value is int)
            {
                @value = (T)(object)Convert.ChangeType(Int32.Parse(Console.ReadLine()), typeof(T));
            }
            else
            {
                if (@value is double)
                {
                    @value = (T)(object)Convert.ChangeType(double.Parse(Console.ReadLine()), typeof(T));
                }
                else
                {
                    @value = (T)(object)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
            }

            Console.WriteLine(string.Empty);
        }

        private void CalculateBodyMassIndex()
        {
            _bodyMassIndex = _weight / (Math.Pow(_height / 100.0, 2));
        }

        public void DoExercise()
        {
            RequestValue<string>(nameof(_lastName), ref _lastName);
            RequestValue<string>(nameof(_firstName), ref _firstName);

            RequestValue<int>(nameof(_age), ref _age);
            RequestValue<double>(nameof(_weight), ref _weight);
            RequestValue<double>(nameof(_height), ref _height);

            CalculateBodyMassIndex();

            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $@"Your profile:{Environment.NewLine}" +
                   $"Full Name: {_lastName},{_firstName}{Environment.NewLine}" +
                   $"Age: {_age}{Environment.NewLine}" +
                   $"Weight: {_weight}{Environment.NewLine}" +
                   $"Height: {_height}{Environment.NewLine}" +
                   $"Body Mass Index: {_bodyMassIndex}{Environment.NewLine}";
        }
    }
}
