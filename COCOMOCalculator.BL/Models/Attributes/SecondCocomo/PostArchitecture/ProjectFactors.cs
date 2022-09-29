using COCOMOCalculator.BL.Enums;

namespace COCOMOCalculator.BL.Models.Attributes.SecondCocomo
{
    public class ProjectFactors
    {
        public PostArchitectureEffortMultiplier UseOfSoftwareTools { get; set; }
        public PostArchitectureEffortMultiplier MultisiteDevelopment { get; set; }
        public PostArchitectureEffortMultiplier RequiredDevelopmentSchedule { get; set; }
    }
}
