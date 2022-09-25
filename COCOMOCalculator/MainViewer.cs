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
            new MessageService().ShowMessage(
                $@"People * month : {result.PeopleMonth}" +
                "\n" +
                $@"Time * month : {result.TimeMonth}"
            );
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
                    RequiredSoftwareReliability = MapAttributes(RSRComboBox.Text),
                    SizeOfApplicationDatabase = MapAttributes(SADComboBox.Text),
                    ComplexityOfTheProduct = MapAttributes(CPComboBox.Text)
                },
                HardwareAttributes = new HardwareAttributes
                {
                    RunTimePerformanceConstraints = MapAttributes(RTPCComboBox.Text),
                    MemoryConstraints = MapAttributes(MCComboBox.Text),
                    VolatilityOfTheVirtualMachineEnvironment = MapAttributes(VVMEComboBox.Text),
                    RequiredTurnaboutTime = MapAttributes(NRTСomboBox.Text)
                },
                PersonnelAttributes = new PersonnelAttributes
                {
                    AnalystCapability = MapAttributes(ASComboBox.Text),
                    SoftwareEngineerCapability = MapAttributes(SDAComboBox.Text),
                    ApplicationsExperience = MapAttributes(DEComboBox.Text),
                    VirtualMachineExperience = MapAttributes(EWVMComboBox.Text),
                    ProgrammingLanguageExperience = MapAttributes(DEPLComboBox.Text)
                },
                ProjectAttributes = new ProjectAttributes
                {
                    UseOfSoftwareTools = MapAttributes(USDTComboBox.Text),
                    ApplicationOfSoftwareEngineeringMethods = MapAttributes(ASDMComboBox.Text),
                    RequiredDevelopmentSchedule = MapAttributes(DSRComboBox.Text)
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
                    return ProjectType.Undefined;
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
                    return RatingType.Undefined;
            }
        }

    }
}
