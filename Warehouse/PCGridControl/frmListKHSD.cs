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

namespace WareHouse.PCGridControl
{
    public partial class frmListKHSD : Form
    {
        public frmListKHSD()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadKHBD();
            LoadKHSD();
        }
        #region KHSĐ
        void LoadKHSD()
        {
            GCKHSD.DataSource = TDSXDAO.Instance.GetListKHSD();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn thêm kế hoạch này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)              
            {
                int secon = 0;
                foreach (var item in gridView2.GetSelectedRows())
                {
                    string MachineCode = gridView2.GetRowCellValue(item, "MachineCode").ToString();
                    long IdBD = long.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                    string PartCode = gridView2.GetRowCellValue(item, "PartCode").ToString();
                    string MaterialCode = PartDAO.Instance.MaterialCodeByCode(PartCode);
                    int quantity = int.Parse(gridView2.GetRowCellValue(item, "CountBD").ToString());
                    string MoldCode = TDSXDAO.Instance.MoldCodeKHBD(IdBD);
                    int cav = PartDAO.Instance.CavityByCode(PartCode);
                    float CycleTime = PartDAO.Instance.CycleTimeByCode(PartCode);
                    string Materialcode = PartDAO.Instance.MaterialCodeByCode(PartCode);
                    string MaterialName = MaterialDAO.Instance.GetNameMaterialByCode(MaterialCode);
                    float Weight = PartDAO.Instance.WeightByCode(PartCode);
                    string inFor = TDSXDAO.Instance.InforMachine(MachineCode);
                    int tan = TDSXDAO.Instance.WeightMachine(inFor);
                    if(tan >180)
                    {
                        secon = 60;
                    }
                    else
                    {
                        secon = 40;
                    }
                    int totalTime = (int)Math.Ceiling(CycleTime * (quantity / cav));
                    int totalMaterial = (int)Math.Ceiling((Weight * quantity) / 1000);
                    DateTime today = DateTime.Today;
                    DateTime Date1 = today.AddDays(1).AddHours(8);
                    DateTime Date2 = Date1.AddSeconds(totalTime);
                    int TestMaxEndTime = TDSXDAO.Instance.TestMaxEndtimeKHSD(MachineCode);
                    if(TestMaxEndTime == 1)
                    {
                        DateTime MaxEndTime = TDSXDAO.Instance.GetMaxEndTimeKHSD(MachineCode);
                        if(MaxEndTime <= Date1)
                        {
                            TDSXDAO.Instance.InsertKHSD(IdBD, MachineCode, PartCode, MoldCode, Date1, Date2, quantity, 0);
                            TDSXDAO.Instance.InsertKHSD(IdBD, MachineCode, "TK", MoldCode, Date2, Date2.AddMinutes(secon), quantity, 1);
                            long idSD = TDSXDAO.Instance.MaxIdKHBD();
                            TDSXDAO.Instance.InsertKHNL(idSD, MaterialCode,MaterialName, MachineCode, Date1, Date2, totalMaterial, 0);
                            TDSXDAO.Instance.InsertKHNL(idSD, "TK","" ,MachineCode, Date2, Date2.AddMinutes(secon), quantity, 1);
                        }
                        else
                        {
                            TDSXDAO.Instance.InsertKHSD(IdBD, MachineCode, PartCode, MoldCode, MaxEndTime, MaxEndTime.AddSeconds(totalTime), quantity, 0);
                            TDSXDAO.Instance.InsertKHSD(IdBD, MachineCode, "TK", MoldCode, MaxEndTime.AddSeconds(totalTime), MaxEndTime.AddSeconds(totalTime).AddMinutes(secon), quantity, 1);
                            long idSD = TDSXDAO.Instance.MaxIdKHBD();
                            TDSXDAO.Instance.InsertKHNL(idSD, MaterialCode, MaterialName, MachineCode, MaxEndTime, MaxEndTime.AddSeconds(totalTime), totalMaterial, 0);
                            TDSXDAO.Instance.InsertKHNL(idSD, "TK","", MachineCode, MaxEndTime.AddSeconds(totalTime), MaxEndTime.AddSeconds(totalTime).AddMinutes(secon), quantity, 1);
                        }
                    }
                    else
                    {
                        TDSXDAO.Instance.InsertKHSD(IdBD, MachineCode, PartCode, MoldCode, Date1, Date2, quantity, 0);
                        TDSXDAO.Instance.InsertKHSD(IdBD, MachineCode, "TK", MoldCode, Date2, Date2.AddMinutes(secon), quantity, 1);
                        long idSD = TDSXDAO.Instance.MaxIdKHBD();
                        TDSXDAO.Instance.InsertKHNL(idSD, MaterialCode, MaterialName, MachineCode, Date1, Date2, totalMaterial, 0);
                        TDSXDAO.Instance.InsertKHNL(idSD, "TK","", MachineCode, Date2, Date2.AddMinutes(secon), quantity, 1);
                    }
                }
                LoadControl();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn xóa thông tin này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    long idSD = TDSXDAO.Instance.IdKHNLByIDSD(id);
                    TDSXDAO.Instance.DeleteKHSD(id);
                    TDSXDAO.Instance.DeleteKHSD(id + 1);
                    if (idSD != -1)
                    {
                        TDSXDAO.Instance.DeleteKHNL(idSD);
                        TDSXDAO.Instance.DeleteKHNL(idSD + 1);
                    }
                }
                LoadControl();
            }
        }
        #endregion
        #region KHBĐ
        void LoadKHBD()
        {
            GCKHBD.DataSource = TDSXDAO.Instance.GetListKHBD();
        }

        #endregion


    }
}
