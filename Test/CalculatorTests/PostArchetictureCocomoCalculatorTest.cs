using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models.Attributes.SecondCocomo;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using COCOMOCalculator.BL.Models.Args;

namespace Test
{
    [TestClass]
    public class PostArchetictureCocomoCalculatorTest
    {
        [TestMethod]
        public void CalculatorTest1 ()
        {
            var calculator = new PostArchitectureCocomoCalculator();
            var result = calculator.Calculate(
                new PostArchitectureCalculationArgs
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
                    PersonnelFactors = new PersonnelFactors
                    {
                        AnalystCapability = PostArchitectureEffortMultiplier.Nominal,
                        ApplicationExperience = PostArchitectureEffortMultiplier.Nominal,
                        ProgrammerCapability = PostArchitectureEffortMultiplier.Nominal,
                        PersonnelContinuity = PostArchitectureEffortMultiplier.Nominal,
                        PlatformExperience = PostArchitectureEffortMultiplier.Nominal,
                        LanguageAndToolExperience = PostArchitectureEffortMultiplier.Nominal
                    },
                    PlatformFactors = new PlatformFactors
                    {
                        ExecutionTimeConstraint = PostArchitectureEffortMultiplier.Nominal,
                        MainStorageConstraint = PostArchitectureEffortMultiplier.Nominal,
                        PlatformVolatility = PostArchitectureEffortMultiplier.Nominal
                    },
                    ProductFactors = new ProductFactors
                    {
                        RequiredSoftwareReliability = PostArchitectureEffortMultiplier.Nominal,
                        DatabaseSize = PostArchitectureEffortMultiplier.Nominal,
                        SoftwareProductComplexity = PostArchitectureEffortMultiplier.Nominal,
                        RequiredResability = PostArchitectureEffortMultiplier.Nominal,
                        DocumentationMatchToLifeCycleNeeds = PostArchitectureEffortMultiplier.Nominal,
                    },
                    ProjectFactors = new ProjectFactors
                    {
                        UseOfSoftwareTools = PostArchitectureEffortMultiplier.Nominal,
                        MultisiteDevelopment = PostArchitectureEffortMultiplier.Nominal,
                        RequiredDevelopmentSchedule = PostArchitectureEffortMultiplier.Nominal
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 387.763f,
                TimeMonth = 24.416f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }

        [TestMethod]
        public void CalculatorTest2()
        {
            var calculator = new PostArchitectureCocomoCalculator();
            var result = calculator.Calculate(
                new PostArchitectureCalculationArgs
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
                    PersonnelFactors = new PersonnelFactors
                    {
                        AnalystCapability = PostArchitectureEffortMultiplier.High,
                        ApplicationExperience = PostArchitectureEffortMultiplier.High,
                        ProgrammerCapability = PostArchitectureEffortMultiplier.High,
                        PersonnelContinuity = PostArchitectureEffortMultiplier.High,
                        PlatformExperience = PostArchitectureEffortMultiplier.High,
                        LanguageAndToolExperience = PostArchitectureEffortMultiplier.High
                    },
                    PlatformFactors = new PlatformFactors
                    {
                        ExecutionTimeConstraint = PostArchitectureEffortMultiplier.High,
                        MainStorageConstraint = PostArchitectureEffortMultiplier.High,
                        PlatformVolatility = PostArchitectureEffortMultiplier.High
                    },
                    ProductFactors = new ProductFactors
                    {
                        RequiredSoftwareReliability = PostArchitectureEffortMultiplier.High,
                        DatabaseSize = PostArchitectureEffortMultiplier.High,
                        SoftwareProductComplexity = PostArchitectureEffortMultiplier.High,
                        RequiredResability = PostArchitectureEffortMultiplier.High,
                        DocumentationMatchToLifeCycleNeeds = PostArchitectureEffortMultiplier.High,
                    },
                    ProjectFactors = new ProjectFactors
                    {
                        UseOfSoftwareTools = PostArchitectureEffortMultiplier.High,
                        MultisiteDevelopment = PostArchitectureEffortMultiplier.High,
                        RequiredDevelopmentSchedule = PostArchitectureEffortMultiplier.Low
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 316.888f,
                TimeMonth = 23.32f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }

        [TestMethod]
        public void CalculatorTest3()
        {
            var calculator = new PostArchitectureCocomoCalculator();
            var result = calculator.Calculate(
                new PostArchitectureCalculationArgs
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
                    PersonnelFactors = new PersonnelFactors
                    {
                        AnalystCapability = PostArchitectureEffortMultiplier.High,
                        ApplicationExperience = PostArchitectureEffortMultiplier.High,
                        ProgrammerCapability = PostArchitectureEffortMultiplier.High,
                        PersonnelContinuity = PostArchitectureEffortMultiplier.High,
                        PlatformExperience = PostArchitectureEffortMultiplier.High,
                        LanguageAndToolExperience = PostArchitectureEffortMultiplier.High
                    },
                    PlatformFactors = new PlatformFactors
                    {
                        ExecutionTimeConstraint = PostArchitectureEffortMultiplier.High,
                        MainStorageConstraint = PostArchitectureEffortMultiplier.High,
                        PlatformVolatility = PostArchitectureEffortMultiplier.High
                    },
                    ProductFactors = new ProductFactors
                    {
                        RequiredSoftwareReliability = PostArchitectureEffortMultiplier.High,
                        DatabaseSize = PostArchitectureEffortMultiplier.High,
                        SoftwareProductComplexity = PostArchitectureEffortMultiplier.High,
                        RequiredResability = PostArchitectureEffortMultiplier.High,
                        DocumentationMatchToLifeCycleNeeds = PostArchitectureEffortMultiplier.High,
                    },
                    ProjectFactors = new ProjectFactors
                    {
                        UseOfSoftwareTools = PostArchitectureEffortMultiplier.High,
                        MultisiteDevelopment = PostArchitectureEffortMultiplier.High,
                        RequiredDevelopmentSchedule = PostArchitectureEffortMultiplier.High
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 60.594f,
                TimeMonth = 12.848f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }
    }
}
