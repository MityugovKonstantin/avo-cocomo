using COCOMOCalculator.BL.Models;
using System;

namespace COCOMOCalculator.Interfaces
{
    public interface ICocomoUi
    {
        void ShowResult(CalculationResult result);

        event EventHandler<BaseCalculationArgs> OnCalculate;
    }
}
