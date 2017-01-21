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
            this.btPuerto = new System.Windows.Forms.Button();
            this.btNLEDS = new System.Windows.Forms.Button();
            this.cbSelecLED = new System.Windows.Forms.ComboBox();
            this.btColorTira = new System.Windows.Forms.Button();
            this.tbNLEDS = new System.Windows.Forms.TextBox();
            this.tbPuerto = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // btPuerto
            // 
            this.btPuerto.Location = new System.Drawing.Point(683, 362);
            this.btPuerto.Name = "btPuerto";
            this.btPuerto.Size = new System.Drawing.Size(89, 23);
            this.btPuerto.TabIndex = 0;
            this.btPuerto.Text = "Puerto";
            this.btPuerto.UseVisualStyleBackColor = true;
            this.btPuerto.Click += new System.EventHandler(this.btPuerto_Click);
            // 
            // btNLEDS
            // 
            this.btNLEDS.Location = new System.Drawing.Point(683, 386);
            this.btNLEDS.Name = "btNLEDS";
            this.btNLEDS.Size = new System.Drawing.Size(89, 23);
            this.btNLEDS.TabIndex = 1;
            this.btNLEDS.Text = "N LEDS";
            this.btNLEDS.UseVisualStyleBackColor = true;
            this.btNLEDS.Click += new System.EventHandler(this.btNLEDS_Click);
            // 
            // cbSelecLED
            // 
            this.cbSelecLED.FormattingEnabled = true;
            this.cbSelecLED.Location = new System.Drawing.Point(119, 290);
            this.cbSelecLED.Name = "cbSelecLED";
            this.cbSelecLED.Size = new System.Drawing.Size(121, 24);
/*            int numLEDs = Int32.Parse(tbNLEDS.Text);
            this.cbSelecLED.TabIndex = Int32.Parse(tbNLEDS.Text);
*/          this.cbSelecLED.TabIndex = 2;
            this.cbSelecLED.SelectedIndexChanged += new System.EventHandler(this.cbSelecLED_SelectedIndexChanged);
//            this.cbSelecLED.It
            // 
            // btColorTira
            // 
            this.btColorTira.Location = new System.Drawing.Point(683, 413);
            this.btColorTira.Name = "btColorTira";
            this.btColorTira.Size = new System.Drawing.Size(89, 23);
            this.btColorTira.TabIndex = 3;
            this.btColorTira.Text = "Color Tira";
            this.btColorTira.UseVisualStyleBackColor = true;
            this.btColorTira.Click += new System.EventHandler(this.btColorTira_Click);
            // 
            // tbNLEDS
            // 
            this.tbNLEDS.Location = new System.Drawing.Point(176, 66);
            this.tbNLEDS.Name = "tbNLEDS";
            this.tbNLEDS.Size = new System.Drawing.Size(59, 22);
            this.tbNLEDS.TabIndex = 5;
//            this.tbNLEDS.TextChanged += new System.EventHandler(this.tbNLEDS_TextChanged);
//            this.tbNLEDS.Text = "0";
            // tbPuerto
            // 
            this.tbPuerto.Location = new System.Drawing.Point(176, 36);
            this.tbPuerto.Name = "tbPuerto";
            this.tbPuerto.Size = new System.Drawing.Size(59, 22);
            this.tbPuerto.TabIndex = 6;
            this.tbPuerto.TextChanged += new System.EventHandler(this.tbPuerto_TextChanged);
            // 
            // lbNLEDS
            // 
            this.lbNLEDS.AutoSize = true;
            this.lbNLEDS.Location = new System.Drawing.Point(78, 69);
            this.lbNLEDS.Name = "lbNLEDS";
            this.lbNLEDS.Size = new System.Drawing.Size(63, 17);
            this.lbNLEDS.TabIndex = 8;
            this.lbNLEDS.Text = "Nº LEDS";
            // 
            // lbPuerto
            // 
            this.lbPuerto.AutoSize = true;
            this.lbPuerto.Location = new System.Drawing.Point(78, 39);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(50, 17);
            this.lbPuerto.TabIndex = 9;
            this.lbPuerto.Text = "Puerto";
            // 
            // lbColorTira
            // 
            this.lbColorTira.AutoSize = true;
            this.lbColorTira.Location = new System.Drawing.Point(78, 99);
            this.lbColorTira.Name = "lbColorTira";
            this.lbColorTira.Size = new System.Drawing.Size(70, 17);
            this.lbColorTira.TabIndex = 10;
            this.lbColorTira.Text = "Color Tira";
            // 
            // lbRGBTira
            // 
            this.lbRGBTira.AutoSize = true;
            this.lbRGBTira.Location = new System.Drawing.Point(204, 99);
            this.lbRGBTira.Name = "lbRGBTira";
            this.lbRGBTira.Size = new System.Drawing.Size(41, 17);
            this.lbRGBTira.TabIndex = 11;
            this.lbRGBTira.Text = "black";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "LED";
            // 
            // lbColorLED
            // 
            this.lbColorLED.AutoSize = true;
            this.lbColorLED.Location = new System.Drawing.Point(246, 293);
            this.lbColorLED.Name = "lbColorLED";
            this.lbColorLED.Size = new System.Drawing.Size(41, 17);
            this.lbColorLED.TabIndex = 13;
            this.lbColorLED.Text = "Color";
            // 
            // tbColorTira
            // 
            this.tbColorTira.Location = new System.Drawing.Point(176, 96);
            this.tbColorTira.Name = "tbColorTira";
            this.tbColorTira.Size = new System.Drawing.Size(22, 22);
            this.tbColorTira.TabIndex = 14;
            // 
            // tbColorLED
            // 
            this.tbColorLED.Location = new System.Drawing.Point(293, 292);
            this.tbColorLED.Name = "tbColorLED";
            this.tbColorLED.Size = new System.Drawing.Size(22, 22);
            this.tbColorLED.TabIndex = 15;
            // 
            // lbRGBLED
            // 
            this.lbRGBLED.AutoSize = true;
            this.lbRGBLED.Location = new System.Drawing.Point(321, 295);
            this.lbRGBLED.Name = "lbRGBLED";
            this.lbRGBLED.Size = new System.Drawing.Size(40, 17);
            this.lbRGBLED.TabIndex = 16;
            this.lbRGBLED.Text = "white";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 447);
            this.Controls.Add(this.lbRGBLED);
            this.Controls.Add(this.tbColorLED);
            this.Controls.Add(this.tbColorTira);
            this.Controls.Add(this.lbColorLED);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRGBTira);
            this.Controls.Add(this.lbColorTira);
            this.Controls.Add(this.lbPuerto);
            this.Controls.Add(this.lbNLEDS);
            this.Controls.Add(this.tbPuerto);
            this.Controls.Add(this.tbNLEDS);
            this.Controls.Add(this.btColorTira);
            this.Controls.Add(this.cbSelecLED);
            this.Controls.Add(this.btNLEDS);
            this.Controls.Add(this.btPuerto);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btPuerto;
        private System.Windows.Forms.Button btNLEDS;
        private System.Windows.Forms.ComboBox cbSelecLED;
        private System.Windows.Forms.Button btColorTira;
        private System.Windows.Forms.TextBox tbNLEDS;
        private System.Windows.Forms.TextBox tbPuerto;
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
    }
}

