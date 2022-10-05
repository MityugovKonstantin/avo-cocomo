using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models;
using System;
using System.Collections.Generic;

namespace COCOMOCalculator.BL.Services
{
    public class IntermediateCocomoCalculator
    {
        Dictionary<string, Dictionary<RatingType, float>> costAttributes = FileManager.CostAttributesDictionaryFill();

        public CalculationResult Calculate(IntermediateCalculationArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var basicAttributes = args.BasicAttributes;
            if (basicAttributes == null)
                throw new ArgumentException("Basic Attributes не верен.");

            var productAttributes = args.ProductAttributes;
            if (productAttributes == null)
                throw new ArgumentException("Product Attributes не верен.");

            var hardwareAttributes = args.HardwareAttributes;
            if (hardwareAttributes == null)
                throw new ArgumentException("Hardware Attributes не верен.");

            var personnelAttributes = args.PersonnelAttributes;
            if (personnelAttributes == null)
                throw new ArgumentException("Personnel Attributes не верен.");

            var projectAttributes = args.ProjectAttributes;
            if (projectAttributes == null)
                throw new ArgumentException("Project Attributes не верен.");

            var projectTypeCoefficents = FileManager.ProjectTypeDictionaryFill("Database\\IntermediateProjectTypeCoefficents.csv");
            var size = basicAttributes.Size;
            var projectType = basicAttributes.ProjectType;

            if (!projectTypeCoefficents.TryGetValue(projectType, out var coefs))
                throw new ArgumentException("Тип проекта должен быть указан.");

            var eaf = coefficentMap(nameof(productAttributes.RequiredSoftwareReliability), productAttributes.RequiredSoftwareReliability);
            eaf *= coefficentMap(nameof(productAttributes.SizeOfApplicationDatabase), productAttributes.SizeOfApplicationDatabase);
            eaf *= coefficentMap(nameof(productAttributes.ComplexityOfTheProduct), productAttributes.ComplexityOfTheProduct);
            eaf *= coefficentMap(nameof(hardwareAttributes.RunTimePerformanceConstraints), hardwareAttributes.RunTimePerformanceConstraints);
            eaf *= coefficentMap(nameof(hardwareAttributes.MemoryConstraints), hardwareAttributes.MemoryConstraints);
            eaf *= coefficentMap(nameof(hardwareAttributes.VolatilityOfTheVirtualMachineEnvironment), hardwareAttributes.VolatilityOfTheVirtualMachineEnvironment);
            eaf *= coefficentMap(nameof(hardwareAttributes.RequiredTurnaboutTime), hardwareAttributes.RequiredTurnaboutTime);
            eaf *= coefficentMap(nameof(personnelAttributes.AnalystCapability), personnelAttributes.AnalystCapability);
            eaf *= coefficentMap(nameof(personnelAttributes.SoftwareEngineerCapability), personnelAttributes.SoftwareEngineerCapability);
            eaf *= coefficentMap(nameof(personnelAttributes.ApplicationsExperience), personnelAttributes.ApplicationsExperience);
            eaf *= coefficentMap(nameof(personnelAttributes.VirtualMachineExperience), personnelAttributes.VirtualMachineExperience);
            eaf *= coefficentMap(nameof(personnelAttributes.ProgrammingLanguageExperience), personnelAttributes.ProgrammingLanguageExperience);
            eaf *= coefficentMap(nameof(projectAttributes.UseOfSoftwareTools), projectAttributes.UseOfSoftwareTools);
            eaf *= coefficentMap(nameof(projectAttributes.ApplicationOfSoftwareEngineeringMethods), projectAttributes.ApplicationOfSoftwareEngineeringMethods);
            eaf *= coefficentMap(nameof(projectAttributes.RequiredDevelopmentSchedule), projectAttributes.RequiredDevelopmentSchedule);

            var peopleMonth = (float)Math.Round(eaf * coefs.A * Math.Pow(size, coefs.B), 6);
            var timeMonth = (float)Math.Round(coefs.C * Math.Pow(size, coefs.D), 6);

            return new CalculationResult { PeopleMonth = peopleMonth, TimeMonth = timeMonth };
        }

        private float coefficentMap(string attribute, RatingType ratingType)
        {
            costAttributes.TryGetValue(attribute, out var dictionary);
            if (!dictionary.TryGetValue(ratingType, out var coefficent))
                throw new ArgumentException("Рейтинг аттрибута " + attribute + " должен быть задан!");
            return coefficent;
        }
    }
}
