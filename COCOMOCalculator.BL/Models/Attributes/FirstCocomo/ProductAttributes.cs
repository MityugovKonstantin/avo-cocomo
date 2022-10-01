using COCOMOCalculator.BL.Enums;

namespace COCOMOCalculator.BL.Models.Attributes
{
    public class ProductAttributes
    {
        public RatingType RequiredSoftwareReliability { get; set; }

        public RatingType SizeOfApplicationDatabase { get; set; }

        public RatingType ComplexityOfTheProduct { get; set; }
    }
}
