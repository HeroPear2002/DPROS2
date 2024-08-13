using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace WareHouse.Statistic
{
    public partial class frmStatisticInputPart : Form
    {
        public frmStatisticInputPart()
        {
            InitializeComponent();
            LoadControl();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            LoadColum();
        }
        void LoadColum()
        {
            gridView1.Columns["CountInput"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CountInput", "Tổng = {0}");
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }
        void LoadControl()
        {
            DateTime today = DateTime.Now;
            dtpkDate1.Value = today.AddDays(-(today.Day)+1).Date;
            dtpkDate2.Value = dtpkDate1.Value.AddMonths(1).AddDays(-1);
            GCData.DataSource = IventoryPartDAO.Instance.GetListInput(dtpkDate1.Value, dtpkDate2.Value);
            btnSave.Enabled = false;
            txtLot.Enabled = false;
            btnSaveDate.Enabled = false;
            dtpkDateSX.Enabled = false;
            btnSaveFac.Enabled = false;
            cbFactoryCode.Enabled = false;
            cbFactoryCode.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtLot.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Lot"]).ToString();
            }
            catch 
            {
            }
   
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime Date1 = dtpkDate1.Value.Date;
            DateTime Date2 = dtpkDate2.Value.Date.AddHours(24);
            GCData.DataSource = IventoryPartDAO.Instance.GetListInput(Date1, Date2);
        }
        void LoadFactoryCode()
        {
            cbFactoryCode.DataSource = FactoryDAO.Instance.GetListDistinctAllFactory();
            cbFactoryCode.DisplayMember = "FactoryCode";
            cbFactoryCode.ValueMember = "FactoryCode";
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            #region Xuất Excel
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            GCData.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            GCData.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            GCData.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            GCData.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            GCData.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            GCData.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtLot.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string lot = txtLot.Text;
            if(MessageBox.Show("bạn muốn sửa số lot ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    IventoryPartDAO.Instance.UpdateLotInputPart(id, lot);
                }
                LoadControl();
            }
            
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                string Lot = view.GetRowCellValue(e.RowHandle, view.Columns["Lot"]).ToString();

                if (Lot == "")
                {
                    e.Appearance.BackColor = Color.Pink;
                    e.Appearance.ForeColor = Color.Black;
                }
            }
        }

        private void btnSaveDate_Click(object sender, EventArgs e)
        {
            DateTime date = dtpkDateSX.Value;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            if (MessageBox.Show("bạn muốn sửa số lot ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    IventoryPartDAO.Instance.UpdateDateInputPart(id, date);
                }
                LoadControl();
            }

        }

        private void btnDateTime_Click(object sender, EventArgs e)
        {
            btnSaveDate.Enabled = true;
            dtpkDateSX.Enabled = true;
        }

        private void btnEditFact_Click(object sender, EventArgs e)
        {
            LoadFactoryCode();
            cbFactoryCode.Enabled = true;
            btnSaveFac.Enabled = true;
        }

        private void btnSaveFac_Click(object sender, EventArgs e)
        {
            string factoryCode = cbFactoryCode.Text;
            if (MessageBox.Show("bạn muốn sửa số lot ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    IventoryPartDAO.Instance.UpdateFactoryInputPart(id, factoryCode);
                }
                LoadControl();
            }
        }
    }
}
