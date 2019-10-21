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
    public partial class LiquidPhaseComponentRateChart : Form
    {
        private FiniteComponentReactor reactor;

        public LiquidPhaseComponentRateChart(FiniteComponentReactor reactor)
        {
            InitializeComponent();
            this.reactor = reactor;
            BuildBasicConcentrationChart();
        }

        private void BuildBasicConcentrationChart()
        {
            crtLiquidPhaseRate.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            crtLiquidPhaseRate.Titles.Add("Hydrocarbonats rate, %");
            crtLiquidPhaseRate.Titles[0].Font = new Font(new FontFamily(GenericFontFamilies.Serif), 12);
            crtLiquidPhaseRate.ChartAreas[0].AxisY.Minimum = 0;
            crtLiquidPhaseRate.ChartAreas[0].AxisX.Minimum = 1;
            crtLiquidPhaseRate.ChartAreas[0].AxisX.Title = "Count carbon atoms";
            crtLiquidPhaseRate.ChartAreas[0].AxisY.Title = "Rate, %";

            string[] seriesArray = { "Liquid phase rate, %" };
            Color[] seriesColor = { Color.Red };

            var series = crtLiquidPhaseRate.Series.Add(seriesArray[0]);
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series.BorderWidth = 4;
            series.Color = seriesColor[0];
            for (int j = 5; j < reactor.component.M; j++)
                crtLiquidPhaseRate.Series[series.Name].Points.AddXY(j - 4, reactor.y[j, reactor.component.M - 1] * 100);
        }
    }
}
