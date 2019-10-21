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
    public partial class LiquidBasicConcentrationChart : Form
    {
        private FiniteComponentReactor reactor;

        public LiquidBasicConcentrationChart(FiniteComponentReactor reactor)
        {
            InitializeComponent();
            this.reactor = reactor;
            BuildBasicConcentrationChart();
        }

        private void BuildBasicConcentrationChart()
        {
            crtLiquidComponent.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            crtLiquidComponent.Titles.Add("Concentration in liquid phase of H2, CO, CO2, H2O, CH4, C2H6, C3H8");
            crtLiquidComponent.Titles[0].Font = new Font(new FontFamily(GenericFontFamilies.Serif), 12);
            crtLiquidComponent.ChartAreas[0].AxisY.Minimum = 0;
            crtLiquidComponent.ChartAreas[0].AxisX.Minimum = 0;
            crtLiquidComponent.ChartAreas[0].AxisX.Title = "Time, sec";
            crtLiquidComponent.ChartAreas[0].AxisY.Title = "Concentration, kmole/m^3";

            string[] seriesArray = { "H2", "CO", "CO2", "H2O", "CH4", "C2H6", "C3H8" };
            Color[] seriesColor = { Color.Red, Color.Green, Color.Blue, Color.Pink, Color.Coral, Color.Cyan, Color.Magenta };

            for (int i = 0; i < 7; i++)
            {
                var series = crtLiquidComponent.Series.Add(seriesArray[i]);
                
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                series.BorderWidth = 4;
                series.Color = seriesColor[i];

                for (int j = 0; j < reactor.component.EndTime; j++)
                    crtLiquidComponent.Series[series.Name].Points.AddXY(j, reactor.cLiquidComponent[i, j]);


            }
        }
    }
}
