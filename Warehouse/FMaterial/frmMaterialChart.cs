using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAO;
using DTO;
using DevExpress.XtraCharts;

namespace WareHouse.FMaterial
{
    public partial class frmMaterialChart : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialChart()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadDate();
            LoadMaterialCode();
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkFrom.Value = today.AddDays(1 - today.Day).AddMonths(1-today.Month);
            dtpkTo.Value = dtpkFrom.Value.AddYears(1).AddSeconds(-10);
        }
        void LoadMaterialCode()
        {
            glMaterialCode.Properties.DataSource = MaterialDAO.Instance.GetListMaterial();
            glMaterialCode.Properties.ValueMember = "MaterialCode";
            glMaterialCode.Properties.DisplayMember = "MaterialCode";
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
            string MaterialCode = glMaterialCode.EditValue.ToString();
            ccUSD.Series.Clear();
            ccVND.Series.Clear();
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;
            List<MaterialPriceDTO> listMP = new List<MaterialPriceDTO>();
            ChartControl chartSaleHistory = new ChartControl();
            chartSaleHistory = ccVND;
            Series saleSeries = new Series("Giá VNĐ", ViewType.Line);
            ((LineSeriesView)saleSeries.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((LineSeriesView)saleSeries.View).LineMarkerOptions.Size = 3;
            ((LineSeriesView)saleSeries.View).Color = Color.DarkGreen;
            ChartControl chartSaleHistory1 = new ChartControl();
            chartSaleHistory1 = ccUSD;
            Series saleSeries1 = new Series("Giá USD", ViewType.Line);
            ((LineSeriesView)saleSeries1.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((LineSeriesView)saleSeries1.View).LineMarkerOptions.Size = 3;
            ((LineSeriesView)saleSeries1.View).Color = Color.Blue;
            listMP = MaterialDAO.Instance.GetListAllMaterPrice().Where(x => x.DateInput >= date1 && x.DateInput <= date2 && x.MaterialCode == MaterialCode).ToList();
            foreach (MaterialPriceDTO item in listMP.OrderBy(x=>x.DateInput))
            {
                saleSeries.Points.Add(new SeriesPoint(item.DateInput, item.PriceVND));
                saleSeries1.Points.Add(new SeriesPoint(item.DateInput, item.PriceUSD));
            }
            chartSaleHistory.Series.Add(saleSeries);
            ((XYDiagram) chartSaleHistory.Diagram).AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
            ((XYDiagram) chartSaleHistory.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram) chartSaleHistory.Diagram).AxisX.Title.Text = "Thời Gian(tháng)";
                ((XYDiagram)chartSaleHistory.Diagram).AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Manual;
                ((XYDiagram)chartSaleHistory.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                ((XYDiagram)chartSaleHistory.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
                ((XYDiagram)chartSaleHistory.Diagram).AxisX.DateTimeScaleOptions.AutoGrid = false;
                ((XYDiagram)chartSaleHistory.Diagram).AxisX.DateTimeScaleOptions.GridSpacing = 0.5;
                ((XYDiagram)chartSaleHistory.Diagram).AxisX.Label.TextPattern = "{A:dd/MM}";
                ((XYDiagram) chartSaleHistory.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                ((XYDiagram) chartSaleHistory.Diagram).AxisY.Title.Text = "Giá VNĐ";
            ((XYDiagram) chartSaleHistory.Diagram).AxisX.Alignment = AxisAlignment.Zero;
            ((XYDiagram) chartSaleHistory.Diagram).EnableAxisXZooming = true;

            chartSaleHistory1.Series.Add(saleSeries1);
            ((XYDiagram)chartSaleHistory1.Diagram).AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
            ((XYDiagram)chartSaleHistory1.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartSaleHistory1.Diagram).AxisX.Title.Text = "Thời Gian(tháng)";
                ((XYDiagram)chartSaleHistory1.Diagram).AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Manual;
                ((XYDiagram)chartSaleHistory1.Diagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                ((XYDiagram)chartSaleHistory1.Diagram).AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
                ((XYDiagram)chartSaleHistory1.Diagram).AxisX.DateTimeScaleOptions.AutoGrid = false;
                ((XYDiagram)chartSaleHistory1.Diagram).AxisX.DateTimeScaleOptions.GridSpacing = 0.5;
                ((XYDiagram)chartSaleHistory1.Diagram).AxisX.Label.TextPattern = "{A:dd/MM}";
                ((XYDiagram)chartSaleHistory1.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartSaleHistory1.Diagram).AxisY.Title.Text = "Giá USD";
            ((XYDiagram)chartSaleHistory1.Diagram).AxisX.Alignment = AxisAlignment.Zero;
            ((XYDiagram)chartSaleHistory1.Diagram).AxisX.NumericScaleOptions.GridSpacing = 15;
            ((XYDiagram)chartSaleHistory1.Diagram).EnableAxisXZooming = true;
            }
            catch
            {
                MessageBox.Show("bạn chưa chọn nguyên liệu cần xem".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}