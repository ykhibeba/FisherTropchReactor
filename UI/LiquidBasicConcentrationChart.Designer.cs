namespace UI
{
    partial class LiquidBasicConcentrationChart
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
            this.crtLiquidComponent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtLiquidComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // crtLiquidComponent
            // 
            chartArea1.Name = "ChartArea1";
            this.crtLiquidComponent.ChartAreas.Add(chartArea1);
            this.crtLiquidComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.crtLiquidComponent.Legends.Add(legend1);
            this.crtLiquidComponent.Location = new System.Drawing.Point(0, 0);
            this.crtLiquidComponent.Name = "crtLiquidComponent";
            this.crtLiquidComponent.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            this.crtLiquidComponent.Size = new System.Drawing.Size(886, 537);
            this.crtLiquidComponent.TabIndex = 0;
            this.crtLiquidComponent.Text = "Сoncentration of basic substances in liquid phase";
            // 
            // LiquidBasicConcentrationChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 537);
            this.Controls.Add(this.crtLiquidComponent);
            this.Name = "LiquidBasicConcentrationChart";
            this.Text = "SlurryResult";
            ((System.ComponentModel.ISupportInitialize)(this.crtLiquidComponent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtLiquidComponent;
    }
}