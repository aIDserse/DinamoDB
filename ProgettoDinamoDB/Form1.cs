using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace ProgettoDinamoDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxSerial.DataSource = SerialPort.GetPortNames();
            label1.Visible = false;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //tries to log in into DynamoDB and load the control form
                //if it gives any Exception, it returns to Form1 interface and 
                //a red label displaying an error will appear
                DynamoClientSetup DCS = new DynamoClientSetup(textBoxAccessKey.Text, textBoxSecretKey.Text);
                label1.Visible = false;
                Hide();
                using (Form2 form2 = new Form2(DCS, comboBoxSerial.Text))
                {
                    form2.ShowDialog();
                }
                Show();
            }
            catch
            {
                Show();
                label1.Visible = true;
                label1.ForeColor = Color.White;
                label1.BackColor = Color.Red;
            }
        }
    }
}
