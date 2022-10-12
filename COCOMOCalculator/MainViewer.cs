using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Args;
using COCOMOCalculator.BL.Models.Attributes;
using COCOMOCalculator.BL.Models.Attributes.SecondCocomo;
using COCOMOCalculator.Interfaces;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace COCOMOCalculator
{
    public partial class COCOMOCalculator : Form, ICocomoUi
    {
        public COCOMOCalculator()
        {
            InitializeComponent();

            CalculateB.Click += CalculateB_Click;
            CalculateI.Click += CalculateI_Click;
            CalculateEd.Click += CalculateEd_Click;
            CalculatePa.Click += CalculatePa_Click;

            CopyResultButton.Click += ResultLabel_Click;
        }

        public event EventHandler<BaseCalculationArgs> OnCalculate;

        public void ShowResult(CalculationResult result)
        {
            ResultLabel.Text = $@"Трудоёмкость: {result.PeopleMonth}        Время разработки (в месяцах): {result.TimeMonth}";
        }

        private void CalculateB_Click(object sender, EventArgs e)
        {
            try
            {
                var args = new BasicCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        ProjectType = MapProjectType(ProjectTypeComboBoxB.Text),
                        Size = int.Parse(SizeTextB.Value.ToString())
                    }
                };
                OnCalculate?.Invoke(sender, args);
            }

            catch (Exception)
            {
                MessageBox.Show("Неправильный формат строки!");
            }
        }

        private void CalculateI_Click(object sender, EventArgs e)
        {
            try
            {
                var args = new IntermediateCalculationArgs
                {
                    BasicAttributes = new BasicAttributes
                    {
                        Size = int.Parse(SizeTextI.Value.ToString()),
                        ProjectType = MapProjectType(ProjectTypeComboBoxI.Text)
                    },
                    ProductAttributes = new ProductAttributes
                    {
                        RequiredSoftwareReliability = MapRatingType(RequiredSoftwareRelabilityComboBoxI.Text),
                        SizeOfApplicationDatabase = MapRatingType(SizeOfApplicationDatabaseComboBoxI.Text),
                        ComplexityOfTheProduct = MapRatingType(ComplexityOfTheProductComboBoxI.Text)
                    },
                    HardwareAttributes = new HardwareAttributes
                    {
                        RunTimePerformanceConstraints = MapRatingType(RunTimePerformanceConstraintsComboBoxI.Text),
                        MemoryConstraints = MapRatingType(MemoryConstraintsComboBoxI.Text),
                        VolatilityOfTheVirtualMachineEnvironment = MapRatingType(VolatilityOfTheVirtualMachineEnvironmentComboBoxI.Text),
                        RequiredTurnaboutTime = MapRatingType(ReuiredTurnaboutTimeComboBoxI.Text)
                    },
                    PersonnelAttributes = new PersonnelAttributes
                    {
                        AnalystCapability = MapRatingType(AnalystCapabilityComboBoxI.Text),
                        SoftwareEngineerCapability = MapRatingType(SoftwareEngineerCapabilityComboBoxI.Text),
                        ApplicationsExperience = MapRatingType(ApplicationExperienceComboBoxI.Text),
                        VirtualMachineExperience = MapRatingType(VirtualMachineExperienceComboBoxI.Text),
                        ProgrammingLanguageExperience = MapRatingType(ProgrammingLanguageExperienceComboBoxI.Text)
                    },
                    ProjectAttributes = new ProjectAttributes
                    {
                        UseOfSoftwareTools = MapRatingType(UseOfSoftwareToolsComboBoxI.Text),
                        ApplicationOfSoftwareEngineeringMethods = MapRatingType(ApplicationOfSoftwareEngineeringMethodsComboBoxI.Text),
                        RequiredDevelopmentSchedule = MapRatingType(RequiredDevelopmentScheduleComboBoxI.Text)
                    }
                };
                OnCalculate?.Invoke(sender, args);
            }
            catch (Exception)
            {
                new MessageService().ShowError("Неправильный формат строки!");
            }
        }

        private void CalculateEd_Click(object sender, EventArgs e)
        {
            try
            {
                var args = new EarlyDesignCalculationArgs
                {
                    Size = int.Parse(SizeTextEd.Value.ToString()),
                    ScaleFactorsAttributes = new ScaleFactorsAttributes
                    {
                        Precedentedness = MapScaleFactor(PrecedentednessComboBoxEd.Text),
                        DevelopmentFlexibility = MapScaleFactor(DevelopmentFlexibilityComboBoxEd.Text),
                        ArchitectureAndRiskResolution = MapScaleFactor(ArchitectureAndRiskResolutionComboBoxEd.Text),
                        TeamCohesion = MapScaleFactor(TeamCohesionComboBoxEd.Text),
                        ProcessMaturuty = MapScaleFactor(ProcessMaturityComboBoxEd.Text)
                    },
                    EffortMultipliersAttributes = new EffortMultipliersAttributes
                    {
                        PersonnelCapability = MapEarlyDesignEffortMultiplier(PersonnelCapabilityComboBoxEd.Text),
                        PersonnelExperience = MapEarlyDesignEffortMultiplier(PersonnelExperienceComboBoxEd.Text),
                        ProductRelabilityAndComplexity = MapEarlyDesignEffortMultiplier(ProductReabilityAndComplexityComboBoxEd.Text),
                        DeveloperForReusability = MapEarlyDesignEffortMultiplier(DevelopedForReusabilityComboBoxEd.Text),
                        PlatformDifficulty = MapEarlyDesignEffortMultiplier(PlatformDifficultyComboBoxEd.Text),
                        Facilities = MapEarlyDesignEffortMultiplier(FacilitiesComboBoxEd.Text),
                        RequiredDevelopmentSchedule = MapEarlyDesignEffortMultiplier(RequiredDevelopmentScheduleComboBoxEd.Text)
                    }
                };
                OnCalculate?.Invoke(sender, args);
            }
            catch (Exception)
            {
                new MessageService().ShowError("Неправильный формат строки!");
            }
        }

        private void CalculatePa_Click(object sender, EventArgs e)
        {
            try
            {

                var args = new PostArchitectureCalculationArgs
                {
                    Size = int.Parse(SizeTextPa.Value.ToString()),
                    ScaleFactorsAttributes = new ScaleFactorsAttributes
                    {
                        Precedentedness = MapScaleFactor(PrecedentednessComboBoxPa.Text),
                        DevelopmentFlexibility = MapScaleFactor(DevelopmentFlexibilityComboBoxPa.Text),
                        ArchitectureAndRiskResolution = MapScaleFactor(ArchitectureAndRiskResolutionComboBoxPa.Text),
                        TeamCohesion = MapScaleFactor(TeamCohesionComboBoxPa.Text),
                        ProcessMaturuty = MapScaleFactor(ProcessMaturityComboBoxPa.Text)
                    },
                    PersonnelFactors = new PersonnelFactors
                    {
                        AnalystCapability = MapPostArchitectureEffortMultiplier(AnalystCapabilityComboBoxPa.Text),
                        ApplicationExperience = MapPostArchitectureEffortMultiplier(ApplicationExperienceComboBoxPa.Text),
                        ProgrammerCapability = MapPostArchitectureEffortMultiplier(ProgrammerCapabilityComboBoxPa.Text),
                        PersonnelContinuity = MapPostArchitectureEffortMultiplier(PersonnelCapabilityComboBoxPa.Text),
                        PlatformExperience = MapPostArchitectureEffortMultiplier(PlatformExperienceComboBoxPa.Text),
                        LanguageAndToolExperience = MapPostArchitectureEffortMultiplier(LanguageAndToolExperienceComboBoxPa.Text)
                    },
                    ProductFactors = new ProductFactors
                    {
                        RequiredSoftwareReliability = MapPostArchitectureEffortMultiplier(RequiredSoftwareRelabilityComboBoxPa.Text),
                        DatabaseSize = MapPostArchitectureEffortMultiplier(DatabaseSizeComboBoxPa.Text),
                        SoftwareProductComplexity = MapPostArchitectureEffortMultiplier(SoftwareProductComplexityComboBoxPa.Text),
                        RequiredResability = MapPostArchitectureEffortMultiplier(RequiredReusabilityComboBoxPa.Text),
                        DocumentationMatchToLifeCycleNeeds = MapPostArchitectureEffortMultiplier(DocumentationMatchToLifeCycleNeedsComboBoxPa.Text)
                    },
                    PlatformFactors = new PlatformFactors
                    {
                        ExecutionTimeConstraint = MapPostArchitectureEffortMultiplier(ExecutionTimeConstraintComboBoxPa.Text),
                        MainStorageConstraint = MapPostArchitectureEffortMultiplier(MainStorageConstraintComboBoxPa.Text),
                        PlatformVolatility = MapPostArchitectureEffortMultiplier(PlatformVolatilityComboBoxPa.Text)
                    },
                    ProjectFactors = new ProjectFactors
                    {
                        UseOfSoftwareTools = MapPostArchitectureEffortMultiplier(UseOfSoftwareToolsComboBoxPa.Text),
                        MultisiteDevelopment = MapPostArchitectureEffortMultiplier(MultisiteDevelopmentComboBoxPa.Text),
                        RequiredDevelopmentSchedule = MapPostArchitectureEffortMultiplier(RequiredDevelopmentScheduleComboBoxPa.Text)
                    }
                };
                OnCalculate?.Invoke(sender, args);
            }
            catch (Exception)
            {
                new MessageService().ShowError("Неправильный формат строки!");
            }
        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ResultLabel.Text);
        }

        private ProjectType MapProjectType(string type)
        {
            switch (type)
            {
                case "Распространённый":
                    return ProjectType.Common;

                case "Полунезависимый":
                    return ProjectType.SemiIndependent;

                case "Встроенный":
                    return ProjectType.BuiltIn;

                default:
                    return ProjectType.Undefined;
            }
        }

        private RatingType MapRatingType(string type)
        {
            switch (type)
            {
                case "Очень низкий":
                    return RatingType.VeryLow;

                case "Низкий":
                    return RatingType.Low;

                case "Средний":
                    return RatingType.Normal;

                case "Высокий":
                    return RatingType.High;

                case "Очень высокий":
                    return RatingType.VeryHigh;

                case "Критический":
                    return RatingType.Critical;

                default:
                    return RatingType.Undefined;
            }
        }

        private ScaleFactor MapScaleFactor(string factor)
        {
            switch (factor)
            {
                case "Очень низкий":
                    return ScaleFactor.VeryLow;

                case "Низкий":
                    return ScaleFactor.Low;

                case "Средний":
                    return ScaleFactor.Nominal;

                case "Высокий":
                    return ScaleFactor.High;

                case "Очень высокий":
                    return ScaleFactor.VeryHigh;

                case "Критический":
                    return ScaleFactor.ExtraHigh;

                default:
                    return ScaleFactor.Undefined;
            }
        }

        private EarlyDesignEffortMultiplier MapEarlyDesignEffortMultiplier(string level)
        {
            switch (level)
            {
                case "Критически низкий":
                    return EarlyDesignEffortMultiplier.ExtraLow;

                case "Очень низкий":
                    return EarlyDesignEffortMultiplier.VeryLow;

                case "Низкий":
                    return EarlyDesignEffortMultiplier.Low;

                case "Средний":
                    return EarlyDesignEffortMultiplier.Nominal;

                case "Высокий":
                    return EarlyDesignEffortMultiplier.High;

                case "Очень высокий":
                    return EarlyDesignEffortMultiplier.VeryHigh;

                case "Критически высокий":
                    return EarlyDesignEffortMultiplier.ExtraHigh;

                default:
                    return EarlyDesignEffortMultiplier.Undefined;
            }
        }

        private PostArchitectureEffortMultiplier MapPostArchitectureEffortMultiplier(string level)
        {
            switch (level)
            {
                case "Очень низкий":
                    return PostArchitectureEffortMultiplier.VeryLow;

                case "Низкий":
                    return PostArchitectureEffortMultiplier.Low;

                case "Средний":
                    return PostArchitectureEffortMultiplier.Nominal;

                case "Высокий":
                    return PostArchitectureEffortMultiplier.High;

                case "Очень высокий":
                    return PostArchitectureEffortMultiplier.VeryHigh;

                case "Критический":
                    return PostArchitectureEffortMultiplier.ExtraHigh;

                default:
                    return PostArchitectureEffortMultiplier.Undefined;
            }
        }

        private void SupportButton_Click(object sender, EventArgs e)
        {
            Process.Start("AVOCocomo-UserManual.pdf");
        }
    }
}
