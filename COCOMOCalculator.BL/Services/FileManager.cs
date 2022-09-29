    using COCOMOCalculator.BL.Models.Coefficents;
using COCOMOCalculator.BL.Models;
using System.Collections.Generic;
using System.IO;
using COCOMOCalculator.BL.Enums;
using System.Linq;
using System;
using System.Security.Cryptography;

namespace COCOMOCalculator.BL.Services
{
    public class FileManager
    {

        public static Dictionary<ProjectType, ProjectTypeCoefficients> ProjectTypeDictionaryFill(string path)
        {
            Dictionary<ProjectType, ProjectTypeCoefficients> coefficentsDictionary = new Dictionary<ProjectType, ProjectTypeCoefficients>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var coefStrings = line.Split(',');
                var projectType = MapProjectType(coefStrings[0].Trim());

                coefParseCheck(coefStrings);

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

        public static Dictionary<string, Dictionary<RatingType, float>> CostAttributesDictionaryFill(string path)
        {
            Dictionary<string, Dictionary<RatingType, float>> coefficentDictionaries = new Dictionary<string, Dictionary<RatingType, float>>();

            var lines = File.ReadAllLines(path);
            
            foreach (var line in lines.Skip(1))
            {
                var coefStrings = line.Split(',');
                var costAttribute = coefStrings[0].Trim();

                coefParseCheck(coefStrings);

                var dicnionary = new Dictionary<RatingType, float>();
                for (int i = 1; i < 7; i++)
                {
                    if (!string.IsNullOrWhiteSpace(coefStrings[i]))
                    {
                        dicnionary.Add(GetRatingTypeByIndex(i), float.Parse(coefStrings[i]));
                    }
                }
                coefficentDictionaries.Add(costAttribute, dicnionary);
            }
            return coefficentDictionaries;
        }



        private static void coefParseCheck(string[] coefs)
        {
            float[] parsedCoefs = new float[coefs.Length - 1];
            for (int i = 1; i < coefs.Length - 1; i++)
            {
                if (!string.IsNullOrWhiteSpace(coefs[i]))
                {
                    bool parseSuccess = float.TryParse(coefs[i], out parsedCoefs[i - 1]);
                    if (!parseSuccess)
                        throw new ArgumentException("Ошибка во внешнем файле. \nТип неверного коэффицента : " + coefs[0] + "\nНеверный коэффицент №" + (i + 1));
                }
            }
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

        private static RatingType GetRatingTypeByIndex(int i)
        {
            switch (i)
            {
                case 1:
                    return RatingType.VeryLow;
                case 2:
                    return RatingType.Low;
                case 3:
                    return RatingType.Normal;
                case 4:
                    return RatingType.High;
                case 5:
                    return RatingType.VeryHigh;
                case 6:
                    return RatingType.Critical;
                default:
                    return RatingType.Undefined;
            }
        }
    }
}
