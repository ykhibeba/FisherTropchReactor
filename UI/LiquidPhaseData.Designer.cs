namespace UI
{
    partial class LiquidPhaseData
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
            this.dgvReactor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReactor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReactor
            // 
            this.dgvReactor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReactor.Location = new System.Drawing.Point(0, 0);
            this.dgvReactor.Name = "dgvReactor";
            this.dgvReactor.Size = new System.Drawing.Size(949, 584);
            this.dgvReactor.TabIndex = 0;
            // 
            // SlurryReactorData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 584);
            this.Controls.Add(this.dgvReactor);
            this.Name = "SlurryReactorData";
            this.Text = "SlurryReactorData";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReactor;
    }
}