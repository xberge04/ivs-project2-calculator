using System;
using MathLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLibraryTests
{

    [TestClass]
    public class MathTests
    {
        /// Exactness for tests with double numbers
		private double Exactness = 0.000001;

        /// <summary>
		/// MathTests construct.
		/// </summary>
        [TestInitialize]
        public MathTests()
        {
            math = new Math();
        }

        /// <summary>
        /// Addition test
        /// </summary>
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
            Assert.AreEqual(-8000000, math.Sub(-7000000, 2000000));
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
            Assert.AreEqual(5, math.Div(-100000000, 20000000));
            Assert.AreEqual(0.5, math.Div(1, 2), Exactness);
            Assert.AreEqual(-0.625, math.Div(-5, 8), Exactness);
            Assert.AreEqual(2, math.Div(128, 256));
            Assert.AreEqual(6.4127039, math.Div(42.6541, 6.6515), Exactness);
            Assert.AreEqual(4, math.Div(1, 0.25), Exactness);


            //dividing by zero
            string noFailMessage = "No exception message after dividing by zero.";

            try
            {
                math.Div(2, 0);
                Assert.Fail(noFailMessage);
            }
            catch (ExceptionMessage)
            {
            }
        }
    }
}

