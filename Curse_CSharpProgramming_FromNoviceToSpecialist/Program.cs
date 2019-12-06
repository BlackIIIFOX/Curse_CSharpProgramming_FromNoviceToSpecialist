using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        TaskFactory.TackCreate("Task8_2").DoTask();
    }
}

public interface Task
{
    void DoTask();
}

class TaskFactory
{
    public static Task TackCreate(string taskClassName)
    {
        Console.WriteLine(taskClassName);
        Type t = Type.GetType(taskClassName);
        return (Task)Activator.CreateInstance(t);
    }
}

public class Task8_2 : Task
{
    public void DoTask()
    {

    }
}

public class Task8_1 : Task
{
    public void DoTask()
    {
        Complex cmlx1 = new Complex(5, 6);
        Complex cmlx2 = new Complex(30.1, 1.123);
        Console.WriteLine(cmlx1.Plus(cmlx2));
        Console.WriteLine(cmlx1.Minus(cmlx2));
    }

    #region Classes
    public class Complex
    {
        private readonly double _realPart;
        private readonly double _imaginaryPart;

        public Complex(double realPart, double imaginartPart)
        {
            _realPart = realPart;
            _imaginaryPart = imaginartPart;
        }

        public double RealPart => _realPart;
        public double ImaginaryPart => _imaginaryPart;

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

public class Task3_6 : Task
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

    public void DoTask()
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

public class Task3_5 : Task
{
    public void DoTask()
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

    }
}

public class Task3_4 : Task
{
    public void DoTask()
    {
        Console.WriteLine("Введите число, факториал которого необходимо вычислить:");

        int n;
        if (!Int32.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Это не число.");
            return;
        }

        if (n < 0)
        {
            Console.WriteLine("Число должно быть положительным.");
            return;
        }

        Console.WriteLine($"Факториал {n} = {GetFactorial(n)}");
    }

    private long GetFactorial(int n)
    {
        long factorial = 1;

        for (int i = 2; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
}

public class Task3_3 : Task
{
    private static readonly int maxNumbers = 10;

    public void DoTask()
    {
        int countNumbers = 0;
        var numbers = new int[maxNumbers];
        int sum = 0;

        while (countNumbers < maxNumbers)
        {
            Console.WriteLine("Введите число:");
            int newNumber;
            if (!Int32.TryParse(Console.ReadLine(), out newNumber))
            {
                Console.WriteLine("Это не число.");
                continue;
            }

            if (newNumber == 0)
            {
                Console.WriteLine("Ввод чисел завершен.");
                break;
            }

            if (newNumber % 3 != 0)
            {
                Console.WriteLine("Число не кратно 3.");
                continue;
            }

            if (newNumber < 0)
            {
                Console.WriteLine("Число отрицательное.");
                continue;
            }

            numbers[countNumbers] = newNumber;
            countNumbers++;

            sum += newNumber;
        }

        if (countNumbers == 0)
        {
            Console.WriteLine("Вы должны были ввести хотя бы одно число для нахождения среднего");
            return;
        }

        Console.WriteLine($"Среднее: {sum / countNumbers}");
    }
}

public class Task3_2 : Task
{
    public void DoTask()
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

public class Task3_1 : Task
{
    public void DoTask()
    {
        Console.WriteLine("Введите первое число:");
        var number1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число:");
        var number2 = int.Parse(Console.ReadLine());

        var max = number1 > number2 ? number1 : number2;
        Console.WriteLine($"Максимальное число {max}");
    }
}

public class Task1_3 : Task
{
    private string lastName, firstName;
    private int age;
    private double bodyMassIndex, weight, height;

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
        bodyMassIndex = weight / (Math.Pow(height / 100.0, 2));
    }

    public void DoTask()
    {
        RequestValue<string>(nameof(lastName), ref lastName);
        RequestValue<string>(nameof(firstName), ref firstName);

        RequestValue<int>(nameof(age), ref age);
        RequestValue<double>(nameof(weight), ref weight);
        RequestValue<double>(nameof(height), ref height);

        CalculateBodyMassIndex();

        Console.WriteLine(this.ToString());
    }

    public override string ToString()
    {
        return $@"Your profile:{Environment.NewLine}" +
            $"Full Name: {lastName},{firstName}{Environment.NewLine}" +
            $"Age: {age}{Environment.NewLine}" +
            $"Weight: {weight}{Environment.NewLine}" +
            $"Height: {height}{Environment.NewLine}" +
            $"Body Mass Index: {bodyMassIndex}{Environment.NewLine}";
    }
}

public class Task1_2 : Task
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

    public void DoTask()
    {
        RequestSides();
        Console.WriteLine($"S = {CalculateHeron()}");
    }
}

public class Task1_1 : Task
{
    public void DoTask()
    {
        Console.Write("UserName = ");
        string userName = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine($"Hello, {userName}");

        Console.Write("X = ");
        var x = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        Console.Write("Y = ");
        var y = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        var tmp = x;
        x = y;
        y = tmp;

        Console.WriteLine($"X: {x}, Y: {y}");

        Console.Write("Number = ");
        Console.WriteLine($"Numbers of digits: {Console.ReadLine().Length}");
    }
}