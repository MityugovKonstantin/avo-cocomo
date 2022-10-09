using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using COCOMOCalculator.BL.Models.Attributes.SecondCocomo;

namespace Test
{
    [TestClass]
    public class EarlyDesignCocomoCalculatorTest
    {
        [TestMethod]
        public void CalculatorTest1()
        {
            var calculator = new EarlyDesignCocomoCalculator();
            var result = calculator.Calculate(
                new EarlyDesignCalculationArgs
                {
                    Size = 100,
                    ScaleFactorsAttributes = new ScaleFactorsAttributes
                    {
                        Precedentedness = ScaleFactor.Nominal,
                        DevelopmentFlexibility = ScaleFactor.Nominal,
                        ArchitectureAndRiskResolution = ScaleFactor.Nominal,
                        TeamCohesion = ScaleFactor.Nominal,
                        ProcessMaturuty = ScaleFactor.Nominal
                    },
                    EffortMultipliersAttributes = new EffortMultipliersAttributes
                    {
                        PersonnelCapability = EarlyDesignEffortMultiplier.Nominal,
                        PersonnelExperience = EarlyDesignEffortMultiplier.Nominal,
                        ProductRelabilityAndComplexity = EarlyDesignEffortMultiplier.Nominal,
                        DeveloperForReusability = EarlyDesignEffortMultiplier.Nominal,
                        PlatformDifficulty = EarlyDesignEffortMultiplier.Nominal,
                        Facilities = EarlyDesignEffortMultiplier.Nominal,
                        RequiredDevelopmentSchedule = EarlyDesignEffortMultiplier.Nominal
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 465.315f,
                TimeMonth = 25.873f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }

        [TestMethod]
        public void CalculatorTest2()
        {
            var calculator = new EarlyDesignCocomoCalculator();
            var result = calculator.Calculate(
                new EarlyDesignCalculationArgs
                {
                    Size = 100,
                    ScaleFactorsAttributes = new ScaleFactorsAttributes
                    {
                        Precedentedness = ScaleFactor.High,
                        DevelopmentFlexibility = ScaleFactor.High,
                        ArchitectureAndRiskResolution = ScaleFactor.High,
                        TeamCohesion = ScaleFactor.High,
                        ProcessMaturuty = ScaleFactor.High
                    },
                    EffortMultipliersAttributes = new EffortMultipliersAttributes
                    {
                        PersonnelCapability = EarlyDesignEffortMultiplier.High,
                        PersonnelExperience = EarlyDesignEffortMultiplier.High,
                        ProductRelabilityAndComplexity = EarlyDesignEffortMultiplier.High,
                        DeveloperForReusability = EarlyDesignEffortMultiplier.High,
                        PlatformDifficulty = EarlyDesignEffortMultiplier.High,
                        Facilities = EarlyDesignEffortMultiplier.High,
                        RequiredDevelopmentSchedule = EarlyDesignEffortMultiplier.High
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 401.134f,
                TimeMonth = 22.88f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }

        [TestMethod]
        public void CalculatorTest3()
        {
            var calculator = new EarlyDesignCocomoCalculator();
            var result = calculator.Calculate(
                new EarlyDesignCalculationArgs
                {
                    Size = 23,
                    ScaleFactorsAttributes = new ScaleFactorsAttributes
                    {
                        Precedentedness = ScaleFactor.High,
                        DevelopmentFlexibility = ScaleFactor.High,
                        ArchitectureAndRiskResolution = ScaleFactor.High,
                        TeamCohesion = ScaleFactor.High,
                        ProcessMaturuty = ScaleFactor.High
                    },
                    EffortMultipliersAttributes = new EffortMultipliersAttributes
                    {
                        PersonnelCapability = EarlyDesignEffortMultiplier.High,
                        PersonnelExperience = EarlyDesignEffortMultiplier.High,
                        ProductRelabilityAndComplexity = EarlyDesignEffortMultiplier.High,
                        DeveloperForReusability = EarlyDesignEffortMultiplier.High,
                        PlatformDifficulty = EarlyDesignEffortMultiplier.High,
                        Facilities = EarlyDesignEffortMultiplier.High,
                        RequiredDevelopmentSchedule = EarlyDesignEffortMultiplier.High
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 87.442f,
                TimeMonth = 14.371f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }
    }
}
