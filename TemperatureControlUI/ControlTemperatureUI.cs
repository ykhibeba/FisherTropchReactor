using FisherTropchTemperatureControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureControlUI
{
    public partial class frmControlUI : Form
    {
        public frmControlUI()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            TemperatureControlModule.cp = Convert.ToDouble(txtCp.Text);
            TemperatureControlModule.K = Convert.ToDouble(txtK.Text);
            TemperatureControlModule.F = Convert.ToDouble(txtF.Text);
            TemperatureControlModule.K0 = Convert.ToDouble(txtK0.Text);
            TemperatureControlModule.T0 = Convert.ToDouble(txtT0.Text);
            TemperatureControlModule.Tzad = Convert.ToDouble(txtTzad.Text);
            TemperatureControlModule.Txl = Convert.ToDouble(txtTxl.Text);
            TemperatureControlModule.delH = Convert.ToDouble(txtH.Text);
            TemperatureControlModule.Wvh = Convert.ToDouble(txtW.Text);
            TemperatureControlModule.Tizod = Convert.ToDouble(txtTizod.Text);
            TemperatureControlModule.Kp = Convert.ToDouble(txtKp.Text);

            double[] cH2 = Array.ConvertAll(File.ReadAllLines(@"C:\KPI\Диплом\FisherTropchReactor\UI\bin\Debug\ConcentrationH2.txt"),Double.Parse);
            double[] cCO = Array.ConvertAll(File.ReadAllLines(@"C:\KPI\Диплом\FisherTropchReactor\UI\bin\Debug\ConcentrationCO.txt"), Double.Parse);
            TemperatureControlModule.cH2 = cH2;
            TemperatureControlModule.cCO = cCO;

            TemperatureControlModule.Calculate();
        }

        private void btnTemperature_Click(object sender, EventArgs e)
        {
            var result = new TemperatureChart();
            result.Show();
        }

        private void bntRegulator_Click(object sender, EventArgs e)
        {
            var result = new RegulatorSignalChart();
            result.Show();
        }
    }
}
