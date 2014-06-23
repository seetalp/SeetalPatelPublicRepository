using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConditionalWarmUps.BLL
{
    public class ConditionalTestMethods
    {
        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#1
        public bool Trouble(bool aSmile, bool bSmile, bool expected)
        {
            if ((aSmile && bSmile) || (!aSmile && !bSmile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#2

        public bool CanSleepIn(bool isWeekday, bool isVacation, bool expected)
        {
            if (!isWeekday || isVacation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#3


        public int SumDouble(int a, int b, int expected)
        {
            int sum = a + b;
            int doublethesum = 2 * sum;

            if (a != b)
            {
                return sum;
            }
            else
            {
                return doublethesum;
            }
        }
        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#4


        public int GetDifference(int n, int expected)
        {

            int b = 21;
            int c = 2;
            int absdiff = Math.Abs(n - b);
            int doubleabsdiff = c * absdiff;

            if (n > 21)
            {
                return doubleabsdiff;
            }
            else
            {
                return absdiff;
            }
        }

        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#5

        public bool ParrotTrouble(bool isTalking, int hour, bool expected)
        {
            if (isTalking && (hour < 7 || hour > 20))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#6
        public bool Makes10(int a, int b, bool expected)
        {
            int sum = a + b;
            if (a == 10 || b == 10 || sum == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //______________________________________________________________________________________________________________________________________________________________________________________________
        //#7


        public bool NearHundred(int n, bool expected)
        {
            if (n >= 90 && n <= 110 || n == 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //______________________________________________________________________________________________________________________________________________________________________________________________
        //#8
        public bool PosNegMethod(int a, int b, bool isNegative, bool expected)
        {
            if (isNegative && (a < 0 && b < 0))
            {
                return true;
            }
            else if (a < 0 || b < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //______________________________________________________________________________________________________________________________________________________________________________________________
        //#9


        public string NotString(string str, string expected)
        {
            if (str.StartsWith("not"))
            {
                return str;
            }
            else
            {
                string str1 = "not " + str;
                return str1;
            }
        }


        //______________________________________________________________________________________________________________________________________________________________________________________________
        //#10

        public string MissingChar(string str, int n, string expected)
        {
            string str1 = str.Remove(n, 1);
            return str1;
        }


        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#11
        public string FrontBack(string str, string expected)
        {


            if (str.Length < 2)
            {
                return str;
            }

            else
            {
                string strmiddle = str.Substring(1, str.Length - 2);
                string strfirst = str.Substring(0, 1);
                string strlast = str.Substring(str.Length - 1, 1);
                string result = strlast + strmiddle + strfirst;
                return result;
            }
        }
       
        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#12

        public string FrontThree(string str, string expected)
        {
            
             if (str.Length < 3)
             {
                string str1 = str + str + str;
                return str1;
            }
            else
             {
                string str2 = str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);
                return str2;
            }
        }

        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#13

        public string BackAround(string str, string expected)
        {
            string addlast = str.Substring(str.Length - 1, 1) + str + str.Substring(str.Length - 1, 1);
            return addlast;
        }

        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#14

        public bool Multiple3or5(int n, bool expected)
        {
            if (n % 3 == 0 || n % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#15
        public bool StartHi(string str, bool expected)
        {
            
            int count = 0;
            string[] words = str.Split(' ');
            foreach (var word in words)
            {
                if (word == "hi")
                    count++;
            }
            if (count > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }



        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#16

        public bool IcyHot(int temp1, int temp2, bool expected)
        {
            if (temp1 < 0 && temp2 > 100 || temp2 < 0 && temp1 > 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#17

        public bool between10and20(int a, int b, bool expected)
        {
            if (a <= 20 && a >= 10 || b <= 20 && b >= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#18
        public bool HasTeen(int a, int b, int c, bool expected)
        {
            if (a >= 13 && a <= 19 || b >= 13 && b <= 19 || c >= 13 && c <= 19)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#19

        public bool SoAlone(int a, int b, bool expected)
        {
            if (((a >= 13 && a <= 19) && (b < 13 || b > 19)) || ((b >= 13 && b <= 19) && ((a < 13 || a > 19))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //_____________________________________________________________________________________________________________________________________________________________________________________
        //#20

        public string RemoveDel(string str, string expected)
        {
            int index = str.IndexOf("del");
            if (index == -1)
            {
                return str;
            }
            else
            {
                string str1 = str.Remove(1, 3);
                return str1;
            }
        }

//_____________________________________________________________________________________________________________________________________________________________________________________
//#21
        public bool IxStart(string str, bool expected)
        {
            int index = str.IndexOf("ix");
            if (index != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

//_____________________________________________________________________________________________________________________________________________________________________________________
//#22

        public string StartOz(string str, string expected)
        {
            if (str.Substring(0, 2) == "oz")
            {
                return str.Substring(0, 2);
            }
            else if (str.Substring(0, 1) == "o")
            {
                return str.Substring(0, 1);
            }
            else if (str.Substring(1, 1) == "z")
            {
                return str.Substring(1, 1);
            }
            else
            {
                return str;
            }
        }


//_____________________________________________________________________________________________________________________________________________________________________________________
//#23

        public int Max(int a, int b, int c, int expected)
        {
            int maxofabc = Math.Max(a, Math.Max(b, c));
            return maxofabc;
        }

//_____________________________________________________________________________________________________________________________________________________________________________________
//#24

        public int Closer(int a, int b, int expected)
        {
            
            int a10 = Math.Abs(a - 10);
            int b10 = Math.Abs(b - 10);
            int zero = 0;

            if (a10 > b10)
            {
                return b;
            }
            else if (b10 > a10)

            {
                return a;
            }
            else
            {
                
                return zero;
            }
        }
//_____________________________________________________________________________________________________________________________________________________________________________________
//#25
        public bool GotE(string str, bool expected)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'e')
                    count++;
            }
            return (count >= 1 && count <= 3);
        }
//_____________________________________________________________________________________________________________________________________________________________________________________
//#26
        public string EndUp(string str, string expected)
        {
            if (str.Length <= 3)
            {
                string str1 = str.ToUpper();
                return str1;
            }
            else
            {
                string str2 = str.Substring(0,str.Length-3) + str.Substring(str.Length - 3).ToUpper();
                return str2;
            }
        }
//_____________________________________________________________________________________________________________________________________________________________________________________
//#27


        public String EveryNth(string str, int n, string expected)
        {
            string str1 = "";
            for (int i = 0; i < str.Length; i += n) 
                    str1 += str[i];
                    return str1;
            
        }





    }

}
