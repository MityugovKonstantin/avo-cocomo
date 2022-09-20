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
                // ...
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

        /*private AttributesType MapCoefs(string type)
        {
            switch (type)
            {
                case "Very low":
                    return AttributesType.VeryLow;
                case "Low":
                    return AttributesType.Low;
                case "Normal":
                    return AttributesType.Normal;
                case "High":
                    return AttributesType.High;
                case "Very high":
                    return AttributesType.VeryHigh;
                case "Critical":
                    return AttributesType.Critical;
                default:
                    throw new Exception("Неверно указан тип атрибуита");
            }
        }*/

    }
}
