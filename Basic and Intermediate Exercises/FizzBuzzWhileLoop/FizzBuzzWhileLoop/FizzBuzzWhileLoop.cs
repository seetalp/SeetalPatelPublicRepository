using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzWhileLoop
{
    class FizzBuzzWhileLoopClass
    {
        public void RunFizzBuzzWhileLoop()
        {

            int x = 1;
            while (x < 101)
            {
                Console.WriteLine("x: {0}", x);
                x++;

                if(x%3==0 && x%5==0)
                    Console.Write("FizzBuzz\n");

                else if (x%5==0)
                    Console.Write("Fizz\n");

                else if (x%3==0)
                    Console.Write("Buzz\n");
              

            }


        }
  
    }
}
