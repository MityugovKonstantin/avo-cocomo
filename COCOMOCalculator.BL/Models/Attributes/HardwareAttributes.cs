namespace COCOMOCalculator.BL.Models.Attributes
{
    public class HardwareAttributes
    {
        public RatingType SpeedLimit { get; set; }
        public RatingType MemoryLimit { get; set; }
        public RatingType EnvironmentalInstability { get; set; }
        public RatingType RecoveryTime { get; set; }
    }
}
