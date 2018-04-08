using System;
//using MathLibrary;
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
            Assert.AreEqual(-3, math.Root(-59049, 10));
            Assert.AreEqual(2.5, math.Root(15.625, 3), Exactness);
            Assert.AreEqual(2.5, math.Root(0.000064, -3), Exactness);
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
            catch (ExceptionMessage)
            {
            }
            try
            {
                math.Root(0, -1);
                Assert.Fail(noFailMessage);
            }
            catch (ExceptionMessage)
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
            Assert.AreEqual(1, math.Pow(1, -42));
            Assert.AreEqual(1, math.Pow(-1, 42));
            Assert.AreEqual(-1, math.Pow(-1, 41));
            Assert.AreEqual(36, math.Pow(6, 2));
            Assert.AreEqual(1000, math.Pow(10, 3));
            Assert.AreEqual(100000000, math.Pow(100000000, 1));
            Assert.AreEqual(1024, math.Pow(2, 10));
            Assert.AreEqual(-59049, math.Pow(-3, 10));
            Assert.AreEqual(3.2768e-41, math.Pow(500, -15), Exactness);
            Assert.AreEqual(15.625, math.Pow(2.5, 3), Exactness);
            Assert.AreEqual(0.000064, math.Pow(2.5, -3), Exactness);

            //NaN result
            string noFailMessage = "No exception message when result was NaN.";

            try
            {
                math.Pow(-1, 0.5);
                Assert.Fail(noFailMessage);
            }
            catch (ExceptionMessage)
            {
            }
            try
            {
                math.Pow(0, -1);
                Assert.Fail(noFailMessage);
            }
            catch (ExceptionMessage)
            {
            }
        }

        /// <summary>
        /// Factorial test
        /// </summary>
        [TestMethod]
        public void FactTest()
        {
            Assert.AreEqual(720, math.Fact(6));
            Assert.AreEqual(3628800, math.Fact(10));
            Assert.AreEqual(1, math.Fact(1));
            Assert.AreEqual(1, math.Fact(0));

            //NaN result
            string noFailMessage = "No exception message when result was NaN.";

            try
            {
                math.Fact(-1);
                Assert.Fail(noFailMessage);
            }
            catch (ExceptionMessage)
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
            Assert.AreEqual(1.2835, math.Log(100, 369), Exactness);
            Assert.AreEqual(-4.9233, math.Log(0.8, 3), Exactness);
            Assert.AreEqual(5.3955, math.Log(0.8, 0.3), Exactness);
            Assert.AreEqual(-0.7481, math.Log(5, 0.3), Exactness);

            //NaN result
            string noFailMessage = "No exception message when result was NaN.";

            try
            {
                math.Log(0, 1);
                Assert.Fail(noFailMessage);
            }
            catch(ExceptionMessage)
            {
            }

            try
            {
                math.Log(1, 10);
                Assert.Fail(noFailMessage);
            }
            catch (ExceptionMessage)
            {
            }

            try
            {
                math.Log(-3, 10);
                Assert.Fail(noFailMessage);
            }
            catch (ExceptionMessage)
            {
            }

            try
            {
                math.Log(10, -3);
                Assert.Fail(noFailMessage);
            }
            catch (ExceptionMessage)
            {
            }
        }
    }
}


