using System;

namespace LinearConvert
{
    class Program
    {
        /*
 The foot to meter conversion formula is:
    m = f * 0.3048

 The meter to foot conversion formula is:
    f = m * 3.2808399

 Write a command line program which prompts a user to enter a length, and whether the measurement is in (m)eters or (f)eet.
 Convert the length to the opposite measurement, and display the old and new measurements to the console.

 C:\Users> LinearConvert
 Please enter the length: 58
 Is the measurement in (m)eter, or (f)eet? f
 58f is 17m.
 */

        static void Main(string[] args)
        {
           
            double meterToFeet = 0;
            double feetToMeter = 0;
            string userInput = null;

            while (userInput != "q")
            { 
                Console.WriteLine("Please enter length");
                Console.WriteLine("Press q to quit");

                userInput = Console.ReadLine();
                

                if (userInput != "q")
                {   int input = int.Parse(userInput);
                    Console.WriteLine("Is the measurement in meters or feet?");
                    string meterOrFeet = Console.ReadLine();

                    switch (meterOrFeet)
                    {
                        case "feet":
                            feetToMeter = input * 0.3048;
                            Console.WriteLine($"{input} feet is {feetToMeter} meters");
                            Console.ReadLine();
                            break;

                        case "meters":
                            meterToFeet = input * 3.2808399;
                            Console.WriteLine($"{input} meters is {meterToFeet} feet");
                            Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Please enter meters or feet");
                            break;
                    }
                }

                
            }
            Console.WriteLine();
        }
    }
}
