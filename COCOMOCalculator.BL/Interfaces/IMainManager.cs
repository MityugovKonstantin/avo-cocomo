using COCOMOCalculator.BL.Models;

namespace COCOMOCalculator.BL.Interfaces
{
    public interface IMainManager
    {
        CalculationResult Calculate(int size, ProjectType type);

    }
}