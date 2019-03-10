using System;

namespace Fibonacci
{
    class Program
    {
        /*
        The Fibonacci numbers are the integers in the following sequence:  
        0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ...
        By definition, the first two numbers in the Fibonacci sequence are 0 and 1, and each subsequent number is the sum of the previous two.

        Write a command line program which prompts the user for an integer value and display the Fibonacci sequence leading up to that number.

        C:\Users> Fiboncci
        Please enter the Fibonacci number: 25

            0, 1, 1, 2, 3, 5, 8, 13, 21

    */
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the desired fibonacci number.");
            string inputString = Console.ReadLine();
            int inputInt = int.Parse(inputString);

            int a = 0;
            int b = 1;
            int c = 0;
            Console.Write("0");

            for (int i = 0; i < inputInt; i++)
            {
                if (a < inputInt && b < inputInt && c < inputInt)
                {
                    a = b;
                    b = c;
                    c = a + b;
                    if (c <= inputInt)

                    {
                        Console.Write($" {c} ");
                    }

                    
                }
            }

            Console.ReadLine();
        }
    }
}
