using COCOMOCalculator.BL.Interfaces;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Args;

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

        public CalculationResult Calculate(EarlyDesignCalculationArgs args)
        {
            EarlyDesignCocomoCalculator calculator = new EarlyDesignCocomoCalculator();
            return calculator.Calculate(args);
        }

        public CalculationResult Calculate(PostArchitectureCalculationArgs args)
        {
            PostArchitectureCocomoCalculator calculator = new PostArchitectureCocomoCalculator();
            return calculator.Calculate(args);
        }
    }
}
