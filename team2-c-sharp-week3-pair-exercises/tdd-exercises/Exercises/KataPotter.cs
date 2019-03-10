using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataPotter
    {
        public decimal GetCost(int[] books)
        {
            decimal setsOfFive = 0;
            decimal setsOfFour = 0;
            decimal setsOfThree = 0;
            decimal setsOfTwo = 0;
            decimal setsOfOne = 0;
            decimal price = 0;

            if (books[0] == 1 && books[1] == 1 && books[2] == 1 && books[3] == 1 && books[4] == 1)
            {
                price = 30M;
                return price;
            }

                while (books[0] != 0 && books[1] != 0 && books[2] != 0 && books[3] != 0 && books[4] != 0)
            {
                int bookSetSize = 0;

                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] > 0)
                    {
                        bookSetSize += 1;
                        books[i] -= 1;

                        if (bookSetSize == 4)
                        {
                            setsOfFour += 1;
                        }
                        else if (bookSetSize == 5)
                        {
                            books[i] += 1;
                        }
                    }
                }
            }

            while (books[0] != 0 || books[1] != 0 || books[2] != 0 || books[3] != 0 || books[4] != 0)
            {
                int bookSetSize = 0;

                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] > 0)
                    {
                        bookSetSize += 1;
                        books[i] -= 1;
                    }
                }

                if (bookSetSize == 5)
                {
                    setsOfFive += 1;
                }
                if (bookSetSize == 4)
                {
                    setsOfFour += 1;
                }
                if (bookSetSize == 3)
                {
                    setsOfThree += 1;
                }
                if (bookSetSize == 2)
                {
                    setsOfTwo += 1;
                }
                if (bookSetSize == 1)
                {
                    setsOfOne += 1;
                }

            }

            price = ((setsOfFive * 30M) + (setsOfFour * 25.60M) + (setsOfThree * 21.60M) + (setsOfTwo * 15.20M) + (setsOfOne * 8M));
            return price; 
        }
    }
}
