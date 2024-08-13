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
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.CustomEditor;
using DevExpress.XtraGrid.Views.Grid;
using DAO;
using DTO;

namespace WareHouse.DataMachine
{
    public partial class frmDataCheck : DevExpress.XtraEditors.XtraForm
    {
        public frmDataCheck()
        {
            InitializeComponent();
            LoadControl();
        }
        #region Control
        void LoadControl()
        {
            LoadMold();
        }
        void LoadMold()
        {
            cbMoldCode.DataSource = DataMachineDAO.Instance.GetListMoldBySetup();
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "MoldCode";
        }
        void LoadMachine()
        {
            string moldcode = cbMoldCode.Text;
            cbMachineCode.DataSource = DataMachineDAO.Instance.GetListMachineBySetup(moldcode);
            cbMachineCode.DisplayMember = "MachineCode";
            cbMachineCode.ValueMember = "MachineCode";
        }
        void LoadData()
        {
            string mold = cbMoldCode.Text;
            string machine = cbMachineCode.Text;
            List<CategoryDataMachineDTO> listC = DataMachineDAO.Instance.GetListCategoryBySetup(mold, machine);
            List<DataMachineCheckDTO> listD = new List<DataMachineCheckDTO>();
            foreach (CategoryDataMachineDTO item in listC)
            {
                long idSetup = DataMachineDAO.Instance.IdSetupdefault(item.Id, mold, machine);
                float valueDefault = DataMachineDAO.Instance.ValuSetupDefault(idSetup);
                listD.Add(new DataMachineCheckDTO(item.Id, item.Name, valueDefault, item.UpperLimit + valueDefault, valueDefault - item.LowerLimit, item.Value));
            }
            GcDataCheck.DataSource = listD;
        }

        #endregion
        #region Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime date = dtpkDateCheck.Value;
            string mold = cbMoldCode.Text;
            string machine = cbMachineCode.Text;
            int k = 0;
            if (gridView2.GetSelectedRows().Count() == 0)
            {
                string mgs = string.Format("bạn chưa chọn hạng mục nào".ToUpper());
                MessageBox.Show(mgs, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var item in gridView2.GetSelectedRows())
            {
                string a = gridView2.GetRowCellValue(item, "ValueCheck").ToString();
                if (a == "DD")
                {
                    k = 1;
                    string mgs = string.Format("bạn chưa điền giá trị cho hạng mục".ToUpper());
                    MessageBox.Show(mgs, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (k == 1)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("bạn muốn lưu thông tin đã check".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    foreach (var item in gridView2.GetSelectedRows())
                    {
                        float value = (float)Convert.ToDouble(gridView2.GetRowCellValue(item, "ValueCheck").ToString());
                        int idCate = int.Parse(gridView2.GetRowCellValue(item, gridView2.Columns["Id"]).ToString());
                        long idSetup = DataMachineDAO.Instance.IdSetupdefault(idCate, mold, machine);
                        float valueUp = (float)Convert.ToDouble(gridView2.GetRowCellValue(item, "ValueUp").ToString());
                        float valueDown = (float)Convert.ToDouble(gridView2.GetRowCellValue(item, "ValueDown").ToString());
                        string name = gridView2.GetRowCellValue(item, gridView2.Columns["NameCategory"]).ToString();
                        string note = "";
                        if ((value < valueDown) || (value > valueUp))
                        {
                            string Msg = string.Format("giá trị hạng mục {0} bị NG \nbạn chọn Yes để máy chạy tiếp và theo dõi, chọn No để Dừng máy", name);
                            if (MessageBox.Show(Msg.ToUpper(), "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                note = "NG Chạy tiếp để theo dõi";
                                DataMachineDAO.Instance.InsertDataCheck(idSetup, date, value, note, Kun_Static.accountDTO.UserName);
                            }
                            else
                            {
                                note = "NG Dừng máy";
                                DataMachineDAO.Instance.InsertDataCheck(idSetup, date, value, note, Kun_Static.accountDTO.UserName);
                            }
                        }
                        else
                        {
                            note = "";
                            DataMachineDAO.Instance.InsertDataCheck(idSetup, date, value, note, Kun_Static.accountDTO.UserName);
                        }
                    }
                    LoadControl();
                }
            }

        }
        private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMachine();
        }
        private void cbMachineCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {

            }
        }
        private void dtpkDateCheck_ValueChanged(object sender, EventArgs e)
        {
            LoadControl();
        }
        void LoadChart(string name)
        {
            //DateTime today = dtpkDateCheck.Value;
            //ChartControl chartSaleHistory = new ChartControl();
            //Series saleSeries = new Series(name, ViewType.Line);
            //((LineSeriesView)saleSeries.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            //((LineSeriesView)saleSeries.View).LineMarkerOptions.Size = 3;
            //((LineSeriesView)saleSeries.View).Color = Color.DarkGreen;
            ////saleSeries.ArgumentDataMember = "DetailData.ReportDate";
            ////saleSeries.ValueDataMembers.AddRange("DetailData.Sales");
            //List<DataCheckDTO> listC = DataMachineDAO.Instance.GetListALLDataCheck();
            //foreach (DataCheckDTO item in listC.Where(x => x.Name == name && x.DateCheck >= today.Date && x.DateCheck <= today.Date.AddDays(1).AddMinutes(-10)).ToList())
            //{
            //    saleSeries.Points.Add(new SeriesPoint(item.DateCheck, Math.Round(item.ValueReal, 2)));
            //}

            //chartSaleHistory.Series.Add(saleSeries);
            //RepositoryItemAnyControl chartRepositoryItem =
            //   new RepositoryItemAnyControl();
            //chartRepositoryItem.Control = chartSaleHistory;
            //GCData.RepositoryItems.Add(chartRepositoryItem);
            //colSalesHistory.ColumnEdit = chartRepositoryItem;

            //XYDiagram diag = (XYDiagram)chartSaleHistory.Diagram;
            //diag.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Manual;
            //diag.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Hour;
            //diag.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Hour;
            //diag.AxisX.DateTimeScaleOptions.AutoGrid = false;
            //diag.AxisX.DateTimeScaleOptions.GridSpacing = 1;
            //diag.AxisX.Label.TextPattern = "{Vi:dd/MM HH:mm}";
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

        }
    }
}