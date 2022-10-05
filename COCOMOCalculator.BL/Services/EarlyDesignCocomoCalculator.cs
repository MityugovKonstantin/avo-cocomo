using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Coefficents;
using System;
using System.Collections.Generic;

namespace COCOMOCalculator.BL.Services
{
    public class EarlyDesignCocomoCalculator
    {
        private readonly Dictionary<string, Dictionary<ScaleFactor, float>> _scaleFactors = FileManager.ScaleFactorDictionaryFill();
        private readonly Dictionary<string, Dictionary<EarlyDesignEffortMultiplier, float>> _effortMultipliers = FileManager.EarlyDesignEffortMultiplierDictionaryFill();
        private readonly CocomoCoefficients _coefficients = FileManager.CocomoCoefficientsFill("Database\\EarlyDesignCoefficents.csv");

        public CalculationResult Calculate(EarlyDesignCalculationArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var scaleFactors = args.ScaleFactorsAttributes;
            if (scaleFactors == null)
                throw new ArgumentException("Scale Factors Attributes не верен.");

            var effortMultipliers = args.EffortMultipliersAttributes;
            if (effortMultipliers == null)
                throw new ArgumentException("Effort Multipliers Attributes не верен.");

            var size = args.Size;

            var scaleFactorsSum = ScaleFactorMap(nameof(scaleFactors.Precedentedness), scaleFactors.Precedentedness);
            scaleFactorsSum += ScaleFactorMap(nameof(scaleFactors.DevelopmentFlexibility), scaleFactors.DevelopmentFlexibility);
            scaleFactorsSum += ScaleFactorMap(nameof(scaleFactors.ArchitectureAndRiskResolution), scaleFactors.ArchitectureAndRiskResolution);
            scaleFactorsSum += ScaleFactorMap(nameof(scaleFactors.TeamCohesion), scaleFactors.TeamCohesion);
            scaleFactorsSum += ScaleFactorMap(nameof(scaleFactors.ProcessMaturuty), scaleFactors.ProcessMaturuty);

            var e = _coefficients.B + 0.01f * scaleFactorsSum;

            var eaf = EffortMutriplierMap(nameof(effortMultipliers.PersonnelCapability), effortMultipliers.PersonnelCapability);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.PersonnelExperience), effortMultipliers.PersonnelExperience);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.ProductRelabilityAndComplexity), effortMultipliers.ProductRelabilityAndComplexity);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.DeveloperForReusability), effortMultipliers.DeveloperForReusability);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.PlatformDifficulty), effortMultipliers.PlatformDifficulty);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.Facilities), effortMultipliers.Facilities);
            eaf *= EffortMutriplierMap(nameof(effortMultipliers.RequiredDevelopmentSchedule), effortMultipliers.RequiredDevelopmentSchedule);

            var peopleMonth = (float)Math.Round(eaf * _coefficients.A * Math.Pow(size, e), 6);

            var sced = EffortMutriplierMap(nameof(effortMultipliers.RequiredDevelopmentSchedule), effortMultipliers.RequiredDevelopmentSchedule);
            var peopleMonthNs = (eaf / sced) * _coefficients.A * Math.Pow(size, e);

            var timeMonth = (float)Math.Round(sced * _coefficients.C * Math.Pow(peopleMonthNs, _coefficients.D + 0.2f * (e - _coefficients.B)), 6);

            return new CalculationResult() { PeopleMonth = peopleMonth, TimeMonth = timeMonth };
        }

        private float ScaleFactorMap(string attribute, ScaleFactor scaleFactor)
        {
            _scaleFactors.TryGetValue(attribute, out var dictionary);
            if (!dictionary.TryGetValue(scaleFactor, out var coefficent))
                throw new ArgumentException("Рейтинг аттрибута " + attribute + " должен быть задан!");
            return coefficent;
        }

        private float EffortMutriplierMap(string attribute, EarlyDesignEffortMultiplier earlyDesignEffortMultiplier)
        {
            _effortMultipliers.TryGetValue(attribute, out var dictionary);
            if (!dictionary.TryGetValue(earlyDesignEffortMultiplier, out var coefficent))
                throw new ArgumentException("Рейтинг аттрибута " + attribute + " должен быть задан!");
            return coefficent;
        }
    }
}
