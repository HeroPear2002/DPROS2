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

namespace WareHouse
{
    public partial class frmInforWarehousePart : Form
    {
        public frmInforWarehousePart()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            GCData.DataSource = IventoryPartDAO.Instance.GetListIventoryPartQCByIDWH(Kun_Static.IdWh);
            this.Name = "thông tin vị trí".ToUpper();
        }
    }
}
 