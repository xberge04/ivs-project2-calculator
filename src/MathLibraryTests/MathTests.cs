using System;
using calculator.Math_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLibraryTests
{

    [TestClass]
    public class MathTests
    {
        /// Exactness for tests with double numbers
		public double Exactness = 0.000001;
        calculator.Math_Library.Math math = new calculator.Math_Library.Math();

        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(0, math.Add(0, 0));
            Assert.AreEqual(20, math.Add(5, 15));
            Assert.AreEqual(-12, math.Add(60, -72));
            Assert.AreEqual(-10, math.Add(-6, -4));
            Assert.AreEqual(48, math.Add(50, -2));
            Assert.AreEqual(-4000000, math.Add(-7000000, 3000000));
            Assert.AreEqual(128, math.Add(-128, 256));
            Assert.AreEqual(4.2, math.Add(6, -1.8), Exactness);
            Assert.AreEqual(0.5, math.Add(0.15, 0.35), Exactness);
            Assert.AreEqual(10.65, math.Add(10.1, 0.55), Exactness);
            Assert.AreEqual(-0.32564, math.Add(0, -0.32564), Exactness);
            Assert.AreEqual(2.3256, math.Add(2, 0.3256), Exactness);
            Assert.AreEqual(200000000, math.Add(100000000, 100000000));
        }

        /// <summary>
        /// Substraction test
        /// </summary>
        [TestMethod]
        public void SubTest()
        {
            Assert.AreEqual(0, math.Sub(0, 0));
            Assert.AreEqual(20, math.Sub(5, -15));
            Assert.AreEqual(-12, math.Sub(60, 72));
            Assert.AreEqual(-2, math.Sub(-6, -4));
            Assert.AreEqual(25, math.Sub(50, 25));
            Assert.AreEqual(4000000, math.Sub(7000000, 3000000));
            Assert.AreEqual(-9000000, math.Sub(-7000000, 2000000));
            Assert.AreEqual(-128, math.Sub(128, 256));
            Assert.AreEqual(4.2, math.Sub(6, 1.8), Exactness);
            Assert.AreEqual(-0.2, math.Sub(0.15, 0.35), Exactness);
            Assert.AreEqual(10.5, math.Sub(10, -0.5), Exactness);
            Assert.AreEqual(-0.32564, math.Sub(0, 0.32564), Exactness);
            Assert.AreEqual(2.3256, math.Sub(2, -0.3256), Exactness);
            Assert.AreEqual(0, math.Sub(100000000, 100000000));
        }

        /// <summary>
        /// Multiplication test
        /// </summary>
        [TestMethod]
        public void MulTest()
        {
            Assert.AreEqual(0, math.Mul(0, 0));
            Assert.AreEqual(30, math.Mul(5, 6));
            Assert.AreEqual(10, math.Mul(-2, -5));
            Assert.AreEqual(-10, math.Mul(2, -5));
            Assert.AreEqual(-10, math.Mul(-2, 5));
            Assert.AreEqual(0, math.Mul(3516, 0));
            Assert.AreEqual(0, math.Mul(0, 3516));
            Assert.AreEqual(0.25, math.Mul(0.5, 0.5), Exactness);
            Assert.AreEqual(-0.25, math.Mul(-0.5, 0.5), Exactness);
            Assert.AreEqual(0.23545135, math.Mul(1, 0.23545135), Exactness);
            Assert.AreEqual(200000000, math.Mul(2, 100000000));
            Assert.AreEqual(200000000, math.Mul(-2, -100000000));
        }

        /// <summary>
        /// Division test
        /// </summary>
        [TestMethod]
        public void DivTest()
        {
            Assert.AreEqual(0, math.Div(0, 5));
            Assert.AreEqual(1, math.Div(10, 10));
            Assert.AreEqual(1, math.Div(-10, -10));
            Assert.AreEqual(-1, math.Div(-10, 10));
            Assert.AreEqual(-1, math.Div(10, -10));
            Assert.AreEqual(-5, math.Div(-100000000, 20000000));
            Assert.AreEqual(0.5, math.Div(1, 2), Exactness);
            Assert.AreEqual(-0.625, math.Div(-5, 8), Exactness);
            Assert.AreEqual(0.5, math.Div(128, 256));
            Assert.AreEqual(6.4127039, math.Div(42.6541, 6.6515), Exactness);
            Assert.AreEqual(4, math.Div(1, 0.25), Exactness);


            //dividing by zero
            string noFailMessage = "No exception message after dividing by zero.";

            try
            {
                math.Div(2, 0);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// Root test
        /// </summary>
        [TestMethod]
        public void RootTest()
        {
            Assert.AreEqual(0, math.Root(0, 42));
            Assert.AreEqual(0, math.Root(0, 0.5), Exactness);
            Assert.AreEqual(2, math.Root(32, 5));
            Assert.AreEqual(0.5, math.Root(8, -3), Exactness);
            Assert.AreEqual(500, math.Root(3.2768e-41, -15), Exactness);
            Assert.AreEqual(2.5, math.Root(15.625, 3), Exactness);
            Assert.AreEqual(25, math.Root(0.000064, -3), Exactness);
            Assert.AreEqual(2, math.Root(1024, 10));
            Assert.AreEqual(10, math.Root(0.1, -1), Exactness);
            Assert.AreEqual(1, math.Root(1, 42));
            Assert.AreEqual(100000000, math.Root(100000000, 1));

            //NaN result
            string noFailMessage = "No exception message when result was NaN.";

            try
            {
                math.Root(-1, 10);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }
            try
            {
                math.Root(0, -1);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Power test
        /// </summary>
        [TestMethod]
        public void PowTest()
        {
            Assert.AreEqual(0, math.Pow(0, 42));
            Assert.AreEqual(1, math.Pow(42, 0));
            Assert.AreEqual(1, math.Pow(1, 42));
            Assert.AreEqual(1, math.Pow(-1, 42));
            Assert.AreEqual(-1, math.Pow(-1, 41));
            Assert.AreEqual(36, math.Pow(6, 2));
            Assert.AreEqual(1000, math.Pow(10, 3));
            Assert.AreEqual(100000000, math.Pow(100000000, 1));
            Assert.AreEqual(1024, math.Pow(2, 10));
            Assert.AreEqual(59049, math.Pow(-3, 10));
            Assert.AreEqual(15.625, math.Pow(2.5, 3), Exactness);

            //NaN result
            string noFailMessage = "No exception message when result was NaN.";

            try
            {
                math.Pow(-1, 0.5);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }
            try
            {
                math.Pow(0, -1);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Factorial test
        /// </summary>
        [TestMethod]
        public void FactTest()
        {
            Assert.AreEqual((ulong)720, math.Fact(6));
            Assert.AreEqual((ulong)3628800, math.Fact(10));
            Assert.AreEqual((ulong)1, math.Fact(1));
            Assert.AreEqual((ulong)1, math.Fact(0));

            //NaN result
            string noFailMessage = "No exception message when result was NaN.";

            try
            {
                math.Fact(-1);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Logarithm test
        /// </summary>
        [TestMethod]
        public void LogTest()
        {
            Assert.AreEqual(0, math.Log(10, 1));
            Assert.AreEqual(10, math.Log(2, 1024));
            Assert.AreEqual(1, math.Log(0.5, 0.5), Exactness);
            Assert.AreEqual(1.283513, math.Log(100, 369), Exactness);
            Assert.AreEqual(-4.923343, math.Log(0.8, 3), Exactness);
            Assert.AreEqual(5.395507, math.Log(0.8, 0.3), Exactness);
            Assert.AreEqual(-0.748070, math.Log(5, 0.3), Exactness);

            //NaN result
            string noFailMessage = "No exception message when result was NaN.";

            try
            {
                math.Log(0, 1);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }

            try
            {
                math.Log(1, 10);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }

            try
            {
                math.Log(-3, 10);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }

            try
            {
                math.Log(10, -3);
                Assert.Fail(noFailMessage);
            }
            catch (Exception)
            {
            }
        }
    }
}

