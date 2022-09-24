using System;
using System.Collections.Generic;
using System.Data;
using COCOMOCalculator.BL.Interfaces;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Attributes;
using COCOMOCalculator.BL.Models.Coefficents;

namespace COCOMOCalculator.BL.Services
{
    public class CocomoCalculator : ICocomoCalculator
    {
        private readonly Dictionary<ProjectType, BasicProjectTypeCoefficients> _basic_coefficients = new Dictionary<ProjectType, BasicProjectTypeCoefficients>
        {
            { ProjectType.Common,          new BasicProjectTypeCoefficients { A = 2.4f, B = 1.05f, C = 2.5f, D = 0.38f } },
            { ProjectType.SemiIndependent, new BasicProjectTypeCoefficients { A = 3.0f, B = 1.12f, C = 2.5f, D = 0.35f } },
            { ProjectType.BuiltIn,         new BasicProjectTypeCoefficients { A = 3.6f, B = 1.20f, C = 2.5f, D = 0.32f } }
        };

        private readonly Dictionary<ProjectType, BasicProjectTypeCoefficients> _intemediate_coefficents = new Dictionary<ProjectType, BasicProjectTypeCoefficients>
        {
            { ProjectType.Common,          new BasicProjectTypeCoefficients { A = 3.2f, B = 1.05f, C = 2.5f, D = 0.38f } },
            { ProjectType.SemiIndependent, new BasicProjectTypeCoefficients { A = 3.0f, B = 1.12f, C = 2.5f, D = 0.35f } },
            { ProjectType.BuiltIn,         new BasicProjectTypeCoefficients { A = 2.8f, B = 1.20f, C = 2.5f, D = 0.32f } }
        };

