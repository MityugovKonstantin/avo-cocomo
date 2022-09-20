using System;
using System.Collections.Generic;
using COCOMOCalculator.BL.Interfaces;
using COCOMOCalculator.BL.Models;

namespace COCOMOCalculator.BL.Services
{
    public class CocomoCalculator : ICocomoCalculator
    {
        private readonly Dictionary<ProjectType, Coefficients> _coefficients =new Dictionary<ProjectType, Coefficients>
        {
            { ProjectType.Common,          new Coefficients { A = 2.4f, B = 1.05f, C = 2.5f, D = 0.38f } },
            { ProjectType.SemiIndependent, new Coefficients { A = 3.0f, B = 1.12f, C = 2.5f, D = 0.35f } },
            { ProjectType.BuiltIn,         new Coefficients { A = 3.6f, B = 1.20f, C = 2.5f, D = 0.32f } },
        };

        public CalculationResult Calculate(BasicCalculationArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var attr = args.BasicAttributes;

            if (attr == null)
                throw new ArgumentException("Атрибуты не заданы.");

            if (!_coefficients.TryGetValue(attr.ProjectType, out var coefs))
                throw new ArgumentException("Тип проекта должен быть указан.");

            var pm = (float)Math.Round(coefs.A * Math.Pow(attr.Size, coefs.B), 6);
            var tm = (float)Math.Round(coefs.C * Math.Pow(pm, coefs.D), 6);

            return new CalculationResult { PeopleMonth = pm, TimeMonth = tm };
        }

        public CalculationResult Calculate(IntermediateCalculationArgs args)
        {
            throw new NotImplementedException();
        }

        private class Coefficients
        {
            public float A { get; set; }
            public float B { get; set; }
            public float C { get; set; }
            public float D { get; set; }
        }
    }
}
