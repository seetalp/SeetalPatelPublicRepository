using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using StringWarmUps.BLL;
using NUnit.Framework;

namespace StringWarmUpsMethods
{
    [TestFixture]

    public class StringsTestsRunner
    {
        //____________________________________________________________________________________________________________________________________________________________________________
        //#1

        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice", "Hello Alice!")]
        [TestCase("X", "Hello X!")]
        public void SayHiTest(string name, string expected)
        {
            StringTestMethods sayhi = new StringTestMethods();
            string actual = sayhi.SayHiMethod(name, expected);

            Assert.AreEqual(expected, actual);
        }

        //____________________________________________________________________________________________________________________________________________________________________________
        //#2

        [TestCase("Hi", "Bye", "HiByeByeHi")]
        [TestCase("Yo", "Alice", "YoAliceAliceYo")]
        [TestCase("What", "Up", "WhatUpUpWhat")]
        public void AbbaTest(string a, string b, string expected)
        {
            StringTestMethods abba = new StringTestMethods();
            string actual = abba.AbbaMethod(a, b, expected);

            Assert.AreEqual(expected, actual);
        }

        //____________________________________________________________________________________________________________________________________________________________________________
        //#3

        [TestCase("i", "Yay", "<i>Yay</i>")]
        [TestCase("i", "Hello", "<i>Hello</i>")]
        [TestCase("cite", "Yay", "<cite>Yay</cite>")]
        public void MakeTagsTest(string a, string b, string expected)
        {
            StringTestMethods tags = new StringTestMethods();
            string actual = tags.MakeTags(a, b, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#4


        [TestCase("<<>>", "Yay", "<<Yay>>")]
        [TestCase("<<>>", "WooHoo", "<<WooHoo>>")]
        [TestCase("[[]]", "Word", "[[Word]]")]
        public void InsertWordTest(string container, string word, string expected)
        {
            StringTestMethods contains = new StringTestMethods();
            string actual = contains.InsertWord(container, word, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#5

        [TestCase("Hello", "lololo")]
        [TestCase("ab", "ababab")]
        [TestCase("Hi", "HiHiHi")]
        public void MultipleEndingsTest(string str, string expected)
        {
            StringTestMethods endings = new StringTestMethods();
            string actual = endings.MultipleEndings(str, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#6

        [TestCase("WooHoo", "Woo")]
        [TestCase("HelloThere", "Hello")]
        [TestCase("abcdef", "abc")]
        public void FirstHalfTest(string str, string expected)
        {
            StringTestMethods half = new StringTestMethods();
            string actual = half.FirstHalf(str, expected);

            Assert.AreEqual(expected, actual);
        }




        //____________________________________________________________________________________________________________________________________________________________________________
        //#7
        [TestCase("Hello", "ell")]
        [TestCase("java", "av")]
        [TestCase("coding", "odin")]
        public void TrimOneTest(string str, string expected)
        {
            StringTestMethods trim = new StringTestMethods();
            string actual = trim.TrimOne(str, expected);

            Assert.AreEqual(expected, actual);
        }



        ////____________________________________________________________________________________________________________________________________________________________________________
        //#8

        [TestCase("Hello", "hi", "hiHellohi")]
        [TestCase("hi", "Hello", "hiHellohi")]
        [TestCase("aaa", "b", "baaab")]
        public void LonginMiddleTest(string a, string b, string expected)
        {
            StringTestMethods middle = new StringTestMethods();
            string actual = middle.LonginMiddle(a, b, expected);

            Assert.AreEqual(expected, actual);
        }


        ////____________________________________________________________________________________________________________________________________________________________________________
        //#9

        [TestCase("Hello", "lloHe")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateLeft2Test(string str, string expected)
        {
            StringTestMethods rotate = new StringTestMethods();
            string actual = rotate.RotateLeft2(str, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#10
        [TestCase("Hello", "loHel")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateRight2Test(string str, string expected)
        {
            StringTestMethods rotate = new StringTestMethods();
            string actual = rotate.RotateRight2(str, expected);

            Assert.AreEqual(expected, actual);
        }



        //____________________________________________________________________________________________________________________________________________________________________________
        //#11
        [TestCase("Hello", true, "H")]
        [TestCase("Hello", false, "o")]
        [TestCase("oh", true, "o")]
        public void TakeOneTest(string str, bool isfromFront, string expected)
        {
            StringTestMethods take = new StringTestMethods();
            string actual = take.TakeOne(str, isfromFront, expected);

            Assert.AreEqual(expected, actual);
        }




        //____________________________________________________________________________________________________________________________________________________________________________
        //#12

        [TestCase("string", "ri")]
        [TestCase("code", "od")]
        [TestCase("Practice", "ct")]
        public void MiddleTwoTest(string str, string expected)
        {
            StringTestMethods middle = new StringTestMethods();
            string actual = middle.MiddleTwo(str, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#13

        [TestCase("oddly", true)]
        [TestCase("y", false)]
        [TestCase("oddy", false)]
        public void EndsyWithLyTest(string str, bool expected)
        {
            StringTestMethods ends = new StringTestMethods();
            bool actual = ends.EndsWithLy(str, expected);

            Assert.AreEqual(expected, actual);
        }



        //____________________________________________________________________________________________________________________________________________________________________________
        //#14
        [TestCase("Hello", 2, "Helo")]
        [TestCase("Chocolate", 3, "Choate")]
        [TestCase("Chocolate", 1, "Ce")]
        public void FrontandBackTest(string str, int n, string expected)
        {
            StringTestMethods back = new StringTestMethods();
            string actual = back.FrontandBack(str, n, expected);

            Assert.AreEqual(expected, actual);
        }

        //____________________________________________________________________________________________________________________________________________________________________________
        //#15
        [TestCase("java", 0, "ja")]
        [TestCase("java", 2, "va")]
        [TestCase("java", 3, "ja")]
        public void TakeTwoFromPositionTest(string str, int n, string expected)
        {
            StringTestMethods take = new StringTestMethods();
            string actual = take.TakeTwoFromPosition(str, n, expected);

            Assert.AreEqual(expected, actual);
        }

        //____________________________________________________________________________________________________________________________________________________________________________
        ////#16

        [TestCase("badxx", true)]
        [TestCase("xbadxx", true)]
        [TestCase("xxbadxx", false)]
        public void HasBadTest(string str, bool expected)
        {
            StringTestMethods test = new StringTestMethods();
            bool actual = test.HasBadTest(str, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#17

        [TestCase("hello", "he")]
        [TestCase("hi", "hi")]
        [TestCase("h", "h@")]
        public void AtFirsttest(string str, string expected)
        {
            StringTestMethods first = new StringTestMethods();
            string actual = first.AtFirst(str, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#18

        [TestCase("last", "chars", "ls")]
        [TestCase("yo", "mama", "ya")]
        [TestCase("hi", "", "h@")]
        public void LastCharsTest(string a, string b, string expected)
        {
            StringTestMethods chars = new StringTestMethods();
            string actual = chars.LastChars(a, b, expected);

            Assert.AreEqual(expected, actual);
        }



        //____________________________________________________________________________________________________________________________________________________________________________
        //#19

        [TestCase("abc", "cat", "abcat")]
        [TestCase("dog", "cat", "dogcat")]
        [TestCase("abc", "", "abc")]
        public void ConCatTest(string a, string b, string expected)
        {
            StringTestMethods cats = new StringTestMethods();
            string actual = cats.ConCat(a, b, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#20

        [TestCase("coding", "codign")]
        [TestCase("cat", "cta")]
        [TestCase("ab", "ba")]
        public void SwapLastTest(string str, string expected)
        {
            StringTestMethods swap = new StringTestMethods();
            string actual = swap.SwapLast(str, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
        //#21
        [TestCase("edited", true)]
        [TestCase("edit", false)]
        [TestCase("ed", true)]
        public void FrontAgainTest(string str, bool expected)
        {
            StringTestMethods front = new StringTestMethods();
            bool actual = front.FrontAgain(str, expected);

            Assert.AreEqual(expected, actual);
        }

        //____________________________________________________________________________________________________________________________________________________________________________
        //#22
        [TestCase("Hello", "Hi", "loHi")]
        [TestCase("Hello", "java", "ellojava")]
        [TestCase("java", "Hello", "javaello")]
        public void MinCatTest(string a, string b, string expected)
        {
            StringTestMethods minc = new StringTestMethods();
            string actual = minc.MinCat(a, b, expected);

            Assert.AreEqual(expected, actual);
        }


        //____________________________________________________________________________________________________________________________________________________________________________
            //#23
        [TestCase("Hello", "llo")]
        [TestCase("away", "aay")]
        [TestCase("abed", "abed")]
        public void TweakFrontTest(string str, string expected)
        {
            StringTestMethods tweak = new StringTestMethods();
            string actual = tweak.TweakFront(str, expected);

            Assert.AreEqual(expected, actual);
        }



            //____________________________________________________________________________________________________________________________________________________________________________
            //#24
        [TestCase("xHix", "Hi")]
        [TestCase("xHi", "Hi")]
        [TestCase("Hxix", "Hxi")]
        public void StripXTest(string str, string expected)
        {
            StringTestMethods strip = new StringTestMethods();
            string actual = strip.StripX(str, expected);

            Assert.AreEqual(expected, actual);
        }



            //____________________________________________________________________________________________________________________________________________________________________________


        }
    }