        private readonly Dictionary<string, Dictionary<RatingType, float>> _rating_coefficents = new Dictionary<string, Dictionary<RatingType, float>>
        {
            {
                "Required Software Reliability",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   0.75f },
                    { RatingType.Low,       0.88f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      1.15f },
                    { RatingType.VeryHigh,  1.40f }
                }
            },
            { 
                "Size of Application Database",
                new Dictionary<RatingType, float>
                {
                    { RatingType.Low,       0.94f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      1.08f },
                    { RatingType.VeryHigh,  1.16f }
                }
            },
            {
                "Complexity of the Product",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   0.70f },
                    { RatingType.Low,       0.85f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      1.15f },
                    { RatingType.VeryHigh,  1.30f },
                    { RatingType.Critical,  1.65f }
                }
            },
            {
                "Run-Time Performance Constraints",
                new Dictionary<RatingType, float>
                {
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      1.11f },
                    { RatingType.VeryHigh,  1.30f },
                    { RatingType.Critical,  1.66f }
                }
            },
            {
                "Memory Constraints",
                new Dictionary<RatingType, float>
                {
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      1.06f },
                    { RatingType.VeryHigh,  1.21f },
                    { RatingType.Critical,  1.56f }
                }
            },
            {
                "Volatility of the Virtual Machine Environment",
                new Dictionary<RatingType, float>
                {
                    { RatingType.Low,       0.87f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      1.15f },
                    { RatingType.VeryHigh,  1.30f }
                }
            },
            {
                "Required Turnabout Time",
                new Dictionary<RatingType, float>
                {
                    { RatingType.Low,       0.87f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      1.07f },
                    { RatingType.VeryHigh,  1.15f }
                }
            },
            {
                "Analyst Capability",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   1.46f },
                    { RatingType.Low,       1.19f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      0.86f },
                    { RatingType.VeryHigh,  0.71f }
                }
            },
            {
                "Applications Experience",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   1.29f },
                    { RatingType.Low,       1.13f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      0.91f },
                    { RatingType.VeryHigh,  0.82f }
                }
            },
            {
                "Software Engineer Capability",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   1.42f },
                    { RatingType.Low,       1.17f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      0.86f },
                    { RatingType.VeryHigh,  0.70f }
                }
            },
            {
                "Virtual Machine Experience",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   1.21f },
                    { RatingType.Low,       1.10f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      0.90f }
                }
            },
            {
                "Programming Language Experience",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   1.14f },
                    { RatingType.Low,       1.07f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      0.95f }
                }
            },
            {
                "Use of Software Tools",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   1.24f },
                    { RatingType.Low,       1.10f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      0.91f },
                    { RatingType.VeryHigh,  0.82f }
                }
            },
            {
                "Application of Software Engineering Methods",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   1.24f },
                    { RatingType.Low,       1.10f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      0.91f },
                    { RatingType.VeryHigh,  0.82f }
                }
            },
            {
                "Required Development Schedule",
                new Dictionary<RatingType, float>
                {
                    { RatingType.VeryLow,   1.23f },
                    { RatingType.Low,       1.08f },
                    { RatingType.Normal,    1.00f },
                    { RatingType.High,      1.04f },
                    { RatingType.VeryHigh,  1.10f }
                }
            }
        };

        public CalculationResult Calculate(BasicCalculationArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var attr = args.BasicAttributes;

            if (attr == null)
                throw new ArgumentException("Атрибуты не заданы.");

            if (!_basic_coefficients.TryGetValue(attr.ProjectType, out var coefs))
                throw new ArgumentException("Тип проекта должен быть указан.");

            var PeopleMonth = (float)Math.Round(coefs.A * Math.Pow(attr.Size, coefs.B), 6);
            var TimeMonth = (float)Math.Round(coefs.C * Math.Pow(PeopleMonth, coefs.D), 6);

            return new CalculationResult { PeopleMonth = PeopleMonth, TimeMonth = TimeMonth };
        }

        public CalculationResult Calculate(IntermediateCalculationArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var attr = args.BasicAttributes;

            if (attr == null)
                throw new ArgumentException("Атрибуты не заданы.");

            var size = args.BasicAttributes.Size;
            var ProjectType = args.BasicAttributes.ProjectType;

            if (!_intemediate_coefficents.TryGetValue(ProjectType, out var coefs))
                throw new ArgumentException("Тип проекта должен быть указан.");

            var ProductAttributes = args.ProductAttributes;
            var HardwareAttributes = args.HardwareAttributes;
            var PersonnelAttributes = args.PersonnelAttributes;
            var ProjectAttributes = args.ProjectAttributes;

            float[] coefficent = new float[15];

            coefficent[0] = coefficentMap("Required Software Reliability",                  ProductAttributes.RequiredSoftwareReliability);
            coefficent[1] = coefficentMap("Size of Application Database",                   ProductAttributes.SizeOfApplicationDatabase);
            coefficent[2] = coefficentMap("Complexity of the Product",                      ProductAttributes.ComplexityOfTheProduct);

            coefficent[3] = coefficentMap("Run-Time Performance Constraints",               HardwareAttributes.RunTimePerformanceConstraints);
            coefficent[4] = coefficentMap("Memory Constraints",                             HardwareAttributes.MemoryConstraints);
            coefficent[5] = coefficentMap("Volatility of the Virtual Machine Environment",  HardwareAttributes.VolatilityOfTheVirtualMachineEnvironment);
            coefficent[6] = coefficentMap("Required Turnabout Time",                        HardwareAttributes.RequiredTurnaboutTime);

            coefficent[7] = coefficentMap("Analyst Capability",                             PersonnelAttributes.AnalystCapability);
            coefficent[8] = coefficentMap("Applications Experience",                        PersonnelAttributes.SoftwareEngineerCapability);
            coefficent[9] = coefficentMap("Software Engineer Capability",                   PersonnelAttributes.ApplicationsExperience);
            coefficent[10] = coefficentMap("Virtual Machine Experience",                    PersonnelAttributes.VirtualMachineExperience);
            coefficent[11] = coefficentMap("Programming Language Experience",               PersonnelAttributes.ProgrammingLanguageExperience);

            coefficent[12] = coefficentMap("Use of Software Tools",                         ProjectAttributes.UseOfSoftwareTools);
            coefficent[13] = coefficentMap("Application of Software Engineering Methods",   ProjectAttributes.ApplicationOfSoftwareEngineeringMethods);
            coefficent[14] = coefficentMap("Required Development Schedule",                 ProjectAttributes.RequiredDevelopmentSchedule);

            float EffortAdjustmentFactor = coefficent[0];

            for (int i = 1; i < 15; i++)
                EffortAdjustmentFactor *= coefficent[i];

            var PeopleMonth = (float) Math.Round(EffortAdjustmentFactor * coefs.A * Math.Pow(size, coefs.B), 6);
            var TimeMonth = (float)Math.Round(coefs.C * Math.Pow(size, coefs.D), 6);

            return new CalculationResult { PeopleMonth = PeopleMonth, TimeMonth = TimeMonth };
        }

        private float coefficentMap(string costAttributes, RatingType ratingType)
        {
            _rating_coefficents.TryGetValue(costAttributes, out var dictionary);
            if (!dictionary.TryGetValue(ratingType, out var coefficent))
                throw new ArgumentException("Неверный рейтинг аттрибута: " + costAttributes);
            return coefficent;
        }
    }
}
