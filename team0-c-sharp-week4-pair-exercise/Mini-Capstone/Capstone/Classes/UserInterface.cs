using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        private VendingMachine vendingMachine = new VendingMachine();
        
        public void RunInterface()
        {
            vendingMachine.StockMachine();
            bool done = false;
            while (!done)
            {
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) End");
                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    vendingMachine.DisplayItems();
                }

                if (userInput == "2")
                {
                    string purchaseInput = "";
                    bool purchasing = true;
                    while (purchasing)
                    {
                        Console.WriteLine();
                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");
                        Console.WriteLine();
                        Console.WriteLine($"Current Money Inserted: ${vendingMachine.CurrentMoney}");

                        purchaseInput = Console.ReadLine();


                        if (purchaseInput == "1")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter Dollar Amount:1, 2, 5, 10, or 20.");

                            vendingMachine.FeedMoney(decimal.Parse(Console.ReadLine()));
                        }

                        if (purchaseInput == "2")
                        {
                            Console.WriteLine("Please enter slot choice:");
                            string slotChoice = Console.ReadLine();
                            Console.WriteLine(vendingMachine.SelectProduct(slotChoice));
                        }

                        if (purchaseInput == "3")
                        {
                            Console.WriteLine(vendingMachine.FinishTransaction());                          
                            purchasing = false;
                        }
                    }
                    
                }

                if (userInput == "3")
                {
                    done = true;
                }
            }

        }
    }
}
