using System;
using System.Windows.Forms;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Attributes;
using COCOMOCalculator.Interfaces;

namespace COCOMOCalculator
{
    public partial class COCOMOCalculator : Form, ICocomoUi
    {
        public COCOMOCalculator()
        {
            InitializeComponent();

            butBCCalculate.Click += ButBCCalculate_Click;
            butICCalculate.Click += ButICCalculate_Click;
        }

        public event EventHandler<BaseCalculationArgs> OnCalculate;

        public void ShowResult(CalculationResult result)
        {
            lblPM.Text = $@"People * month : {result.PeopleMonth}";
            lblTM.Text = $@"Time * month : {result.TimeMonth}";
        }

        private void ButBCCalculate_Click(object sender, EventArgs e)
        {
            var args = new BasicCalculationArgs
            {
                BasicAttributes = new BasicAttributes
                {
                    ProjectType = MapProjectType(cmbBCProjectType.Text),
                    Size = int.Parse(txtBCSize.Text)
                }
            };

            OnCalculate?.Invoke(sender, args);
        }

        private void ButICCalculate_Click(object sender, EventArgs e)
        {
            var args = new IntermediateCalculationArgs
            {
                BasicAttributes = new BasicAttributes
                {
                    Size = int.Parse(txtICSize.Text),
                    ProjectType = MapProjectType(cmbICProjectType.Text)
                },
                ProductAttributes = new ProductAttributes
                {
                    SoftwareReadability = MapAttributes(RSRComboBox.Text),
                    DatabaseSize = MapAttributes(SADComboBox.Text),
                    ProductComplexity = MapAttributes(CPComboBox.Text)
                },
                HardwareAttributes = new HardwareAttributes
                {
                    SpeedLimit = MapAttributes(RTPCComboBox.Text),
                    MemoryLimit = MapAttributes(MCComboBox.Text),
                    EnvironmentalInstability = MapAttributes(VVMEComboBox.Text),
                    RecoveryTime = MapAttributes(NRTСomboBox.Text)
                },
                PersonalAttributes = new PersonalAttributes
                { 
                    AnalyticSkills = MapAttributes(ASComboBox.Text),
                    SoftwareDevelopmentAbility = MapAttributes(SDAComboBox.Text),
                    DevelopmentExperience = MapAttributes(DEComboBox.Text),
                    ExperienceWithVirtualMachines = MapAttributes(EWVMComboBox.Text),
                    DevelopmentExperienceInProgrammingLanguages = MapAttributes(DEPLComboBox.Text)
                },
                ProjectAttributes = new ProjectAttributes
                {
                    UsingSDToolkit = MapAttributes(USDTComboBox.Text),
                    ApplicationSDMethods = MapAttributes(ASDMComboBox.Text),
                    DevelopmentScheduleRequirements = MapAttributes(DSRComboBox.Text)
                }
                
            };

            OnCalculate?.Invoke(sender, args);
        }

        private static ProjectType MapProjectType(string type)
        {
            switch (type)
            {
                case "Common":
                    return ProjectType.Common;

                case "Semi-independent":
                    return ProjectType.SemiIndependent;

                case "Built-in":
                    return ProjectType.BuiltIn;

                default:
                    return default;
            }
        }

        private RatingType MapAttributes(string type)
        {
            switch (type)
            {
                case "Very low":
                    return RatingType.VeryLow;
                case "Low":
                    return RatingType.Low;
                case "Normal":
                    return RatingType.Normal;
                case "High":
                    return RatingType.High;
                case "Very high":
                    return RatingType.VeryHigh;
                case "Critical":
                    return RatingType.Critical;
                default:
                    throw new Exception("Неверно указан тип атрибуита");
            }
        }

    }
}
