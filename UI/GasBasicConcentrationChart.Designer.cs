namespace UI
{
    partial class GasBasicConcentrationChart
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
            this.crtGasComponent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtGasComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // crtGasComponent
            // 
            chartArea1.Name = "ChartArea1";
            this.crtGasComponent.ChartAreas.Add(chartArea1);
            this.crtGasComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.crtGasComponent.Legends.Add(legend1);
            this.crtGasComponent.Location = new System.Drawing.Point(0, 0);
            this.crtGasComponent.Name = "crtGasComponent";
            this.crtGasComponent.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            this.crtGasComponent.Size = new System.Drawing.Size(829, 502);
            this.crtGasComponent.TabIndex = 1;
            this.crtGasComponent.Text = "Сoncentration of basic substances in liquid phase";
            // 
            // GasBasicConcentrationChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 502);
            this.Controls.Add(this.crtGasComponent);
            this.Name = "GasBasicConcentrationChart";
            this.Text = "GasBasicConcentrationChart";
            ((System.ComponentModel.ISupportInitialize)(this.crtGasComponent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtGasComponent;
    }
}