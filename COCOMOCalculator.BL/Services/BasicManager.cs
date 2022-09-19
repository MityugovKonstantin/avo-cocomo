using System;
using System.Collections.Generic;
using COCOMOCalculator.BL.Interfaces;
using COCOMOCalculator.BL.Models;

namespace COCOMOCalculator.BL.Services
{
    public class BasicManager : IBasicManager
    {
        private readonly Dictionary<ProjectType, Coefficients> _coefficients =new Dictionary<ProjectType, Coefficients>
        {
            { ProjectType.Common,          new Coefficients { A = 2.4f, B = 1.05f, C = 2.5f, D = 0.38f } },
            { ProjectType.SemiIndependent, new Coefficients { A = 3.0f, B = 1.05f, C = 2.5f, D = 0.35f } },
            { ProjectType.BuiltIn,         new Coefficients { A = 3.6f, B = 1.20f, C = 2.5f, D = 0.32f } },
        };

        public CalculationResult Calculate(int size, ProjectType type)
        {
            if (!_coefficients.TryGetValue(type, out var coefs))
                throw new Exception("Тип проекта должен быть указан.");

            var pm = (float)Math.Round(coefs.A * Math.Pow(size, coefs.B), 6);
            var tm = (float)Math.Round(coefs.C * Math.Pow(pm, coefs.D), 6);

            return new CalculationResult { Pm = pm, Tm = tm };
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
