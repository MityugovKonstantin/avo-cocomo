using COCOMOCalculator.BL.Models.Attributes.SecondCocomo;

namespace COCOMOCalculator.BL.Models.Args
{
    public class PostArchitectureCalculationArgs : BaseCalculationArgs
    {
        public int Size { get; set; }
        public ScaleFactorsAttributes ScaleFactorsAttributes { get; set; }
        public PersonnelFactors PersonnelFactors { get; set; }
        public ProductFactors ProductFactors { get; set; }
        public PlatformFactors PlatformFactors { get; set; }
        public ProjectFactors ProjectFactors { get; set; }
    }
}
