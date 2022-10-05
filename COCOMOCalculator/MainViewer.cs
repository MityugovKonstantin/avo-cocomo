using COCOMOCalculator.BL.Enums;
using COCOMOCalculator.BL.Models;
using COCOMOCalculator.BL.Models.Args;
using COCOMOCalculator.BL.Models.Attributes;
using COCOMOCalculator.BL.Models.Attributes.SecondCocomo;
using COCOMOCalculator.Interfaces;
using System;
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

        private void CalculateB_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(SizeTextB.Text) <= 0)
                {
                    MessageBox.Show("Количество тысяч строк кода должно быть больше нуля.");
                }
                else
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
                if (int.Parse(SizeTextI.Text) <= 0)
                {
                    new MessageService().ShowError("Количество тысяч строк кода должно быть больше нуля.");
                }
                else
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
                if (int.Parse(SizeTextEd.Text) <= 0)
                {
                    new MessageService().ShowError("Количество тысяч строк кода должно быть больше нуля.");
                }
                else
                {
                    var args = new EarlyDesignCalculationArgs
                    {
                        Size = int.Parse(SizeTextEd.Text),
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
                if (int.Parse(SizeTextPa.Text) <= 0)
                {
                    new MessageService().ShowError("Количество тысяч строк кода должно быть больше нуля.");
                }
                else
                {
                    var args = new PostArchitectureCalculationArgs
                    {
                        Size = int.Parse(SizeTextPa.Text),
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
            }
            catch (Exception)
            {
                new MessageService().ShowError("Неправильный формат строки!");
            }
        }

        private ProjectType MapProjectType(string type)
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

        private RatingType MapRatingType(string type)
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

        private ScaleFactor MapScaleFactor(string factor)
        {
            switch (factor)
            {
                case "Very low":
                    return ScaleFactor.VeryLow;

                case "Low":
                    return ScaleFactor.Low;

                case "Nominal":
                    return ScaleFactor.Nominal;

                case "High":
                    return ScaleFactor.High;

                case "Very high":
                    return ScaleFactor.VeryHigh;

                case "Extra high":
                    return ScaleFactor.ExtraHigh;

                default:
                    return ScaleFactor.Undefined;
            }
        }

        private EarlyDesignEffortMultiplier MapEarlyDesignEffortMultiplier(string level)
        {
            switch (level)
            {
                case "Extra low":
                    return EarlyDesignEffortMultiplier.ExtraLow;

                case "Very low":
                    return EarlyDesignEffortMultiplier.VeryLow;

                case "Low":
                    return EarlyDesignEffortMultiplier.Low;

                case "Nominal":
                    return EarlyDesignEffortMultiplier.Nominal;

                case "High":
                    return EarlyDesignEffortMultiplier.High;

                case "Very high":
                    return EarlyDesignEffortMultiplier.VeryHigh;

                case "Extra high":
                    return EarlyDesignEffortMultiplier.ExtraHigh;

                default:
                    return EarlyDesignEffortMultiplier.Undefined;
            }
        }

        private PostArchitectureEffortMultiplier MapPostArchitectureEffortMultiplier(string level)
        {
            switch (level)
            {
                case "Very low":
                    return PostArchitectureEffortMultiplier.VeryLow;

                case "Low":
                    return PostArchitectureEffortMultiplier.Low;

                case "Nominal":
                    return PostArchitectureEffortMultiplier.Nominal;

                case "High":
                    return PostArchitectureEffortMultiplier.High;

                case "Very high":
                    return PostArchitectureEffortMultiplier.VeryHigh;

                case "Extra high":
                    return PostArchitectureEffortMultiplier.ExtraHigh;

                default:
                    return PostArchitectureEffortMultiplier.Undefined;
            }
        }
    }
}
