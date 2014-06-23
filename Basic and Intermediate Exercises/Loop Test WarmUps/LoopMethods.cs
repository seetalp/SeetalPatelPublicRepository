using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace LoopTestRunners.BLL
{
    public class LoopMethods
    {
        //#1
        public string StringTimes(string str, int n)
        {
            string result = str; //stores the string content
            for (int i = 1; i < n; i++) //run the string concat "n" number times - remember if "n" is one that it won't run and we don't want to add/join
            {
                result = result + str;
            }
            return result;
        }

        //____________________________________________________________________________________________________________________________________________________________________  
        //#2

        public string FrontStrings(string str, int n)
        {
            string result = str.Substring(0, 3);
            string modresult = result; //stores the string content
            for (int i = 1; i < n; i++) //run the string concat "n" number times - remember if "n" is one that it won't run and we don't want to add/join
            {
                modresult = modresult + result;
            }
            return modresult;
        }
        //___________________________________________________________________________________________________________________________________________________________________
        //#3


        public int CountXX(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                string newString = str.Substring(i, 2);

                if (newString == "xx")
                {
                    count++;
                }
            }

            return count;
        }

        //___________________________________________________________________________________________________________________________________________________________________
        //#4

        public bool DoubleX(string str)
        {


            for (int i = 0; i < str.Length; i++)
            {
                string newString = str.Substring(i, 1);
                string newString2 = str.Substring(i + 1, 1);
                if (newString == "x")
                {
                    if (newString2 == "x")
                        return true;

                    else
                    {
                        return false;
                    }

                }
            }
            return false;
        }
        //____________________________________________________________________________________________________________________________________________________________________  
        //#5

        public string EveryOther(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i += 2)
            {
                result += str[i];
            }

            return result;
        }


        //____________________________________________________________________________________________________________________________________________________________________  
        //#6


        public string StringSplosion(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                result += str.Substring(0, i + 1);
            }

            return result;
        }



        //____________________________________________________________________________________________________________________________________________________________________  
        //#7

        public int CountLast(string str)
        {


            int count = 0;
            for (int i = 0; i < str.Length - 2; i++)
            {
                string str1 = str.Substring(i, 2);
                string str2 = str.Substring(str.Length - 2, 2);

                if (str1 == str2)
                {
                    count++;
                }
            }
            return count;
        }




        //____________________________________________________________________________________________________________________________________________________________________  
        //#8



        public int CountNine(int[] numbers, int expected)
        {
            int count = 0;
            foreach (var num in numbers)
            {
                if (num == 9)
                    count++;
            }
            return count;
        }



        //____________________________________________________________________________________________________________________________________________________________________  
        //#9

        public bool ArrayFront9(int[] numbers, bool expected)
        {
            for (int i = 0; i < 4; i++)
            {
                if (numbers[i] == 9)
                {
                    return true;
                }
            }
            return false;
        }





        //____________________________________________________________________________________________________________________________________________________________________  
        //#10


        public bool Array123(int[] numbers, bool expected)
        {

            for (int i = 0; i < (numbers.Length - 2); i++)
            {
                if ((numbers[i] == 1) && (numbers[i + 1] == 2) && (numbers[i + 2] == 3))
                {
                    return true;
                }
            }
            return false;
        }



        //____________________________________________________________________________________________________________________________________________________________________  
        //#11



        public int SubStringMatch(string a, string b, int expected)
        {



           int small = Math.Min(a.Length, b.Length) - 1;

            int count = 0;
            for (int i = 0; i < small; i++)
            {
                if (a.Substring(i, 2) == (b.Substring(i, 2)))
                    count++;
            }

            return count;

        }


        //____________________________________________________________________________________________________________________________________________________________________  
        //#12


        public string StringX(string str, string expected)
        {
            string firstx = str.Substring(0, 1);
            string lastx = str.Substring(str.Length - 1, 1);
            string str1 = str.Substring(1, str.Length - 2);
            string str2 = str1.Replace("x", "");
            string str3 = firstx + str2 + lastx;
            return str3;
        }


        //____________________________________________________________________________________________________________________________________________________________________  
        //#13



        public string AltPairs(string str, string expected)
        {

            string result = "";

            for (int i = 0; i < str.Length; i += 4)
            {
                if ((i + 1)  == str.Length)
                {
                    result += str[i];
                }
            else
                {
                    result += str.Substring(i, 2);
                }
                
            }
            return result;
        }
              
 //____________________________________________________________________________________________________________________________________________________________________  
 //#14

        public string DoNotYak(string str, string expected)
        {

            string str1 = str.Replace("yak", "");
            return str1;

        }

    
//____________________________________________________________________________________________________________________________________________________________________  
//#15


        public int Array667(int[] numbers, int expected)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 6 && numbers[i + 1] == 6)
                count++;
               
            }
            return count;
        }

//____________________________________________________________________________________________________________________________________________________________________  
//#16

        public bool NoTriples(int[] numbers, bool expected)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i+1] && numbers[i] == numbers[i+2])
                    return false;
            }
            return true;
        }

//____________________________________________________________________________________________________________________________________________________________________  
//#17



        public bool Pattern51(int[] numbers, bool expected)
        {
            for (int i = 0; i < (numbers.Length - 1); i++)
            {
                if ((numbers[i] == 2) && (numbers[i + 1] == 7) && (numbers[i + 2] == 1))
                {
                    return true;
                }
            }
            return false;
        }


















        
    }
}


