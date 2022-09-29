using COCOMOCalculator.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COCOMOCalculator.BL.Services
{
    public class EarlyDesignCocomoCalculator
    {
        private const float A = 2.94f;
        private const float B = 0.91f;
        private const float C = 3.67f;
        private const float D = 0.28f;

        public CalculationResult Calculate(EarlyDesignCalculationArgs args)
        {
            var size = args.Size;




            var eaf = 0f;

            var peopleMonth = eaf * A * Math.Pow(size, 1);
            //var timeMonth;
            return null;// new CalculationResult() { PeopleMonth = peopleMonth, TimeMonth = timeMonth };
        }
    }
}
