using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models;
using System;
using System.Collections.Generic;

namespace COCOMOCalculator.BL.Services
{
    public class EarlyDesignCocomoCalculator
    {
        private readonly Dictionary<string, Dictionary<ScaleFactor, float>> _scale_factors = FileManager<ScaleFactor>.ScaleFactorDictionaryFill();
        private readonly Dictionary<string, Dictionary<EarlyDesignEffortMultiplier, float>> _effort_multipliers =
            FileManager<EarlyDesignEffortMultiplier>.EarlyDesignEffortMultiplierDictionaryFill();

        private const float A = 2.94f;
        private const float B = 0.91f;
        private const float C = 3.67f;
        private const float D = 0.28f;

        public CalculationResult Calculate(EarlyDesignCalculationArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var scaleFactors = args.ScaleFactorsAttributes;
            if (scaleFactors == null)
                throw new ArgumentNullException(nameof(scaleFactors));

            var effortMultipliers = args.EffortMultipliersAttributes;
            if (effortMultipliers == null)
                throw new ArgumentNullException(nameof(effortMultipliers));

            var size = args.Size;

            var scaleFactorsSum =   ScaleFactorMap(nameof(scaleFactors.Precedentedness),                scaleFactors.Precedentedness);
            scaleFactorsSum +=      ScaleFactorMap(nameof(scaleFactors.DevelopmentFlexibility),         scaleFactors.DevelopmentFlexibility);
            scaleFactorsSum +=      ScaleFactorMap(nameof(scaleFactors.ArchitectureAndRiskResolution),  scaleFactors.ArchitectureAndRiskResolution);
            scaleFactorsSum +=      ScaleFactorMap(nameof(scaleFactors.TeamCohesion),                   scaleFactors.TeamCohesion);
            scaleFactorsSum +=      ScaleFactorMap(nameof(scaleFactors.ProcessMaturuty),                scaleFactors.ProcessMaturuty);

            var e = B + 0.01f * scaleFactorsSum;

            var eaf =   EffortMutriplierMap(nameof(effortMultipliers.PersonnelCapability),              effortMultipliers.PersonnelCapability);
            eaf *=      EffortMutriplierMap(nameof(effortMultipliers.PersonnelExperience),              effortMultipliers.PersonnelExperience);
            eaf *=      EffortMutriplierMap(nameof(effortMultipliers.ProductRelabilityAndComplexity),   effortMultipliers.ProductRelabilityAndComplexity);
            eaf *=      EffortMutriplierMap(nameof(effortMultipliers.DeveloperForReusability),          effortMultipliers.DeveloperForReusability);
            eaf *=      EffortMutriplierMap(nameof(effortMultipliers.PlatformDifficulty),               effortMultipliers.PlatformDifficulty);
            eaf *=      EffortMutriplierMap(nameof(effortMultipliers.Facilities),                       effortMultipliers.Facilities);
            eaf *=      EffortMutriplierMap(nameof(effortMultipliers.RequiredDevelopmentSchedule),      effortMultipliers.RequiredDevelopmentSchedule);

            var peopleMonth = (float)Math.Round(eaf * A * Math.Pow(size, e), 6);

            eaf =  EffortMutriplierMap(nameof(effortMultipliers.PersonnelCapability),               effortMultipliers.PersonnelCapability);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.PersonnelExperience),               effortMultipliers.PersonnelExperience);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.ProductRelabilityAndComplexity),    effortMultipliers.ProductRelabilityAndComplexity);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.DeveloperForReusability),           effortMultipliers.DeveloperForReusability);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.PlatformDifficulty),                effortMultipliers.PlatformDifficulty);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.Facilities),                        effortMultipliers.Facilities);

            var peopleMonthNs = eaf * A * Math.Pow(size, e);

            var sced = EffortMutriplierMap(nameof(effortMultipliers.RequiredDevelopmentSchedule), effortMultipliers.RequiredDevelopmentSchedule);

            var timeMonth = (float)Math.Round(sced * C * Math.Pow(peopleMonthNs, D + 0.2f * (e - B)), 6);

            return new CalculationResult() { PeopleMonth = peopleMonth, TimeMonth = timeMonth };
        }

        private float ScaleFactorMap(string attribute, ScaleFactor scaleFactor)
        {
            _scale_factors.TryGetValue(attribute, out var dictionary);
            if (!dictionary.TryGetValue(scaleFactor, out var coefficent))
                throw new ArgumentException("Рейтинг аттрибута " + attribute + " должен быть задан!");
            return coefficent;
        }

        private float EffortMutriplierMap(string attribute, EarlyDesignEffortMultiplier earlyDesignEffortMultiplier)
        {
            _effort_multipliers.TryGetValue(attribute, out var dictionary);
            if (!dictionary.TryGetValue(earlyDesignEffortMultiplier, out var coefficent))
                throw new ArgumentException("Рейтинг аттрибута " + attribute + " должен быть задан!");
            return coefficent;
        }
    }
}
