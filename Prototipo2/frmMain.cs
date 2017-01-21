using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo2
{
    public partial class frmMain : Form
    {
        System.IO.Ports.SerialPort ArduinoPort;

        public frmMain()
        {
            InitializeComponent();
            //crear Serial Port
            ArduinoPort = new System.IO.Ports.SerialPort();
            ArduinoPort.PortName = "COM3"; //sustituir por vuestro 
            ArduinoPort.BaudRate = 115200;
            ArduinoPort.Open();

            //crear Serial Port
            //            ArduinoPort = new System.IO.Ports.SerialPort();
            //            ArduinoPort.PortName = "COM4";  //sustituir por vuestro 
            //            ArduinoPort.BaudRate = 9600;
            //            ArduinoPort.Open();

            //vincular eventos
            this.FormClosing += FrmMain_FormClosing;
            this.btNLEDS.Click += btNLEDS_Click;
            this.btPuerto.Click += btPuerto_Click;
            this.tbColorTira.Click += tbColorTira_Click;
            this.tbColorLED.Click += tbColorLED_Click;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cerrar puerto
            if (ArduinoPort.IsOpen) ArduinoPort.Close();
        }


        private void btPuerto_Click(object sender, EventArgs e)
        {

            byte[] serialData = new byte[31];

            serialData[0] = 0x41;                              // Magic word
            serialData[1] = 0x64;
            serialData[2] = 0x61;


            serialData[3] = (byte)((8 - 1) >> 8);   // LED count high byte
            serialData[4] = (byte)((8 - 1) & 0xff); // LED count low byte
            serialData[5] = (byte)(serialData[3] ^ serialData[4] ^ 0x55); // Checksum

            /*
                        // A special header / magic word is expected by the corresponding LED
                        // streaming code running on the Arduino.  This only needs to be initialized
                        // once (not in draw() loop) because the number of LEDs remains constant:
                        serialData[0] = 'A';                              // Magic word
                        serialData[1] = 'd';
                        serialData[2] = 'a';
                        serialData[3] = (byte)((leds.length - 1) >> 8);   // LED count high byte
                        serialData[4] = (byte)((leds.length - 1) & 0xff); // LED count low byte
                        serialData[5] = (byte)(serialData[3] ^ serialData[4] ^ 0x55); // Checksum

            */






            /*            serialData[6] = 0x56;
                        serialData[7] = 0x00;
                        serialData[8] = 0x00;
                        serialData[9] = 0x2f;
                        serialData[10] = 0x4e;
                        serialData[11] = 0x4a;
                        serialData[12] = 0x4f;
                        serialData[13] = 0x5a;
                        serialData[14] = 0x5a;
                        serialData[15] = 0x5a;
                        serialData[16] = 0x2d;
                        serialData[17] = 0x2c;
                        serialData[18] = 0x2c;
                        serialData[19] = 0x4a;
                        serialData[20] = 0x3f;
                        serialData[21] = 0x49;
                        serialData[22] = 0x58;
                        serialData[23] = 0x57;
                        serialData[24] = 0x00;
                        serialData[25] = 0x00;
                        serialData[26] = 0x00;
                        serialData[27] = 0x00;
                        serialData[28] = 0x00;
                        serialData[29] = 0x00;
                        serialData[30] = 0x00;
            */




            serialData[6] = 0x52;
                        serialData[7] = 0x31;
                        serialData[8] = 0x32;
                        serialData[9] = 0x2f;
                        serialData[10] = 0x4e;
                        serialData[11] = 0x4a;
                        serialData[12] = 0x4f;
                        serialData[13] = 0x5a;
                        serialData[14] = 0x5a;
                        serialData[15] = 0x5a;
                        serialData[16] = 0x2d;
                        serialData[17] = 0x2c;
                        serialData[18] = 0x2c;
                        serialData[19] = 0x4a;
                        serialData[20] = 0x3f;
                        serialData[21] = 0x00;
                        serialData[22] = 0x00;
                        serialData[23] = 0x57;
                        serialData[24] = 0x59;
                        serialData[25] = 0x4c;
                        serialData[26] = 0x4a;
                        serialData[27] = 0x4d;
                        serialData[28] = 0x58;
                        serialData[29] = 0x57;
                        serialData[30] = 0x5a;
            




            ArduinoPort.Write(serialData,0,31);
            //            ArduinoPort.Write("b");
        }

        private void btNLEDS_Click(object sender, EventArgs e)
        {







            byte[] serialData = new byte[31];

            serialData[0] = 0x41;                              // Magic word
            serialData[1] = 0x64;
            serialData[2] = 0x61;


            serialData[3] = (8 - 1) >> 8;   // LED count high byte
            serialData[4] = (8 - 1) & 0xff; // LED count low byte
            serialData[5] = (byte)(serialData[3] ^ serialData[4] ^ 0x55); // Checksum


            
            serialData[6] = 0x52;
            serialData[7] = 0x31;
            serialData[8] = 0x32;
            serialData[9] = 0x2f;
            serialData[10] = 0x4e;
            serialData[11] = 0x4a;
            serialData[12] = 0x4f;
            serialData[13] = 0x5a;
            serialData[14] = 0x5a;
            serialData[15] = 0x5a;
            serialData[16] = 0x2d;
            serialData[17] = 0x2c;
            serialData[18] = 0x2c;
            serialData[19] = 0x4a;
            serialData[20] = 0x3f;
            serialData[21] = 0x49;
            serialData[22] = 0x58;
            serialData[23] = 0x57;
            serialData[24] = 0x59;
            serialData[25] = 0x4c;
            serialData[26] = 0x4a;
            serialData[27] = 0x4d;
            serialData[28] = 0x58;
            serialData[29] = 0x57;
            serialData[30] = 0x5a;





            ArduinoPort.Write(serialData, 0, 31);










            //            ArduinoPort.Write("a");
        }

        private void btColorTira_Click(object sender, EventArgs e)
        {

        }


        private void tbColorLED_Click(object sender, EventArgs e)
        {
            ColorDialog DialogColorLED = new ColorDialog();
            // Keeps the user from selecting a custom color.
            DialogColorLED.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            DialogColorLED.ShowHelp = false;
            // Sets the initial color select to the current text color.
            DialogColorLED.Color = tbColorLED.ForeColor;

            // Update the text box color if the user clicks OK 
            if (DialogColorLED.ShowDialog() == DialogResult.OK)
            {
                this.tbColorLED.BackColor = DialogColorLED.Color;
                this.lbRGBLED.Text = "R = " + DialogColorLED.Color.R + ", G = " + DialogColorLED.Color.G + ", B = " + DialogColorLED.Color.B;
            }
        }


        private void tbColorTira_Click(object sender, EventArgs e)
        {
            ColorDialog DialogColorTira = new ColorDialog();
            // Keeps the user from selecting a custom color.
            DialogColorTira.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            DialogColorTira.ShowHelp = false;
            // Sets the initial color select to the current text color.
            DialogColorTira.Color = tbColorLED.ForeColor;

            // Update the text box color if the user clicks OK 
            if (DialogColorTira.ShowDialog() == DialogResult.OK)
            {
                this.tbColorTira.BackColor = DialogColorTira.Color;
//              tbColorTira.Text = "R = " + MyDialog.Color.R + ", G = " + MyDialog.Color.G + ", B = " + MyDialog.Color.B;
                this.lbRGBTira.Text = "R = " + DialogColorTira.Color.R + ", G = " + DialogColorTira.Color.G + ", B = " + DialogColorTira.Color.B + "Lum" + DialogColorTira.Color.GetBrightness();
            }

        }

        private void cbSelecLED_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbPuerto_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void tbColorLED_TextChanged(object sender, EventArgs e)
        {
//            
        }

        /*        private void label1_Click(object sender, EventArgs e)
                {

                }

        *//*        private void label2_Click(object sender, EventArgs e)
                {

                }
        */
    }
}
