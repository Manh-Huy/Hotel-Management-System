using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _20142178_20110370_Nhom15_QLHotel
{
    public partial class FormStaticFoodAndDrink : Form
    {
        private bool isTooltipShown = false;
        private bool isTooltip2Shown = false;
        public FormStaticFoodAndDrink()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        private void FormStaticFoodAndDrink_Load(object sender, EventArgs e)
        {





            List<string> foodNames = new List<string>(); // Danh sách tên các món Food
            List<int> foodConsumption = new List<int>(); // Danh sách lượng tiêu thụ của các món Food

            List<string> waterNames = new List<string>(); // Danh sách tên các món Water
            List<int> waterConsumption = new List<int>(); // Danh sách lượng tiêu thụ của các món Water

            //try
            //{


            mydb.openConnection();

            string foodQuery = "SELECT Name, Quantity FROM Foods WHERE Type = 'food' ";
            string waterQuery = "SELECT Name, Quantity FROM Foods WHERE Type = 'Water' ";

            SqlCommand foodCommand = new SqlCommand(foodQuery, mydb.getConnection);
            SqlCommand waterCommand = new SqlCommand(waterQuery, mydb.getConnection);

            using (SqlDataReader foodReader = foodCommand.ExecuteReader())
            {
                while (foodReader.Read())
                {
                    string name = foodReader["Name"].ToString();
                    int quantity = int.Parse(foodReader["Quantity"].ToString());
                    int consumption = 100 - quantity;

                    foodNames.Add(name);
                    foodConsumption.Add(consumption);
                }
            }

            using (SqlDataReader waterReader = waterCommand.ExecuteReader())
            {
                while (waterReader.Read())
                {
                    string name = waterReader["Name"].ToString();
                    int quantity = int.Parse(waterReader["Quantity"].ToString());
                    int consumption = 100 - quantity;

                    waterNames.Add(name);
                    waterConsumption.Add(consumption);
                }
            }

            mydb.closeConnection();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            // Code phần cập nhật dữ liệu vào biểu đồ

            // Tạo danh sách màu ngẫu nhiên



            List<Color> randomColors = new List<Color>();
            Random random = new Random();

            for (int i = 0; i < foodNames.Count + waterNames.Count; i++)
            {
                int red = random.Next(256); // Giá trị màu đỏ (0-255)
                int green = random.Next(256); // Giá trị màu xanh lá cây (0-255)
                int blue = random.Next(256); // Giá trị màu xanh dương (0-255)

                Color color = Color.FromArgb(red, green, blue); // Tạo màu từ giá trị RGB ngẫu nhiên
                randomColors.Add(color);
            }

            // Cập nhật biểu đồ cho món Food (Chart1)
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Interval = 1;

            Series foodSeries = new Series("Food Consumption");
            foodSeries.ChartType = SeriesChartType.Column;

            for (int i = 0; i < foodNames.Count; i++)
            {
                foodSeries.Points.AddXY(foodNames[i], foodConsumption[i]);
                foodSeries.Points[i].Color = randomColors[i]; // Thiết lập màu ngẫu nhiên cho series món Food
            }

            chart1.Series.Add(foodSeries);



            // Cập nhật biểu đồ cho món Water (Chart2)
            chart2.Series.Clear();
            chart2.ChartAreas[0].AxisX.Interval = 1;

            Series waterSeries = new Series("Water Consumption");
            waterSeries.ChartType = SeriesChartType.Column;

            for (int i = 0; i < waterNames.Count; i++)
            {
                waterSeries.Points.AddXY(waterNames[i], waterConsumption[i]);
                waterSeries.Points[i].Color = randomColors[foodNames.Count + i]; // Thiết lập màu ngẫu nhiên cho series món Water
            }

            chart2.Series.Add(waterSeries);


        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;

            HitTestResult hitTestResult = chart.HitTest(e.X, e.Y);
            if (hitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint dataPoint = chart.Series[hitTestResult.Series.Name].Points[hitTestResult.PointIndex];
                string name = dataPoint.AxisLabel;
                int consumption = (int)(dataPoint.YValues[0]);

                if (!isTooltipShown)
                {
                    // Hiển thị thông tin
                    toolTip1.SetToolTip(chart, $"Name: {name}\nConsumption: {consumption}");
                    isTooltipShown = true;
                }
            }
            else
            {
                if (isTooltipShown)
                {
                    // Ẩn thông tin
                    toolTip1.SetToolTip(chart, "");
                    isTooltipShown = false;
                }
            }
        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;

            HitTestResult hitTestResult = chart.HitTest(e.X, e.Y);
            if (hitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint dataPoint = chart.Series[hitTestResult.Series.Name].Points[hitTestResult.PointIndex];
                string name = dataPoint.AxisLabel;
                int consumption = (int)(dataPoint.YValues[0]);

                if (!isTooltip2Shown)
                {
                    // Hiển thị thông tin
                    toolTip2.SetToolTip(chart, $"Name: {name}\nConsumption: {consumption}");
                    isTooltip2Shown = true;
                }
            }
            else
            {
                if (isTooltip2Shown)
                {
                    // Ẩn thông tin
                    toolTip2.SetToolTip(chart, "");
                    isTooltip2Shown = false;
                }
            }
        }
    }
}
