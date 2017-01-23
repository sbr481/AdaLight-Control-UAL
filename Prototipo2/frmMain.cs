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
        static int num_leds = 0;
        byte[] serialData = new byte[6 + (num_leds * 3)];
        string[] portsAvailable = System.IO.Ports.SerialPort.GetPortNames();
        string[] array_numeros = null;

        //Alpha Test - RAW Attribs
        /*
        byte r_global, g_global, b_global, brigth_global;
        byte r_led, g_led, b_led, bright_led;
        int sine = 1;
        int brightness;*/

        //Beta Test - ColorCorrectionMod Attribs
        byte[,] gamma = new byte[256, 3];
        float f;
        short[] stripColor = new short[3], ledColor = new short[3];
        int sum, deficit, s2;
        static short minBrightness = 120;

        //Beta Test - Colorswirl Attribs
        byte[] buffer = new byte[6 + (num_leds * 3)];
        float sine1, sine2;
        int hue1, hue2, bright, lo, r, g, b;


        public frmMain()
        {
            InitializeComponent();
            
            //Alpha Test - Correccion Gamma
            //
            //brightness = (int)(Math.Pow(0.5 + Math.Sin(sine) * 0.5, 3.0) * 255.0);

            //Beta Test - ColorCorrectionMod
            //Status: WORKING
            //
            //Pre-compute gamma correction table for LED brightness levels:
            for (int i = 0; i < 256; i++)
            {
                f = (float)Math.Pow((float)i / 255.0, 2.8);
                gamma[i, 0] = (byte)(f * 255.0);
                gamma[i, 1] = (byte)(f * 240.0);
                gamma[i, 2] = (byte)(f * 220.0);
            }

            tbNLEDS.Text = "0";
            cbSelecLED.DataSource = array_numeros;
            //Crear Serial Port
            ArduinoPort = new System.IO.Ports.SerialPort();
            

            //Alpha Test - Puerto
            //
            //Crear Serial Port
            //            ArduinoPort = new System.IO.Ports.SerialPort();
            //            ArduinoPort.PortName = "COM4";  //sustituir por vuestro 
            //            ArduinoPort.BaudRate = 9600;
            //            ArduinoPort.Open();

            //Vinculacion eventos
            //
            this.FormClosing += FrmMain_FormClosing;
            this.btNLEDS.Click += btNLEDS_Click;
            this.btConnect.Click += btConnect_Click;
            this.tbColorTira.Click += tbColorTira_Click;
            this.tbColorLED.Click += tbColorLED_Click;
            this.tbNLEDS.Leave += tbNLEDS_Leave;
            this.btColorswirl.Click += btColorswirl_Click;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbPuerto.DataSource = portsAvailable;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cierre puerto
            if (ArduinoPort.IsOpen) ArduinoPort.Close();
            MessageBox.Show("Conexion cerrada con Arduino. Hasta pronto!!!");
        }


        private void btConnect_Click(object sender, EventArgs e)
        {

            if (ArduinoPort.IsOpen) ArduinoPort.Close();
            if (!cbPuerto.Text.Equals(""))
            {
                MessageBox.Show("Conectando a Arduino...");
                ArduinoPort.PortName = cbPuerto.Text;
                ArduinoPort.BaudRate = 115200;
                ArduinoPort.Open();
                MessageBox.Show("Conectado al puerto: " + ArduinoPort.PortName);
            }
            else
            {
                //Alerta de que no hay ningun puerto serie en el sistema
                MessageBox.Show("No hay puerto seleccionado.");
            }

        }

        private void btNLEDS_Click(object sender, EventArgs e)
        {

            byte[] serialData2 = serialData;

            int n_led = 6 + (int.Parse(cbSelecLED.Text) * 3);

            serialData2[n_led] = gamma[ledColor[0], 0];
            serialData2[n_led + 1] = gamma[ledColor[1], 1];
            serialData2[n_led + 2] = gamma[ledColor[2], 2];

            ArduinoPort.Write(serialData2, 0, serialData2.Length);

            serialData = serialData2;

        }

        private void btColorTira_Click(object sender, EventArgs e)
        {
            //Connection Check
            if (ArduinoPort.IsOpen)
            {

                //Adalight Protocol - Magic Word
                //
                serialData[0] = (byte)'A';  //Hex = 0x41
                serialData[1] = (byte)'d';  //Hex = 0x64
                serialData[2] = (byte)'a';  //Hex = 0x61
                //
                serialData[3] = (byte)((num_leds - 1) >> 8);                    //LED count high byte
                serialData[4] = (byte)((num_leds - 1) & 0xff);                  //LED count low byte
                serialData[5] = (byte)(serialData[3] ^ serialData[4] ^ 0x55);   //Checksum

                //Alpha Test - Buffer Length Check
                //MessageBox.Show("1.La longitud del buffer en posiciones es: " +serialData.Length);

                for (int i = 6; i < serialData.Length; i++)
                {

                    //Alpha Test - Paleta RAW
                    //
                    /*serialData[i++] = r_global;
                      serialData[i++] = g_global;
                      serialData[i] = b_global;*/

                    //Alpha Test - RAW & Brightness Correction
                    //
                    /*serialData[i++] = (byte)(((char)r_global * brightness)/255);
                      serialData[i++] = (byte)(((char)g_global * brightness) / 255);
                      serialData[i] = (byte)(((char)b_global * brightness) / 255);*/

                    //Beta Test - ColorCorrectionMod
                    //
                    serialData[i++] = gamma[stripColor[0], 0];
                    serialData[i++] = gamma[stripColor[1], 1];
                    serialData[i] = gamma[stripColor[2], 2];

                }

                //Writing Strip Data on Serial Port
                ArduinoPort.Write(serialData, 0, serialData.Length);

            }
            else
            {
                MessageBox.Show("¡Debe establecer la comunicación por el puerto serie antes de hacer cambios!");
            }

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

                //LED Color Dialog Update
                this.tbColorLED.BackColor = DialogColorLED.Color;
                this.lbRGBLED.Text = "R = " + DialogColorLED.Color.R + ", G = " + DialogColorLED.Color.G + ", B = " + DialogColorLED.Color.B;

                //Alpha Test - Paleta RAW
                /*
                r_led = DialogColorLED.Color.R;
                g_led = DialogColorLED.Color.G;
                b_led = DialogColorLED.Color.B;*/
                //bright_led = DialogColorLED.Color.GetBrightness();

                //Beta Test - ColorCorrectionMod
                //
                ledColor[0] = (short)DialogColorLED.Color.R;
                ledColor[1] = (short)DialogColorLED.Color.G;
                ledColor[2] = (short)DialogColorLED.Color.B;
                //
                //Boost pixels that fall below the minimum brightness
                sum = ledColor[0] + ledColor[1] + ledColor[2];
                if (sum < minBrightness)
                {
                    if (sum == 0)
                    { // To avoid divide-by-zero
                        deficit = minBrightness / 3; // Spread equally to R,G,B
                        ledColor[0] += (short)deficit;
                        ledColor[1] += (short)deficit;
                        ledColor[2] += (short)deficit;
                    }
                    else
                    {
                        deficit = minBrightness - sum;
                        s2 = sum * 2;
                        // Spread the "brightness deficit" back into R,G,B in proportion to
                        // their individual contribition to that deficit.  Rather than simply
                        // boosting all pixels at the low end, this allows deep (but saturated)
                        // colors to stay saturated...they don't "pink out."
                        ledColor[0] += (short)(deficit * (sum - ledColor[0]) / s2);
                        ledColor[1] += (short)(deficit * (sum - ledColor[1]) / s2);
                        ledColor[2] += (short)(deficit * (sum - ledColor[2]) / s2);
                    }
                }

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
                this.lbRGBTira.Text = "R = " + DialogColorTira.Color.R + ", G = " + DialogColorTira.Color.G + ", B = " + DialogColorTira.Color.B + "Lum" + DialogColorTira.Color.GetBrightness();

                //Alpha Test - Paleta RAW
                //
              /*r_global = DialogColorTira.Color.R;
                g_global = DialogColorTira.Color.G;
                b_global = DialogColorTira.Color.B;*/

                //Beta Test - ColorCorrectionMod
                //
                stripColor[0] = (short)DialogColorTira.Color.R;
                stripColor[1] = (short)DialogColorTira.Color.G;
                stripColor[2] = (short)DialogColorTira.Color.B;
                //
                //Boost pixels that fall below the minimum brightness
                sum = stripColor[0] + stripColor[1] + stripColor[2];
                if (sum < minBrightness)
                {
                    if (sum == 0)
                    { // To avoid divide-by-zero
                        deficit = minBrightness / 3; // Spread equally to R,G,B
                        stripColor[0] += (short)deficit;
                        stripColor[1] += (short)deficit;
                        stripColor[2] += (short)deficit;
                    }
                    else
                    {
                        deficit = minBrightness - sum;
                        s2 = sum * 2;
                        // Spread the "brightness deficit" back into R,G,B in proportion to
                        // their individual contribition to that deficit.  Rather than simply
                        // boosting all pixels at the low end, this allows deep (but saturated)
                        // colors to stay saturated...they don't "pink out."
                        stripColor[0] += (short)(deficit * (sum - stripColor[0]) / s2);
                        stripColor[1] += (short)(deficit * (sum - stripColor[1]) / s2);
                        stripColor[2] += (short)(deficit * (sum - stripColor[2]) / s2);
                    }
                }

            }

        }

        private void tbNLEDS_Leave(object sender, EventArgs e)
        {

            num_leds = int.Parse(tbNLEDS.Text);
            serialData = new byte[6 + (num_leds * 3)];
            array_numeros = new string[num_leds];
            buffer = new byte[6 + (num_leds * 3)];

            for (int i = 0; i < num_leds; i++)
            {
                array_numeros[i] = i.ToString();
            }
            //MessageBox.Show("Numero de leds actualizado.");
            cbSelecLED.DataSource = array_numeros;

        }

        private void btColorswirl_Click(object sender, EventArgs e)
        {
            buffer[0] = (byte) 'A';                                // Magic word
            buffer[1] = (byte) 'd';
            buffer[2] = (byte) 'a';
            buffer[3] = (byte) ((num_leds - 1) >> 8);            // LED count high byte
            buffer[4] = (byte) ((num_leds - 1) & 0xff);          // LED count low byte
            buffer[5] = (byte) (buffer[3] ^ buffer[4] ^ 0x55); // Checksum

            sine1 = (float) 0.0;
            hue1 = 0;
            //prev = second(); // For bandwidth statistics

            while (!btCStop.)
            {
                sine2 = sine1;
                hue2 = hue1;

                // Start at position 6, after the LED header/magic word
                for (int i = 6; i < buffer.Length;)
                {
                    // Fixed-point hue-to-RGB conversion.  'hue2' is an integer in the
                    // range of 0 to 1535, where 0 = red, 256 = yellow, 512 = green, etc.
                    // The high byte (0-5) corresponds to the sextant within the color
                    // wheel, while the low byte (0-255) is the fractional part between
                    // the primary/secondary colors.
                    lo = hue2 & 255;
                    switch ((hue2 >> 8) % 6)
                    {
                        case 0:
                            r = 255;
                            g = lo;
                            b = 0;
                            break;
                        case 1:
                            r = 255 - lo;
                            g = 255;
                            b = 0;
                            break;
                        case 2:
                            r = 0;
                            g = 255;
                            b = lo;
                            break;
                        case 3:
                            r = 0;
                            g = 255 - lo;
                            b = 255;
                            break;
                        case 4:
                            r = lo;
                            g = 0;
                            b = 255;
                            break;
                        default:
                            r = 255;
                            g = 0;
                            b = 255 - lo;
                            break;
                    }

                    // Resulting hue is multiplied by brightness in the range of 0 to 255
                    // (0 = off, 255 = brightest).  Gamma corrrection (the 'pow' function
                    // here) adjusts the brightness to be more perceptually linear.
                    int bright = (int)(Math.Pow(0.5 + Math.Sin(sine2) * 0.5, 2.8) * 255.0);
                    buffer[i++] = (byte)((r * bright) / 255);
                    buffer[i++] = (byte)((g * bright) / 255);
                    buffer[i++] = (byte)((b * bright) / 255);

                    // Each pixel is slightly offset in both hue and brightness
                    hue2 += 40;
                    sine2 += (float) 0.3;
                }

                // Slowly rotate hue and brightness in opposite directions
                hue1 = (hue1 + 4) % 1536;
                sine1 -= (float) .03;

                ArduinoPort.Write(buffer, 0, buffer.Length);

            }
        }

        private void cbSelecLED_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }


}
