using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ArrayWarmUps.BLL;

namespace MethodsforTests
{
    [TestFixture]
    class ArrayTestRunner
    {

//___________________________________________________________________________________________________________________
//#1
        [TestCase(new int [] {1,2,6}, true, TestName = "Test 1")]
        [TestCase(new int [] {6,1,2,3}, true, TestName = "Test 2")]
        [TestCase(new int [] {13,6,1,2,3}, false, TestName = "Test 3")]
        public void FirstLastSixTest(int[] numbers, bool expected)
        { 
        ArrayMethods six = new ArrayMethods();
        bool actual = six.FirstLastSix(numbers);

        Assert.AreEqual(expected, actual);
        }
//___________________________________________________________________________________________________________________
//#2        
        [TestCase(new int [] {1,2,3}, false, TestName = "Test 1")]
        [TestCase(new int [] {1,2,3,1}, true, TestName = "Test 2")]
        [TestCase(new int [] {1,2,1}, true, TestName = "Test 3")]
        public void SameFirstLastTest(int[] numbers, bool expected)
        { 
        ArrayMethods six = new ArrayMethods();
        bool actual = six.SameFirstLast(numbers);

        Assert.AreEqual(expected, actual);
        }
//___________________________________________________________________________________________________________________    
//#3
        [TestCase(3, new int[] { 3, 1, 4 }, TestName = "Test 1")]
        
        public void MakePiTest(int n, int [] expected)
        {
            ArrayMethods make = new ArrayMethods();
            int [] actual = make.MakePi(n);

            Assert.AreEqual(expected, actual);
        }
//___________________________________________________________________________________________________________________        
// #4
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 7, 3 }, true, TestName = "Test 1")]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 7, 3, 2 }, false, TestName = "Test 2")]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 3 }, true, TestName = "Test 3")]
        public void CommonEndTest(int[] a, int[] b, bool expected)
        {
            ArrayMethods common = new ArrayMethods();
            bool actual = common.CommonEnd(a, b, expected);

            Assert.AreEqual(expected, actual);
        }


//___________________________________________________________________________________________________________________        
// #5 


        [TestCase(new int[] { 1, 2, 3 }, 6, TestName = "Test 1")]
        [TestCase(new int[] { 5, 11, 2 }, 18, TestName = "Test 2")]
        [TestCase(new int[] { 7, 0, 0 }, 7, TestName = "Test 3")]
        public void SumTest(int[] numbers, int expected)
        {
            ArrayMethods sumofall = new ArrayMethods();
            int actual = sumofall.SumMethod(numbers, expected);

            Assert.AreEqual(expected, actual);
        }





//___________________________________________________________________________________________________________________        
// #6

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3, 1 }, TestName = "Test 1")]
        [TestCase(new int[] { 5, 11, 9 }, new int[] { 11, 9, 5 }, TestName = "Test 2")]
        [TestCase(new int[] { 7, 0, 0 }, new int[] { 0, 0, 7 }, TestName = "Test 3")]
        public void RotateLeftTest(int[] numbers , int[] expected)
        {
            ArrayMethods rotate = new ArrayMethods();
            int [] actual = rotate.RotateLeft(numbers, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________        
// #7

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 }, TestName = "Test 1")]
        public void ReverseTest(int[] numbers, int[] expected)
        {
            ArrayMethods rev = new ArrayMethods();
            int[] actual = rev.Reverse(numbers, expected);

            Assert.AreEqual(expected, actual);
        }




