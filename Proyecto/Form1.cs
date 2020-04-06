using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace Proyecto
{
    public partial class Form1 : Form
    {
        private SerialPort myport;
        private DateTime datetime;
        private string in_data;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                myport.Close();

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void iniciar(object sender, EventArgs e)
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = puerto.Text;
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += myport_DataReceived;

            try {
                myport.Open();
                tabladatos.Text = "";
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Error");


            }
        }

        private void myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            in_data = myport.ReadLine();
            this.Invoke(new EventHandler(displaydataevent));
           
            
        }

        private void displaydataevent(object sender, EventArgs e)
        {
            datetime = DateTime.Now;
            string time = datetime.Hour + ":" + datetime.Minute + ":" + datetime.Second;
            tabladatos.AppendText(time + "\t\t\t" + in_data+"\n");
        }

        private void guardar_Click(object sender, EventArgs e)
        {try { 
            string pathfile = @"C:\Users\BorjaZuma\Desktop\DATOS\";
            string filename = "datos.txt";
            System.IO.File.WriteAllText(pathfile + filename, tabladatos.Text);
            MessageBox.Show("Se han guardado los datos en "+pathfile, "Save File" );
            }
            catch(Exception ex3)
            {
                MessageBox.Show(ex3.Message, "Error");
            }
        }
    }
}
