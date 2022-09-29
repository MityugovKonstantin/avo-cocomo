using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Args;

namespace COCOMOCalculator.BL.Interfaces
{
    public interface ICocomoCalculator
    {
        CalculationResult Calculate(BasicCalculationArgs args);

        CalculationResult Calculate(IntermediateCalculationArgs args);

        CalculationResult Calculate(EarlyDesignCalculationArgs args);

        CalculationResult Calculate(PostArchitectureCalculationArgs args);
    }
}