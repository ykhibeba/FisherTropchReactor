using SlurryReactor;
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

namespace UI
{
    public partial class GasPhaseComponentRateChart : Form
    {
        private FiniteComponentReactor reactor;

        public GasPhaseComponentRateChart(FiniteComponentReactor reactor)
        {
            InitializeComponent();
            this.reactor = reactor;
            BuildBasicConcentrationChart();
        }

        private void BuildBasicConcentrationChart()
        {
            crtGasPhaseRate.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            crtGasPhaseRate.Titles.Add("Hydrocarbonats rate, %");
            crtGasPhaseRate.Titles[0].Font = new Font(new FontFamily(GenericFontFamilies.Serif), 12);
            crtGasPhaseRate.ChartAreas[0].AxisY.Minimum = 0;
            crtGasPhaseRate.ChartAreas[0].AxisX.Minimum = 1;
            crtGasPhaseRate.ChartAreas[0].AxisX.Title = "Count carbon atoms";
            crtGasPhaseRate.ChartAreas[0].AxisY.Title = "Rate, %";

            string[] seriesArray = { "Gas phase rate, %" };
            Color[] seriesColor = { Color.Red };

            var series = crtGasPhaseRate.Series.Add(seriesArray[0]);
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series.BorderWidth = 4;
            series.Color = seriesColor[0];
            for (int j = 5; j < reactor.component.M; j++)
                crtGasPhaseRate.Series[series.Name].Points.AddXY(j - 4, reactor.x[j, reactor.component.M - 1] * 100);
        }
    }
}
