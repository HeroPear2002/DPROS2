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

namespace WareHouse.WareHouseMaterial
{
    public partial class frmOutputMaterialHH : Form
    {
        public frmOutputMaterialHH()
        {
            InitializeComponent();
            LoadDate();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            this.AcceptButton = btnSaveOutput;
            this.CancelButton = btnDelete;
        }
        void DeleteText()
        {
            txtBarCodeOut.Text = String.Empty;
            txtQuantityOut.Text = "1";
        }
        void LoadDate()
        {
            dtpkDateOutput.Value = DateTime.Now;
        }
        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            string BarCode = txtBarCodeOut.Text;
            string[] array = BarCode.Split('&');
            string MaterialCode = array[0].ToUpper();
            string partCode = array[1].ToUpper();
            string machineCode = array[2].ToUpper();
            string employess = Kun_Static.EmployessCode;
            float k = 1;
            try
            {
                k = (float)Convert.ToDouble(txtQuantityOut.Text);
            }
            catch
            {
                k = 1;
            }

            List<MaterialInforDTO> listM = MaterialInforDAO.Instance.GetlistMaterialByCode(MaterialCode);
            List<IventoryMaterialDTO> listMA = new List<IventoryMaterialDTO>();
            foreach (MaterialInforDTO item in listM.OrderByDescending(x => x.Count))
            {
                string code = item.MaterialCode;
                long IdInput = IventoryMaterialDAO.Instance.IdIventory(code);
                string lot = IventoryMaterialDAO.Instance.GetLotByID(IdInput);
                if (lot.Length <= 0)
                {
                    MessageBox.Show("Nguyên liệu này chưa có số Lot".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                float iventory = IventoryMaterialDAO.Instance.TotalIventoryByCode(code);
                string name = MaterialDAO.Instance.GetNameMaterialByCode(code);
                float count = item.Count * k;
                if (iventory < count)
                {
                    string mgs = string.Format("mã nguyên liệu : {0}\n\nsố lượng tồn trên kho không đủ !".ToUpper(), code);
                    MessageBox.Show(mgs, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            foreach (MaterialInforDTO item in listM.OrderByDescending(x => x.Count))
            {
                string code = item.MaterialCode;
                long IdInput = IventoryMaterialDAO.Instance.IdIventory(code);
                string lot = IventoryMaterialDAO.Instance.GetLotByID(IdInput);
                if (lot.Length <= 0)
                {
                    MessageBox.Show("Nguyên liệu này chưa có số Lot".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                float iventory = IventoryMaterialDAO.Instance.TotalIventoryByCode(code);
                string name = MaterialDAO.Instance.GetNameMaterialByCode(code);
                float count = item.Count * k;
                if (iventory < count)
                {
                    string mgs = string.Format("mã nguyên liệu : {0}\n\nsố lượng tồn trên kho không đủ !".ToUpper(), code);
                    MessageBox.Show(mgs, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListOutputIventory(code);
                foreach (IventoryMaterialDTO item1 in listI)
                {
                    long Id = item1.Id;
                    float quantity = item1.QuantityInput;
                    float a = (float)Math.Round(count - quantity, 2);
                    if (a <= 0)
                    {
                        IventoryMaterialDAO.Instance.OutPutMaterial(Id, dtpkDateOutput.Value, count, employess, "Xuất Nhựa HH", partCode, machineCode, item1.Lot);
                        listMA.Add(new IventoryMaterialDTO(1, 1, code, item1.DateInput, name, count, item1.Name,item1.StyleInput, item1.Lot, " "));
                        count = 0;
                        DeleteText();
                        break;
                    }
                    else
                    {
                        IventoryMaterialDAO.Instance.OutPutMaterial(Id, dtpkDateOutput.Value, quantity, employess, "Xuất Nhựa HH", partCode, machineCode, item1.Lot);
                        listMA.Add(new IventoryMaterialDTO(1, 1, code, item1.DateInput, name, quantity, item1.Name,item1.StyleInput, item1.Lot, " "));
                        count = a;
                    }
                }
            }
            MessageBox.Show("bạn xuất thành công !".ToUpper());
            GCData.DataSource = listMA;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn hủy xuất kho ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                LamMoi?.Invoke(sender, e);
                this.Close();
            }
        }

        private void frmOutputMaterialHH_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
