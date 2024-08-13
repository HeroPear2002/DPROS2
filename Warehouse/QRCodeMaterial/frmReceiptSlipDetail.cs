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

namespace WareHouse.QRCodeMaterial
{
    public partial class frmReceiptSlipDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmReceiptSlipDetail()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            LoadData();
        }
        void LoadData()
        {
            string receiptCode = Kun_Static.ReceiptCode;
            List<ReceiptSlipDTO> listR = new List<ReceiptSlipDTO>();
            listR = ReceiptSlipDAO.Instance.GetReceiptSlipDTOs(receiptCode);
            GCData.DataSource = listR;
        }
    }
}