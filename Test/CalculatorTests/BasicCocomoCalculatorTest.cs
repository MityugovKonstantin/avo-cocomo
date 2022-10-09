using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Attributes;
using COCOMOCalculator.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class BasicCocomoCalculatorTest
    {
        [TestMethod]
        public void CommonProjectTypeTest()
        {
            var calculator = new BasicCocomoCalculator();
            var result = calculator.Calculate(
                new BasicCalculationArgs
                {
                    BasicAttributes = new BasicAttributes {
                        Size = 100,
                        ProjectType = ProjectType.Common
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 302.142f,
                TimeMonth = 21.898f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }

        [TestMethod]
        public void SemiIndependentProjectTypeTest()
        {
            var calculator = new BasicCocomoCalculator();
            var result = calculator.Calculate(
                new BasicCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        Size = 100,
                        ProjectType = ProjectType.SemiIndependent
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 521.340f,
                TimeMonth = 22.332f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }

        [TestMethod]
        public void BuiltInProjectTypeTest()
        {
            var calculator = new BasicCocomoCalculator();
            var result = calculator.Calculate(
                new BasicCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        Size = 100,
                        ProjectType = ProjectType.BuiltIn
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 904.279f,
                TimeMonth = 22.078f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }

        [TestMethod]
        public void SizeTest()
        {
            var calculator = new BasicCocomoCalculator();
            var result = calculator.Calculate(
                new BasicCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        Size = 23,
                        ProjectType = ProjectType.BuiltIn
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 155.016f,
                TimeMonth = 12.556f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }
    }
}
