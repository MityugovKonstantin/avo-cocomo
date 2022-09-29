using COCOMOCalculator.BL.Enums;

namespace COCOMOCalculator.BL.Models.Attributes.SecondCocomo
{
    public class PersonnelFactors
    {
        public PostArchitectureEffortMultiplier AnalystCapability { get; set; }
        public PostArchitectureEffortMultiplier ApplicationExperience { get; set; }
        public PostArchitectureEffortMultiplier ProgrammerCapability { get; set; }
        public PostArchitectureEffortMultiplier PersonnelContinuity { get; set; }
        public PostArchitectureEffortMultiplier PlatformExperience { get; set; }
        public PostArchitectureEffortMultiplier LanguageAndToolExperience { get; set; }
    }
}
