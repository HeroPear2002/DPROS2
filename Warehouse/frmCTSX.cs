using DevExpress.XtraReports.UI;
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
using WareHouse.Report;
using DevExpress.XtraGrid.Views.Grid;
using System.Net.Mail;
using System.Net;
using WareHouse.Common;

namespace WareHouse
{
    public partial class frmCTSX : Form
    {
        public frmCTSX()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;
        long _id = 0;
        #region Control()
        void LoadControl()
        {
            LoadDate();
            LoadFactory();
            LoadData();
            KhoaDK();
            LoadPartCode();
            LoadMailPCAsync();
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now;
            string thu = today.DayOfWeek.ToString();
            if (thu == "Saturday")
            {
                dtpkDateto.Value = today.AddDays(2);
            }
            else
            {
                dtpkDateto.Value = today.AddDays(1);
            }
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            GCData.DataSource = CTSXDAO.Instance.GetDataCTSX();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        async void LoadMailPCAsync()
        {
            if (Kun_Static.accountDTO.Type != 1)
            {
                await SendMail();
            }
        }
        void LoadData()
        {
            DateTime today = dtpkDateto.Value.Date;
            DateTime date1 = today.AddDays(1 - today.Day);
            DateTime date2 = date1.AddMonths(1).AddSeconds(-2);
            List<ProductDirectives> listD = new List<ProductDirectives>();
            listD = CTSXDAO.Instance.GetDataCTSX().Where(x => x.DateInput >= date1 && x.DateInput <= date2).ToList();
            GCData.DataSource = listD;
        }
        #region gửi mail
        public static async Task SendMail()
        {
            await Task.Run(() =>
            {
                List<string> listMail = new List<string>();
                List<ProductDirectives> listP = CTSXDAO.Instance.GetDataCTSX().Where(x=>x.Status == 1).ToList();
                string message = "";
                if (listP.Count > 0)
                {
                    foreach (ProductDirectives item in listP)
                    {
                        message += item.Id + " ;";
                    }
                    List<AccountDTO> listEmail = AccountDAO.Instance.GetAccountEmail(2);
                    if ( listEmail.Count > 0)
                    {
                        string to = "";
                        foreach (AccountDTO item in listEmail)
                        {
                            to += item.EMail + " ";
                        }
                        string subject = "Chỉ thị sản xuất quá 10%";
                        SendEMail.SendGMail(to, subject, message);
                    }
                }
              
            });
        }
        #endregion
        void KhoaDK()
        {
            cbPartCode.Enabled = false;
            cbMachineCode.Enabled = false;
            cbMoldCode.Enabled = false;
            nudQuantity.Enabled = false;
            dtpkDateto.Enabled = true;
            txtNoteSX.Enabled = false;
            txtNoteNL.Enabled = false;
            cbFactory.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            cbPartCode.Enabled = true;
            cbMachineCode.Enabled = true;
            cbMoldCode.Enabled = true;
            nudQuantity.Enabled = true;
            dtpkDateto.Enabled = true;
            txtNoteSX.Enabled = true;
            txtNoteNL.Enabled = true;
            cbFactory.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void XoaText()
        {
            cbPartCode.Text = String.Empty;
            cbMachineCode.Text = String.Empty;
            cbMoldCode.Text = String.Empty;
            nudQuantity.Text = String.Empty;
            txtNoteSX.Text = String.Empty;
            txtNoteNL.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                _id = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                cbPartCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
                cbMachineCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineCode"]).ToString();
                cbMoldCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldCode"]).ToString();
                nudQuantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Quantity"]).ToString();
                dtpkDateto.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString();
                txtNoteSX.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NoteSX"]).ToString();
                txtNoteNL.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NoteNL"]).ToString();
                cbFactory.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FactoryCode"]).ToString();
            }
            catch
            {
            }
        }
        void LoadPartCode()
        {
            cbPartCode.DataSource = CTSXDAO.Instance.PartCodeCTSX();
            cbPartCode.DisplayMember = "PartCode";
            cbPartCode.ValueMember = "PartCode";
        }
        void LoadMoldCode()
        {
            string PartCode = cbPartCode.Text;
            cbMoldCode.DataSource = CTSXDAO.Instance.MoldCodeCTSX(PartCode);
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "MoldCode";
        }
        void LoadMachineCode()
        {
            string PartCode = cbPartCode.Text;
            string MoldCode = cbMoldCode.Text;
            cbMachineCode.Properties.DataSource = CTSXDAO.Instance.MachineCodeCTSX(PartCode, MoldCode);
            cbMachineCode.Properties.DisplayMember = "MachineCode";
            cbMachineCode.Properties.ValueMember = "MachineCode";
        }
        void LoadFactory()
        {
            string PartCode = cbPartCode.Text;
            string MoldCode = cbMoldCode.Text;
            string MachineCode = cbMachineCode.Text;
            cbFactory.DataSource = MacInforDAO.Instance.GetListFactoryCodeByAll(PartCode, MoldCode, MachineCode);
            cbFactory.DisplayMember = "FactoryCode";
            cbFactory.ValueMember = "FactoryCode";
        }
        #endregion
        #region Event
        private void cbPartCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMoldCode();
        }

