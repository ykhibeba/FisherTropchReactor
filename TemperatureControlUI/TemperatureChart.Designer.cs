namespace TemperatureControlUI
{
    partial class TemperatureChart
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
            this.chrTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chrTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // chrTemp
            // 
            chartArea1.Name = "ChartArea1";
            this.chrTemp.ChartAreas.Add(chartArea1);
            this.chrTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chrTemp.Legends.Add(legend1);
            this.chrTemp.Location = new System.Drawing.Point(0, 0);
            this.chrTemp.Name = "chrTemp";
            this.chrTemp.Size = new System.Drawing.Size(821, 355);
            this.chrTemp.TabIndex = 0;
            this.chrTemp.Text = "chart1";
            // 
            // TemperatureChart
            // 
            this.ClientSize = new System.Drawing.Size(821, 355);
            this.Controls.Add(this.chrTemp);
            this.Name = "TemperatureChart";
            ((System.ComponentModel.ISupportInitialize)(this.chrTemp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrTemp;
    }
}