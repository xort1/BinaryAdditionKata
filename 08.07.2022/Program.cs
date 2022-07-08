using System;
using System.Collections;
using System.Linq;

public static class Program
{
    static void Main(string[] args)
    {
        int a = 0, b = 0; string str;

        do
        {
            Console.WriteLine("Enter two numbers...");

            Console.WriteLine("First number: ");
            str = Console.ReadLine();
            bool isParsing = int.TryParse(str, out a);

            if (isParsing)
            {
                Console.WriteLine("Second number: ");
                str = Console.ReadLine();
                bool isParsing2 = int.TryParse(str, out b);

                if (!isParsing2)
                {
                    Console.WriteLine("Error!\n");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Error!\n");
                continue;
            }
        } while (a > 2147483647 || a < -2147483648 || b > 2147483647 || b < -2147483648);

        Console.WriteLine(AddBinary(a, b));
    }

    public static string AddBinary(int a, int b)
    {
        int count = 0; bool isMinus = false;

        int c = a + b;

        if (c < 0)
            isMinus = true;

        c = Math.Abs(c); int d = c; int e = d;

        for (int i = 21; i >= 0; i--)
        {
            if (Math.Pow(2, i) <= d)
                count = i + 1;

            if (count != 0)
                break;
        }

        if (isMinus)
            count++;

        char[] result = Enumerable.Repeat('0', count).ToArray();

        for (int i = 21; i >= 0; i--)
        {
            if (Math.Pow(2, i) <= e)
            {
                e -= Convert.ToInt32(Math.Pow(2, i));

                result[i] = '1';
            }

            if (e == 0)
                break;
        }

        if (isMinus)
            result[^1] = '-';

        Array.Reverse(result);

        string str = String.Concat<char>(result);

        return str;
    }
}