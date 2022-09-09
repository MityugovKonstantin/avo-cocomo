using System;
using System.Windows.Forms;
using COCOMOCalculator.BL.Models;

namespace COCOMOCalculator
{
    public interface ICOCOMOCalculator
    {
        int ProjectScore { get; }

        ProjectType ProjectType { get; }

        void ShowResult(float pm, float tm);

        event EventHandler CalculateClick;
    }

    public partial class COCOMOCalculator : Form, ICOCOMOCalculator
    {

        public COCOMOCalculator()
        {
            InitializeComponent();
            butBCCalculate.Click += ButBCCalculate_Click;
        }

        public event EventHandler CalculateClick;

        public int ProjectScore => int.Parse(txtBCProgramScope.Text);

        public ProjectType ProjectType => MapProjectType(cmbBCProjectType.Text);

        public void ShowResult(float pm, float tm)
        {
            lblPM.Text = $@"People * month : {pm}";
            lblTM.Text = $@"Time * month : {tm}";
        }

        private void ButBCCalculate_Click(object sender, EventArgs e)
        {
            if (CalculateClick != null) CalculateClick(sender, EventArgs.Empty);
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
    }
}
