using COCOMOCalculator.BL.Models;

namespace COCOMOCalculator.BL.Interfaces
{
    public interface IBasicManager
    {
        CalculationResult Calculate(int size, ProjectType type);

    }
}