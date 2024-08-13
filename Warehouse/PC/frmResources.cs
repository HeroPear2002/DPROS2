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
using DAO;
using DTO;

namespace WareHouse.PC
{
    public partial class frmResources : DevExpress.XtraEditors.XtraForm
    {
        public frmResources()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            GCDataParent.DataSource = ResoucesDAO.Instance.GetListResource().Where(x => x.ParentId == 0);
            GCDataSon.DataSource = ResoucesDAO.Instance.GetListResource().Where(x => x.ParentId > 0);
        }

        private void btnAddParent_Click(object sender, EventArgs e)
        {
            List<MachineDTO> listM = MachineDAO.Instance.GetListMachineByDevice(1).ToList();
            foreach (MachineDTO item in listM)
            {
                int idSort = ResoucesDAO.Instance.MaxIdsort();
                int test = ResoucesDAO.Instance.TestResource(0, item.MachineCode);
                string machine = item.MachineCode.Substring(0,1);
                if (test == -1 && machine == "M")
                {
                    ResoucesDAO.Instance.InsertResource(idSort+1, 0, item.MachineCode, 0, "");
                }
            }
            MessageBox.Show("Thêm thông tin thành công !".ToUpper());
            LoadControl();
        }

        private void btnAddSon_Click(object sender, EventArgs e)
        {
            List<string> listS = new List<string>() { "1.Sản xuất","2.Thực tế","3.Định kỳ","4.Xuất hàng"};
            List<Resources> listR = ResoucesDAO.Instance.GetListResource().Where(x => x.ParentId == 0).ToList();
            foreach (Resources item in listR)
            {
                foreach (var item1 in listS)
                {
                    int idSort = ResoucesDAO.Instance.MaxIdsort();
                    int test = ResoucesDAO.Instance.TestResource(item.Id, item1);
                    if (test == -1)
                    {
                        ResoucesDAO.Instance.InsertResource(idSort+1, item.Id, item1, 0, "");
                    }
                }
            }
            MessageBox.Show("Thêm thông tin thành công !".ToUpper());
            LoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn xóa thông tin này?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ResoucesDAO.Instance.DeleteResourceALL();
                LoadControl();
            }
        }
    }
}