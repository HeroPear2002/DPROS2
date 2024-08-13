using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.DataMachine
{
    public partial class frmDataMachine : Form
    {
        public frmDataMachine()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsinSert = false;
        #region Control
        void LoadControl()
        {
            LoadDate();
            LoadMold();
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkDate.Value = today.AddDays(-(today.Day - 1));
            dtpkDate2.Value = dtpkDate.Value.AddMonths(1).AddMinutes(-5);
        }
        void LoadData()
        {
            string mold = cbMoldCode.Text;
            string machine = cbMachine.Text;
            List<DataCheckDTO> listC = DataMachineDAO.Instance.GetListALLDataCheck().Where(x=>x.MoldCode == mold && x.MachineCode == machine && x.DateCheck>=dtpkDate.Value).ToList();
            GCData.DataSource = listC;
        }
       
        void XoaText()
        {
            cbMachine.Text = String.Empty;
            cbMoldCode.Text = String.Empty;
            dtpkDate.Text = String.Empty;
  
        }
        void LoadMold()
        {
            cbMoldCode.DataSource = DataMachineDAO.Instance.GetListMoldBySetup();
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "MoldCode";
            LoadMachine();
        }
        void LoadMachine()
        {
            string moldCode = cbMoldCode.Text;
            cbMachine.DataSource = DataMachineDAO.Instance.GetListMachineBySetup(moldCode);
            cbMachine.DisplayMember = "MachineCode";
            cbMachine.ValueMember = "MachineCode";
        }
        void AddText()
        {
            try
            {
                cbMachine.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["MachineCode"]).ToString();
                cbMoldCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldCode"]).ToString();
                dtpkDate.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString();
            }
            catch
            {
            }
        }
        #endregion
        #region Event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    DataMachineDAO.Instance.DeleteDataCheck(id);
                }
                LoadControl();
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsinSert = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn sửa thông tin này?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    float value = (float)Convert.ToDouble(gridView1.GetRowCellValue(item, "ValueReal").ToString());
                    string note= gridView1.GetRowCellValue(item,"Note").ToString();
                    DataMachineDAO.Instance.UpdateHisDataCheck(id, value, note);
                }
            }
        }
        #endregion
        private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMachine();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void cbMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
            btnSave.Enabled = true;
        }

        private void cbMoldCode_TextChanged(object sender, EventArgs e)
        {
            //AddChart();
        }

        private void btnExport_Click(object sender, EventArgs e)
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

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
            btnSave.Enabled = false;
        }
    }
}