        private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMachineCode();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            XoaText();
            IsInsert = true;
            MoKhoaDK();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsInsert = false;
            MoKhoaDK();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    CTSXDAO.Instance.DeleteCTSX(id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string PartCode = cbPartCode.Text;
            string Machine = cbMachineCode.Text;
            string Mold = cbMoldCode.Text;
            string NoteSx = txtNoteSX.Text;
            string NoteNl = txtNoteNL.Text;
            string facCode = cbFactory.Text;
            int quantity = (int)nudQuantity.Value;
            int confirm = MoldDAO.Instance.ConfirmMold(Mold);
            float shotTT = MoldDAO.Instance.ShoTTByCode(Mold);
            float shotTC = MoldDAO.Instance.ShoTTCByCode(Mold);
            int shot = quantity / PartDAO.Instance.CavityByCode(PartCode);
            float test = (float)(shotTT + shot) / shotTC;
            string MaterialCode = PartDAO.Instance.MaterialCodeByCode(PartCode);
            DateTime date = dtpkDateto.Value;
          
            DateTime dt = DateTime.Parse(date.ToString());
            string StylePart = PartDAO.Instance.StylePart(PartCode);
            int testM = MacInforDAO.Instance.TestMacByAll(PartCode, Machine, Mold);
            string MaterialName = PartDAO.Instance.MaterialNameByCode(PartCode);
            float weight = PartDAO.Instance.WeightByCode(PartCode);
            float weightrunner = PartDAO.Instance.WeightRunnerByCode(PartCode);
            float percent = PartDAO.Instance.PercentPart(PartCode);
            int TotalWeight = (int)Math.Ceiling((quantity * (weight + weightrunner) + (percent * quantity * (weight + weightrunner)) / 100) / 1000);

            if (FactoryDAO.Instance.TestFactoryByFacCode(facCode) == -1)
            {
                MessageBox.Show("mã nhà máy không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (testM == -1)
            {
                MessageBox.Show("bạn chưa Setup thông tin Mac sản phẩm !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (test > 1)
            {
                MessageBox.Show("Khuôn không được phép sản xuất vì quá số shot bảo dưỡng!".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsInsert == true)
            {
                if (confirm == 3 || confirm == -5)
                {
                    MessageBox.Show("khuôn không được phép sản xuất vì chưa bảo dưỡng! hoặc đăng bị Block".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (StylePart.Length < 6)
                {
                    MessageBox.Show("linh kiện chưa được phê duyệt ! \n\nbạn hãy liên lạc với cấp trên".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CTSXDAO.Instance.InsertCTSX(dt, PartCode, quantity, Machine, Mold, NoteSx, NoteNl, facCode, TotalWeight,0,0);
                    EditHistoryDAO.Instance.Insert(DateTime.Now, Kun_Static.accountDTO.UserName, "Chỉ thị sản xuất với mã nguyên liệu : " + MaterialCode, "");
                    MessageBox.Show("thêm thông tin thành công!".ToUpper());
                    LoadControl();
                }
            }
            else
            {
                long Id = _id;
                CTSXDAO.Instance.UpdateCTSX(Id, dt, PartCode, quantity, Machine, Mold, NoteSx, NoteNl, facCode, TotalWeight);
                EditHistoryDAO.Instance.Insert(DateTime.Now, Kun_Static.accountDTO.UserName, "Chỉ thị sản xuất với mã nguyên liệu : " + MaterialCode, "");
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            List<ReportCTSX> listC = new List<ReportCTSX>();
            string Employess = "";
            string statusMold = "OK";
            string account = Kun_Static.accountDTO.DisplayName;
            string[] array = account.Split(' ');
            if (array.Count() > 0)
            {
                Employess = array[array.Count() - 1];
            }
            else
            {
                Employess = account;
            }
            foreach (var item in gridView1.GetSelectedRows())
            {
                DateTime date = DateTime.Parse(gridView1.GetRowCellValue(item, "DateInput").ToString());
                string MachineCode = gridView1.GetRowCellValue(item, "MachineCode").ToString();
                string MoldNumber = gridView1.GetRowCellValue(item, "MoldNumber").ToString();
                string PartCode = gridView1.GetRowCellValue(item, "PartCode").ToString();
                string FactoryCode = gridView1.GetRowCellValue(item, "FactoryCode").ToString();
                float quantity = (float)Convert.ToDouble(gridView1.GetRowCellValue(item, "Quantity").ToString());
                long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                string moldCode = gridView1.GetRowCellValue(item, "MoldCode").ToString();
                int totalShot = MoldDAO.Instance.TotalShotByCode(moldCode);
                if (totalShot > 1000000)
                {
                    statusMold = "OVER SHOT";
                }
                else
                {
                    statusMold = "OK";
                }
                string noteSX = " ";
                string noteNL = " ";
                try
                {
                    noteSX = gridView1.GetRowCellValue(item, "NoteSX").ToString();
                    noteNL = gridView1.GetRowCellValue(item, "NoteNL").ToString();
                }
                catch
                {
                }
                string PartName = PartDAO.Instance.NamePartByCode(PartCode);
                string customer = PartDAO.Instance.CustomerByCode(PartCode);
                string MaterialCode = PartDAO.Instance.MaterialCodeByCode(PartCode);
                string MaterialName = PartDAO.Instance.MaterialNameByCode(PartCode);
                float weight = PartDAO.Instance.WeightByCode(PartCode);
                float weightrunner = PartDAO.Instance.WeightRunnerByCode(PartCode);
                float percent = PartDAO.Instance.PercentPart(PartCode);
                float quantityPart = PartDAO.Instance.CountPartByCode(PartCode);
                float quantityBox = PartDAO.Instance.CountBoxByCode(PartCode);
                int CountBox = (int)Math.Ceiling(quantity / quantityPart);
                int Cav = PartDAO.Instance.CavityByCode(PartCode);
                float CycleTime = PartDAO.Instance.CycleTimeByCode(PartCode);
                float hour = (float)Math.Ceiling(((quantity * CycleTime) / Cav) / 3600);
                string weightMin = MaterialDAO.Instance.WeightMinByCode(MaterialCode);
                string timeMin = MaterialDAO.Instance.TimeMinByCode(MaterialCode);
                int TotalWeight = (int)Math.Ceiling((quantity * (weight + weightrunner) + (percent * quantity * (weight + weightrunner)) / 100) / 1000);
                string barCode = MaterialCode + "&" + PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + CountBox + "&" + FactoryCode +"&"+id;
                listC.Add(new ReportCTSX(PartCode, PartName, MaterialCode, MaterialName, MoldNumber, MachineCode, (int)quantity, (int)quantityPart, CountBox, hour, date, TotalWeight, Employess, barCode.ToUpper(), "Ghi chú : " + noteSX, "Ghi chú : " + noteNL, customer, statusMold, timeMin, weightMin));
            }
            rpCTSX report = new rpCTSX();
            report.DataSource = listC;
            report.Print();
            LoadControl();
        }
        #endregion
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void cbMachineCode_EditValueChanged(object sender, EventArgs e)
        {
            LoadFactory();
        }

        private void cbMachineCode_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            LoadFactory();
        }

        private void btnUpdateOut_Click(object sender, EventArgs e)
        {
            List<ProductDirectives> listP = CTSXDAO.Instance.GetDataCTSX();
            foreach (ProductDirectives item in listP)
            {
                string PartCode = item.PartCode;
                int quantity = item.Quantity;
                float weight = PartDAO.Instance.WeightByCode(PartCode);
                float weightrunner = PartDAO.Instance.WeightRunnerByCode(PartCode);
                float percent = PartDAO.Instance.PercentPart(PartCode);
                int TotalWeight = (int)Math.Ceiling((quantity * (weight + weightrunner) + (percent * quantity * (weight + weightrunner)) / 100) / 1000);

                CTSXDAO.Instance.UpdateCTSXWeightUse(item.Id,TotalWeight);
            }
            MessageBox.Show("Update thành công!".ToUpper());
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn xác nhận chỉ thị sản xuất này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    CTSXDAO.Instance.UpdateStatusCTSX(id, 0, "");
                }
                LoadData();
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn muốn khóa chỉ thị sản xuất này?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                 long id = long.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                 CTSXDAO.Instance.UpdateStatusCTSX(id, 2, "");
                }
                LoadData();
            }         
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            DateTime today = DateTime.Now;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                int statusCheck = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Status"]).ToString());
                if(statusCheck == 1)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else if(statusCheck==2)
                {
                    e.Appearance.BackColor = Color.Orange;
                }
            }
        }
    }
}
