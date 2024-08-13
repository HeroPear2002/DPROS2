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

namespace WareHouse.PO_and_Order
{
    public partial class frmDetailPO : DevExpress.XtraEditors.XtraForm
    {
        public frmDetailPO()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadData();
        }
        void LoadData()
        {
            long idInput = Kun_Static.IdPOInput;
            List<OnlyDateOutput> listO = PODAO.Instance.GetListOnlyDateOut(idInput);
            PODTO pODTO = PODAO.Instance.GetItemPOInput(idInput);
            List<PODTO> listP = new List<PODTO>();
            txtCountOut.Text = PODAO.Instance.SumQuantityOut(idInput).ToString();
            txtCountChange.Text = pODTO.QuantityOut.ToString();
            if (listO.Count == 0)
            {
                PODAO.Instance.UpdateStatusPO(idInput, 0);
                PODAO.Instance.UpdateQuantityOut(idInput, 0);
            }
            else
            {
                int dem = 0;
                int quantity = 0;
                foreach (OnlyDateOutput item in listO)
                {
                    DateTime today = item.DateOutput;
                    int mini = today.Millisecond;
                    DateTime date1 = today.AddMilliseconds(-mini);
                    DateTime date2 = date1.AddSeconds(1);
                    int sum = PODAO.Instance.SumQuantityOut(idInput, date1, date2);
                    if (dem == 0)
                    {
                        quantity = pODTO.QuantityIn - sum;
                        listP.Add(new PODTO(idInput, pODTO.POCode, pODTO.PartCode, pODTO.QuantityIn, pODTO.DateInput, pODTO.StatusPO, pODTO.FactoryCode, pODTO.Price, item.DateOutput, pODTO.Customer, sum, quantity, 0));
                    }
                    else
                    {
                        quantity = quantity - sum;
                        listP.Add(new PODTO(idInput, pODTO.POCode, pODTO.PartCode, 0, pODTO.DateInput, pODTO.StatusPO, pODTO.FactoryCode, pODTO.Price, item.DateOutput, pODTO.Customer, sum, quantity, 0));
                    }
                    dem++;
                }
                GCData.DataSource = listP;
            }
        }
    }
}