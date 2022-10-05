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
        public static Dictionary<ProjectType, CocomoCoefficients> ProjectTypeDictionaryFill(string path)
        {
            Dictionary<ProjectType, CocomoCoefficients> coefficentsDictionary = new Dictionary<ProjectType, CocomoCoefficients>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var coefStrings = line.Split(',');
                var projectType = MapProjectType(coefStrings[0].Trim());
                var parsedCoefs = CoefParseCheck(coefStrings);

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

        public static Dictionary<string, Dictionary<RatingType, float>> CostAttributesDictionaryFill()
        {
            var path = "Database\\CostAttributesCoefficents.csv";
            return DoubleDictionaryFill<RatingType>(path);
        }

        public static Dictionary<string, Dictionary<ScaleFactor, float>> ScaleFactorDictionaryFill()
        {
            var path = "Database\\ScaleFactorsCoefficents.csv";
            return DoubleDictionaryFill<ScaleFactor>(path);
        }

        public static Dictionary<string, Dictionary<EarlyDesignEffortMultiplier, float>> EarlyDesignEffortMultiplierDictionaryFill()
        {
            var path = "Database\\EarlyDesignEffortMultiplierCoefficents.csv";
            return DoubleDictionaryFill<EarlyDesignEffortMultiplier>(path);
        }

        public static Dictionary<string, Dictionary<PostArchitectureEffortMultiplier, float>> PostArchitectureEffortMultiplierDictionaryFill()
        {
            var path = "Database\\PostArchitectureEffortMultiplierCoefficents.csv";
            return DoubleDictionaryFill<PostArchitectureEffortMultiplier>(path);
        }

        public static CocomoCoefficients CocomoCoefficientsFill(string path)
        {
            var lines = File.ReadAllLines(path);

            var line = lines[1];
            var coefStrings = line.Split(',');
            var parsedCoefs = CoefParseCheck(coefStrings);

            var coefficents = new CocomoCoefficients()
            {
                A = (float)parsedCoefs[0],
                B = (float)parsedCoefs[1],
                C = (float)parsedCoefs[2],
                D = (float)parsedCoefs[3]
            };

            return coefficents;
        }

        private static Dictionary<string, Dictionary<TEnum, float>> DoubleDictionaryFill<TEnum>(string path)
        {
            Dictionary<string, Dictionary<TEnum, float>> coefficentDictionaries = new Dictionary<string, Dictionary<TEnum, float>>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var coefStrings = line.Split(',');
                var scaleFactor = coefStrings[0].Trim();
                var parsedCoefs = CoefParseCheck(coefStrings);
                var dicnionary = SubArrayFill<TEnum>(parsedCoefs);
                coefficentDictionaries.Add(scaleFactor, dicnionary);
            }

            return coefficentDictionaries;
        }

        private static Dictionary<TEnum, float> SubArrayFill<TEnum>(float?[] parsedCoefs)
        {
            var dicnionary = new Dictionary<TEnum, float>();
            for (int i = 1; i <= parsedCoefs.Length - 1; i++)
            {
                var coefficent = parsedCoefs[i - 1];
                if (coefficent != null)
                {
                    dicnionary.Add(GetEnum<TEnum>(i), (float)coefficent);
                }
            }
            return dicnionary;
        }

        private static float?[] CoefParseCheck(string[] coefs)
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

        private static TEnum GetEnum<TEnum>(int i)
        {
            return (TEnum)Enum.GetValues(typeof(TEnum)).GetValue(i);
        }

        private static ProjectType MapProjectType(string type)
        {
            return Enum.TryParse<ProjectType>(type, out var enumValue) ? enumValue : default;
        }
    }
}
