using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DAO;
using DTO;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using WareHouse.PO_and_Order;
using DevExpress.XtraGrid.Views.Grid;

namespace WareHouse.Product
{
    public partial class frmOutputDetail : DevExpress.XtraEditors.XtraForm
    {

        public frmOutputDetail()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LoadAcc();
            LockControl();
            LoadData();
            LoadProduct();
        }
        void LoadAcc()
        {
            if (Kun_Static.accountDTO.Type == 1 || Kun_Static.accountDTO.Type == 2)
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }
        void LoadData()
        {
            GCData.DataSource = ProductDAO.Instance.ListOutputDetail();
        }
        void LockControl()
        {
            cbCode.Enabled = false;
            txtCount.Enabled = false;
            txtDetail.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            cbCode.Enabled = true;
            txtCount.Enabled = true;
            txtDetail.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void CleanText()
        {
            cbCode.Text = String.Empty;
            txtCount.Text = String.Empty;
            txtDetail.Text = String.Empty;
            txtID.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ProductCode"]).ToString();
                txtCount.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CountOut"]).ToString();
                txtDetail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail"]).ToString();
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch
            {
            }
        }
        void LoadProduct()
        {
            cbCode.Properties.DataSource = ProductDAO.Instance.ListProduct();
            cbCode.Properties.DisplayMember = "Code";
            cbCode.Properties.ValueMember = "Code";
        }
        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsInsert = true;
            CleanText();
            OpenControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsInsert = false;
            OpenControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    ProductDAO.Instance.DeleteOutputDetail(id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long Id = 1;
            float count = (float)Convert.ToDouble(txtCount.Text);
            try
            {
                Id = long.Parse(txtID.Text);
            }
            catch
            {
                Id = 1;
            }
            OutputWarnProduct ou = new OutputWarnProduct(Id, cbCode.Text, DateTime.Now, Kun_Static.accountDTO.UserName, count, txtDetail.Text, "");
            if (IsInsert == true)
            {
                ProductDAO.Instance.InsertOutputDetail(ou);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                ProductDAO.Instance.UpdateOutputDetail(ou);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();

            }
            SenMail(txtDetail.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            frmInportOutputDetail f= new frmInportOutputDetail();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnDownload_Click(object sender, EventArgs e)
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

        private void btnForm_Click(object sender, EventArgs e)
        {
            frmFormOutputDetail f = new frmFormOutputDetail();
            f.ShowDialog();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        private void btnOutput_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string code = cbCode.Text;
            float countOut = (float)Math.Round(Convert.ToDouble(txtCount.Text), 2);
            float totalIventory = ProductDAO.Instance.TotalIventory(code);
            long id = long.Parse(txtID.Text);
            string note = ProductDAO.Instance.NoteOutputDetail(id);
            if (note.Length < 0)
            {
                MessageBox.Show("phiếu hàng chưa được phê duyệt".ToUpper());
                return;
            }
            if (note == "Đã xuất kho")
            {
                MessageBox.Show("phiếu hàng này đã xuất".ToUpper());
                return;
            }
            if (countOut > 0)
            {
                if (countOut <= totalIventory)
                {
                    List<ProductIventoryDTO> listP = ProductDAO.Instance.ListIventoryProduct();
                    ProductDAO.Instance.UpdateOutputDetailNote(id, "Đã xuất kho");
                    foreach (ProductIventoryDTO item in listP.Where(x => x.ProductCode == code).OrderBy(y => y.DateInput))
                    {
                        float iventory = item.Iventory;
                        float b = countOut - iventory;
                        if (b <= 0)
                        {
                            ProductDAO.Instance.InsertOutputPro(item.Id, today, Kun_Static.accountDTO.UserName, countOut, "", "");
                            MessageBox.Show("Xuất kho thành công !".ToUpper());
                            countOut = 0;
                            CleanText();
                            LoadControl();
                            return;
                        }
                        else
                        {
                            ProductDAO.Instance.InsertOutputPro(item.Id, today, Kun_Static.accountDTO.UserName, iventory, "", "");
                            ProductDAO.Instance.UpdateStatusInput(item.Id, 1);
                            countOut = b;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("hàng trong kho không đủ !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("bạn chưa điền số lượng xuất !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn muốn phế duyệt phiếu này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                    string note = ProductDAO.Instance.NoteOutputDetail(id);
                    if (note == "Đã xuất kho")
                    {
                        MessageBox.Show("phiếu hàng này đã xuất".ToUpper());
                    }
                    else
                    {
                        ProductDAO.Instance.UpdateOutputDetailNote(id, "Đã phê duyệt");
                    }        
                }
                LoadControl();
            }
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {

                string note = (view.GetRowCellValue(e.RowHandle, view.Columns["Note"]).ToString());
                switch (note)
                {
                    case "Đã phê duyệt":
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.White;
                        break;
                    case "":
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    default:
                        break;
                }
            }
        }
        #region gửi mail
        void SenMail(string message)
        {

            string mailAll = "anh.dangh@dongduongpla.com.vn;thu.ngot@dongduongpla.com.vn,ha.chuv@dongduongpla.com.vn";
            string[] arr = mailAll.Split(';');
            List<string> listEmail = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                listEmail.Add(arr[i]);
            }
            string from = "system.dongduongpla@gmail.com";
            foreach (var item in listEmail)
            {
                string to = item;
                string subject = "linh kiện dự bị".ToUpper();
                MailMessage mess = new MailMessage(from, to, subject, message);
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("system.dongduongpla@gmail.com", "P@ssword090992");
                client.Send(mess);
            }

        }

        #endregion
    }

}
