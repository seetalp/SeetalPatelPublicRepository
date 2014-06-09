using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LogicTestWarmups.BLL
{
    public class Logic
    {
//__________________________________________________________________________________________________________________________________________________________
//#1
        public bool GoodParty(int cigars, bool isWeekend)
        {
            if (cigars < 40)
            {
                return false;
            }
            else if (cigars >=40 && cigars <=60)
            {
                return true;
            }
            else if (cigars > 60 && isWeekend)
            {
                return true;
            }

            else
            {
                return false;
            }
                
        }
//__________________________________________________________________________________________________________________________________________________________
//#2
        public int CanHazTable(int yourStyle, int dateStyle)
        {
           

            if (yourStyle < 3 || dateStyle < 3)
            {
                int GetTable = 0;
                return GetTable;
            }
            else if (yourStyle > 8 || dateStyle > 8)
            {
                int GetTable = 2;
                return GetTable;
            }
            else
            {
                int GetTable = 1;
                return GetTable;
            }
        }
 //_________________________________________________________________________________________________________________________________________________________    
//#3
        public bool PlayOutside(int temp, bool isSummer)
        {


            if (temp >= 60 && temp <=90 )
            {
                
                return true;
            }
            else if (temp>=60 && temp <=100 && isSummer)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
//_________________________________________________________________________________________________________________________________________________________
//#4
        public int CaughtSpeeding (int speed, bool isBirthday)
        {
            //int noticket = 0;
            //int smallticket = 1;
            //int bigticket = 2;

            if (speed <= 60 && !isBirthday)
            {

                return 0;
            }
            else if (speed <= 65 && isBirthday)
            {

                return 0;
            }
            else if (speed >= 61 && speed <= 80 && !isBirthday)
            {
                return 1;
            }

            else if (speed >= 66 && speed <= 80 && isBirthday)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
//_________________________________________________________________________________________________________________________________________________________
//#5
        public int SkipSum(int a, int b)


        {
            int sum = a + b;

            if (sum >= 10 && sum <=19 )
            {
                int altSum = 20;
                return altSum;
            }
            else
            {
                
                return sum;
            }
        }

//_________________________________________________________________________________________________________________________________________________________
//#6
         public string AlarmClock(int day, bool IsVacation)//No Vacation & Weekday = 7; No Vacation & Weekend = 10, Vacation & Weekday = 10, Vacation and Weekend = off
        {
             if ((day == 0 || day == 6) && IsVacation)
             {
                 string alarm = "Off";
                 return alarm;
             }
             else if((day > 0 && day < 6) && IsVacation)
            {
                string alarm1 = "10:00";
                 return alarm1;
            }
            else if((day == 0 || day == 6) && !IsVacation)
            {
                string alarm2 = "10:00";
                 return alarm2;
            }
           else 
            {
                string alarm3 = "7:00";
                 return alarm3;
            }
             }
        
        
//_________________________________________________________________________________________________________________________________________________________
//#7
        public bool LoveSix (int a, int b)

        {
            int sum = a + b;
            if (sum == 6)
            {
                return true;
            }
            else if ( a -  b == 6 || b - a == 6)
            {
                return true;
            }
            else if ( a == 6 ||  b == 6)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

//_________________________________________________________________________________________________________________________________________________________
//#8
        public bool InRange(int n, bool outsideMode)
        {
            if ((n >= 1 && n <= 10) && !outsideMode)
            {
                return true;
            }
            else if ((n <= 1 || n>10) && outsideMode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

//_________________________________________________________________________________________________________________________________________________________
//#9
        public bool SpecialEleven(int a, bool expected)
        {
            if (a < 0)
            {
                return false;
            }
            else if (a%11==0 || a%11==1)
            {
                return true;
            }
            else 
            {
                return false;
            }
            
        }

//__________________________________________________________________________________________________________________________________________________________
//#10
        public bool Mod20(int n)
        {
            if (n>0&& n%20 == 1 || n%20 == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
//___________________________________________________________________________________________________________________________________________________________
//#11
        public bool Mod35(int a, bool expected)
        {
            if (a < 0)
            {
                return false;
            }
            else if (a % 3 == 0 && a % 5 == 0)
            {
                return false;
            }
            else if (a % 3 == 0 || a % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

//_________________________________________________________________________________________________________________________________________________________
//#12
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep)
            {
                return false;
            }
            else if (isMorning && !isMom && !isAsleep)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

//_________________________________________________________________________________________________________________________________________________________
//#13
        public bool TwoisOne(int a, int b, int c, bool expected)
        {
            if (a + b == c)
            {
                return true;
            }
            else if (b + c == a)
            {
                return true;
            }
            else if (c + a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

//_________________________________________________________________________________________________________________________________________________________
//#14

        public bool AreInOrder(int a, int b, int c, bool isbOk, bool expected)
        {
            if (!isbOk && (b > a && c > b))
            {
                return true;
            }

            else if (isbOk && c > b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


//_________________________________________________________________________________________________________________________________________________________
//#15
        public bool InOrderEqual(int a, int b, int c, bool equalOk, bool expected)
        {
            if (a <= b && b <= c && equalOk)
            {
                return true;
            }
            else if (a < b && b < c )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
//________________________________________________________________________________________________________________________________________________________________________________________
//#16
        public bool LastDigit(int a, int b, int c, bool expected)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                return false;
            }
            else if (a%10 == b%10 || b%10 == c%10 || a%10 == c%10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
//________________________________________________________________________________________________________________________________________________________________________________________
//#17

            public int RollDice(int die1, int die2, bool noDoubles, int expected)
            {
                int sum = die1 + die2;
            
                
                if (!noDoubles)
                {
                    return sum;
                }
                else if (die1 == die2 && die1!= 6 && noDoubles)
                {
                    int die1add = die1 + 1;
                    int altsum = die1add + die2;
                    return altsum;
                }
                else if (die1 == die2 && die1 == 6 && noDoubles)
                {
                    int die1is1 = 1;
                    int altsum2 = die1is1 + die2;
                    return altsum2;
                }
                else
                {
                    return sum;
                }
              
            }

//_________________________________________________________________________________________________________________________________________________________________________________________
    } 
}
