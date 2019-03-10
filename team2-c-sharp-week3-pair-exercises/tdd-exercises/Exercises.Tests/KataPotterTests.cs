using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class KataPotterTests
    {
        [TestMethod()]
        public void GetCost1BookTest()
        {
            int[] books = new int[5] { 1, 0, 0, 0, 0 };
            KataPotter myObject = new KataPotter();           
         
            decimal result = myObject.GetCost(books);

            Assert.AreEqual(8, result);
        }

        [TestMethod()]
        public void GetCost1Copy2BooksTest()
        {
            int[] books = new int[5] { 1, 1, 0, 0, 0 };
            KataPotter myObject = new KataPotter();
            decimal result = myObject.GetCost(books);

            Assert.AreEqual((8 * .95M) * 2, result);
        }

        [TestMethod()]
        public void GetCost1Copy3BooksTest()
        {
            int[] books = new int[5] { 1, 1, 1, 0, 0 };
            KataPotter myObject = new KataPotter();
            decimal result = myObject.GetCost(books);

            Assert.AreEqual((8 * .90M) * 3, result);
        }

        [TestMethod()]
        public void GetCost1Copy4BooksTest()
        {
            int[] books = new int[5] { 1, 1, 1, 1, 0 }; 
            KataPotter myObject = new KataPotter();
            decimal result = myObject.GetCost(books);

            Assert.AreEqual((8 * .80M) * 4, result);
        }

        [TestMethod()]
        public void GetCost1Copy5BooksTest()
        {
            int[] books = new int[5] { 1, 1, 1, 1, 1 };
            KataPotter myObject = new KataPotter();
            decimal result = myObject.GetCost(books);

            Assert.AreEqual((8 * .75M) * 5, result);
        }

        [TestMethod()]
        public void GetCost3And5Test()
        {
            int[] books = new int[5] { 2, 2, 2, 1, 1 };
            KataPotter myObject = new KataPotter();
            decimal result = myObject.GetCost(books);

            Assert.AreEqual((8 * .8M) * 8, result);
        }

        [TestMethod()]
        public void GetCost44422Test()
        {
            int[] books = new int[5] { 4, 4, 4, 2, 2 };
            KataPotter myObject = new KataPotter();
            decimal result = myObject.GetCost(books);

            Assert.AreEqual((8 * .8M) * 16, result);
        }

    }
}
