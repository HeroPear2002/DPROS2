using DevExpress.XtraEditors;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.Output
{
    public partial class frmOutputPart : Form
    {
        public frmOutputPart()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            timer1.Start();
        }
        private void frmOutputPart_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
        void XoaText()
        {
            txtBarCode.Text = String.Empty;
            dtpkDateOut.Text = String.Empty;
        }
        long LoadIdDe(string Code)
        {
            try
            {
                string[] array = Code.Split('&');
                long idDe = long.Parse(array[1]);
                LoadStatus(idDe);
                List<DeliveryDetail> deliveryDetails = DeliveryDAO.Instance.GetListDeliveryDetail(idDe);
                foreach (DeliveryDetail item in deliveryDetails)
                {
                    int status = item.StatusDetail;
                    if(status == 0 &&(item.Quantity - item.QuantityOut) == 0)
                    {
                        DeliveryDAO.Instance.UpdateDeliveryDetail(item.Id, 1, item.Quantity);
                    }
                }
                return idDe;
            }
            catch
            {
                return -1;
            }
        }
        void LoadStatus(long IdDe)
        {
            DeliveryNotesDTO deliveryNotesDTO = DeliveryDAO.Instance.GetItemDelivery(IdDe);
            if (deliveryNotesDTO.StatusDe == 1)
            {
                List<DeliveryDetail> listDetail = new List<DeliveryDetail>();
                listDetail = DeliveryDAO.Instance.GetListDeliveryDetail(deliveryNotesDTO.Id);
                int count = 0;
                foreach (DeliveryDetail jtem in listDetail)
                {
                    if (jtem.StatusDetail == 0 && (jtem.QuantityOut != jtem.Quantity))
                    {
                        count = 1;
                        break;
                    }
                }
                if (count == 1)
                {
                    DeliveryDAO.Instance.UpdateDelivery(deliveryNotesDTO.Id, 0, "");
                }
                else
                {
                    int a = (int)(DateTime.Now - (DateTime)deliveryNotesDTO.DateDelivery).TotalHours;
                    if (a >= 12)
                    {
                        DeliveryDAO.Instance.UpdateDelivery(deliveryNotesDTO.Id, 2, "BB chưa được giao");
                    }
                }
            }
            else if (deliveryNotesDTO.StatusDe == 0)
            {
                List<DeliveryDetail> listDetail = new List<DeliveryDetail>();
                listDetail = DeliveryDAO.Instance.GetListDeliveryDetail(deliveryNotesDTO.Id);
                int count = 0;
                foreach (DeliveryDetail jtem in listDetail)
                {
                    if (jtem.StatusDetail == 0 && (jtem.QuantityOut != jtem.Quantity))
                    {
                        POFixDAO.Instance.UpdatePOFixByCode(jtem.IdPOFix, 2, "");
                        count++;
                    }
                }
                if (deliveryNotesDTO.EmployessOut.Length > 0 && count == 0)
                {
                    DeliveryDAO.Instance.UpdateDelivery(deliveryNotesDTO.Id, 1, "");
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string DeCode = txtBarCode.Text;
            if (LoadIdDe(DeCode) == -1)
            {
                MessageBox.Show("Bạn phải bấm mã vạch của BBGH !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            long idDe = LoadIdDe(DeCode);
            List<DeliveryDetail> deliveryDetails = DeliveryDAO.Instance.GetListDeliveryDetail(idDe);
            if (DeliveryDAO.Instance.StatusDe(idDe) != 0)
            {
                MessageBox.Show("biên bản giao hàng này đã được xuất kho!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string Employess = Kun_Static.EmployessCode;
            int check = 0;
            DateTime DateOutput = dtpkDateOut.Value;
            foreach (DeliveryDetail jtem in deliveryDetails)
            {
                long idPOInput = POFixDAO.Instance.GetItemPOFix(jtem.IdPOFix).IdPOInput;
                int test = PODAO.Instance.StatusPO(idPOInput);
                if (test == 1)
                {
                    MessageBox.Show("Mã PO : "+jtem.POCode+" đã xuất hàng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string factoryCode = PODAO.Instance.FactoryPO(idPOInput);
                    if (factoryCode.Length == 0)
                    {
                        MessageBox.Show("Mã PO hoặc mã nhà Máy không đúng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        check++;
                        break;
                    }
                    string PartCode = jtem.PartCode;
                    int CountOut = jtem.Quantity - jtem.QuantityOut;
                    string Factory = PODAO.Instance.GetItemPOInput(idPOInput).FactoryCode;
                    int sum = IventoryPartDAO.Instance.TotalPartOK(PartCode, Factory);
                    if (sum < CountOut)
                    {
                        MessageBox.Show("Số lượng hàng OK không đủ!\n\nPO : " + jtem.POCode + " Chưa được xuất kho!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        check++;
                    }
                    else
                    {
                        int quantityInput = PODAO.Instance.QuantityInputPO(idPOInput);
                        int sumQuantityOut = PODAO.Instance.SumQuantityOut(idPOInput);  
                        if (CountOut <= 0)
                        {
                            if(jtem.StatusDetail == 0)
                            {
                                DeliveryDAO.Instance.UpdateDeliveryDetail(jtem.Id, 1, jtem.Quantity);
                            }
                        }
                        else
                        {

                            List<IvenstoryDTO> listIAll = IventoryPartDAO.Instance.GetListIvenstoryPart().Where(x => x.PartCode == PartCode && x.FactoryCode == factoryCode).ToList();
                            List<IvenstoryDTO> listI = IventoryPartDAO.Instance.GetListPartOKByCode(PartCode, factoryCode);
                            List<IvenstoryDTO> listIYellow = listIAll.Where(x => x.Yellow == "NO").ToList();
                            if (listIYellow.Count > 0)
                            {
                                listI = listI.Where(x => x.Yellow == "YES").ToList(); ;
                            }
                            int totalIventory = 0;
                            totalIventory = listI.Sum(x => x.Iventory);
                            if (totalIventory == 0)
                            {
                                MessageBox.Show("số lượng Hàng gắn thẻ vàng không đủ !\n\nPO : " + jtem.POCode + " Chưa được xuất kho!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                check++;
                                break;
                            }
                                DateTime dateIventory = IventoryPartDAO.Instance.GetDateIventory(PartCode, factoryCode);
                                int totalDate = (int)(DateOutput - dateIventory).TotalDays;
                                if (totalDate >= 90)
                                {
                                    if (MessageBox.Show("mã linh kiện đã tồn kho quá 3 tháng \n\nbạn hãy xác nhận với QC trước khi xuất hàng".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                                    {
                                        MessageBox.Show("PO : " + jtem.POCode + " Chưa được xuất kho!".ToUpper());
                                        check++;
                                        return;
                                    }
                                }
                                #region Output
                                if (CountOut > 0)
                                {
                                    if (CountOut <= totalIventory)
                                    {
                                        foreach (IvenstoryDTO item in listI)
                                        {
                                            int countPart = PartDAO.Instance.CountPartByCode(item.PartCode);
                                            string Note2 = item.Note2;
                                            if (Note2 == "Vị trí có thùng lẻ")
                                            {
                                                MessageBox.Show("Chú ý vị trí có thùng lẻ, kiểm tra khi lấy hàng".ToUpper());
                                                Note2 = "Chú ý vị trí có thùng lẻ, kiểm tra khi lấy hàng";
                                            }
                                            long idInput = item.Id;
                                            int Iventory = item.Iventory;
                                            int b = CountOut - Iventory;
                                            if (b <= 0)
                                            {
                                                int box = CountOut / countPart;
                                                if (CountOut % countPart != 0)
                                                {
                                                    MessageBox.Show("Chú ý số lượng xuất không tròn thùng.\n\nCần liên lạc SX xác nhận".ToUpper());
                                                    Note2 = "Chú ý số lượng xuất không tròn thùng.Cần liên lạc SX xác nhận";
                                                    box += 1;
                                                }
                                                IventoryPartDAO.Instance.OutputPartNotProvider(idInput, DateOutput, CountOut, Employess, Note2, idDe, jtem.POCode);
                                                PODAO.Instance.InsertPOOutput(jtem.POCode, DateOutput, CountOut, idInput, "", idPOInput, idDe);
                                                POFixDAO.Instance.UpdatePOFixByCode(jtem.IdPOFix, 3, "PO đã xuất");
                                                DeliveryDAO.Instance.UpdateDeliveryDetail(jtem.Id, 1, jtem.Quantity);
                                                if (b == 0)
                                                {
                                                    WareHouseDAO.Instance.UpdateStatusWH(item.IdWareHouse, 1);
                                                    IventoryPartDAO.Instance.UpdateInputPart(item.Id, 1);
                                                }
                                                CountOut = 0;
                                                XoaText();
                                                break;
                                            }
                                            else
                                            {
                                                int box = Iventory / countPart;
                                                if (Iventory % countPart != 0)
                                                {
                                                    MessageBox.Show("Chú ý số lượng xuất không tròn thùng.\n\nCần liên lạc SX xác nhận".ToUpper());
                                                    Note2 = "Chú ý số lượng xuất không tròn thùng.Cần liên lạc SX xác nhận";
                                                    box += 1;
                                                }
                                                IventoryPartDAO.Instance.OutputPartNotProvider(idInput, DateOutput, Iventory, Employess, Note2, idDe, jtem.POCode);
                                                PODAO.Instance.InsertPOOutput(jtem.POCode, DateOutput, Iventory, idInput, "", idPOInput, idDe);
                                                CountOut = b;
                                                WareHouseDAO.Instance.UpdateStatusWH(item.IdWareHouse, 1);
                                                IventoryPartDAO.Instance.UpdateInputPart(item.Id, 1);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("sô lượng hàng OK trong kho không đủ !".ToUpper());
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("bạn chưa điền số lượng xuất !".ToUpper());
                                }
                                #endregion
                        }
                    }
                }
            }
            MessageBox.Show("xuất thành công BBGH !".ToUpper());
            XoaText();
            if(check == 0)
            {
                DeliveryDAO.Instance.UpdateDelivery(idDe, 1,"");
            }
            DeliveryDAO.Instance.UpdateDeliveryOUT(idDe, DateOutput, Employess);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dtpkDateOut.Value = DateTime.Now.AddSeconds(1);
        }

        private void frmOutputPart_Load(object sender, EventArgs e)
        {

        }
    }
}
