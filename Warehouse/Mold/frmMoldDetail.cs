using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.Mold
{
    public partial class frmMoldDetail : Form
    {
        public frmMoldDetail()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            LoadData();
            LoadMachine();
            LoadDetailMold();
            LoadErrorMold();
            LoadTribeMold();
        }
        #region Control
        void LoadData()
        {
            txtMoldCode.Text = frmMoldInfor.MoldInfor.moldCode;
            txtMoldName.Text = "";
        }
        void LoadMachine()
        {
            List<MachineDTO> listM = MachineDAO.Instance.GetListMachine();
            cbMachine.DataSource = listM;
            cbMachine.DisplayMember = "MachineCode";
            cbMachine.ValueMember = "MachineCode";
        }
        void LoadErrorMold()
        {
            cbErrorM.DataSource = MoldDAO.Instance.GetListErrorMold();
            cbErrorM.DisplayMember = "NameError";
            cbErrorM.ValueMember = "Id";
        }
        void LoadDetailMold()
        {
            cbCategory.DataSource = MoldDAO.Instance.GetListCategoryMold();
            cbCategory.DisplayMember = "NameError";
            cbCategory.ValueMember = "Id";
        }
        void LoadTribeMold()
        {
            cbTribe.DataSource = MoldDAO.Instance.GetListTribeMold();
            cbTribe.DisplayMember = "NameError";
            cbTribe.ValueMember = "Id";
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            string check = (today.Day.ToString() + "/" + today.Month.ToString() + "/" + today.Year.ToString());
            string MachineCode = cbMachine.Text;
            DateTime DateError = dtpkDateError.Value;
            int ShotTT = frmMoldInfor.MoldInfor.shotTT;
            int TotalShot = frmMoldInfor.MoldInfor.totalShot;
            string Category = cbCategory.Text;
            int id = (int)cbCategory.SelectedValue;
            string note = MoldDAO.Instance.NoteErrorMold(id);
            string Error = cbErrorM.Text;
            string Tribe = cbTribe.Text;
            string Detail = txtDetail.Text;
            DateTime DateStart = dtpkDateStart.Value;
            DateTime DateEnd = dtpkDateEnd.Value;
            string Detail1 = txtDetail1.Text;
            string Detail2 = txtDetail2.Text;
            string Detail3 = txtDetail3.Text;
            string Detail4 = txtDetail4.Text;
            string Detail5 = txtDetail5.Text;
            string Detail6 = txtDetail6.Text;
            string MoldCode = txtMoldCode.Text;
            int warn = MoldDAO.Instance.WarnMoldInforByCode(MoldCode);
            if (nudTime.Text.Length == 0)
            {
                MessageBox.Show("tổng số giờ bảo dưỡng không được phép trống !".ToUpper());

            }
            else
            {
                float TotalTime = (float)Convert.ToDouble(nudTime.Text);
                if (MessageBox.Show("Xác nhận khuôn đã được Bảo Dưỡng ".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_InsertHistoryMold @MachineCode , @DateError , @CountShort , @TotalShort , @Category , @Error  , @TribeError , @Detail , @DateStart ,  @DateEnd ,  @TotalTime , @Detail1 , @Detail2 , @Detail3 , @Detail4 , @Detail5 , @Detail6 , @MoldCode ", new object[] { MachineCode, DateError, ShotTT, TotalShot, Category, Error, Tribe, Detail, DateStart, DateEnd, TotalTime, Detail1, Detail2, Detail3, Detail4, Detail5, Detail6, MoldCode });
                    MoldDAO.Instance.UpdateWainMoldInfor(MoldCode, warn);
                    if (note != "1")
                    {
                        MoldDAO.Instance.UpdateShotTTMoldInfor(MoldCode, 0);
                        MoldDAO.Instance.UpdatePlanMoldInfor(MoldCode, "");
                        MoldDAO.Instance.UpdateConfirmMoldInfor(MoldCode, 0);
                        MoldDAO.Instance.DeleteMoldConfirm(MoldCode);
                        MoldDAO.Instance.UpdateNoteMoldInfor(MoldCode, "");
                        MessageBox.Show("Xác Nhận Thành Công !");
                    }
                    else
                    {
                        MessageBox.Show("Xác Nhận Sửa chữa Thành Công !");
                    }
                    this.Close();
                }
            }

        }

        private void frmMoldDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
