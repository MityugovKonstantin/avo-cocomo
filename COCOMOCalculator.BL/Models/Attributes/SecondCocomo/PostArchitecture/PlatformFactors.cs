using COCOMOCalculator.BL.Enums;

namespace COCOMOCalculator.BL.Models.Attributes.SecondCocomo
{
    public class PlatformFactors
    {
        public PostArchitectureEffortMultiplier ExecutionTimeConstraint { get; set; }
        public PostArchitectureEffortMultiplier MainStorageConstraint { get; set; }
        public PostArchitectureEffortMultiplier PlatformVolatility { get; set; }
    }
}