//___________________________________________________________________________________________________________________        
// #8


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 3, 3 }, TestName = "Test 1")]
        [TestCase(new int[] { 11, 5, 9 }, new int[] { 11, 11, 11 }, TestName = "Test 2")]
        [TestCase(new int[] { 2, 11, 3 }, new int[] { 3, 3, 3 }, TestName = "Test 3")]
        public void HigherWinsTest(int[] numbers, int[] expected)
        {
            ArrayMethods higher = new ArrayMethods();
            int[] actual = higher.HigherWins(numbers, expected);

            Assert.AreEqual(expected, actual);
        }




        //___________________________________________________________________________________________________________________        
        // #9

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[]{2, 5}, TestName = "Test 1")]
        [TestCase(new int[] { 7, 7, 7 }, new int[] { 3, 8, 0 }, new int[]{7, 8}, TestName = "Test 2")]
        [TestCase(new int[] { 5, 2, 9 }, new int[] { 1, 4, 5 }, new int[]{ 2, 4 }, TestName = "Test 3")]
        public void GetMiddleTest(int[] a, int[] b, int[] expected)
        {
            ArrayMethods middle = new ArrayMethods();
            int[] actual = middle.GetMiddle(a, b, expected);

            Assert.AreEqual(expected, actual);
        }




        //___________________________________________________________________________________________________________________        
        // #10

        [TestCase(new int[] { 2, 5 }, true, TestName = "Test 1")]
        [TestCase(new int[] { 4, 3 }, true, TestName = "Test 2")]
        [TestCase(new int[] { 7, 5 }, false, TestName = "Test 3")]
        public void HasEvenTest(int[] numbers, bool expected)
        {
            ArrayMethods even = new ArrayMethods();
            bool actual = even.HasEven(numbers);

            Assert.AreEqual(expected, actual);
        }




        //___________________________________________________________________________________________________________________        
        // #11


        [TestCase(new int[] { 4, 5, 6 }, new int[] { 0, 0, 0, 0, 0, 6 }, TestName = "Test 1")]
        [TestCase(new int[] { 1, 2 }, new int[] { 0, 0, 0, 2 }, TestName = "Test 2")]
        [TestCase(new int[] { 3 }, new int[] { 0, 3 },TestName = "Test 3")]
        public void KeepLastTest(int[] numbers, int[] expected)
        {
            ArrayMethods middle = new ArrayMethods();
            int[] actual = middle.KeepLast(numbers, expected);

            Assert.AreEqual(expected, actual);
        }





        //___________________________________________________________________________________________________________________        
        // #12

        [TestCase(new int[] { 2, 2, 3 }, true, TestName = "Test 1")]
        [TestCase(new int[] { 3, 4, 5, 3 }, true, TestName = "Test 2")]
        [TestCase(new int[] { 2, 3, 2, 2 }, false, TestName = "Test 3")]
        public void Double23Test(int[] numbers, bool expected)
        {
            ArrayMethods doubles = new ArrayMethods();
            bool actual= doubles.Double23(numbers, expected);

            Assert.AreEqual(expected, actual);
        }




        ////___________________________________________________________________________________________________________________        
        //// #13

        [TestCase(new int[] {  1, 2, 3  }, new int[] { 1, 2, 0 }, TestName = "Test 1")]
        [TestCase(new int[] {  2, 3, 5  }, new int[] { 2, 0, 5 }, TestName = "Test 2")]
        [TestCase(new int[] {  1, 2, 1  }, new int[] { 1, 2, 1 }, TestName = "Test 3")]
        public void Fix23Test(int[] numbers, int[] expected)
        {
            ArrayMethods fix = new ArrayMethods();
            int[] actual = fix.Fix23(numbers, expected);

            Assert.AreEqual(expected, actual);
        }




        //___________________________________________________________________________________________________________________        
        // #14

        [TestCase(new int[] { 1, 3, 4, 5 }, true, TestName = "Test 1")]
        [TestCase(new int[] { 2, 1, 3, 4, 5 }, true, TestName = "Test 2")]
        [TestCase(new int[] { 1, 1, 1 }, false, TestName = "Test 3")]
        public void Unlucky1Test(int[] numbers, bool expected)
        {
           ArrayMethods fix = new ArrayMethods();
           bool actual = fix.UnluckyOne(numbers, expected);

            Assert.AreEqual(expected, actual);
        }


        //___________________________________________________________________________________________________________________        
        // #15


        [TestCase(new int[] {4, 5}, new int[] {1, 2, 3}, new int[] {4, 5}, TestName = "Test 1")]
        [TestCase(new int[] { 4 }, new int[] { 1, 2, 3 }, new int[] { 4, 1 }, TestName = "Test 1")]
        [TestCase(new int[] { }, new int[] { 1, 2 }, new int[] { 1, 2 }, TestName = "Test 1")]
        public void make2Test(int[] a, int[] b, int[] expected)
        {
            ArrayMethods make = new ArrayMethods();
            int [] actual = make.make2(a, b);

            Assert.AreEqual(expected, actual);
        }


        //___________________________________________________________________________________________________________________        

    }
}
