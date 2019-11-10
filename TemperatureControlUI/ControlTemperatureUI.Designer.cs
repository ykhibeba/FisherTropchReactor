namespace TemperatureControlUI
{
    partial class frmControlUI
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
            this.btnCalc = new System.Windows.Forms.Button();
            this.grpReactorData = new System.Windows.Forms.GroupBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTxl = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtTzad = new System.Windows.Forms.TextBox();
            this.lblT = new System.Windows.Forms.Label();
            this.txtT0 = new System.Windows.Forms.TextBox();
            this.lblAlfa = new System.Windows.Forms.Label();
            this.txtK0 = new System.Windows.Forms.TextBox();
            this.lblK0 = new System.Windows.Forms.Label();
            this.txtF = new System.Windows.Forms.TextBox();
            this.lblG2 = new System.Windows.Forms.Label();
            this.txtK = new System.Windows.Forms.TextBox();
            this.lblK = new System.Windows.Forms.Label();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.lblHeatCapacity = new System.Windows.Forms.Label();
            this.grpRegulator = new System.Windows.Forms.GroupBox();
            this.txtTizod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtW = new System.Windows.Forms.TextBox();
            this.lblControl = new System.Windows.Forms.Label();
            this.txtKp = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTemperature = new System.Windows.Forms.Button();
            this.bntRegulator = new System.Windows.Forms.Button();
            this.grpReactorData.SuspendLayout();
            this.grpRegulator.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalc
            // 
            this.btnCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalc.Location = new System.Drawing.Point(19, 345);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(337, 65);
            this.btnCalc.TabIndex = 4;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // grpReactorData
            // 
            this.grpReactorData.Controls.Add(this.txtH);
            this.grpReactorData.Controls.Add(this.label5);
            this.grpReactorData.Controls.Add(this.txtTxl);
            this.grpReactorData.Controls.Add(this.lblTime);
            this.grpReactorData.Controls.Add(this.txtTzad);
            this.grpReactorData.Controls.Add(this.lblT);
            this.grpReactorData.Controls.Add(this.txtT0);
            this.grpReactorData.Controls.Add(this.lblAlfa);
            this.grpReactorData.Controls.Add(this.txtK0);
            this.grpReactorData.Controls.Add(this.lblK0);
            this.grpReactorData.Controls.Add(this.txtF);
            this.grpReactorData.Controls.Add(this.lblG2);
            this.grpReactorData.Controls.Add(this.txtK);
            this.grpReactorData.Controls.Add(this.lblK);
            this.grpReactorData.Controls.Add(this.txtCp);
            this.grpReactorData.Controls.Add(this.lblHeatCapacity);
            this.grpReactorData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpReactorData.Location = new System.Drawing.Point(1, 3);
            this.grpReactorData.Name = "grpReactorData";
            this.grpReactorData.Size = new System.Drawing.Size(372, 336);
            this.grpReactorData.TabIndex = 3;
            this.grpReactorData.TabStop = false;
            this.grpReactorData.Text = "Enter reactor parameters";
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(264, 275);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(91, 22);
            this.txtH.TabIndex = 16;
            this.txtH.Text = "140";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(21, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Enthalpy, kJ:";
            // 
            // txtTxl
            // 
            this.txtTxl.Location = new System.Drawing.Point(264, 236);
            this.txtTxl.Name = "txtTxl";
            this.txtTxl.Size = new System.Drawing.Size(91, 22);
            this.txtTxl.TabIndex = 14;
            this.txtTxl.Text = "400";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(21, 242);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(166, 16);
            this.lblTime.TabIndex = 13;
            this.lblTime.Text = "Refrigerant temperature, K:";
            // 
            // txtTzad
            // 
            this.txtTzad.Location = new System.Drawing.Point(264, 200);
            this.txtTzad.Name = "txtTzad";
            this.txtTzad.Size = new System.Drawing.Size(91, 22);
            this.txtTzad.TabIndex = 12;
            this.txtTzad.Text = "420";
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblT.Location = new System.Drawing.Point(21, 206);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(142, 16);
            this.lblT.TabIndex = 11;
            this.lblT.Text = "Control temperature, K:";
            // 
            // txtT0
            // 
            this.txtT0.Location = new System.Drawing.Point(264, 168);
            this.txtT0.Name = "txtT0";
            this.txtT0.Size = new System.Drawing.Size(91, 22);
            this.txtT0.TabIndex = 9;
            this.txtT0.Text = "420";
            // 
            // lblAlfa
            // 
            this.lblAlfa.AutoSize = true;
            this.lblAlfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAlfa.Location = new System.Drawing.Point(21, 174);
            this.lblAlfa.Name = "lblAlfa";
            this.lblAlfa.Size = new System.Drawing.Size(124, 16);
            this.lblAlfa.TabIndex = 8;
            this.lblAlfa.Text = "Inlet temperature, K:";
            // 
            // txtK0
            // 
            this.txtK0.Location = new System.Drawing.Point(264, 134);
            this.txtK0.Name = "txtK0";
            this.txtK0.Size = new System.Drawing.Size(91, 22);
            this.txtK0.TabIndex = 7;
            this.txtK0.Text = "0,002";
            // 
            // lblK0
            // 
            this.lblK0.AutoSize = true;
            this.lblK0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblK0.Location = new System.Drawing.Point(21, 137);
            this.lblK0.Name = "lblK0";
            this.lblK0.Size = new System.Drawing.Size(131, 16);
            this.lblK0.TabIndex = 6;
            this.lblK0.Text = "Average rate, 1/sec :";
            // 
            // txtF
            // 
            this.txtF.Location = new System.Drawing.Point(264, 98);
            this.txtF.Name = "txtF";
            this.txtF.Size = new System.Drawing.Size(91, 22);
            this.txtF.TabIndex = 5;
            this.txtF.Text = "10";
            // 
            // lblG2
            // 
            this.lblG2.AutoSize = true;
            this.lblG2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblG2.Location = new System.Drawing.Point(21, 101);
            this.lblG2.Name = "lblG2";
            this.lblG2.Size = new System.Drawing.Size(173, 16);
            this.lblG2.TabIndex = 4;
            this.lblG2.Text = "Area of heat exchange m^2:";
            // 
            // txtK
            // 
            this.txtK.Location = new System.Drawing.Point(264, 64);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(91, 22);
            this.txtK.TabIndex = 3;
            this.txtK.Text = "0,027";
            // 
            // lblK
            // 
            this.lblK.AutoSize = true;
            this.lblK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblK.Location = new System.Drawing.Point(21, 70);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(215, 16);
            this.lblK.TabIndex = 2;
            this.lblK.Text = "Heat transfer coefficient kW*K/m^2:";
            // 
            // txtCp
            // 
            this.txtCp.Location = new System.Drawing.Point(264, 30);
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(91, 22);
            this.txtCp.TabIndex = 1;
            this.txtCp.Text = "0,76";
            // 
            // lblHeatCapacity
            // 
            this.lblHeatCapacity.AutoSize = true;
            this.lblHeatCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeatCapacity.Location = new System.Drawing.Point(21, 36);
            this.lblHeatCapacity.Name = "lblHeatCapacity";
            this.lblHeatCapacity.Size = new System.Drawing.Size(191, 16);
            this.lblHeatCapacity.TabIndex = 0;
            this.lblHeatCapacity.Text = "Specific heat capacity kJ/kg*K:";
            // 
            // grpRegulator
            // 
            this.grpRegulator.Controls.Add(this.txtTizod);
            this.grpRegulator.Controls.Add(this.label7);
            this.grpRegulator.Controls.Add(this.txtW);
            this.grpRegulator.Controls.Add(this.lblControl);
            this.grpRegulator.Controls.Add(this.txtKp);
            this.grpRegulator.Controls.Add(this.label9);
            this.grpRegulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpRegulator.Location = new System.Drawing.Point(379, 12);
            this.grpRegulator.Name = "grpRegulator";
            this.grpRegulator.Size = new System.Drawing.Size(372, 133);
            this.grpRegulator.TabIndex = 17;
            this.grpRegulator.TabStop = false;
            this.grpRegulator.Text = "Enter regulator parameters";
            // 
            // txtTizod
            // 
            this.txtTizod.Location = new System.Drawing.Point(264, 98);
            this.txtTizod.Name = "txtTizod";
            this.txtTizod.Size = new System.Drawing.Size(91, 22);
            this.txtTizod.TabIndex = 5;
            this.txtTizod.Text = "200";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(21, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Izodrom time, sec:";
            // 
            // txtW
            // 
            this.txtW.Location = new System.Drawing.Point(264, 64);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(91, 22);
            this.txtW.TabIndex = 3;
            this.txtW.Text = "1";
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblControl.Location = new System.Drawing.Point(21, 70);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(127, 16);
            this.lblControl.TabIndex = 2;
            this.lblControl.Text = "Basic control signal:";
            // 
            // txtKp
            // 
            this.txtKp.Location = new System.Drawing.Point(264, 30);
            this.txtKp.Name = "txtKp";
            this.txtKp.Size = new System.Drawing.Size(91, 22);
            this.txtKp.TabIndex = 1;
            this.txtKp.Text = "0,001";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(21, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Proportionality factor, m^3/sec*K :";
            // 
            // btnTemperature
            // 
            this.btnTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTemperature.Location = new System.Drawing.Point(397, 177);
            this.btnTemperature.Name = "btnTemperature";
            this.btnTemperature.Size = new System.Drawing.Size(337, 65);
            this.btnTemperature.TabIndex = 18;
            this.btnTemperature.Text = "Build Temperature Graph";
            this.btnTemperature.UseVisualStyleBackColor = true;
            this.btnTemperature.Click += new System.EventHandler(this.btnTemperature_Click);
            // 
            // bntRegulator
            // 
            this.bntRegulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bntRegulator.Location = new System.Drawing.Point(397, 274);
            this.bntRegulator.Name = "bntRegulator";
            this.bntRegulator.Size = new System.Drawing.Size(337, 65);
            this.bntRegulator.TabIndex = 19;
            this.bntRegulator.Text = "Build Regulator Signal Graph";
            this.bntRegulator.UseVisualStyleBackColor = true;
            this.bntRegulator.Click += new System.EventHandler(this.bntRegulator_Click);
            // 
            // frmControlUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 449);
            this.Controls.Add(this.bntRegulator);
            this.Controls.Add(this.btnTemperature);
            this.Controls.Add(this.grpRegulator);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.grpReactorData);
            this.Name = "frmControlUI";
            this.Text = "Temperature control FT reactor";
            this.grpReactorData.ResumeLayout(false);
            this.grpReactorData.PerformLayout();
            this.grpRegulator.ResumeLayout(false);
            this.grpRegulator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.GroupBox grpReactorData;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTxl;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtTzad;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.TextBox txtT0;
        private System.Windows.Forms.Label lblAlfa;
        private System.Windows.Forms.TextBox txtK0;
        private System.Windows.Forms.Label lblK0;
        private System.Windows.Forms.TextBox txtF;
        private System.Windows.Forms.Label lblG2;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.Label lblHeatCapacity;
        private System.Windows.Forms.GroupBox grpRegulator;
        private System.Windows.Forms.TextBox txtTizod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.TextBox txtKp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTemperature;
        private System.Windows.Forms.Button bntRegulator;
    }
}

