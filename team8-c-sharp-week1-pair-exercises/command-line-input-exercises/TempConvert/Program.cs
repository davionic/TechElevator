using System;

namespace TempConvert
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

            string userInput = null;
            

            while (userInput != "q")
            {
                Console.WriteLine("Please enter temperature");
                Console.WriteLine("Press q to exit");

                userInput = Console.ReadLine();
                
                if(userInput!= "q")
                {
                    int temperature = int.Parse(userInput);
                    Console.WriteLine("Is the temperature in 'C'elsius or 'F'arenheit?");
                    string typeOfTemp = Console.ReadLine();

                    double celToFar = 0;
                    double farToCel = 0;

                    switch (typeOfTemp)
                    {
                        case "C":
                            celToFar = temperature * 0.3048;
                            Console.WriteLine($"{temperature}C to {celToFar}F.");
                            break;

                        case "F":
                            farToCel = temperature * 3.2808399;
                            Console.WriteLine($"{temperature}F to {farToCel}C.");                            
                            break;

                        default:
                            Console.WriteLine("Please enter C or F.");
                            break;
                    }
                    Console.WriteLine();
                }




            }
        }
    }
}

