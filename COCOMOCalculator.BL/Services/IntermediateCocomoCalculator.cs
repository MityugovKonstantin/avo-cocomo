using COCOMOCalculator.BL.Models;
using System;
using System.Collections.Generic;

namespace COCOMOCalculator.BL.Services
{
    public class IntermediateCocomoCalculator
    {
        Dictionary<string, Dictionary<RatingType, float>> costAttributes = FileManager.FillCostAttributesDictionary("Database\\CostAttributesCoefficents.csv");

        public CalculationResult Calculate(IntermediateCalculationArgs args)
        {
            var projectTypeCoefficents = FileManager.FillProjectTypeDictionary("Database\\IntermediateProjectTypeCoefficents.csv");

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var attr = args.BasicAttributes;

            if (attr == null)
                throw new ArgumentException("Атрибуты не заданы.");

            var size = args.BasicAttributes.Size;
            var projectType = args.BasicAttributes.ProjectType;

            if (!projectTypeCoefficents.TryGetValue(projectType, out var coefs))
                throw new ArgumentException("Тип проекта должен быть указан.");

            var ProductAttributes =     args.ProductAttributes;
            var HardwareAttributes =    args.HardwareAttributes;
            var PersonnelAttributes =   args.PersonnelAttributes;
            var ProjectAttributes =     args.ProjectAttributes;

            float[] coefficent = new float[15];

            coefficent[0] = coefficentMap(nameof(ProductAttributes.RequiredSoftwareReliability),                ProductAttributes.RequiredSoftwareReliability);
            coefficent[1] = coefficentMap(nameof(ProductAttributes.SizeOfApplicationDatabase),                  ProductAttributes.SizeOfApplicationDatabase);
            coefficent[2] = coefficentMap(nameof(ProductAttributes.ComplexityOfTheProduct),                     ProductAttributes.ComplexityOfTheProduct);

            coefficent[3] = coefficentMap(nameof(HardwareAttributes.RunTimePerformanceConstraints),             HardwareAttributes.RunTimePerformanceConstraints);
            coefficent[4] = coefficentMap(nameof(HardwareAttributes.MemoryConstraints),                         HardwareAttributes.MemoryConstraints);
            coefficent[5] = coefficentMap(nameof(HardwareAttributes.VolatilityOfTheVirtualMachineEnvironment),  HardwareAttributes.VolatilityOfTheVirtualMachineEnvironment);
            coefficent[6] = coefficentMap(nameof(HardwareAttributes.RequiredTurnaboutTime),                     HardwareAttributes.RequiredTurnaboutTime);

            coefficent[7] = coefficentMap(nameof (PersonnelAttributes.AnalystCapability),                       PersonnelAttributes.AnalystCapability);
            coefficent[8] = coefficentMap(nameof (PersonnelAttributes.SoftwareEngineerCapability),              PersonnelAttributes.SoftwareEngineerCapability);
            coefficent[9] = coefficentMap(nameof (PersonnelAttributes.ApplicationsExperience),                  PersonnelAttributes.ApplicationsExperience);
            coefficent[10] = coefficentMap(nameof(PersonnelAttributes.VirtualMachineExperience),                PersonnelAttributes.VirtualMachineExperience);
            coefficent[11] = coefficentMap(nameof(PersonnelAttributes.ProgrammingLanguageExperience),           PersonnelAttributes.ProgrammingLanguageExperience);

            coefficent[12] = coefficentMap(nameof(ProjectAttributes.UseOfSoftwareTools),                        ProjectAttributes.UseOfSoftwareTools);
            coefficent[13] = coefficentMap(nameof(ProjectAttributes.ApplicationOfSoftwareEngineeringMethods),   ProjectAttributes.ApplicationOfSoftwareEngineeringMethods);
            coefficent[14] = coefficentMap(nameof(ProjectAttributes.RequiredDevelopmentSchedule),               ProjectAttributes.RequiredDevelopmentSchedule);

            float EffortAdjustmentFactor = coefficent[0];

            for (int i = 1; i < 15; i++)
                EffortAdjustmentFactor *= coefficent[i];

            var PeopleMonth = (float)Math.Round(EffortAdjustmentFactor * coefs.A * Math.Pow(size, coefs.B), 6);
            var TimeMonth = (float)Math.Round(coefs.C * Math.Pow(size, coefs.D), 6);

            return new CalculationResult { PeopleMonth = PeopleMonth, TimeMonth = TimeMonth };
        }

        private float coefficentMap(string costAttribute, RatingType ratingType)
        {
            costAttributes.TryGetValue(costAttribute, out var dictionary);
            if (!dictionary.TryGetValue(ratingType, out var coefficent))
                throw new ArgumentException("Неверный рейтинг аттрибута: " + costAttribute);
            return coefficent;
        }
    }
}
