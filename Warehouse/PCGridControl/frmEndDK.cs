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

namespace WareHouse.PCGridControl
{
    public partial class frmEndDK : Form
    {
        public frmEndDK()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler Lammoi;
        void LoadControl()
        {
            btnSave.Enabled = false;
            LoadPartCode();
        }
        void ClearText()
        {
            txtId.Text = String.Empty;

        }
        void AddText()
        {
            try
            {
                txtId.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch 
            {
            }
        }
        void LoadPartCode()
        {
            cbPart.DataSource = TDSXDAO.Instance.GetPartCode();
            cbPart.DisplayMember = "PartCode";
            cbPart.ValueMember = "PartCode";
        }
        void LoadMoldNumber()
        {
            string part = cbPart.Text;
            cbMold.DataSource = TDSXDAO.Instance.GetMolnumber(part);
            cbMold.DisplayMember = "MoldNumber";
            cbMold.ValueMember = "MoldNumber";
        }
        void LoadMachineCode()
        {
            string part = cbPart.Text;
            string mold = cbMold.Text;
            cbMachine.DataSource = TDSXDAO.Instance.GetMachineCode(part, mold);
            cbMachine.DisplayMember = "MachineCode";
            cbMachine.ValueMember = "MachineCode";
        }
        void LoadData()
        {
            string part = cbPart.Text;
            string mold = cbMold.Text;
            string machine = cbMachine.Text;
            long idSX = TDSXDAO.Instance.IdSXByALL(machine, part, mold);
            GCData.DataSource = TDSXDAO.Instance.GetTableDKByCode(idSX);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = DateTime.Now;
            long iddk = long.Parse(txtId.Text);
            List <TableDK> listT = TDSXDAO.Instance.GetListTableDK().Where(x=>x.Id > iddk).ToList();
            int i = 0;
            DateTime endTime = TDSXDAO.Instance.EndTime(iddk);
            DateTime warnTime = TDSXDAO.Instance.WarnTime(iddk);
            if(today >= warnTime)
            {
                long id = 0;
                foreach (TableDK item in listT)
                {
                    if (i == 0)
                    {
                        id = item.Id;
                        endTime = item.EndTime;
                        warnTime = item.WarnTime;
                    }
                    i++;
                }
                TDSXDAO.Instance.UpdateTableDK(iddk, endTime, warnTime);
                TDSXDAO.Instance.DeleteTableDKX(id);
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("chưa đến thời gian đo hàng !".ToUpper(),"Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEndDK_FormClosing(object sender, FormClosingEventArgs e)
        {
            Lammoi?.Invoke(sender, e);
        }

        private void cbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearText();
            LoadMoldNumber();
        }

        private void cbMold_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearText();
            LoadMachineCode();
        }

        private void cbMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearText();
            LoadData();
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            AddText();
        }
    }
}
