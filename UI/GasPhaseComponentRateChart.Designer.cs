namespace UI
{
    partial class GasPhaseComponentRateChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.crtGasPhaseRate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtGasPhaseRate)).BeginInit();
            this.SuspendLayout();
            // 
            // crtGasPhaseRate
            // 
            chartArea1.Name = "ChartArea1";
            this.crtGasPhaseRate.ChartAreas.Add(chartArea1);
            this.crtGasPhaseRate.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.crtGasPhaseRate.Legends.Add(legend1);
            this.crtGasPhaseRate.Location = new System.Drawing.Point(0, 0);
            this.crtGasPhaseRate.Name = "crtGasPhaseRate";
            this.crtGasPhaseRate.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            this.crtGasPhaseRate.Size = new System.Drawing.Size(800, 450);
            this.crtGasPhaseRate.TabIndex = 2;
            this.crtGasPhaseRate.Text = "Сoncentration of basic substances in liquid phase";
            // 
            // GasPhaseComponentRateChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crtGasPhaseRate);
            this.Name = "GasPhaseComponentRateChart";
            this.Text = "GasPhaseComponentRateChart";
            ((System.ComponentModel.ISupportInitialize)(this.crtGasPhaseRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtGasPhaseRate;
    }
}