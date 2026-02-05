using System;
using System.Runtime.InteropServices;
class Program
{
    public static bool isprime(int n)
    {
        if (n < 2)
            return false;
        if (n == 2 || n == 3)
            return true;
        if (n % 2 == 0)
            return false;
        for (long i = 3; i * i <= n; i += 2)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                Console.WriteLine($"{numbers[i]} is even");
                if (isprime(numbers[i]))
                {
                    Console.WriteLine($"{numbers[i]} is also prime");
                }
            }
            else
            {
                Console.WriteLine($"{numbers[i]} is odd");
                if (isprime(numbers[i]))
                {
                    Console.WriteLine($"{numbers[i]} is also prime");
                }
            }
        }
    }
}




