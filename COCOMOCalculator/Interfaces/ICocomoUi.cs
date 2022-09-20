using System;
using COCOMOCalculator.BL.Models;

namespace COCOMOCalculator.Interfaces
{
    public interface ICocomoUi
    {
        void ShowResult(CalculationResult result);

        event EventHandler<BaseCalculationArgs> OnCalculate;
    }
}
