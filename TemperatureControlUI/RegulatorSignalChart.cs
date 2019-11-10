using FisherTropchTemperatureControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureControlUI
{
    public partial class RegulatorSignalChart : Form
    {
        public RegulatorSignalChart()
        {
            InitializeComponent();
            BuildChart();
        }

        private void BuildChart()
        {
            chrRegulator.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            chrRegulator.Titles.Add("Regulator signal");
            chrRegulator.Titles[0].Font = new Font(new FontFamily(GenericFontFamilies.Serif), 12);
            chrRegulator.ChartAreas[0].AxisY.Minimum = 0;
            chrRegulator.ChartAreas[0].AxisX.Minimum = 0;
            chrRegulator.ChartAreas[0].AxisX.Title = "Time, sec";
            chrRegulator.ChartAreas[0].AxisY.Title = "Regulator signal";

            var series = chrRegulator.Series.Add("Regulator");

            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series.BorderWidth = 4;
            series.Color = Color.Red;

            for (int j = 0; j < TemperatureControlModule.cCO.Length; j++)
                chrRegulator.Series[series.Name].Points.AddXY(j, TemperatureControlModule.W[j]);

        }
    }
}
