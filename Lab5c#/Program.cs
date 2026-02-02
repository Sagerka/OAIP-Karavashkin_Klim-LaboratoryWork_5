using System;
public class Rational
{
    private int numerator;
    private int denominator;

    public int Numerator => numerator;
    public int Denominator => denominator;

    public Rational(int a, int b)
    {
        if (b == 0)
            throw new ArgumentException("Знаменатель не может быть нулем");

        if (b < 0)
        {
            a = -a;
            b = -b;
        }

        int gcd = GCD(Math.Abs(a), b);
        numerator = a / gcd;
        denominator = b / gcd;
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static Rational operator +(Rational r1, Rational r2)
    {
        int num = r1.numerator * r2.denominator + r2.numerator * r1.denominator;
        int den = r1.denominator * r2.denominator;
        return new Rational(num, den);
    }

    public static Rational operator -(Rational r1, Rational r2)
    {
        int num = r1.numerator * r2.denominator - r2.numerator * r1.denominator;
        int den = r1.denominator * r2.denominator;
        return new Rational(num, den);
    }

    public static Rational operator *(Rational r1, Rational r2)
    {
        return new Rational(r1.numerator * r2.numerator, r1.denominator * r2.denominator);
    }

    public static Rational operator /(Rational r1, Rational r2)
    {
        if (r2.numerator == 0)
            throw new DivideByZeroException("Деление на ноль.");
        return new Rational(r1.numerator * r2.denominator, r1.denominator * r2.numerator);
    }

    public override bool Equals(object obj)
    {
        if (obj is Rational other)
            return numerator == other.numerator && denominator == other.denominator;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(numerator, denominator);
    }

    public static bool operator ==(Rational r1, Rational r2)
    {
        if (ReferenceEquals(r1, null) && ReferenceEquals(r2, null)) return true;
        if (ReferenceEquals(r1, null) || ReferenceEquals(r2, null)) return false;
        return r1.Equals(r2);
    }

    public static bool operator !=(Rational r1, Rational r2)
    {
        return !(r1 == r2);
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }
}
class Program
{
    static void Main()
    {
        try
        {
            var r1 = new Rational(4, 6);   //  2/3
            var r2 = new Rational(1, 3);   //  1/3

            Console.WriteLine($"r1 = {r1}");
            Console.WriteLine($"r2 = {r2}");
            Console.WriteLine($"r1 + r2 = {r1 + r2}");
            Console.WriteLine($"r1 - r2 = {r1 - r2}");
            Console.WriteLine($"r1 * r2 = {r1 * r2}");
            Console.WriteLine($"r1 / r2 = {r1 / r2}");
            Console.WriteLine($"r1 == r2? {r1 == r2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}