using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace ArrayWarmUps.BLL
{

    public class ArrayMethods
    {

        public bool FirstLastSix(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6) //what is "numbers.Length"
            {
                return true;
            }
            else
            {
                return false;
            }


        }

//_________________________________________________________________________________________________________________________
//#2
        public bool SameFirstLast(int[] numbers)
        {
            if (numbers[0] == numbers[numbers.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

//___________________________________________________________________________________________________________________
//#3
        public int[] MakePi(int n) // Strip Pi, Find N digits of Pit and return in array

        {
            string pi = Math.PI.ToString();
            string cleanStringPi = pi.Replace(".", "");
            int[] piArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                piArray[i] = int.Parse(cleanStringPi.Substring(i, 1));
            }

            return piArray;

        }
//___________________________________________________________________________________________________________________ 
//#4
        public bool CommonEnd(int[] a, int[] b, bool expected)
        {
            

            if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1])
            {
                return true;
            }

            else
            {
                return false;
            }
        }


//___________________________________________________________________________________________________________________ 
//#5
        public int SumMethod(int[] numbers, int expected)
        {
            int sumArray = numbers.Sum();
            return sumArray;
        }

//___________________________________________________________________________________________________________________ 
//#6

        public int[] RotateLeft(int[] numbers, int[] expected)
        {
            int[] rotated = {numbers[1], numbers [2], numbers[0]};
            return rotated;
        }
//___________________________________________________________________________________________________________________ 
//#7

        public int[] Reverse(int[] numbers, int[] expected)
        {
            int[] reverse = { numbers[2], numbers[1], numbers[0] };
            return reverse;
        }



//___________________________________________________________________________________________________________________ 
//#8
        public int[] HigherWins(int[] numbers, int[] expected)
        {
            if (numbers[0] > numbers[2])
            {
                int[] numbers1 = {numbers[0], numbers[0], numbers[0]};
                return numbers1;
            }
            else if (numbers[2] > numbers[0])
            {
                int[] numbers2 = {numbers[2], numbers[2], numbers[2]};
                return numbers2;
            }
            else
            {
                return numbers;
            }
        }



//___________________________________________________________________________________________________________________ 
//#9


        public int[] GetMiddle(int[] a, int[] b, int[] expected)
        {
            int[] middleab = { a[1], b[1]};
            return middleab;

        }


//___________________________________________________________________________________________________________________ 
//#10

        public bool HasEven(int[] numbers)
        {
            if (numbers[0]%2 == 0 || numbers[1]%2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



//___________________________________________________________________________________________________________________ 
//#11


        public int[] KeepLast(int[] numbers, int[] expected)
        {
           
            int[] numbers1 = new int[numbers.Length*2];
            numbers1[numbers.Length * 2 - 1] = numbers[numbers.Length - 1];
            return numbers1;
        }
       



//___________________________________________________________________________________________________________________ 
//#12


        public bool Double23(int[] numbers, bool expected)
        {
            int count2s = 0;
            int count3s = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                    
                {
                    count2s++;
                }
                if (numbers[i] == 3)
                {
                    count3s++;
                }
            }
            if (count2s == 2 || count3s == 2)
            {
                return true;
            }

            else
            {
                return false;
            }
        
            
        }



//___________________________________________________________________________________________________________________ 
 //#13
        public int [] Fix23(int[] numbers, int[] expected)
        {
            if (numbers[0] == 2 && numbers[1] == 3)
            {
                int[] numbers1 = new[] {numbers[0], numbers[1] = 0, numbers[2]};
                return numbers1;
            }
            else if (numbers[1] == 2 && numbers[2] == 3)
            {
                int[] numbers2 = new[] { numbers[0], numbers[1], numbers[2] = 0 };
                return numbers2;
            }
            else
            {
                return numbers;
            }
        }



//___________________________________________________________________________________________________________________ 
//#14

        public bool UnluckyOne(int[] numbers, bool expected)
        {
            if (numbers[0] == 1 && numbers[1] == 3 || numbers[1] == 1 && numbers[2] == 3 || numbers[numbers.Length - 3] == 1 && numbers[numbers.Length - 2] == 3 || numbers[numbers.Length - 2] == 1 && numbers[numbers.Length - 1] == 3)
            {
                
                return true;
            }
      
            else
            {
                return false;
            }
        }


//___________________________________________________________________________________________________________________ 
//#15



        public int[] make2(int[] a, int[] b)
        {
            int[] arrayresults = new int[2];//create new array and loop through a and b

            int count = 0;

            foreach (var i in a)//make statements, loops, decision
            {
                arrayresults[count] = i;
                count++;

                if (count >= 2)
                {
                    return arrayresults;
                }
            }

            foreach (var i in b)
            {
                arrayresults[count] = i;
                count++;

                if (count >= 2)
                {
                    return arrayresults;
                }
            }

            return arrayresults;
        }

    
    }
}




                                               