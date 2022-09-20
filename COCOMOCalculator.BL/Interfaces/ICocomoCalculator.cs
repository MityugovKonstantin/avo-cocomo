using COCOMOCalculator.BL.Models;

namespace COCOMOCalculator.BL.Interfaces
{
    public interface ICocomoCalculator
    {
        CalculationResult Calculate(BasicCalculationArgs args);

        CalculationResult Calculate(IntermediateCalculationArgs args);

        // ...
    }
}