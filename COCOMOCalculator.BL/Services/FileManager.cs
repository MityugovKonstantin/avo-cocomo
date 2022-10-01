using COCOMOCalculator.BL.Models.Coefficents;
using COCOMOCalculator.BL.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace COCOMOCalculator.BL.Services
{
    public class FileManager<T>
    {
        public static Dictionary<ProjectType, ProjectTypeCoefficients> ProjectTypeDictionaryFill(string path)
        {
            Dictionary<ProjectType, ProjectTypeCoefficients> coefficentsDictionary = new Dictionary<ProjectType, ProjectTypeCoefficients>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var coefStrings = line.Split(',');
                var projectType = MapProjectType(coefStrings[0].Trim());

                CoefParseCheck(coefStrings);

                var coefficents = new ProjectTypeCoefficients()
                {
                    A = float.Parse(coefStrings[1]),
                    B = float.Parse(coefStrings[2]),
                    C = float.Parse(coefStrings[3]),
                    D = float.Parse(coefStrings[4])
                };

                coefficentsDictionary.Add(projectType, coefficents);
            }

            return coefficentsDictionary;
        }

        public static Dictionary<string, Dictionary<T, float>> CostAttributesDictionaryFill()
        {
            var path = "Database\\CostAttributesCoefficents.csv";
            var size = 6;
            return DoubleDictionaryFill(path, size);
        }

        public static Dictionary<string, Dictionary<T, float>> ScaleFactorDictionaryFill()
        {
            var path = "Database\\ScaleFactorsCoefficents.csv";
            var size = 6;
            return DoubleDictionaryFill(path, size);
        }

        public static Dictionary<string, Dictionary<T, float>> EarlyDesignEffortMultiplierDictionaryFill()
        {
            var path = "Database\\EarlyDesignEffortMultiplierCoefficents.csv";
            var size = 7;
            return DoubleDictionaryFill(path, size);
        }

        public static Dictionary<string, Dictionary<T, float>> PostArchitectureEffortMultiplierDictionaryFill()
        {
            var path = "Database\\PostArchitectureEffortMultiplierCoefficents.csv";
            var size = 6;
            return DoubleDictionaryFill(path, size);
        }

        private static Dictionary<string, Dictionary<T, float>> DoubleDictionaryFill(string path, int size)
        {
            Dictionary<string, Dictionary<T, float>> coefficentDictionaries = new Dictionary<string, Dictionary<T, float>>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var coefStrings = line.Split(',');
                var scaleFactor = coefStrings[0].Trim();

                CoefParseCheck(coefStrings);

                var dicnionary = SubArrayFill(size, coefStrings);
                coefficentDictionaries.Add(scaleFactor, dicnionary);
            }

            return coefficentDictionaries;
        }

        private static Dictionary<T, float> SubArrayFill(int size, string[] coefStrings)
        {
            var dicnionary = new Dictionary<T, float>();
            for (int i = 1; i <= size; i++)
            {
                if (!string.IsNullOrWhiteSpace(coefStrings[i]))
                {
                    dicnionary.Add(GetEnumValueByIndex(i), float.Parse(coefStrings[i]));
                }
            }
            return dicnionary;
        }

        private static void CoefParseCheck(string[] coefs)
        {
            float[] parsedCoefs = new float[coefs.Length - 1];
            for (int i = 1; i < coefs.Length - 1; i++)
            {
                if (!string.IsNullOrWhiteSpace(coefs[i]))
                {
                    bool parseSuccess = float.TryParse(coefs[i], out parsedCoefs[i - 1]);
                    if (!parseSuccess)
                        throw new ArgumentException("Ошибка во внешнем файле. \nТип неверного коэффицента : "
                            + coefs[0] + "\nНеверный коэффицент №" + (i + 1));
                }
            }
        }

        private static T GetEnumValueByIndex(int i)
        {
            return (T)Enum.GetValues(typeof(T)).GetValue(i);
        }

        private static ProjectType MapProjectType(string type)
        {
            switch (type)
            {
                case "Common":
                    return ProjectType.Common;
                case "SemiIndependent":
                    return ProjectType.SemiIndependent;
                case "BuiltIn":
                    return ProjectType.BuiltIn;
                default:
                    return ProjectType.Undefined;
            }
        }
    }
}
