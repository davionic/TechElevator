using System;

namespace DecimalToBinary
{
    class Program
    {
        /*
        Write a command line program which prompts the user for a series of decimal integer values  
        and displays each decimal value as itself and its binary equivalent

        C:\Users> DecimalToBinary

        Please enter in a series of decimal values (separated by spaces): 460 8218 1 31313 987654321

        460 in binary is 111001100
        8218 in binary is 10000000011010
        1 in binary is 1
        31313 in binary is 111101001010001
        987654321 in binary is 111010110111100110100010110001
        */
        static void Main(string[] args)
        {
            string userInput;


            Console.Write("Enter decimal numbers seperated by spaces : ");
            userInput = Console.ReadLine();

            string[] numbers = userInput.Split();
            int[] numbersAsInts = Array.ConvertAll(numbers, int.Parse);

            for (int i = 0; i < numbersAsInts.Length; i++)
            {
                string binary = Convert.ToString(numbersAsInts[i], 2);

                Console.WriteLine($"{numbersAsInts[i]} in binary is {binary}");
            }
            Console.ReadLine();
        }
    }
}
