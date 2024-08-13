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

namespace WareHouse.PCGridControl
{
    public partial class frmStopANDStartMachine : Form
    {
        public frmStopANDStartMachine()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;
        public EventHandler LamMoi;
        void LoadControl()
        {
            LockControl();
        }
        void LoadData()
        {
            string BarCode = txtBarCode.Text;
            string[] arrayList = BarCode.Split('&');
            int leng = arrayList.Count();
            if (leng == 4)
            {
                txtPartCode.Text = arrayList[0];
                txtMachine.Text = arrayList[1];
                txtMoldNumber.Text = arrayList[2];
            }
            else
            {
                txtPartCode.Text = arrayList[3];
                txtMachine.Text = arrayList[9];
                string moldSTR = arrayList[8];
                bool a = moldSTR.Contains("-");
                if (a == true)
                {
                    string[] array = moldSTR.Split('-');
                    txtMoldNumber.Text = array[0];
                }
                else
                {
                    txtMoldNumber.Text = moldSTR;
                }
            }
            string machineCode = txtMachine.Text;
            string partCode = txtPartCode.Text;
            string mold = txtMoldNumber.Text;
            List<TableSX> listT = TDSXDAO.Instance.GetListTableSX().Where(x => x.MachineCode == machineCode).Where(y => y.PartCode == partCode).Where(z => z.MoldNumber == mold).Where(m => m.ConfirmSX == 1).ToList();
            GCData.DataSource = listT;
        }
        void LockControl()
        {
            txtBarCode.Enabled = false;
            txtNote.Enabled = false;
            dtpkStart.Enabled = false;

            btnStop.Enabled = true;
            btnReStart.Enabled = true;
        }
        void OpenControl()
        {
            txtBarCode.Enabled = true;
            txtNote.Enabled = true;
            dtpkStart.Enabled = true;

            btnStop.Enabled = false;
            btnReStart.Enabled = false;
        }
        void AddText()
        {
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch 
            {

            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            Isinsert = false;
            OpenControl();
            btnReStart.Enabled = false;
        }

        private void btnReStart_Click(object sender, EventArgs e)
        {
            Isinsert = true;
            OpenControl();
            btnStop.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime date = dtpkStart.Value;
            long idSX = long.Parse(txtID.Text);
            long IdTT = TDSXDAO.Instance.IDTableTT(idSX);
            int quantity = TDSXDAO.Instance.QuantityTT(IdTT);
            int idResourceTT = TDSXDAO.Instance.IDResourceTableTT(idSX);
            DateTime endTime = TDSXDAO.Instance.EndTimeSX(idSX);
            string note = txtNote.Text;
            if (Isinsert == true)
            {
                long IdTT2 = TDSXDAO.Instance.IDTableTTConfirm2(idSX);
                if(IdTT2 == -1)
                {
                    MessageBox.Show("MÁy này không bị dừng nên không cần chạy lại".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Update EndTime cho TT có Confirm =2
                TDSXDAO.Instance.UpdateTableTT(IdTT2, date, 0);
                //Insert TT có startTim = dtpk , EndTime = +5,MaxTime = EndTimeSX
                TDSXDAO.Instance.InsertTableTT(idResourceTT, idSX, date.AddMinutes(2), date.AddMinutes(7), quantity, 4, 1, endTime,"");
                MessageBox.Show("Chạy lại thành công !".ToUpper());
                this.Close();
            }
            else
            {
                // Update MaxTime 
                TDSXDAO.Instance.UpdateMaxTimeTableTT(IdTT, date.AddMilliseconds(-2));
                TDSXDAO.Instance.UpdateTableTT(IdTT, date.AddMilliseconds(-2),quantity);
                //Insert TT có  confirm = 2
                if (note == "")
                {
                    MessageBox.Show("bạn chưa điền lý do dừng máy".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TDSXDAO.Instance.InsertTableTT(idResourceTT, idSX, date, date.AddMinutes(5), 0, 1, 2, date,txtNote.Text);
                MessageBox.Show("dừng máy thành công !".ToUpper());
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStopANDStartMachine_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadData();
            timer1.Stop();
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            AddText();
        }
    }
}
