using FisherTropchTemperatureControl;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TemperatureControlUI
{
    public partial class TemperatureChart : Form
    {
        public TemperatureChart()
        {
            InitializeComponent();
            BuildChart();
        }

        private void BuildChart()
        {
            chrTemp.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            chrTemp.Titles.Add("Temperature in reactor");
            chrTemp.Titles[0].Font = new Font(new FontFamily(GenericFontFamilies.Serif), 12);
            chrTemp.ChartAreas[0].AxisX.Minimum = 0;
            chrTemp.ChartAreas[0].AxisX.Title = "Time, sec";
            chrTemp.ChartAreas[0].AxisY.Title = "Temperature, K";

            var series = chrTemp.Series.Add("Temperature");

            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series.BorderWidth = 4;
            series.Color = Color.Red;

            for (int j = 0; j < TemperatureControlModule.cCO.Length; j++)
                chrTemp.Series[series.Name].Points.AddXY(j, TemperatureControlModule.T[j]);

        }
    }
}
