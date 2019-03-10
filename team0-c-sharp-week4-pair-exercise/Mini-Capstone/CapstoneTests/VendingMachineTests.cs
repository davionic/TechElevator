using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void StockMachineTests()
        {
            VendingMachine tester = new VendingMachine();
            tester.StockMachine();
            decimal value = tester.ListToArray()[0].Price;
            Assert.AreEqual(3.05m, value);


        }
        [TestMethod]
        public void SelectProductTests()
        {
            VendingMachine tester = new VendingMachine();
            tester.StockMachine();
            tester.FeedMoney(20.0m);
            Assert.AreEqual("Crunch Crunch Yum!", tester.SelectProduct("A1"));

            VendingMachine tester2 = new VendingMachine();
            tester2.StockMachine();
            Assert.AreEqual("Feed me more money to buy that item", tester2.SelectProduct("A1"));

            VendingMachineItem[] testerArray = tester.ListToArray();
            testerArray[0].StockLeft = 0;
            Assert.AreEqual("That item is out of stock", tester.SelectProduct("A1"));
        }
        [TestMethod]
        public void FinishTransactionTest()
        {
            VendingMachine tester = new VendingMachine();
            tester.StockMachine();
            tester.CurrentMoney = .80M;
            Assert.AreEqual(tester.FinishTransaction(), "Pew pew 3 quarter(s)! Pew pew 0 dime(s)! Pew pew 1 nickel(s)! Yay");

        }

        [TestMethod]
        public void FeedMoneyTests()
        {
            VendingMachine tester = new VendingMachine();
            tester.CurrentMoney = 2.0m;
            tester.FeedMoney(3.0m);
            Assert.AreEqual(2.0m, tester.CurrentMoney);
            tester.FeedMoney(2.0m);
            Assert.AreEqual(4.0m, tester.CurrentMoney);
        }

        



    }
}
