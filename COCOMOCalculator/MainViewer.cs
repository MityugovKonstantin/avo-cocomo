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

            CalculateB.Click += ButBCCalculate_Click;
            CalculateI.Click += ButICCalculate_Click;
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
            try
            {
                var args = new BasicCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        ProjectType = MapProjectType(ProjectTypeComboBoxB.Text),
                        Size = int.Parse(SizeTextB.Text)
                    }
                };
                OnCalculate?.Invoke(sender, args);
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильный формат строки!");
            }
        }

        private void ButICCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var args = new IntermediateCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        Size = int.Parse(SizeTextI.Text),
                        ProjectType = MapProjectType(ProjectTypeComboBoxI.Text)
                    },
                    ProductAttributes = new ProductAttributes
                    {
                        RequiredSoftwareReliability = MapAttributes(RequiredSoftwareRelabilityComboBoxI.Text),
                        SizeOfApplicationDatabase = MapAttributes(SizeOfApplicationDatabaseComboBoxI.Text),
                        ComplexityOfTheProduct = MapAttributes(ComplexityOfTheProductComboBoxI.Text)
                    },
                    HardwareAttributes = new HardwareAttributes
                    {
                        RunTimePerformanceConstraints = MapAttributes(RunTimePerformanceConstraintsComboBoxI.Text),
                        MemoryConstraints = MapAttributes(MemoryConstraintsComboBoxI.Text),
                        VolatilityOfTheVirtualMachineEnvironment = MapAttributes(VolatilityOfTheVirtualMachineEnvironmentComboBoxI.Text),
                        RequiredTurnaboutTime = MapAttributes(ReuiredTurnaboutTimeComboBoxI.Text)
                    },
                    PersonnelAttributes = new PersonnelAttributes
                    {
                        AnalystCapability = MapAttributes(AnalystCapabilityComboBoxI.Text),
                        SoftwareEngineerCapability = MapAttributes(SoftwareEngineerCapabilityComboBoxI.Text),
                        ApplicationsExperience = MapAttributes(ApplicationExperienceComboBoxI.Text),
                        VirtualMachineExperience = MapAttributes(VirtualMachineExperienceComboBoxI.Text),
                        ProgrammingLanguageExperience = MapAttributes(ProgrammingLanguageExperienceComboBoxI.Text)
                    },
                    ProjectAttributes = new ProjectAttributes
                    {
                        UseOfSoftwareTools = MapAttributes(UseOfSoftwareToolsComboBoxI.Text),
                        ApplicationOfSoftwareEngineeringMethods = MapAttributes(ApplicationOfSoftwareEngineeringMethodsComboBoxI.Text),
                        RequiredDevelopmentSchedule = MapAttributes(RequiredDevelopmentScheduleComboBoxI.Text)
                    }
                };
                OnCalculate?.Invoke(sender, args);
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильный формат строки!");
            }
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
