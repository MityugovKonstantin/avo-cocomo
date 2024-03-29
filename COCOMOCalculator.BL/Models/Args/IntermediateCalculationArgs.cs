﻿using COCOMOCalculator.BL.Models.Attributes;

namespace COCOMOCalculator.BL.Models
{
    public class IntermediateCalculationArgs : BaseCalculationArgs
    {
        public BasicAttributes BasicAttributes { get; set; }

        public ProductAttributes ProductAttributes { get; set; }

        public HardwareAttributes HardwareAttributes { get; set; }

        public PersonnelAttributes PersonnelAttributes { get; set; }

        public ProjectAttributes ProjectAttributes { get; set; }
    }
}
