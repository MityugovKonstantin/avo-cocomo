using COCOMOCalculator.BL.Enums;

namespace COCOMOCalculator.BL.Models.Attributes
{
    public class HardwareAttributes
    {
        public RatingType RunTimePerformanceConstraints { get; set; }
        public RatingType MemoryConstraints { get; set; }
        public RatingType VolatilityOfTheVirtualMachineEnvironment { get; set; }
        public RatingType RequiredTurnaboutTime { get; set; }
    }
}
