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
using System.Data.SqlClient;
using DAO;
using WareHouse.Report;
using DTO;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Text.RegularExpressions;

namespace WareHouse.Employess
{
    public partial class frmEmployessCard : DevExpress.XtraEditors.XtraForm
    {
        public frmEmployessCard()
        {
            InitializeComponent();
            LoadControl();
        }
        string targetPath = @"\\192.168.2.10\DATASAVE\IMAGEEM";
        bool IsInsert = false;
        #region Control
        void ReadData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtLink.Text = ofd.FileName;
                }
            }
        }
        void LoadControl()
        {
            LockControl();
            LoadEmployessCode();
            LoadPosition();
            LoadData();
        }
        void LoadData()
        {
            GCData.DataSource = EmployessDAO.Instance.GetListEmployessCard();
        }
        void LockControl()
        {
            cbEmployess.Enabled = false;
            cbPosition.Enabled = false;

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            cbEmployess.Enabled = true;
            cbPosition.Enabled = true;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            cbEmployess.Text = String.Empty;
            cbPosition.Text = String.Empty;
            txtLink.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbEmployess.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["EmployessCode"]).ToString();
                cbPosition.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PositionName"]).ToString();
                txtLink.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["LinkImage"]).ToString();
            }
            catch
            {

            }
        }
        void LoadEmployessCode()
        {
            cbEmployess.DataSource = EmployessDAO.Instance.GetlistAllEmployess();
            cbEmployess.DisplayMember = "EmployessCode";
            cbEmployess.ValueMember = "EmployessCode";
        }
        void LoadPosition()
        {
            cbPosition.DataSource = EmployessDAO.Instance.GetListPosition();
            cbPosition.DisplayMember = "PositionName";
            cbPosition.ValueMember = "PositionName";
        }
        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearText();
            OpenControl();
            IsInsert = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn xóa thông tin này?".ToString(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string EmployessCode = gridView1.GetRowCellValue(item, "EmployessCode").ToString();
                    EmployessDAO.Instance.DeleteEmployessCard(EmployessCode);
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            IsInsert = false;
            cbEmployess.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = cbEmployess.Text;
            string name = cbPosition.Text;
            if (EmployessDAO.Instance.TestEmployessByCode(code) == -1)
            {
                MessageBox.Show("mã nhân viên không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (EmployessDAO.Instance.TestPosition(name) == -1)
            {
                MessageBox.Show("Tên chức vụ không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            char[] charArray = name.ToLower().ToCharArray();
            bool testSpace = true;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (Char.IsLetter(charArray[i]))
                {
                    if (testSpace)
                    {
                        charArray[i] = Char.ToUpper(charArray[i]);
                        testSpace = false;
                    }
                }
                else
                {
                    testSpace = true;
                }
            }
            name = new string(charArray);
            string linkSource = txtLink.Text;
            string fileName = Path.GetFileName(linkSource);
            // Use Path class to manipulate file and directory paths.
            string sourceFile = linkSource;
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if (linkSource.Length > 0)
            {
                try
                {
                    System.IO.File.Copy(sourceFile, destFile, true);
                }
                catch
                {
         
                }
            }
            else
            {
                MessageBox.Show("File không tồn tại".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string link = fileName;
            if (IsInsert == true)
            {
                try
                {
                    EmployessDAO.Instance.InsertEmployessCard(code.ToUpper(), name, link);
                    MessageBox.Show("thêm thông tin thành công !".ToUpper());
                    LoadControl();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("mã đã tồn tại".ToUpper());
                    }
                }
            }
            else
            {
                EmployessDAO.Instance.UpdateEmployessCard(code, name, link);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ReadData();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<EmployessCard> listE = new List<EmployessCard>();
            Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
            if (MessageBox.Show("bạn muốn in những thông tin này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string code = gridView1.GetRowCellValue(item, "EmployessCode").ToString();
                    string name = gridView1.GetRowCellValue(item, "EmployessName").ToString();
                    name = trimmer.Replace(name, " ");
                    char[] charArray = name.ToLower().ToCharArray();
                    bool testSpace = true;
                    for (int i = 0; i < charArray.Length; i++)
                    {
                        if (Char.IsLetter(charArray[i]))
                        {
                            if (testSpace)
                            {
                                charArray[i] = Char.ToUpper(charArray[i]);
                                testSpace = false;
                            }
                        }
                        else if (charArray[i].ToString() == " ")
                        {
                            testSpace = true;
                        }
                    }
                    name = new string(charArray);
                    string positionName = gridView1.GetRowCellValue(item, "PositionName").ToString();
                    string link = gridView1.GetRowCellValue(item, "LinkImage").ToString();
                    string urlName = System.IO.Path.Combine(targetPath, link);
                    listE.Add(new EmployessCard(code.ToUpper(), name, positionName, urlName));
                }
            }
            rpEmployessCard report = new rpEmployessCard();
            report.DataSource = listE;
            report.PrintDialog();
            LoadControl();
        }
        #endregion
    }
}