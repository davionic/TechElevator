using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercises;


namespace Exercises.Tests
{
    [TestClass()]
    public class KataFizzBuzzTests
    {
        [TestMethod()]
        public void FizzBuzzTest()
        {
            KataFizzBuzz myObject = new KataFizzBuzz();
            string result = myObject.FizzBuzz(15);
            Assert.AreEqual("FizzBuzz", result);
        }

        [TestMethod()]
        public void FizzBuzz3FizzTest()
        {
            KataFizzBuzz myObject = new KataFizzBuzz();
            string result = myObject.FizzBuzz(3);
            Assert.AreEqual("Fizz", result);
        }

        [TestMethod()]
        public void FizzBuzz5BuzzTest()
        {
            KataFizzBuzz myObject = new KataFizzBuzz();
            string result = myObject.FizzBuzz(5);
            Assert.AreEqual("Buzz", result);
        }

        [TestMethod()]
        public void FizzBuzzPast100Test()
        {
            KataFizzBuzz myObject = new KataFizzBuzz();
            string result = myObject.FizzBuzz(101);
            Assert.AreEqual("", result);
        }

        [TestMethod()]
        public void FizzBuzzUnder1Test()
        {
            KataFizzBuzz myObject = new KataFizzBuzz();
            string result = myObject.FizzBuzz(0);
            Assert.AreEqual("FizzBuzz", result);
        }


        [TestMethod()]
        public void FizzBuzzNoMultipleTest()
        {
            KataFizzBuzz myObject = new KataFizzBuzz();
            string result = myObject.FizzBuzz(4);
            Assert.AreEqual("4", result);
        }
    }
}
