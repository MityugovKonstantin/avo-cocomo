using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Coefficents;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace COCOMOCalculator.BL.Services
{
    public class FileManager
    {
        public static Dictionary<ProjectType, CocomoCoefficients> FillBasicProjectTypeDictionary()
        {
            var path = "Database\\BasicProjectTypeCoefficents.csv";
            return FillProjectTypeDictionary(path);
        }

        public static Dictionary<ProjectType, CocomoCoefficients> FillIntermediateProjectTypeDictionary()
        {
            var path = "Database\\IntermediateProjectTypeCoefficents.csv";
            return FillProjectTypeDictionary(path);
        }

        public static Dictionary<string, Dictionary<RatingType, float>> FillCostAttributesDictionary()
        {
            var path = "Database\\CostAttributesCoefficents.csv";
            return FillDoubleDictionary<RatingType>(path);
        }

        public static Dictionary<string, Dictionary<ScaleFactor, float>> FillScaleFactorDictionary()
        {
            var path = "Database\\ScaleFactorsCoefficents.csv";
            return FillDoubleDictionary<ScaleFactor>(path);
        }

        public static Dictionary<string, Dictionary<EarlyDesignEffortMultiplier, float>> FillEarlyDesignEffortMultiplierDictionary()
        {
            var path = "Database\\EarlyDesignEffortMultiplierCoefficents.csv";
            return FillDoubleDictionary<EarlyDesignEffortMultiplier>(path);
        }

        public static Dictionary<string, Dictionary<PostArchitectureEffortMultiplier, float>> FillPostArchitectureEffortMultiplierDictionary()
        {
            var path = "Database\\PostArchitectureEffortMultiplierCoefficents.csv";
            return FillDoubleDictionary<PostArchitectureEffortMultiplier>(path);
        }

        public static CocomoCoefficients FillCocomoCoefficients(string path)
        {
            var lines = File.ReadAllLines(path);

            var line = lines[1];
            var coefStrings = line.Split(',');
            var parsedCoefs = CheckCoefParse(coefStrings);

            var coefficents = new CocomoCoefficients()
            {
                A = (float)parsedCoefs[0],
                B = (float)parsedCoefs[1],
                C = (float)parsedCoefs[2],
                D = (float)parsedCoefs[3]
            };

            return coefficents;
        }

        private static Dictionary<ProjectType, CocomoCoefficients> FillProjectTypeDictionary(string path)
        {
            Dictionary<ProjectType, CocomoCoefficients> coefficentsDictionary = new Dictionary<ProjectType, CocomoCoefficients>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var coefStrings = line.Split(',');
                var projectType = MapProjectType(coefStrings[0].Trim());
                var parsedCoefs = CheckCoefParse(coefStrings);

                var coefficents = new CocomoCoefficients()
                {
                    A = (float)parsedCoefs[0],
                    B = (float)parsedCoefs[1],
                    C = (float)parsedCoefs[2],
                    D = (float)parsedCoefs[3]
                };

                coefficentsDictionary.Add(projectType, coefficents);
            }

            return coefficentsDictionary;
        }

        private static Dictionary<string, Dictionary<TEnum, float>> FillDoubleDictionary<TEnum>(string path)
        {
            Dictionary<string, Dictionary<TEnum, float>> coefficentDictionaries = new Dictionary<string, Dictionary<TEnum, float>>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var coefStrings = line.Split(',');
                var scaleFactor = coefStrings[0].Trim();
                var parsedCoefs = CheckCoefParse(coefStrings);
                var dicnionary = FillSubArray<TEnum>(parsedCoefs);
                coefficentDictionaries.Add(scaleFactor, dicnionary);
            }

            return coefficentDictionaries;
        }

        private static Dictionary<TEnum, float> FillSubArray<TEnum>(float?[] parsedCoefs)
        {
            var dicnionary = new Dictionary<TEnum, float>();
            for (int i = 1; i <= parsedCoefs.Length - 1; i++)
            {
                var coefficent = parsedCoefs[i - 1];
                if (coefficent != null)
                {
                    dicnionary.Add(GetEnumTypeByIndex<TEnum>(i), (float)coefficent);
                }
            }
            return dicnionary;
        }

        private static float?[] CheckCoefParse(string[] coefs)
        {
            float?[] parsedCoefs = new float?[coefs.Length - 1];
            for (int i = 1; i < coefs.Length; i++)
            {
                var checkedCoef = coefs[i];
                if (string.IsNullOrWhiteSpace(checkedCoef))
                {
                    parsedCoefs[i - 1] = null;
                }
                else
                {
                    bool parseSuccess = float.TryParse(checkedCoef, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed);
                    if (!parseSuccess)
                        throw new ArgumentException("Ошибка во внешнем файле. \nТип неверного коэффицента : "
                            + coefs[0] + "\nНеверный коэффицент №" + (i + 1));
                    else
                        parsedCoefs[i - 1] = parsed;
                }
            }
            return parsedCoefs;
        }

        private static TEnum GetEnumTypeByIndex<TEnum>(int i)
        {
            return (TEnum)Enum.GetValues(typeof(TEnum)).GetValue(i);
        }

        private static ProjectType MapProjectType(string type)
        {
            return Enum.TryParse<ProjectType>(type, out var enumValue) ? enumValue : default;
        }
    }
}
