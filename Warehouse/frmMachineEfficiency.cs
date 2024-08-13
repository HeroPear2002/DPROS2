using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.PC;

namespace WareHouse
{
    public partial class frmMachineEfficiency : Form
    {
        public frmMachineEfficiency()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {

        }
        private void btnMonth_Click(object sender, EventArgs e)
        {
            LoadChartMonth();
            MessageBox.Show("OK");
        }

        private void btnYear_Click(object sender, EventArgs e)
        {

            LoadChartYear();
            MessageBox.Show("OK");
        }
        void LoadChartMonth()
        {
            chartControl1.Series.Clear();
            DateTime today = dtpkToday.Value.Date;
            int year = today.Year;
            int month = (today.Date.Month);
            int day = today.Date.Day;
            DateTime Date1 = today.AddDays((-day) + 1);
            DateTime Date2 = Date1.AddMonths(1).AddDays(-1).AddSeconds(86390);
            int dateEnd = Date2.Day;
            int dateStart = Date1.Day;
            List<MachineDTO> listM = MachineDAO.Instance.GetListMachine();
            List<MachineEfficChart> listMachine = new List<MachineEfficChart>();
            foreach (MachineDTO item in listM)
            {
                float nod = 0;
                float TTLK = 0;
                for (int i = dateStart; i <= dateEnd; i++)
                {
                    string ngayI = i + "/" + month + "/" + year;
                    DateTime datei1 = DateTime.Parse(ngayI).Date;
                    DateTime datei2 = datei1.AddMinutes(1439);
                    List<InputPartDTO> listN = IventoryPartDAO.Instance.GetListInputByMachine(datei1, datei2, item.MachineCode);
                    float TT = 0;
                    float test = 0;
                    foreach (InputPartDTO item1 in listN)
                    {
                        string PartCode = item1.PartCode;
                        int Cav = PartDAO.Instance.CavityByCode(PartCode);
                        if (Cav != 0)
                        {
                            int CountN = item1.CountInput;
                            float countTime = PartDAO.Instance.CycleTimeByCode(PartCode);
                            DateTime dateItem = (DateTime)item1.DateManufacturi;
                            float TimeSX = ((CountN / Cav) * countTime);
                            TT = TT + TimeSX;
                            test = test + TimeSX;
                        }
                    }
                    TTLK = TT + nod;
                    nod = TTLK;
                    double percent = Math.Round(((TTLK) / (86400 * i)) * 100, 2);

                    //if (percent > 110)
                    //{
                    //    percent = 110;
                    //}
                    listMachine.Add(new MachineEfficChart(item.MachineCode, i, percent, month));
                }
            }
            foreach (MachineDTO item in listM)
            {
                /////
                Series series1 = new Series(item.MachineCode, ViewType.Line);
                series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                ((LineSeriesView)series1.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((LineSeriesView)series1.View).LineMarkerOptions.Size = 3;
                series1.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                series1.Label.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
                series1.Label.BackColor = Color.Transparent;
                series1.ArgumentScaleType = ScaleType.Numerical;
                series1.ValueScaleType = ScaleType.Numerical;
                series1.NumericSummaryOptions.MeasureUnit = 1;
                foreach (MachineEfficChart item1 in listMachine.Where(x => x.MachineCode == item.MachineCode).ToList())
                {
                    series1.Points.Add(new SeriesPoint(item1.Ngay, item1.Percent));
                }
                chartControl1.Series.Add(series1);
            }
            ((XYDiagram)chartControl1.Diagram).AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
            ((XYDiagram)chartControl1.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl1.Diagram).AxisX.Title.Text = "Thời Gian(Ngày)";
            ((XYDiagram)chartControl1.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl1.Diagram).AxisY.Title.Text = "Phần Trăm (%)";
            ((XYDiagram)chartControl1.Diagram).AxisX.Alignment = AxisAlignment.Zero;
            ((XYDiagram)chartControl1.Diagram).AxisX.NumericScaleOptions.GridSpacing = 1;
            ((XYDiagram)chartControl1.Diagram).EnableAxisXZooming = true;
            ((XYDiagram)chartControl1.Diagram).AxisX.VisualRange.MinValue = 2;
            ((XYDiagram)chartControl1.Diagram).AxisX.VisualRange.MaxValue = 30;
            ((XYDiagram)chartControl1.Diagram).AxisX.WholeRange.MinValue = 2;
            ((XYDiagram)chartControl1.Diagram).AxisX.WholeRange.MaxValue = 30;
        }
        void LoadChartYear()
        {
            chartControl1.Series.Clear();
            DateTime today = DateTime.Now;
            int year = today.Year;
            int month = (today.Date.Month);
            int day = today.Date.Day;
            DateTime Date1 = today.AddDays((-day) + 1).AddMonths(-(today.Month) + 1);
            DateTime Date2 = Date1.AddYears(1).AddMonths(-1).AddSeconds(86390);
            List<MachineDTO> listM = MachineDAO.Instance.GetListMachine();
            List<MachineEfficChart> listMachine = new List<MachineEfficChart>();
            foreach (MachineDTO item in listM)
            {

                for (int j = 1; j <= 12; j++)
                {
                    float test = 0;
                    int dateStart = 1;
                    int dateEnd = 1;
                    if (j == 1 || j == 3 || j == 5 || j == 7 || j == 8 || j == 10 || j == 12)
                    {
                        dateEnd = 31;
                    }
                    if (j == 4 || j == 6 || j == 9 || j == 11)
                    {
                        dateEnd = 30;
                    }
                    if (j == 2)
                    {
                        if ((year % 4) == 0)
                        {
                            dateEnd = 29;
                        }
                        dateEnd = 28;
                    }
                    string ngayI = dateStart + "/" + j + "/" + year;
                    DateTime datei1 = DateTime.Parse(ngayI).Date;
                    DateTime datei2 = datei1.AddDays(dateEnd).AddMinutes(1439);
                    List<InputPartDTO> listN = IventoryPartDAO.Instance.GetListInputByMachine(datei1, datei2, item.MachineCode);
                    float TT = 0;
                    if (listN.Count == 0)
                    {

                    }
                    else
                    {
                        foreach (InputPartDTO item1 in listN)
                        {
                            string PartCode = item1.PartCode;
                            int Cav = PartDAO.Instance.CavityByCode(PartCode);
                            if (Cav != 0)
                            {
                                int CountN = item1.CountInput;
                                float countTime = PartDAO.Instance.CycleTimeByCode(PartCode);
                                DateTime dateItem = (DateTime)item1.DateManufacturi;
                                float TimeSX = ((CountN / Cav) * countTime);
                                TT = TT + TimeSX;
                                test = (test + TimeSX);
                            }
                        }
                    }
                    double percent = Math.Round(((test / dateEnd) / (86400)) * 100, 2);
                    listMachine.Add(new MachineEfficChart(item.MachineCode, j, percent, j));
                }
            }

            foreach (MachineDTO item in listM)
            {

                Series series1 = new Series(item.MachineCode, ViewType.Line);
                series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                ((LineSeriesView)series1.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((LineSeriesView)series1.View).LineMarkerOptions.Size = 3;
                series1.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                series1.Label.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
                series1.Label.BackColor = Color.Transparent;
                foreach (MachineEfficChart item1 in listMachine.Where(x => x.MachineCode == item.MachineCode).ToList())
                {
                    series1.Points.Add(new SeriesPoint(item1.Thang, Math.Round((item1.Percent), 2)));
                }
                chartControl1.Series.Add(series1);
            }

            ((XYDiagram)chartControl1.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl1.Diagram).AxisX.Title.Text = "Thời Gian(Tháng)";
            ((XYDiagram)chartControl1.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartControl1.Diagram).AxisY.Title.Text = "Phần Trăm (%)";
            ((XYDiagram)chartControl1.Diagram).AxisX.Alignment = AxisAlignment.Zero;
            ((XYDiagram)chartControl1.Diagram).EnableAxisXZooming = true;
        }
    }
}
