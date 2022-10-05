using COCOMOCalculator.BL.Models;
using System;

namespace COCOMOCalculator.BL.Services
{
    public class BasicCocomoCalculator
    {
        public CalculationResult Calculate(BasicCalculationArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var basicAttributes = args.BasicAttributes;

            if (basicAttributes == null)
                throw new ArgumentException("Basic Attributes не верен.");

            var coefficents = FileManager.ProjectTypeDictionaryFill("Database\\BasicProjectTypeCoefficents.csv");

            if (!coefficents.TryGetValue(basicAttributes.ProjectType, out var coefs))
                throw new ArgumentException("Тип проекта должен быть указан.");

            var peopleMonth = (float)Math.Round(coefs.A * Math.Pow(basicAttributes.Size, coefs.B), 6);
            var timeMonth = (float)Math.Round(coefs.C * Math.Pow(peopleMonth, coefs.D), 6);

            return new CalculationResult { PeopleMonth = peopleMonth, TimeMonth = timeMonth };
        }
    }
}
