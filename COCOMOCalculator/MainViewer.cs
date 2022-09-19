using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using COCOMOCalculator.BL.Models;

namespace COCOMOCalculator
{
    public interface ICOCOMOCalculator
    {
        int BCSize { get; }
        int ICSize { get; }

        ProjectType BCProjectType { get; }
        ProjectType ICProjectType { get; }

        void ShowResult(float pm, float tm);

        event EventHandler BasicCalculateClick;
        event EventHandler InterCalculateClick;
    }

    public partial class COCOMOCalculator : Form, ICOCOMOCalculator
    {

        public COCOMOCalculator()
        {
            InitializeComponent();

            butBCCalculate.Click += ButBCCalculate_Click;
            butICCalculate.Click += ButICCalculate_Click;
        }

        public event EventHandler BasicCalculateClick;
        public event EventHandler InterCalculateClick;

        public int BCSize => int.Parse(txtBCSize.Text);
        public int ICSize => int.Parse(txtICSize.Text);

        public ProjectType BCProjectType => MapProjectType(cmbBCProjectType.Text);
        public ProjectType ICProjectType => MapProjectType(cmbICProjectType.Text);

        public void ShowResult(float pm, float tm)
        {
            lblPM.Text = $@"People * month : {pm}";
            lblTM.Text = $@"Time * month : {tm}";
        }

        private void ButBCCalculate_Click(object sender, EventArgs e)
        {
            if (BasicCalculateClick != null) BasicCalculateClick(sender, EventArgs.Empty);
        }


        private void ButICCalculate_Click(object sender, EventArgs e)
        {
            if (InterCalculateClick != null) InterCalculateClick(sender, EventArgs.Empty);
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
