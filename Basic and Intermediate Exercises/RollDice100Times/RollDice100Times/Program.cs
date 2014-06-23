using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RollDice100Times
{
    class Program
    {
        static void Main(string[] args)
        {

            PlayGameClass p = new PlayGameClass();
            p.PlayGame();
            Console.ReadLine();



        }

       
    }
}
