using ArduinoUploader;
using ArduinoUploader.Hardware;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace ProgettoDinamoDB
{
    public partial class Form2 : Form
    {
        DynamoClientSetup DB;
        JsonConnection js;
        SerialPort s;
        Thread t;
        public Form2(DynamoClientSetup db, string SerialSelected)
        {
            JsonConnection js = new JsonConnection();
            //Opens the serial port to arduino 
            s = new SerialPort(SerialSelected, 9600);
            InitializeComponent();
            js = new JsonConnection();
            ArduinoSketchUploader uploader = new ArduinoSketchUploader(
            //Set the options and loads a pre-complied file into our arduino
            new ArduinoSketchUploaderOptions()
            {
                FileName = @".\Sketch\Sketch.hex",
                PortName = SerialSelected,
                ArduinoModel = ArduinoModel.UnoR3,
            });
            uploader.UploadSketch();
            try
            {
                //checks if our tables exits and tries to create it
                DB = db;
                List<string> currentTables = DB.client.ListTablesAsync().Result.TableNames;
                if (!currentTables.Contains("Data"))
                {
                    DB.CreateTable("Data");
                    DB.WaitUntilTableReady();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fatal exception\n Cant't find or create the Data Table needed for functioning\n! The program can't function correctly!\n" + exc.Message);
                throw exc;
            }
            dataGridView1.AllowUserToDeleteRows = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //Adds to datagrid the current DynamoDB data
            ListToDT(DB.SearchItem(DateTime.Today, DateTime.Now.AddDays(1)));
            //creates and runs a new thread that runs the method that retrieves
            //the informations from the serial port and puts them into the DB
            t = new Thread(RunJsonRead);
            s.Open();
            t.Start();
        }
        public void RunJsonRead()
        {
            while(true)
            {
                Data d = new Data();
                if (!s.IsOpen)
                {
                    s.DtrEnable = true;
                    s.Open();
                }
                DB.WaitUntilTableReady();
                try
                {
                    d = js.GetData(s);
                    DB.InsertItem(d);
                    dataGridView1.Invoke(new MethodInvoker(() => { ListToDT(DB.SearchItem(DateTime.Today, DateTime.Now.AddDays(1))); }));
                }
                catch
                {
                    MessageBox.Show("Error! Invalid data submitted!");
                }
                //Reads every 5 seconds
                Thread.Sleep(5000);
            }
        }
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Data d = new Data();
            d.Time = DateTime.Now.ToString();
            d.ID = (uint)d.Time.GetHashCode();
            DB.InsertItem(d);
            MessageBox.Show(Convert.ToString(d.ID));
            ListToDT(DB.SearchItem(DateTime.Today, DateTime.Now.AddDays(1)));
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewBand dgvb in dataGridView1.Columns)
            {
                dgvb.ReadOnly = true;
            }
        }
        public void ListToDT(List<Data> ld2)
        {
            List<Data> ld = ld2.OrderByDescending(x => Convert.ToDateTime(x.Time)).ToList();
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(ld))
            {
                table.Load(reader);
            }
            dataGridView1.DataSource = table;
            dataGridView1.Columns["ID"].DisplayIndex = 0;
            dataGridView1.Columns["Time"].DisplayIndex = 1;
            dataGridView1.Columns["Time"].Width = 150;
            dataGridView1.Columns["CordX"].HeaderText = "X Coordinate";
            dataGridView1.Columns["CordY"].HeaderText = "Y Coordinate";
            dataGridView1.Columns["Deg"].HeaderText = "Temperature";
            dataGridView1.Columns["Lumin"].HeaderText = "Luminosity";
            dataGridView1.Columns["Humidity"].HeaderText = "Humidity";
            dataGridView1.Columns["WaterLevel"].HeaderText = "Water Level";
        }
        private void buttonGenGraph_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 f = new Form3(dateTimePickerGraphStart.Value, dateTimePickerGraphEnd.Value, DB);
                f.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error! Graph has invalid or corrupted data, check your DynamoDB table!");
            }
        }
        private void buttonExportToSCV_Click(object sender, EventArgs e)
        {
            //Exports a DataTable into a string, that gets converted into a CSV
            StringBuilder sb = new StringBuilder();
            DataTable dt = (DataTable)(dataGridView1.DataSource);
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }
            //Lets the user decide the save path
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";
            saveFileDialog1.Title = "Export to comma separated values";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "" && saveFileDialog1.FileName != null)
            {
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
            }
            else
            {
                MessageBox.Show("Invalid path!");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Closes serial and thread reading from arduino
            s.Close();
            t.Abort();
        }
    }
}