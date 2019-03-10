using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataFizzBuzz
    {
        public string FizzBuzz(int n)
        {
            if (n > 100 || n < 0)
            {
                return "";
            }

            if (n % 3 != 0 && n % 5 != 0)
            {
                return $"{n}";
            }

            if (n % 3 == 0 && n % 5 == 0)
            {
                return "FizzBuzz";
            }

            if (n % 3 == 0 && n % 5 != 0)
            {
                return "Fizz";
            }

                return "Buzz";
        }
    }
}
