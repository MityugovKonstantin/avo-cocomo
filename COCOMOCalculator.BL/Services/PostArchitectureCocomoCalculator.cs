using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Args;
using System;
using System.Collections.Generic;

namespace COCOMOCalculator.BL.Services
{
    public class PostArchitectureCocomoCalculator
    {
        private readonly Dictionary<string, Dictionary<ScaleFactor, float>> _scale_factors = FileManager<ScaleFactor>.ScaleFactorDictionaryFill();
        private readonly Dictionary<string, Dictionary<PostArchitectureEffortMultiplier, float>> _effort_multipliers =
            FileManager<PostArchitectureEffortMultiplier>.PostArchitectureEffortMultiplierDictionaryFill();

        private const float A = 2.45f;
        private const float B = 0.91f;
        private const float C = 3.67f;
        private const float D = 0.28f;

        public CalculationResult Calculate(PostArchitectureCalculationArgs args)
        {
            var size = args.Size;

            var scaleFactors = args.ScaleFactorsAttributes;

            var scaleFactorsSum =   ScaleFactorMap(nameof(scaleFactors.Precedentedness),                scaleFactors.Precedentedness);
            scaleFactorsSum +=      ScaleFactorMap(nameof(scaleFactors.DevelopmentFlexibility),         scaleFactors.DevelopmentFlexibility);
            scaleFactorsSum +=      ScaleFactorMap(nameof(scaleFactors.ArchitectureAndRiskResolution),  scaleFactors.ArchitectureAndRiskResolution);
            scaleFactorsSum +=      ScaleFactorMap(nameof(scaleFactors.TeamCohesion),                   scaleFactors.TeamCohesion);
            scaleFactorsSum +=      ScaleFactorMap(nameof(scaleFactors.ProcessMaturuty),                scaleFactors.ProcessMaturuty);

            var e = B + 0.01f * scaleFactorsSum;

            var personnelFactors =  args.PersonnelFactors;
            var productFactors =    args.ProductFactors;
            var platformFactors =   args.PlatformFactors;
            var projectFactors =    args.ProjectFactors;

            var eaf =   EffortMutriplierMap(nameof(personnelFactors.AnalystCapability),         personnelFactors.AnalystCapability);
            eaf *=      EffortMutriplierMap(nameof(personnelFactors.ApplicationExperience),     personnelFactors.ApplicationExperience);
            eaf *=      EffortMutriplierMap(nameof(personnelFactors.ProgrammerCapability),      personnelFactors.ProgrammerCapability);
            eaf *=      EffortMutriplierMap(nameof(personnelFactors.PersonnelContinuity),       personnelFactors.PersonnelContinuity);
            eaf *=      EffortMutriplierMap(nameof(personnelFactors.PlatformExperience),        personnelFactors.PlatformExperience);
            eaf *=      EffortMutriplierMap(nameof(personnelFactors.LanguageAndToolExperience), personnelFactors.LanguageAndToolExperience);

            eaf *=      EffortMutriplierMap(nameof(productFactors.RequiredSoftwareReliability),         productFactors.RequiredSoftwareReliability);
            eaf *=      EffortMutriplierMap(nameof(productFactors.DatabaseSize),                        productFactors.DatabaseSize);
            eaf *=      EffortMutriplierMap(nameof(productFactors.SoftwareProductComplexity),           productFactors.SoftwareProductComplexity);
            eaf *=      EffortMutriplierMap(nameof(productFactors.RequiredResability),                  productFactors.RequiredResability);
            eaf *=      EffortMutriplierMap(nameof(productFactors.DocumentationMatchToLifeCycleNeeds),  productFactors.DocumentationMatchToLifeCycleNeeds);

            eaf *=      EffortMutriplierMap(nameof(platformFactors.ExecutionTimeConstraint),    platformFactors.ExecutionTimeConstraint);
            eaf *=      EffortMutriplierMap(nameof(platformFactors.MainStorageConstraint),      platformFactors.MainStorageConstraint);
            eaf *=      EffortMutriplierMap(nameof(platformFactors.PlatformVolatility),         platformFactors.PlatformVolatility);

            eaf *=      EffortMutriplierMap(nameof(projectFactors.UseOfSoftwareTools),          projectFactors.UseOfSoftwareTools);
            eaf *=      EffortMutriplierMap(nameof(projectFactors.MultisiteDevelopment),        projectFactors.MultisiteDevelopment);
            eaf *=      EffortMutriplierMap(nameof(projectFactors.RequiredDevelopmentSchedule), projectFactors.RequiredDevelopmentSchedule);

            var peopleMonth = (float)Math.Round(eaf * A * Math.Pow(size, e), 6);

            var sced = EffortMutriplierMap(nameof(projectFactors.RequiredDevelopmentSchedule), projectFactors.RequiredDevelopmentSchedule);

            var peopleMonthNs = (eaf / sced) * A * Math.Pow(size, e);

            var timeMonth = (float)Math.Round(sced * C * Math.Pow(peopleMonthNs, D + 0.2f * (e - B)), 6);

            return new CalculationResult() { PeopleMonth = peopleMonth, TimeMonth = timeMonth };
        }

        private float ScaleFactorMap(string costAttribute, ScaleFactor scaleFactor)
        {
            _scale_factors.TryGetValue(costAttribute, out var dictionary);
            if (!dictionary.TryGetValue(scaleFactor, out var coefficent))
                throw new ArgumentException("Рейтинг аттрибута должен быть задан!");
            return coefficent;
        }

        private float EffortMutriplierMap(string costAttribute, PostArchitectureEffortMultiplier postArchitectureEffortMultiplier)
        {
            _effort_multipliers.TryGetValue(costAttribute, out var dictionary);
            if (!dictionary.TryGetValue(postArchitectureEffortMultiplier, out var coefficent))
                throw new ArgumentException("Рейтинг аттрибута должен быть задан!");
            return coefficent;
        }
    }
}
