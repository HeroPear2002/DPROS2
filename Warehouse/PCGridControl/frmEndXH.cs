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
    public partial class frmEndXH : Form
    {
        public frmEndXH()
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
            GCData.DataSource = TDSXDAO.Instance.GetTableXHByCode(idSX);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = DateTime.Now;
            long idxh = long.Parse(txtId.Text);
            List<TableXH> listT = TDSXDAO.Instance.GetListTableXH().Where(x => x.Id > idxh).ToList();
            int i = 0;
            long idPlus = 0;


            foreach (TableXH item in listT)
            {
                if (i == 0)
                {
                    DateTime Time = TDSXDAO.Instance.DateStartTimeXH(item.Id);
                    idPlus = item.Id;
                    if (today >= Time)
                    {
                        TDSXDAO.Instance.UpdateEndTimeTableXH(idxh, item.StartTime);
                        TDSXDAO.Instance.UpdateColorTableXH(item.Id, 7,2);
                        MessageBox.Show("OK");
                    }
                    else
                    {
                        MessageBox.Show("chưa đến thời gian lấy hàng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Close();
                }
                i++;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmEndXH_FormClosing(object sender, FormClosingEventArgs e)
        {
            Lammoi?.Invoke(sender, e);
        }
    }
}
