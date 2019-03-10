using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private List<VendingMachineItem> items = new List<VendingMachineItem>();
        public decimal CurrentMoney { get; set; }

        public VendingMachineItem[] ListToArray()
        {
            return items.ToArray();
        }

        public void StockMachine()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\VendingMachine\vendingmachine.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split('|');
                        VendingMachineItem item = new VendingMachineItem();
                        item.Slot = values[0];
                        item.Name = values[1];
                        item.Price = decimal.Parse(values[2]);
                        item.StockLeft = 5;
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error reading the .csv file occurred");
            }
        }

        public void DisplayItems()
        {
            foreach (VendingMachineItem item in items)
            {
                Console.WriteLine($"{item.Slot} | {item.Name} | {item.Price}");
            }
            Console.WriteLine();
        }

        public void FeedMoney(decimal moneyInserted)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\VendingMachine\log.txt", true))
                {
                    if (moneyInserted == 1 || moneyInserted == 2 || moneyInserted == 5 || moneyInserted == 10 || moneyInserted == 20)
                    {
                        sw.WriteLine(DateTime.Now + " FeedMoney: " + "$" +CurrentMoney + " " + "$" +(CurrentMoney + moneyInserted));
                        CurrentMoney += moneyInserted;
                    }
                    else
                    {
                        Console.WriteLine("Invalid dollar amount. Please enter 1, 2, 5, 10, or 20.");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong with streamreader in the feedmoney method");
            }

        }



        public string SelectProduct(string inputSlot)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\VendingMachine\log.txt", true))
                {
                    foreach (VendingMachineItem item in items)
                    {
                        if (item.Slot == inputSlot)
                        {
                            if (item.StockLeft > 0)
                            {
                                if (CurrentMoney < item.Price)
                                {
                                    return "Feed me more money to buy that item";
                                }
                                sw.WriteLine(DateTime.Now + " " + item.Name + " " + "$" + CurrentMoney + " " + "$" + (CurrentMoney - item.Price));
                                item.StockLeft -= 1;
                                if (inputSlot[0] == 'A')
                                {
                                    CurrentMoney -= item.Price;
                                    return "Crunch Crunch Yum!";
                                }
                                else if (inputSlot[0] == 'B')
                                {
                                    CurrentMoney -= item.Price;
                                    return "Munch Munch Yum!";
                                }
                                else if (inputSlot[0] == 'C')
                                {
                                    CurrentMoney -= item.Price;
                                    return "Glug Glug Yum!";

                                }
                                else if (inputSlot[0] == 'D')
                                {
                                    CurrentMoney -= item.Price;
                                    return "Chew Chew Yum!";
                                }
                            }
                            else
                            {
                                return "That item is out of stock";

                            }
                        }

                    }
                    {
                        return "That slot is not valid";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something is wonky with the StreamWriter");
                return "-1";
            }
        }

        public string FinishTransaction()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\VendingMachine\log.txt", true))
                {
                    sw.WriteLine(DateTime.Now + " GiveChange " + "$" + CurrentMoney + " $0.00");
                    int quartersChange = 0;
                    int dimesChange = 0;
                    int nickelsChange = 0;

                    while (CurrentMoney >= .25M)
                    {

                        CurrentMoney -= .25M;
                        quartersChange += 1;
                    }
                    while (CurrentMoney >= .10M)
                    {

                        CurrentMoney -= .10M;
                        dimesChange += 1;
                    }
                    while (CurrentMoney >= .05M)
                    {

                        CurrentMoney -= .05M;
                        nickelsChange += 1;
                    }

                    return $"Pew pew {quartersChange} quarter(s)! Pew pew {dimesChange} dime(s)! Pew pew {nickelsChange} nickel(s)! Yay";
                }
            }
            catch (Exception ex)
            {
                return "Error occured while writing log in finish transaction";
            }

        }
    }
}
