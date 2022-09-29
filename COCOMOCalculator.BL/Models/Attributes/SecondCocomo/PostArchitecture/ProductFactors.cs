using COCOMOCalculator.BL.Enums;

namespace COCOMOCalculator.BL.Models.Attributes.SecondCocomo
{
    public class ProductFactors
    {
        public PostArchitectureEffortMultiplier RequiredSoftwareReliability { get; set; }
        public PostArchitectureEffortMultiplier DatabaseSize { get; set; }
        public PostArchitectureEffortMultiplier SoftwareProductComplexity { get; set; }
        public PostArchitectureEffortMultiplier RequiredResability { get; set; }
        public PostArchitectureEffortMultiplier DocumentationMatchToLifeCycleNeeds { get; set; }

    }
}
