using COCOMOCalculator.BL.Enums;

namespace COCOMOCalculator.BL.Models.Attributes
{
    public class PersonnelAttributes
    {
        public RatingType AnalystCapability { get; set; }
        public RatingType SoftwareEngineerCapability { get; set; }
        public RatingType ApplicationsExperience { get; set; }
        public RatingType VirtualMachineExperience { get; set; }
        public RatingType ProgrammingLanguageExperience { get; set; }
    }
}
