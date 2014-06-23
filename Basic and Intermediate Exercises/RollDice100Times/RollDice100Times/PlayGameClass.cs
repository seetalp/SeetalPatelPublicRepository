using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RollDice100Times
{
    class PlayGameClass
    {
        Dictionary<int, int> rollDictionary = new Dictionary<int, int>();

        public void PlayGame()
        {
            InitDictionary();
            RollDice();
            PrintResults();


        }

        private void InitDictionary()
        {
            rollDictionary.Add(2, 0);
            rollDictionary.Add(3, 0);
            rollDictionary.Add(4, 0);
            rollDictionary.Add(5, 0);
            rollDictionary.Add(6, 0);
            rollDictionary.Add(7, 0);
            rollDictionary.Add(8, 0);
            rollDictionary.Add(9, 0);
            rollDictionary.Add(10, 0);
            rollDictionary.Add(11, 0);
            rollDictionary.Add(12, 0);
        }

        private void PrintResults()
        {
            foreach (var key in rollDictionary.Keys)
            {
                Console.WriteLine("{0}, {1}", key, rollDictionary[key]);
            }

        }

        private void RollDice()
        {
            Random rng = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int sumOfDice = rng.Next(1, 7) + rng.Next(1, 7);
                rollDictionary[sumOfDice]++;
                //if(rollDictionary.ContainsKey(sumOfDice))
                //    rollDictionary[sumOfDice]++;
                //else
                //    rollDictionary.Add(sumOfDice, 1);

            }

        }




    }
}
