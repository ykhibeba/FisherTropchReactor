namespace TemperatureControlUI
{
    partial class RegulatorSignalChart
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
            this.chrRegulator = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chrRegulator)).BeginInit();
            this.SuspendLayout();
            // 
            // chrRegulator
            // 
            chartArea1.Name = "ChartArea1";
            this.chrRegulator.ChartAreas.Add(chartArea1);
            this.chrRegulator.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chrRegulator.Legends.Add(legend1);
            this.chrRegulator.Location = new System.Drawing.Point(0, 0);
            this.chrRegulator.Name = "chrRegulator";
            this.chrRegulator.Size = new System.Drawing.Size(800, 450);
            this.chrRegulator.TabIndex = 1;
            this.chrRegulator.Text = "chart1";
            // 
            // RegulatorSignalChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chrRegulator);
            this.Name = "RegulatorSignalChart";
            this.Text = "RegulatorSignalChart";
            ((System.ComponentModel.ISupportInitialize)(this.chrRegulator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrRegulator;
    }
}