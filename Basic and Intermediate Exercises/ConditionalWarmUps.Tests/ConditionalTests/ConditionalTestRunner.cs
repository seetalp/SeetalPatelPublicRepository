using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConditionalWarmUps.BLL;

namespace ConditionalTests
{
    [TestFixture]

    public class ConditionalTestRunner
    {

//__________________________________________________________________________________________________________________________________________________________________
 //#1
        [TestCase(true, true, true)]
        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        public void TroubleTest(bool aSmile, bool bSmile, bool expected)
        {
            ConditionalTestMethods introuble = new ConditionalTestMethods();
            bool actual = introuble.Trouble(aSmile, bSmile, expected);

            Assert.AreEqual(expected, actual);
        }

//__________________________________________________________________________________________________________________________________________________________________
//#2

        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, true)]
        public void CanSleepInTests(bool isWeekday, bool isVacation, bool expected)
        {
            ConditionalTestMethods sleep = new ConditionalTestMethods();
            bool actual = sleep.CanSleepIn(isWeekday, isVacation, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#3

        [TestCase(1,2,3)]
        [TestCase(3,2,5)]
        [TestCase(2,2,8)]
        public void SumDoubleTest(int a, int b, int expected)
        {
            ConditionalTestMethods twosum = new ConditionalTestMethods();
            int actual = twosum.SumDouble(a, b, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#4

        [TestCase(23, 4)]
        [TestCase(10, 11)]
        [TestCase(21, 0)]
        public void GetDifferenceTest(int n, int expected)
        {
            ConditionalTestMethods getdiff = new ConditionalTestMethods();
            int actual = getdiff.GetDifference(n, expected);

            Assert.AreEqual(expected, actual);
        }

//___________________________________________________________________________________________________________________________________________________________________
//#5

        [TestCase(true, 6, true)]
        [TestCase(true, 7, false)]
        [TestCase(false, 6, false)]
        public void ParrotTroubleTest(bool isTalking, int hour, bool expected)
        {
            ConditionalTestMethods parrot = new ConditionalTestMethods();
            bool actual = parrot.ParrotTrouble(isTalking, hour, expected);

            Assert.AreEqual(expected, actual);
        }



//___________________________________________________________________________________________________________________________________________________________________
//#6

        [TestCase(9, 10, true)]
        [TestCase(9, 9, false)]
        [TestCase(1, 9, true)]
        public void Makes10Test(int a, int b, bool expected)
        {
            ConditionalTestMethods makes = new ConditionalTestMethods();
            bool actual = makes.Makes10(a, b, expected);

            Assert.AreEqual(expected, actual);
        }



//___________________________________________________________________________________________________________________________________________________________________
//#7

        [TestCase(103, true)]
        [TestCase(90, true)]
        [TestCase(89, false)]
        public void NearHundredTest(int n, bool expected)
        {
            ConditionalTestMethods hundred = new ConditionalTestMethods();
            bool actual = hundred.NearHundred(n, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#8

        [TestCase(1, -1, false, true)]
        [TestCase(-1, 1, false, true)]
        [TestCase(-4, -5, true, true)]
        public void PosNegTest(int a, int b, bool isNegative, bool expected)
        {
            ConditionalTestMethods posneg = new ConditionalTestMethods();
            bool actual = posneg.PosNegMethod(a, b, isNegative, expected);

            Assert.AreEqual(expected, actual);
        }



//___________________________________________________________________________________________________________________________________________________________________
//#9

        [TestCase("candy", "not candy")]
        [TestCase("x", "not x")]
        [TestCase("not bad", "not bad")]
        public void NotStringTest(string str, string expected)
        {
            ConditionalTestMethods strings = new ConditionalTestMethods();
            string actual = strings.NotString(str, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#10

        [TestCase("kitten", 1, "ktten")]
        [TestCase("kitten", 0, "itten")]
        [TestCase("kitten", 4, "kittn")]
        public void MissingCharTest(string str, int n, string expected)
        {
            ConditionalTestMethods kittenstr = new ConditionalTestMethods();
            string actual = kittenstr.MissingChar(str, n, expected);

            Assert.AreEqual(expected, actual);

        }

//___________________________________________________________________________________________________________________________________________________________________
//#11

        [TestCase("code", "eodc")]
        [TestCase("a", "a")]
        [TestCase("ab", "ba")]
        public void FrontBackTest(string str, string expected)
        {
            ConditionalTestMethods front = new ConditionalTestMethods();
            string actual = front.FrontBack(str, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#12

        [TestCase("Microsoft", "MicMicMic")]
        [TestCase("Chocolate", "ChoChoCho")]
        [TestCase("at", "atatat")]
        public void FrontThreeTest(string str, string expected)
        {
            ConditionalTestMethods front = new ConditionalTestMethods();
            string actual = front.FrontThree(str, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#13

        [TestCase("cat", "tcatt")]
        [TestCase("Hello", "oHelloo")]
        [TestCase("a", "aaa")]
        public void BackAroundTest(string str, string expected)
        {
            ConditionalTestMethods back = new ConditionalTestMethods();
            string actual = back.BackAround(str, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#14

        [TestCase(3, true)]
        [TestCase(10, true)]
        [TestCase(8, false)]
        public void Multiple3or5Test(int n, bool expected)
        {
            ConditionalTestMethods mult35 = new ConditionalTestMethods();
            bool actual = mult35.Multiple3or5(n, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#15

        [TestCase("hi there", true)]
        [TestCase("hi", true)]
        [TestCase("high up", false)]
        public void StartHiTest(string str, bool expected)
        {
            ConditionalTestMethods hi = new ConditionalTestMethods();
            bool actual = hi.StartHi(str, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________

//#16

        [TestCase(120, -1, true)]
        [TestCase(-1, 120, true)]
        [TestCase(2, 120, false)]
        public void IcyHotTest(int temp1, int temp2, bool expected)
        {
            ConditionalTestMethods icy = new ConditionalTestMethods();
            bool actual = icy.IcyHot(temp1, temp2, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________

//#17

        [TestCase(12, 99, true)]
        [TestCase(21, 12, true)]
        [TestCase(8, 99, false)]
        public void between10and20Test(int a, int b, bool expected)
        {
            ConditionalTestMethods between = new ConditionalTestMethods();
            bool actual = between.between10and20(a,  b, expected);

            Assert.AreEqual(expected, actual);
        }




        //___________________________________________________________________________________________________________________________________________________________________

        //#18

        [TestCase(13, 20, 10, true)]
        [TestCase(20, 19, 10, true)]
        [TestCase(20, 10, 12, false)]
        public void HasTeenTest(int a, int b, int c, bool expected)
        {
            ConditionalTestMethods teen = new ConditionalTestMethods();
            bool actual = teen.HasTeen(a, b, c, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#19

        [TestCase(13, 99, true)]
        [TestCase(21, 19, true)]
        [TestCase(13, 13, false)]
        public void SoAloneTest(int a, int b, bool expected)
        {
            ConditionalTestMethods soa = new ConditionalTestMethods();
            bool actual = soa.SoAlone(a, b, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#20

        [TestCase("adelbc", "abc")]
        [TestCase("adelHello", "aHello")]
        [TestCase("adedbc", "adedbc")]
        public void RemoveDelTest(string str, string expected)
        {
            ConditionalTestMethods remove = new ConditionalTestMethods();
            string actual = remove.RemoveDel(str, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#21

        [TestCase("mix snacks", true)]
        [TestCase("pix snacks", true)]
        [TestCase("piz snacks", false)]
        public void IxStartTest(string str, bool expected)
        {
            ConditionalTestMethods ix = new ConditionalTestMethods();
            bool actual = ix.IxStart(str, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#22

        [TestCase("ozymandias", "oz")]
        [TestCase("bzoo", "z")]
        [TestCase("oxx", "o")]
        public void StartOzTest(string str, string expected)
        {
            ConditionalTestMethods oz = new ConditionalTestMethods();
            string actual = oz.StartOz(str, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#23

        [TestCase(1, 2, 3, 3)]
        [TestCase(1, 3, 2, 3)]
        [TestCase(3, 2, 1, 3)]
        public void MaxTest(int a, int b, int c, int expected)
        {
            ConditionalTestMethods maxt = new ConditionalTestMethods();
            int actual = maxt.Max(a, b, c, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#24

        [TestCase(8, 13, 8)]
        [TestCase(13, 8, 8)]
        [TestCase(13, 7, 0)]
        public void CloserTest(int a, int b, int expected)
        {
            ConditionalTestMethods close = new ConditionalTestMethods();
            int actual = close.Closer(a, b, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#25

        [TestCase("Hello", true)]
        [TestCase("Heelle", true)]
        [TestCase("Heelele", false)]
        public void GotETest(string str, bool expected)
        {
            ConditionalTestMethods got = new ConditionalTestMethods();
            bool actual = got.GotE(str, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________________________________________________________
//#26

        [TestCase("Hello", "HeLLO")]
        [TestCase("hi there", "hi thERE")]
        [TestCase("hi", "HI")]
        public void EndUpTest(string str, string expected)
        {
            ConditionalTestMethods end = new ConditionalTestMethods();
            string actual = end.EndUp(str, expected);

            Assert.AreEqual(expected, actual);
        }



//___________________________________________________________________________________________________________________________________________________________________
//#27
        [TestCase("Miracle", 2, "Mrce")]
        [TestCase("abcdefg", 2, "aceg")]
        [TestCase("abcdefg", 3, "adg")]
        public void EveryNthTest(string str, int n, string expected)
        {
            ConditionalTestMethods every = new ConditionalTestMethods();
            string actual = every.EveryNth(str, n, expected);

            Assert.AreEqual(expected, actual);
        }

    }
}
