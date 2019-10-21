using SlurryReactor;
using SlurryReactor.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Main : Form
    {
        private ConstantInputModel constantInputModel;
        private FiniteComponentInputModel componentInputModel;

        private FiniteComponentReactor slurryReactor;

        public Main()
        {
            InitializeComponent();
        }

        private void chbDefaultConst_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDefaultConst.Checked)
            {
                txtK1.Text = (8.8073 * Math.Pow(10, 6)).ToString();
                txtK2.Text = (13.66 * Math.Pow(10, 6)).ToString();
                txtK3.Text = (48.502 * Math.Pow(10, 6)).ToString();
                txtK4.Text = (687.63 * Math.Pow(10, 6)).ToString();
                txtK5.Text = (0.22097 * Math.Pow(10, 6)).ToString();
                txtK.Text = (35.838 * Math.Pow(10, 6)).ToString();
                txtB1.Text = (-769.491).ToString();
                txtB2.Text = (-424.565).ToString();
                txtB3.Text = 636.999.ToString();
                txtB4.Text = 746.846.ToString();
                txtB5.Text = 95.8691.ToString();
                txtB.Text = 627.218.ToString();
                txtB0.Text = (2.0298 * Math.Pow(10, -3)).ToString();
                txtEft.Text = 136.1.ToString();
                txtEsh.Text = 1181.ToString();
                txtKft.Text = 0.001.ToString();
                txtKsh.Text = 0.000001.ToString();
            }
            else
            {
                txtK1.Text = null;
                txtK2.Text = null;
                txtK3.Text = null;
                txtK4.Text = null;
                txtK5.Text = null;
                txtK.Text = null;
                txtB1.Text = null;
                txtB2.Text = null;
                txtB3.Text = null;
                txtB4.Text = null;
                txtB5.Text = null;
                txtB.Text = null;
                txtB0.Text = null;
                txtEft.Text = null;
                txtEsh.Text = null;
                txtKft.Text = null;
                txtKsh.Text = null;
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (ValidateReactorParameters())
            {
                MessageBox.Show("Please enter all reactor model parameters.");
                return;
            }
            if (ValidateReactorConstatants())
            {
                MessageBox.Show("Please enter all reactor model constatants or use default.");
                return;
            }
            lblPress.Text = "Press in reactor, MPa: ";
            lblBeta.Text = "Beta: ";

            constantInputModel = new ConstantInputModel
            {
                K1 = Convert.ToDouble(txtK1.Text),
                K2 = Convert.ToDouble(txtK2.Text),
                K3 = Convert.ToDouble(txtK3.Text),
                K4 = Convert.ToDouble(txtK4.Text),
                K5 = Convert.ToDouble(txtK5.Text),
                K = Convert.ToDouble(txtK.Text),
                B1 = Convert.ToDouble(txtB1.Text),
                B2 = Convert.ToDouble(txtB2.Text),
                B3 = Convert.ToDouble(txtB3.Text),
                B4 = Convert.ToDouble(txtB4.Text),
                B5 = Convert.ToDouble(txtB5.Text),
                B = Convert.ToDouble(txtB.Text),
                B0 = Convert.ToDouble(txtB0.Text),
                Eft = Convert.ToDouble(txtEft.Text),
                Esh = Convert.ToDouble(txtEsh.Text),
                Kft = Convert.ToDouble(txtKft.Text),
                Ksh = Convert.ToDouble(txtKsh.Text)
            };
            componentInputModel = new FiniteComponentInputModel
            {

                Alfa = Convert.ToDouble(txtAlfa.Text),
                Density = Convert.ToDouble(txtDensity.Text),
                EndTime = Convert.ToInt32(txtTime.Text),
                G1 = Convert.ToDouble(txtG1.Text),
                G2 = Convert.ToDouble(txtG2.Text),
                Gama = Convert.ToDouble(txtGama.Text),
                M = Convert.ToInt32(txtComponents.Text),
                T = Convert.ToDouble(txtT.Text)
            };

            slurryReactor = new FiniteComponentReactor(constantInputModel, componentInputModel);
            slurryReactor.StartCalc();

            btnLiquidConcentration.Enabled = true;
            btnGasConcentration.Enabled = true;
            btnGasRate.Enabled = true;
            btnLiquidRate.Enabled = true;
            btnLiquidData.Enabled = true;
            btnGasData.Enabled = true;

            lblPress.Text += slurryReactor.reactorPress[1] / Math.Pow(10, 6);
            lblBeta.Text += slurryReactor.beta;
            grbCalculatedParameters.Visible = true;
        }

        private bool ValidateReactorConstatants()
        {
            var parameters = grpReactorData.Controls.OfType<TextBox>();
            foreach (var item in parameters)
            {
                if (string.IsNullOrEmpty(item.Text))
                    return true;
            }
            return false;
        }

        private bool ValidateReactorParameters()
        {
            var constants = grbConstants.Controls.OfType<TextBox>();
            foreach (var item in constants)
            {
                if (string.IsNullOrEmpty(item.Text))
                    return true;
            }
            return false;
        }

        private void btnLiquidConcentration_Click(object sender, EventArgs e)
        {
            var result = new LiquidBasicConcentrationChart(slurryReactor);
            result.Show();
        }

        private void btnGasConcentration_Click(object sender, EventArgs e)
        {
            var result = new GasBasicConcentrationChart(slurryReactor);
            result.Show();
        }

        private void btnGasRate_Click(object sender, EventArgs e)
        {
            var result = new GasPhaseComponentRateChart(slurryReactor);
            result.Show();
        }

        private void btnLiquidRate_Click(object sender, EventArgs e)
        {
            var result = new LiquidPhaseComponentRateChart(slurryReactor);
            result.Show();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            var result = new LiquidPhaseData(slurryReactor);
            result.Show();
        }

        private void btnGasData_Click(object sender, EventArgs e)
        {
            var result = new GasPhaseData(slurryReactor);
            result.Show();
        }
    }
}
