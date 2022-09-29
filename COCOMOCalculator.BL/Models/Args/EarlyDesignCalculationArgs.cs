using COCOMOCalculator.BL.Models.Attributes;
using COCOMOCalculator.BL.Models.Attributes.SecondCocomo;

namespace COCOMOCalculator.BL.Models
{
    public class EarlyDesignCalculationArgs : BaseCalculationArgs
    {
        public int Size { get; set; }
        public ScaleFactorsAttributes ScaleFactorsAttributes { get; set; }
        public EffortMultipliersAttributes EffortMultipliersAttributes { get; set; }
    }
}
