using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;

namespace ProgettoDinamoDB
{
    public partial class Form3 : Form
    {
        DynamoClientSetup DB;
        DateTime StartDate;
        DateTime EndDate;
        public Form3(DateTime start, DateTime end, DynamoClientSetup db)
        {
            InitializeComponent();
            DB = db;
            StartDate = start;
            EndDate = end;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            List<Data> ld2 = new List<Data>();
            ld2.AddRange(DB.SearchItem(StartDate, EndDate));
            List<Data> ld = ld2.OrderBy(x => Convert.ToDateTime(x.Time)).ToList();
            List<string> Lables = new List<string>();
            ListToDT(DB.SearchItem(StartDate, EndDate));
            cartesianChart1.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(55, 32, 49));
            ChartValues<ChartModel> val = new ChartValues<ChartModel>();
            for (int i = 0; i < ld.Count; i++)
            {
                Data d = ld[i];
                val.Add(new ChartModel(d.Time, d.Deg, d.Lumin, d.WaterLevel, d.Humidity));
                Lables.Add(d.Time);
            }
            //Sets the display methods for the various types of Data
            var LightModel = Mappers.Xy<ChartModel>()
                .Y(dayModel => dayModel.Light);
            var HuModel = Mappers.Xy<ChartModel>()
                .Y(dayModel => dayModel.Humidity);
            var WatModel = Mappers.Xy<ChartModel>()
                .Y(dayModel => dayModel.WaterLevel);
            var DegModel = Mappers.Xy<ChartModel>()
                .Y(dayModel => dayModel.Temperature);
            LineSeries scTemperature = new LineSeries(DegModel)
            {
                Values = val,
                Title = "Temperature:",
            };
            LineSeries scLight = new LineSeries(LightModel)
            {
                Values = val,
                Title = "Light:",
            };
            LineSeries scHumidity = new LineSeries(HuModel)
            {
                Values = val,
                Title = "Humidity: ",
            };
            LineSeries scWaterLevel = new LineSeries(LightModel)
            {
                Values = val,
                Title = "Water level:",
            };
            //Creates the X and Y axis
            cartesianChart1.AxisX.Add(new Axis
            {
                IsMerged = true,
                Title = "Date",
                Labels = Lables,
                ShowLabels = false,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new DoubleCollection(2),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                IsMerged = true,
                Title = "Values",
                Separator = new Separator
                {
                    StrokeThickness = 1.5,
                    StrokeDashArray = new DoubleCollection(2),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86)),
                }
            });
            //Adds the data series to the graphics
            cartesianChart1.Series.Add(scTemperature);
            cartesianChart1.Series.Add(scLight);
            cartesianChart1.Series.Add(scWaterLevel);
            cartesianChart1.Series.Add(scHumidity);
        }
        public void ListToDT(List<Data> ld2)
        {
            List<Data> ld = ld2.OrderBy(x => Convert.ToDateTime(x.Time)).ToList();
            DataTable table = new DataTable();
            using (var reader = FastMember.ObjectReader.Create(ld))
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
            dataGridView1.AllowUserToDeleteRows = false;
            foreach (DataGridViewBand dgvb in dataGridView1.Columns)
            {
                dgvb.ReadOnly = true;
            }
        }

        private void buttonExportToCSV_Click(object sender, EventArgs e)
        {
            //Already explained into Form2.cs
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
    }
    public class ChartModel
    {
        //Chart Model for correct display with dates
        public string DateTime { get; set; }
        public int Temperature { get; set; }
        public int Light { get; set; }
        public int Humidity { get; set; }
        public int WaterLevel { get; set; }
        public ChartModel(string dt, int t, int l, int hum, int wat)
        {
            DateTime = dt;
            Temperature = t;
            Light = l;
            WaterLevel = wat;
            Humidity = hum;
        }
    }
}