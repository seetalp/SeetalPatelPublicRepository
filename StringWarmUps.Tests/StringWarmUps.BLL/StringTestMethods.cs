using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace StringWarmUps.BLL
{

    public class StringTestMethods
    {
        //____________________________________________________________________________________________________________________________________________________________________________
        //#1
        public string SayHiMethod(string name, string expected)
        {
            string name2 = "Hello " + name + "!";
            return name2;
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#2

        public string AbbaMethod(string a, string b, string expected)
        {
            string abba = a + b + b + a;
            return abba;
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#3


        public string MakeTags(string a, string b, string expected)
        {
            string maketags = "<" + a + ">" + b + "</" + a + ">";
            return maketags;
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#4
        public string InsertWord(string container, string word, string expected)
        {
            string fullcontainer = container.Insert(2, word);
            return fullcontainer;
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#5

        public string MultipleEndings(string str, string expected)
        {
            string str2 = str.Substring(str.Length - 2);
            string str3 = str2 + str2 + str2;
            return str3;
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#6


        public string FirstHalf(string str, string expected)
        {
            int strhalflength = (str.Length) / 2;
            string str1 = str.Substring(0, strhalflength);
            return str1;
        }

        //____________________________________________________________________________________________________________________________________________________________________________
        //#7

        public string TrimOne(string str, string expected)
        {
            string str1 = str.Substring(1, str.Length - 1);
            string str2 = str1.Remove(str1.Length - 1);
            return str2;


        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#8
        public string LonginMiddle(string a, string b, string expected)
        {
            int alength = a.Length;
            int blength = b.Length;

            if (alength > blength)
            {
                string bab = b + a + b;
                return bab;
            }
            else
            {
                string aba = a + b + a;
                return aba;
            }
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#9

        public string RotateLeft2(string str, string expected)
        {

            string str1 = str.Substring(0, 2);
            string str2 = str.Remove(0, 2) + str1;
            return str2;
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#10

        public string RotateRight2(string str, string expected)
        {
            int strlength = str.Length - 2;
            string str1 = str.Remove(strlength, 2);
            string str2 = str.Substring(strlength, 2);
            string str3 = str2 + str1;

            return str3;
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#11



        public string TakeOne(string str, bool isfromFront, string expected)
        {
            int strlength = str.Length;
            string str1 = str.Remove(0, strlength - 1);
            string str2 = str.Substring(0, 1);

            if (!isfromFront)
            {
                return str1;
            }
            else
            {
                return str2;
            }

        }

        //____________________________________________________________________________________________________________________________________________________________________________
        //#12
        public string MiddleTwo(string str, string expected)
        {
            int strlength = (str.Length / 2) - 1;
            string str1 = str.Substring(strlength, 2);


            return str1;
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#13

        public bool EndsWithLy(string str, bool expected)
        {
            int strlength = str.Length;


            if (strlength < 2)
                return false;


            int strlength1 = str.Length - 2;
            string str1 = str.Substring(strlength1, 2);

            if (str1 == "ly")
                return true;
            return false;
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#14

        public string FrontandBack(string str, int n, string expected)
        {
            int strlength = str.Length - 1;//Cat = 3= = 2
            string str1 = str.Substring(0, n);
            string str2 = str.Remove(0, strlength - (n - 1));
            string str3 = str1 + str2;
            return str3;
        }

        //____________________________________________________________________________________________________________________________________________________________________________
        //#15Given a string and an index, return a string length 2 starting at the given index. //return str.Substring(n, (n + 2));
         

        public string TakeTwoFromPosition(string str, int n, string expected)
        {

            if  (n <= str.Length - 2 && n >= 0)
            {
                return str.Substring(n, 2);
            }
            else
            {
                return str.Substring(0, 2);
            }
                
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#16 use for loop and use count
        public bool HasBadTest(string str, bool expected)
        {

            string a = str.Substring(0, 3);
            string b = str.Substring(1, 3);

            if (a == "bad" || b == "bad")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#17

        public string AtFirst(string str, string expected)
        {
            int str1 = str.Length;
            if (str1 < 2)
            {
                string str2 = str + "@";
                return str2;
            }

            else
            {
                string str3 = str.Substring(0, 2);
                return str3;
            }
        }

        //____________________________________________________________________________________________________________________________________________________________________________
        //#18  

        public string LastChars(string a, string b, string expected)
        {
            int blength = b.Length-1;
            string replace = "@";

            if (b.Length == 0)
            {
                string afirst = a.Substring(0, 1);
                string ab2 = afirst + replace;
                return ab2;
            }

            else if (a.Length == 0)
            {
                string blast = b.Remove(0, blength);
                string ab1 = replace + blast;
                return ab1;
            }
            else
            {
                string afirst = a.Substring(0, 1);
                string blast = b.Remove(0, blength);
                string ab = afirst + blast;
                return ab;
            }
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#19

        public string ConCat(string a, string b, string expected)
        {
            string ab = a + b;
            
            if (a.Length <= 0 || b.Length<=0)
                return ab;
            
            int alength = a.Length - 1;
            string alast = a.Remove(0, alength);
            string aless1 = a.Substring(0, alength);
            string bfirst = b.Substring(0, 1);
            
            if (alast == bfirst)
            {
                string ab1 = aless1 + b;
                return ab1;
            }
            else
            {
                return ab;
            }
            
        }
//____________________________________________________________________________________________________________________________________________________________________________
//#20


        public string SwapLast(string str, string expected)
        {
            string str1 = str.Substring(str.Length - 2, 1);
            string str2 = str.Substring(str.Length - 1, 1);
            string str3 = str.Substring(0, str.Length - 2);
            if (str.Length > 2)
            {

                return str3 + str2 + str1;
            }
            else
            {
                return str.Substring(1, 1) + str.Substring(0, 1);
            }
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#21
        public bool FrontAgain(string str, bool expected)
        {
            string str1 = str.Substring(0, 2);
            string str2 = str.Substring(str.Length - 2, 2);

            if (str1 == str2)
            {
                return true;
            }
            else
            {
                return false; 
            }
                
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#22
        public string MinCat(string a, string b, string expected)
        {
            int alength = a.Length;
            int blength = b.Length;

            if (alength > blength)
            {
                string atrim = a.Remove(0, alength - blength) + b;
                return atrim;
            }
            else if (blength > alength)
            {
                string btrim = a + b.Remove(0, blength - alength);
                return btrim;
            }
            else
            {
                string ab = a + b;
                return ab;
            }
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#23
        public string TweakFront(string str, string expected)
        {
                if (str.Length > 0 && str.Substring(0, 1) == "a" && str.Substring(1, 1) == "b")
                {
                    return str;
                }
                else if (str.Length > 0 && str.Substring(0, 1) == "a" && str.Substring(1, 1) != "b")
                {
                    return str.Substring(0, 1) + str.Remove(0, 2);
                }
                else if (str.Length > 0 && str.Substring(0, 1) != "a" && str.Substring(1, 1) == "b")
                {
                    return str.Substring(1, 1) + str.Remove(0, 2);
                }
                else
                {
                    return str.Remove(0, 2);
                }

            
        }
        //____________________________________________________________________________________________________________________________________________________________________________
        //#24
        public string StripX(string str, string expected)

        {
            if (str.Length > 0 && str.Substring(0, 1) == "x" && str.Substring(str.Length - 1, 1) == "x")
            {
                string str1 = str.Remove(0, 1);
                string str2 = str1.Remove(str1.Length - 1, 1);
                return str2;
            }
            else if (str.Length > 0 && str.Substring(0, 1) == "x" && str.Substring(str.Length - 1, 1) != "x")
            {
                string str3 = str.Substring(1);
                return str3;
            }
            else if (str.Length > 0 && str.Substring(0, 1) != "x" && str.Substring(1, 1) == "x")
            {
                string str4 = str.Remove(str.Length - 1, 1);
                string str5 = str4.Substring(0);
                return str5;
            }
            else
            {
                return str;
            }
        }
    }
}
