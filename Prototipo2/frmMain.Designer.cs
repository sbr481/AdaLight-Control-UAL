using System;

namespace Prototipo2
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConnect = new System.Windows.Forms.Button();
            this.btNLEDS = new System.Windows.Forms.Button();
            this.cbSelecLED = new System.Windows.Forms.ComboBox();
            this.btColorTira = new System.Windows.Forms.Button();
            this.tbNLEDS = new System.Windows.Forms.TextBox();
            this.lbNLEDS = new System.Windows.Forms.Label();
            this.lbPuerto = new System.Windows.Forms.Label();
            this.lbColorTira = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lbRGBTira = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbColorLED = new System.Windows.Forms.Label();
            this.tbColorTira = new System.Windows.Forms.TextBox();
            this.tbColorLED = new System.Windows.Forms.TextBox();
            this.lbRGBLED = new System.Windows.Forms.Label();
            this.cbPuerto = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(387, 26);
            this.btConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(67, 19);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Conectar";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btNLEDS
            // 
            this.btNLEDS.Location = new System.Drawing.Point(387, 164);
            this.btNLEDS.Margin = new System.Windows.Forms.Padding(2);
            this.btNLEDS.Name = "btNLEDS";
            this.btNLEDS.Size = new System.Drawing.Size(67, 19);
            this.btNLEDS.TabIndex = 1;
            this.btNLEDS.Text = "N LEDS";
            this.btNLEDS.UseVisualStyleBackColor = true;
            this.btNLEDS.Click += new System.EventHandler(this.btNLEDS_Click);
            // 
            // cbSelecLED
            // 
            this.cbSelecLED.FormattingEnabled = true;
            this.cbSelecLED.Location = new System.Drawing.Point(89, 162);
            this.cbSelecLED.Margin = new System.Windows.Forms.Padding(2);
            this.cbSelecLED.Name = "cbSelecLED";
            this.cbSelecLED.Size = new System.Drawing.Size(92, 21);
            this.cbSelecLED.TabIndex = 2;
            this.cbSelecLED.SelectedIndexChanged += new System.EventHandler(this.cbSelecLED_SelectedIndexChanged);
            // 
            // btColorTira
            // 
            this.btColorTira.Location = new System.Drawing.Point(387, 74);
            this.btColorTira.Margin = new System.Windows.Forms.Padding(2);
            this.btColorTira.Name = "btColorTira";
            this.btColorTira.Size = new System.Drawing.Size(67, 19);
            this.btColorTira.TabIndex = 3;
            this.btColorTira.Text = "Color Tira";
            this.btColorTira.UseVisualStyleBackColor = true;
            this.btColorTira.Click += new System.EventHandler(this.btColorTira_Click);
            // 
            // tbNLEDS
            // 
            this.tbNLEDS.Location = new System.Drawing.Point(132, 54);
            this.tbNLEDS.Margin = new System.Windows.Forms.Padding(2);
            this.tbNLEDS.Name = "tbNLEDS";
            this.tbNLEDS.Size = new System.Drawing.Size(45, 20);
            this.tbNLEDS.TabIndex = 5;
            // 
            // lbNLEDS
            // 
            this.lbNLEDS.AutoSize = true;
            this.lbNLEDS.Location = new System.Drawing.Point(58, 56);
            this.lbNLEDS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNLEDS.Name = "lbNLEDS";
            this.lbNLEDS.Size = new System.Drawing.Size(50, 13);
            this.lbNLEDS.TabIndex = 8;
            this.lbNLEDS.Text = "Nº LEDS";
            // 
            // lbPuerto
            // 
            this.lbPuerto.AutoSize = true;
            this.lbPuerto.Location = new System.Drawing.Point(58, 32);
            this.lbPuerto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(38, 13);
            this.lbPuerto.TabIndex = 9;
            this.lbPuerto.Text = "Puerto";
            // 
            // lbColorTira
            // 
            this.lbColorTira.AutoSize = true;
            this.lbColorTira.Location = new System.Drawing.Point(58, 80);
            this.lbColorTira.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbColorTira.Name = "lbColorTira";
            this.lbColorTira.Size = new System.Drawing.Size(52, 13);
            this.lbColorTira.TabIndex = 10;
            this.lbColorTira.Text = "Color Tira";
            // 
            // lbRGBTira
            // 
            this.lbRGBTira.AutoSize = true;
            this.lbRGBTira.Location = new System.Drawing.Point(153, 80);
            this.lbRGBTira.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRGBTira.Name = "lbRGBTira";
            this.lbRGBTira.Size = new System.Drawing.Size(33, 13);
            this.lbRGBTira.TabIndex = 11;
            this.lbRGBTira.Text = "black";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "LED";
            // 
            // lbColorLED
            // 
            this.lbColorLED.AutoSize = true;
            this.lbColorLED.Location = new System.Drawing.Point(184, 164);
            this.lbColorLED.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbColorLED.Name = "lbColorLED";
            this.lbColorLED.Size = new System.Drawing.Size(31, 13);
            this.lbColorLED.TabIndex = 13;
            this.lbColorLED.Text = "Color";
            // 
            // tbColorTira
            // 
            this.tbColorTira.Location = new System.Drawing.Point(132, 78);
            this.tbColorTira.Margin = new System.Windows.Forms.Padding(2);
            this.tbColorTira.Name = "tbColorTira";
            this.tbColorTira.Size = new System.Drawing.Size(18, 20);
            this.tbColorTira.TabIndex = 14;
            // 
            // tbColorLED
            // 
            this.tbColorLED.Location = new System.Drawing.Point(220, 163);
            this.tbColorLED.Margin = new System.Windows.Forms.Padding(2);
            this.tbColorLED.Name = "tbColorLED";
            this.tbColorLED.Size = new System.Drawing.Size(18, 20);
            this.tbColorLED.TabIndex = 15;
            // 
            // lbRGBLED
            // 
            this.lbRGBLED.AutoSize = true;
            this.lbRGBLED.Location = new System.Drawing.Point(241, 166);
            this.lbRGBLED.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRGBLED.Name = "lbRGBLED";
            this.lbRGBLED.Size = new System.Drawing.Size(32, 13);
            this.lbRGBLED.TabIndex = 16;
            this.lbRGBLED.Text = "white";
            // 
            // cbPuerto
            // 
            this.cbPuerto.FormattingEnabled = true;
            this.cbPuerto.Location = new System.Drawing.Point(132, 29);
            this.cbPuerto.Name = "cbPuerto";
            this.cbPuerto.Size = new System.Drawing.Size(121, 21);
            this.cbPuerto.TabIndex = 17;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 241);
            this.Controls.Add(this.cbPuerto);
            this.Controls.Add(this.lbRGBLED);
            this.Controls.Add(this.tbColorLED);
            this.Controls.Add(this.tbColorTira);
            this.Controls.Add(this.lbColorLED);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRGBTira);
            this.Controls.Add(this.lbColorTira);
            this.Controls.Add(this.lbPuerto);
            this.Controls.Add(this.lbNLEDS);
            this.Controls.Add(this.tbNLEDS);
            this.Controls.Add(this.btColorTira);
            this.Controls.Add(this.cbSelecLED);
            this.Controls.Add(this.btNLEDS);
            this.Controls.Add(this.btConnect);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "AdaLight-Control";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btNLEDS;
        private System.Windows.Forms.ComboBox cbSelecLED;
        private System.Windows.Forms.Button btColorTira;
        private System.Windows.Forms.TextBox tbNLEDS;
        private System.Windows.Forms.Label lbNLEDS;
        private System.Windows.Forms.Label lbPuerto;
        private System.Windows.Forms.Label lbColorTira;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lbRGBTira;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbColorLED;
        private System.Windows.Forms.TextBox tbColorTira;
        private System.Windows.Forms.TextBox tbColorLED;
        private System.Windows.Forms.Label lbRGBLED;
        private System.Windows.Forms.ComboBox cbPuerto;
    }
}

