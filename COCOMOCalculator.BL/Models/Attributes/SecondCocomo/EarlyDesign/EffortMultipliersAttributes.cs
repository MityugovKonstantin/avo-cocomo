using COCOMOCalculator.BL.Enums;

namespace COCOMOCalculator.BL.Models.Attributes.SecondCocomo
{
    public class EffortMultipliersAttributes
    {
        public EarlyDesignEffortMultiplier PersonnelCapability { get; set; }
        public EarlyDesignEffortMultiplier PersonnelExperience { get; set; }
        public EarlyDesignEffortMultiplier ProductRelabilityAndComplexity { get; set; }
        public EarlyDesignEffortMultiplier DeveloperForReusability { get; set; }
        public EarlyDesignEffortMultiplier PlatformDifficulty { get; set; }
        public EarlyDesignEffortMultiplier Facilities { get; set; }
        public EarlyDesignEffortMultiplier RequiredDevelopmentSchedule { get; set; }
    }
}