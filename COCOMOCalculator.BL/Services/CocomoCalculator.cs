using System;
using COCOMOCalculator.BL.Interfaces;
using COCOMOCalculator.BL.Models;

namespace COCOMOCalculator.BL.Services
{
    public class CocomoCalculator : ICocomoCalculator
    {
        public CalculationResult Calculate(BasicCalculationArgs args)
        {
            BasicCocomoCalculator calculator = new BasicCocomoCalculator();
            return calculator.Calculate(args);
        }

        public CalculationResult Calculate(IntermediateCalculationArgs args)
        {
            IntermediateCocomoCalculator calculator = new IntermediateCocomoCalculator();
            return calculator.Calculate(args);
        }
    }
}
