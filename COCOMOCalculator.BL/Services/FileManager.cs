using COCOMOCalculator.BL.Models.Coefficents;
using COCOMOCalculator.BL.Models;
using System.Collections.Generic;
using System.IO;

namespace COCOMOCalculator.BL.Services
{
    public class FileManager
    {
        public static Dictionary<ProjectType, ProjectTypeCoefficients> FillProjectTypeDictionary(string path)
        {
            Dictionary<ProjectType, ProjectTypeCoefficients> coefficentsDictionary = new Dictionary<ProjectType, ProjectTypeCoefficients>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var coefficentStrings = line.Split(',');
                var projectType = MapProjectType(coefficentStrings[0]);
                var coefficents = new ProjectTypeCoefficients()
                {
                    A = float.Parse(coefficentStrings[1]),
                    B = float.Parse(coefficentStrings[2]),
                    C = float.Parse(coefficentStrings[3]),
                    D = float.Parse(coefficentStrings[4])
                };
                coefficentsDictionary.Add(projectType, coefficents);
            }
            return coefficentsDictionary;
        }

        public static Dictionary<string, Dictionary<RatingType, float>> FillCostAttributesDictionary(string path)
        {

            Dictionary<string, Dictionary<RatingType, float>> coefficentDictionaries = new Dictionary<string, Dictionary<RatingType, float>>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var coefficentStrings = line.Split(',');
                var costAttribute = coefficentStrings[0];
                var dicnionary = new Dictionary<RatingType, float>();
                for (int i = 1; i < 7; i++)
                {
                    if (coefficentStrings[i] != "null")
                    {
                        dicnionary.Add(GetRatingTypeByIndex(i), float.Parse(coefficentStrings[i]));
                    }
                }
                coefficentDictionaries.Add(costAttribute, dicnionary);
            }
            return coefficentDictionaries;
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
