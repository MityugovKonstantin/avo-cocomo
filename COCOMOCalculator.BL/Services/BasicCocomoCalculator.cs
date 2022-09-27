using COCOMOCalculator.BL.Models;
using System;

namespace COCOMOCalculator.BL.Services
{
    public class BasicCocomoCalculator
    {
        public CalculationResult Calculate(BasicCalculationArgs args)
        {
            var coefficents = FileManager.FillProjectTypeDictionary("Database\\BasicProjectTypeCoefficents.csv");

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var attr = args.BasicAttributes;

            if (attr == null)
                throw new ArgumentException("Атрибуты не заданы.");

            if (!coefficents.TryGetValue(attr.ProjectType, out var coefs))
                throw new ArgumentException("Тип проекта должен быть указан.");

            var peopleMonth = (float)Math.Round(coefs.A * Math.Pow(attr.Size, coefs.B), 6);
            var timeMonth = (float)Math.Round(coefs.C * Math.Pow(peopleMonth, coefs.D), 6);

            return new CalculationResult { PeopleMonth = peopleMonth, TimeMonth = timeMonth };
        }
    }
}
