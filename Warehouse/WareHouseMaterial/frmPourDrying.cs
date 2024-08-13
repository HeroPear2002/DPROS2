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
using DTO;
using DAO;

namespace WareHouse.WareHouseMaterial
{
    public partial class frmPourDrying : DevExpress.XtraEditors.XtraForm
    {

        public frmPourDrying()
        {
            InitializeComponent();
        }
        public EventHandler Refreshs;
        void LoadControl()
        {
            txtKanban.Focus();
        }
        void LoadData()
        {
            string barCode = txtBarCodeDry.Text;
            string materialCode = barCode.Split('&')[0];
            string kanban = txtKanban.Text;
            if (materialCode.ToUpper() == kanban.ToUpper())
            {
                long id = long.Parse(barCode.Split('&')[1]);
                DryingDTO dryingDTO = DryingAndPourDAO.Instance.GetItemDry(id);
                if (dryingDTO.StatusDry == 1)
                {
                    timer2.Stop();
                    MessageBox.Show("Mã vạch đã được bắn!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarCodeDry.SelectAll();
                    return;
                }
                else if (dryingDTO.MaterialCode != materialCode)
                {
                    timer2.Stop();
                    MessageBox.Show("Tem không đúng,cần xác nhận lại!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarCodeDry.SelectAll();
                    return;
                }
                else
                {
                    DryingAndPourDAO.Instance.UpdateDrying(id, DateTime.Now, 1);
                    txtBarCodeDry.SelectAll();
                }
            }
            else
            {
                timer2.Stop();
                MessageBox.Show("Loại nguyên liệu không đúng,cần xác nhận lại!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBarCodeDry.SelectAll();
                return;
            }
        }
        private void txtBarCodeDry_TextChanged(object sender, EventArgs e)
        {
            timer2.Interval = 400;
            timer2.Start();
        }

        private void txtKanban_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = 300;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            txtBarCodeDry.Focus();
        }

        private void frmPourDrying_FormClosing(object sender, FormClosingEventArgs e)
        {
            Refreshs?.Invoke(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            LoadData();
        }
    }
}