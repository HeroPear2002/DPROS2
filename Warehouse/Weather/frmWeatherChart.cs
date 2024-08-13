using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.Weather
{
    public partial class frmWeatherChart : Form
    {
        public frmWeatherChart()
        {
            InitializeComponent();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            chartControl1.Series.Clear();
            DateTime today = dtpkDate.Value.Date;
            int year = today.Year;
            int month = (today.Date.Month);
            int day = today.Date.Day;
            DateTime Date1 = today.AddDays((-day) + 1);
            DateTime Date2 = Date1.AddMonths(1);
            int dateEnd = Date2.Day;
            int dateStart = Date1.Day;
            List<WeatherDTO> listW = WeatherDAO.Instance.GetlistWeatherByDate(Date1,Date2);
            var name = listW.Select(x=>x.Location).Distinct().ToList();
            foreach (var item in name)
            {
                Series series1 = new Series(item, ViewType.Line);
                series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                ((LineSeriesView)series1.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((LineSeriesView)series1.View).LineMarkerOptions.Size = 3;
                series1.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
                series1.Label.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
                series1.Label.BackColor = Color.Transparent;
                //series1.ArgumentScaleType = ScaleType.Numerical;
                //series1.ValueScaleType = ScaleType.Numerical;
                List<WeatherDTO> listN = listW.Where(x => x.Location == item).ToList();
                foreach (WeatherDTO item1 in listW.Where(x => x.Location == item).ToList())
                {
                    DateTime h = item1.DateWeater;
                    float k = (float)Math.Round(item1.Temperature,2);
                    series1.Points.Add(new SeriesPoint(h, Math.Round(k,2)));
                }
                chartControl1.Series.AddRange(series1);
            }
            foreach (var item in name)
            {

                Series series1 = new Series(item, ViewType.Line);
                series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                ((LineSeriesView)series1.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((LineSeriesView)series1.View).LineMarkerOptions.Size = 3;
                series1.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
                series1.Label.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
                series1.Label.BackColor = Color.Transparent;
                //series1.ArgumentScaleType = ScaleType.Numerical;
                //series1.ValueScaleType = ScaleType.Numerical;
                List<WeatherDTO> listN = listW.Where(x => x.Location == item).ToList();
                foreach (WeatherDTO item1 in listW.Where(x => x.Location == item).ToList())
                {
                    DateTime h = item1.DateWeater;
                    float k = (float)Math.Round(item1.Humidity,2);
                    series1.Points.Add(new SeriesPoint(h, Math.Round(k, 2)));
                }
                chartControl2.Series.AddRange(series1);
            }

            ((XYDiagram)chartControl1.Diagram).AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
            ((XYDiagram)chartControl1.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl1.Diagram).AxisX.Label.TextPattern = "{A:dd-MM}";
            ((XYDiagram)chartControl1.Diagram).AxisX.Title.Text = "Thời Gian(Ngày)";
            ((XYDiagram)chartControl1.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl1.Diagram).AxisY.Title.Text = "Nhiệt Độ (°C)";
            ((XYDiagram)chartControl1.Diagram).AxisX.Alignment = AxisAlignment.Zero;
            ((XYDiagram)chartControl1.Diagram).AxisX.NumericScaleOptions.GridSpacing = 1;

            ((XYDiagram)chartControl2.Diagram).EnableAxisXZooming = true;
            ((XYDiagram)chartControl2.Diagram).AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
            ((XYDiagram)chartControl2.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl2.Diagram).AxisX.Label.TextPattern = "{A:dd-MM}";
            ((XYDiagram)chartControl2.Diagram).AxisX.Title.Text = "Thời Gian(Ngày)";
            ((XYDiagram)chartControl2.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl2.Diagram).AxisY.Title.Text = "Độ Ẩm (%)";
            ((XYDiagram)chartControl2.Diagram).AxisX.Alignment = AxisAlignment.Zero;
            ((XYDiagram)chartControl2.Diagram).AxisX.NumericScaleOptions.GridSpacing = 1;
            ((XYDiagram)chartControl2.Diagram).EnableAxisXZooming = true;
        }
    }
}
