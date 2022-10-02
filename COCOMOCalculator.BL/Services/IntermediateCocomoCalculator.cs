using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models;
using System;
using System.Collections.Generic;

namespace COCOMOCalculator.BL.Services
{
    public class IntermediateCocomoCalculator
    {
        Dictionary<string, Dictionary<RatingType, float>> costAttributes = FileManager<RatingType>.CostAttributesDictionaryFill();

        public CalculationResult Calculate(IntermediateCalculationArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var basicAttributes = args.BasicAttributes;
            if (basicAttributes == null)
                throw new ArgumentNullException(nameof(basicAttributes));

            var productAttributes = args.ProductAttributes;
            if (productAttributes == null)
                throw new ArgumentNullException(nameof(productAttributes));

            var hardwareAttributes = args.HardwareAttributes;
            if (hardwareAttributes == null)
                throw new ArgumentNullException(nameof(hardwareAttributes));

            var personnelAttributes = args.PersonnelAttributes;
            if (personnelAttributes == null)
                throw new ArgumentNullException(nameof(personnelAttributes));

            var projectAttributes = args.ProjectAttributes;
            if (projectAttributes == null)
                throw new ArgumentNullException(nameof(projectAttributes));

            var projectTypeCoefficents = FileManager<ProjectType>.ProjectTypeDictionaryFill("Database\\IntermediateProjectTypeCoefficents.csv");
            var size = basicAttributes.Size;
            var projectType = basicAttributes.ProjectType;

            if (!projectTypeCoefficents.TryGetValue(projectType, out var coefs))
                throw new ArgumentException("Тип проекта должен быть указан.");

            float[] coefficent = new float[15];

            coefficent[0]  = coefficentMap(nameof(productAttributes.RequiredSoftwareReliability),               productAttributes.RequiredSoftwareReliability);
            coefficent[1]  = coefficentMap(nameof(productAttributes.SizeOfApplicationDatabase),                 productAttributes.SizeOfApplicationDatabase);
            coefficent[2]  = coefficentMap(nameof(productAttributes.ComplexityOfTheProduct),                    productAttributes.ComplexityOfTheProduct);
                           
            coefficent[3]  = coefficentMap(nameof(hardwareAttributes.RunTimePerformanceConstraints),            hardwareAttributes.RunTimePerformanceConstraints);
            coefficent[4]  = coefficentMap(nameof(hardwareAttributes.MemoryConstraints),                        hardwareAttributes.MemoryConstraints);
            coefficent[5]  = coefficentMap(nameof(hardwareAttributes.VolatilityOfTheVirtualMachineEnvironment), hardwareAttributes.VolatilityOfTheVirtualMachineEnvironment);
            coefficent[6]  = coefficentMap(nameof(hardwareAttributes.RequiredTurnaboutTime),                    hardwareAttributes.RequiredTurnaboutTime);
                           
            coefficent[7]  = coefficentMap(nameof (personnelAttributes.AnalystCapability),                      personnelAttributes.AnalystCapability);
            coefficent[8]  = coefficentMap(nameof (personnelAttributes.SoftwareEngineerCapability),             personnelAttributes.SoftwareEngineerCapability);
            coefficent[9]  = coefficentMap(nameof (personnelAttributes.ApplicationsExperience),                 personnelAttributes.ApplicationsExperience);
            coefficent[10] = coefficentMap(nameof(personnelAttributes.VirtualMachineExperience),                personnelAttributes.VirtualMachineExperience);
            coefficent[11] = coefficentMap(nameof(personnelAttributes.ProgrammingLanguageExperience),           personnelAttributes.ProgrammingLanguageExperience);

            coefficent[12] = coefficentMap(nameof(projectAttributes.UseOfSoftwareTools),                        projectAttributes.UseOfSoftwareTools);
            coefficent[13] = coefficentMap(nameof(projectAttributes.ApplicationOfSoftwareEngineeringMethods),   projectAttributes.ApplicationOfSoftwareEngineeringMethods);
            coefficent[14] = coefficentMap(nameof(projectAttributes.RequiredDevelopmentSchedule),               projectAttributes.RequiredDevelopmentSchedule);

            float effortAdjustmentFactor = coefficent[0];

            for (int i = 1; i < 15; i++)
                effortAdjustmentFactor *= coefficent[i];

            var peopleMonth = (float)Math.Round(effortAdjustmentFactor * coefs.A * Math.Pow(size, coefs.B), 6);
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
