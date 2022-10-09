using COCOMOCalculator.BL.Models.Attributes;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using COCOMOCalculator.BL.Enums;

namespace Test
{
    [TestClass]
    public class IntermediateCocomoCalculatorTest
    {
        [TestMethod]
        public void RatingTypeTest1()
        {
            var calculator = new IntermediateCocomoCalculator();
            var result = calculator.Calculate(
                new IntermediateCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        Size = 100,
                        ProjectType = ProjectType.Common
                    },
                    ProductAttributes = new ProductAttributes
                    {
                        RequiredSoftwareReliability =               RatingType.Normal,
                        SizeOfApplicationDatabase =                 RatingType.Normal,
                        ComplexityOfTheProduct =                    RatingType.Normal
                    },
                    HardwareAttributes = new HardwareAttributes
                    {
                        RunTimePerformanceConstraints =             RatingType.Normal,
                        MemoryConstraints =                         RatingType.Normal,
                        VolatilityOfTheVirtualMachineEnvironment =  RatingType.Normal,
                        RequiredTurnaboutTime =                     RatingType.Normal
                    },
                    PersonnelAttributes = new PersonnelAttributes
                    {
                        AnalystCapability =                         RatingType.Normal,
                        SoftwareEngineerCapability =                RatingType.Normal,
                        ApplicationsExperience =                    RatingType.Normal,
                        VirtualMachineExperience =                  RatingType.Normal,
                        ProgrammingLanguageExperience =             RatingType.Normal
                    },
                    ProjectAttributes = new ProjectAttributes
                    {
                        UseOfSoftwareTools =                        RatingType.Normal,
                        ApplicationOfSoftwareEngineeringMethods =   RatingType.Normal,
                        RequiredDevelopmentSchedule =               RatingType.Normal
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 402.856f,
                TimeMonth = 24.429f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }

        [TestMethod]
        public void RatingTypeTest2()
        {
            var calculator = new IntermediateCocomoCalculator();
            var result = calculator.Calculate(
                new IntermediateCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        Size = 100,
                        ProjectType = ProjectType.Common
                    },
                    ProductAttributes = new ProductAttributes
                    {
                        RequiredSoftwareReliability = RatingType.High,
                        SizeOfApplicationDatabase = RatingType.High,
                        ComplexityOfTheProduct = RatingType.High
                    },
                    HardwareAttributes = new HardwareAttributes
                    {
                        RunTimePerformanceConstraints = RatingType.High,
                        MemoryConstraints = RatingType.High,
                        VolatilityOfTheVirtualMachineEnvironment = RatingType.High,
                        RequiredTurnaboutTime = RatingType.High
                    },
                    PersonnelAttributes = new PersonnelAttributes
                    {
                        AnalystCapability = RatingType.High,
                        SoftwareEngineerCapability = RatingType.High,
                        ApplicationsExperience = RatingType.High,
                        VirtualMachineExperience = RatingType.High,
                        ProgrammingLanguageExperience = RatingType.High
                    },
                    ProjectAttributes = new ProjectAttributes
                    {
                        UseOfSoftwareTools = RatingType.High,
                        ApplicationOfSoftwareEngineeringMethods = RatingType.High,
                        RequiredDevelopmentSchedule = RatingType.High
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 412.858f,
                TimeMonth = 24.657f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }

        [TestMethod]
        public void SizeTest()
        {
            var calculator = new IntermediateCocomoCalculator();
            var result = calculator.Calculate(
                new IntermediateCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        Size = 23,
                        ProjectType = ProjectType.Common
                    },
                    ProductAttributes = new ProductAttributes
                    {
                        RequiredSoftwareReliability = RatingType.High,
                        SizeOfApplicationDatabase = RatingType.High,
                        ComplexityOfTheProduct = RatingType.High
                    },
                    HardwareAttributes = new HardwareAttributes
                    {
                        RunTimePerformanceConstraints = RatingType.High,
                        MemoryConstraints = RatingType.High,
                        VolatilityOfTheVirtualMachineEnvironment = RatingType.High,
                        RequiredTurnaboutTime = RatingType.High
                    },
                    PersonnelAttributes = new PersonnelAttributes
                    {
                        AnalystCapability = RatingType.High,
                        SoftwareEngineerCapability = RatingType.High,
                        ApplicationsExperience = RatingType.High,
                        VirtualMachineExperience = RatingType.High,
                        ProgrammingLanguageExperience = RatingType.High
                    },
                    ProjectAttributes = new ProjectAttributes
                    {
                        UseOfSoftwareTools = RatingType.High,
                        ApplicationOfSoftwareEngineeringMethods = RatingType.High,
                        RequiredDevelopmentSchedule = RatingType.High
                    }
                }
            );
            var expected = new CalculationResult()
            {
                PeopleMonth = 88.23f,
                TimeMonth = 13.717f
            };
            Assert.IsTrue(Math.Round(result.PeopleMonth, 2).Equals(Math.Round(expected.PeopleMonth, 2)));
            Assert.IsTrue(Math.Round(result.TimeMonth, 2).Equals(Math.Round(expected.TimeMonth, 2)));
        }
    }
}
