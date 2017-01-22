using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Comentario 1
//Comentario 2
//Comentario generico
namespace Prototipo2
{
    public partial class frmMain : Form
    {
        System.IO.Ports.SerialPort ArduinoPort;
        static int num_leds = 0;
        byte[] serialData = new byte[6+(num_leds*3)];
        string[] portsAvailable = System.IO.Ports.SerialPort.GetPortNames();
        byte r_global, g_global, b_global, brigth_global;
        byte r_led, g_led, b_led, bright_led;
        string[] array_numeros = null;

        public frmMain()
        {
            InitializeComponent();

            tbNLEDS.Text = "0";
            cbSelecLED.DataSource = array_numeros;
            //crear Serial Port
            ArduinoPort = new System.IO.Ports.SerialPort();
            // ArduinoPort.PortName = "COM3"; //sustituir por vuestro 
            //ArduinoPort.BaudRate = 115200; //

        //    if (portsAvailable.Contains(tbPuerto.Text))
         //   {
          //      ArduinoPort.Open();
           // }
            

            //crear Serial Port
            //            ArduinoPort = new System.IO.Ports.SerialPort();
            //            ArduinoPort.PortName = "COM4";  //sustituir por vuestro 
            //            ArduinoPort.BaudRate = 9600;
            //            ArduinoPort.Open();

            //vincular eventos
            this.FormClosing += FrmMain_FormClosing;
            this.btNLEDS.Click += btNLEDS_Click;
            this.btConnect.Click += btConnect_Click;
            this.tbColorTira.Click += tbColorTira_Click;
            this.tbColorLED.Click += tbColorLED_Click;
            this.tbNLEDS.Leave += tbNLEDS_Leave;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbPuerto.DataSource = portsAvailable;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cerrar puerto
            if (ArduinoPort.IsOpen) ArduinoPort.Close();
            MessageBox.Show("Conexion cerrada con Arduino. Hasta pronto!!!");
        }


        private void btConnect_Click(object sender, EventArgs e)
        {

            if (ArduinoPort.IsOpen) ArduinoPort.Close();
            // ArduinoPort.PortName = cbPuerto.Text;
            if (!cbPuerto.Text.Equals(""))
            {
                MessageBox.Show("Conectando a Arduino...");
                ArduinoPort.PortName = cbPuerto.Text;
                ArduinoPort.BaudRate = 115200;
                ArduinoPort.Open();
                MessageBox.Show("Conectado al puerto: " +ArduinoPort.PortName);
            }else
            {
                //mostrar alerta de que no hay ningun puerto serie en el sistema
                MessageBox.Show("No hay puerto seleccionado.");
            }
                
            //ArduinoPort.Write(serialData,0,serialData.Length);
            //            ArduinoPort.Write("b");
        }

        private void btNLEDS_Click(object sender, EventArgs e)
        {

            byte[] serialData2 = serialData;

            int n_led = 6 + (int.Parse(cbSelecLED.Text) * 3);

            serialData2[n_led] = r_led;
            serialData2[n_led + 1] = g_led;
            serialData2[n_led + 2] = b_led;

            ArduinoPort.Write(serialData2, 0, serialData2.Length);

            serialData = serialData2;

        }

        private void btColorTira_Click(object sender, EventArgs e)
        {

            //if (!tbColorLED.Text.Equals(""))
            //{
                serialData[0] = 0x41;                              // Magic word
                serialData[1] = 0x64;
                serialData[2] = 0x61;
                           
                serialData[3] = (byte)((num_leds - 1) >> 8);   // LED count high byte
                serialData[4] = (byte)((num_leds - 1) & 0xff); // LED count low byte
                serialData[5] = (byte)(serialData[3] ^ serialData[4] ^ 0x55); // Checksum

                //MessageBox.Show("1.La longitud del buffer en posiciones es: " +serialData.Length);

                for (int i = 6; i < serialData.Length; i++)
                {
                    serialData[i] = r_global;
                    serialData[i++] = g_global;
                    serialData[i++] = b_global;
                }
                ArduinoPort.Write(serialData, 0, serialData.Length);
            //}
            //MessageBox.Show("2.La longitud del buffer en posiciones es: " + serialData.Length);
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
                r_led = DialogColorLED.Color.R;
                g_led = DialogColorLED.Color.G;
                b_led = DialogColorLED.Color.B;
                //bright_led = DialogColorLED.Color.GetBrightness();

               
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
                r_global = DialogColorTira.Color.R;
                g_global = DialogColorTira.Color.G;
                b_global = DialogColorTira.Color.B;
            }

        }

        private void cbSelecLED_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void tbNLEDS_Leave(object sender, EventArgs e)
        {

            num_leds = int.Parse(tbNLEDS.Text);
            serialData = new byte[6+(num_leds*3)];
            array_numeros = new string[num_leds];

            for(int i=0; i < num_leds; i++)
            {
                array_numeros[i] = i.ToString();
            }
            MessageBox.Show("Numero de leds actualizado.");
            cbSelecLED.DataSource = array_numeros;

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
