namespace UI
{
    partial class LiquidPhaseComponentRateChart
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
            this.crtLiquidPhaseRate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtLiquidPhaseRate)).BeginInit();
            this.SuspendLayout();
            // 
            // crtLiquidPhaseRate
            // 
            chartArea1.Name = "ChartArea1";
            this.crtLiquidPhaseRate.ChartAreas.Add(chartArea1);
            this.crtLiquidPhaseRate.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.crtLiquidPhaseRate.Legends.Add(legend1);
            this.crtLiquidPhaseRate.Location = new System.Drawing.Point(0, 0);
            this.crtLiquidPhaseRate.Name = "crtLiquidPhaseRate";
            this.crtLiquidPhaseRate.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            this.crtLiquidPhaseRate.Size = new System.Drawing.Size(800, 450);
            this.crtLiquidPhaseRate.TabIndex = 3;
            this.crtLiquidPhaseRate.Text = "Сoncentration of basic substances in liquid phase";
            // 
            // LiquidPhaseComponentRateChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crtLiquidPhaseRate);
            this.Name = "LiquidPhaseComponentRateChart";
            this.Text = "LiquidPhaseComponentRateChart";
            ((System.ComponentModel.ISupportInitialize)(this.crtLiquidPhaseRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtLiquidPhaseRate;
    }
}