using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachineItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Slot { get; set; }
        public int StockLeft { get; set; }
    }
}
