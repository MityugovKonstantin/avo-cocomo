using System;
using System.Windows.Forms;

namespace COCOMOCalculator
{
    public interface ICOCOMOCalculator
    {
        string ProjectScore { get; }
        string ProjectType { get; }
        string PM { set; }
        string TM { set; }
        event EventHandler CalculateClick;
    }

    public partial class COCOMOCalculator : Form, ICOCOMOCalculator
    {

        public COCOMOCalculator()
        {
            InitializeComponent();
            butBCCalculate.Click += ButBCCalculate_Click;
        }


        private void ButBCCalculate_Click(object sender, EventArgs e)
        {
            if (CalculateClick != null) CalculateClick(sender, EventArgs.Empty);
        }

        public string ProjectScore
        {
            get { return txtBCProgramScope.Text; }
        }

        public string ProjectType
        {
            get { return cmbBCProjectType.Text; }
        }

        public string PM
        {
            set { lblPM.Text = "People * month : " + value; }
        }

        public string TM
        {
            set { lblTM.Text = "Time * month : " + value; }
        }

         public event EventHandler CalculateClick;

    }
}
