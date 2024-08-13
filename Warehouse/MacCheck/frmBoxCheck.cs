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
using WMPLib;
using System.IO;
using System.Reflection;
using WareHouse.MacCheck;
using WareHouse.Common;

namespace WareHouse.PO_and_Order
{
    public partial class frmBoxCheck : DevExpress.XtraEditors.XtraForm
    {
        Timer timer1;
        public frmBoxCheck()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Tick += timer1_Tick;
            timer1.Interval = 500;
        }
        public EventHandler LamMoi;
        string _checkCode = Kun_Static.CheckCode;
        string poCode = Kun_Static.POCode;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtQrCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadBox();
        }

        private void frmBoxCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
         void LoadBox()
        {
            timer1.Stop();
            string QrCode = txtQrCode.Text;
            if(QrCode.ToUpper() == "YES")
            {
                txtQrCode.SelectAll();
            }
            if (QrCode.Contains("&"))
            {
                string[] array = QrCode.Split('&');
                if (array.Count() != 13)
                {
                    LoadSound("SOUND\\ng1.wav");
                    MessageBox.Show("Thông tin tem sai!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQrCode.SelectAll();
                    return;
                }
                string partCode = array[3];
                string machine = array[9];
                string mold = array[8];
                string lot = array[6]+"&"+partCode+"&"+machine+"&"+mold;
                DateTime dateCheck = DateTime.Now;
                string employess = Kun_Static.EmployessCode;
                int statusCheck = 0;
                int countCheck = int.Parse(array[7]);
                string factory = array[10];
                BoxCheckDTO boxCheckDTO = BoxCheckDAO.Instance.GetItemBoxCheck(QrCode);
                string note = "";
                if (boxCheckDTO == null)
                {
                    List<CheckDeliveryDTO> listC = BoxCheckDAO.Instance.GetCheckDeliveryDTOs(_checkCode, partCode, factory, poCode).Where(x => x.StatusCheck != 1).ToList();
                    if (listC.Count() == 0)
                    {
                        LoadSound("SOUND\\ng1.wav");
                        string msg = "Thông tin tem sai!";
                        MessageBox.Show(msg.ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQrCode.SelectAll();
                        return;
                    }
                    else
                    {
                        int quantityOut = BoxCheckDAO.Instance.SumQuantityOut(_checkCode, partCode, poCode, factory);
                        int quantityCheck = BoxCheckDAO.Instance.SumQuantityCheck(_checkCode, partCode, poCode, factory);
                        if ((quantityCheck + countCheck) > quantityOut)
                        {
                            LoadSound("SOUND\\ng3.wav");
                            lblCountCheck.Text = BoxCheckDAO.Instance.SumQuantityCheckALL(_checkCode, partCode, poCode, factory).ToString() + " Psc";
                            lblCountOut.Text = BoxCheckDAO.Instance.SumQuantityOutALL(_checkCode, partCode, poCode, factory).ToString() + " Psc";
                            string msg = "Số lượng check vượt quá PO";
                            MessageBox.Show(msg.ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtQrCode.SelectAll();
                            return;
                        }
                        List<BoxCheckDTO> listBox = BoxCheckDAO.Instance.GetListBoxCheck(_checkCode);
                        List<BoxCheckDTO> _listBox = listBox.Where(x => x.LotNo == lot).ToList();
                        if (_listBox.Count == 0)
                        {
                            txtQrCode.Enabled = false;
                            LoadSound("SOUND\\lot.wav");
                            txtQrCode.SelectAll();
                            var body = "<size=14><b><color=255, 0, 0>Có lot sản xuất mới\n\nhãy gắn tem lên thùng</color></size></b>";
                            XtraMessageBox.Show(body.ToUpper(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
                            txtQrCode.Enabled = true;
                            txtQrCode.Focus();
                            statusCheck = 1;
                            note = "Lot mới";
                        }
                        int test = 0;
                        foreach (CheckDeliveryDTO item in listC)
                        {
                            long idCheck = item.Id;
                            int quantityC = item.QuantityCheck;
                            int quantityO = item.QuantityOut;
                            if (test > 0)
                            {
                                if (test >= item.QuantityOut)
                                {
                                    BoxCheckDAO.Instance.UpdateStatusCheck(idCheck, 1);
                                    BoxCheckDAO.Instance.UpdateCheck(idCheck, item.QuantityOut);
                                    test = test - item.QuantityOut;
                                }
                                else
                                {
                                    BoxCheckDAO.Instance.UpdateCheck(idCheck, test);
                                    break;
                                }
                            }
                            if ((quantityC + countCheck < quantityO))
                            {
                                BoxCheckDAO.Instance.UpdateCheck(idCheck, quantityC + countCheck);
                                break;
                            }
                            else
                            {
                                BoxCheckDAO.Instance.UpdateStatusCheck(idCheck, 1);
                                BoxCheckDAO.Instance.UpdateCheck(idCheck, item.QuantityOut);
                                test = (quantityC + countCheck) - quantityO;
                                if (test == 0)
                                    break;
                            }
                        }
                        BoxCheckDAO.Instance.InsertBoxCheck(_checkCode, partCode, DateTime.Now, Kun_Static.EmployessCode,
                            countCheck, lot, QrCode, statusCheck, note, mold, machine, poCode);
                        txtQrCode.SelectAll();
                        List<CheckDeliveryDTO> listCheck = BoxCheckDAO.Instance.GetCheckDeliveryDTOs(_checkCode, partCode, factory, poCode).Where(x => x.StatusCheck != 1).ToList();
                        lblCountCheck.Text = BoxCheckDAO.Instance.SumQuantityCheckALL(_checkCode, partCode, poCode, factory).ToString() + " Psc";
                        lblCountOut.Text = BoxCheckDAO.Instance.SumQuantityOutALL(_checkCode, partCode, poCode, factory).ToString() + " Psc";
                        if (listCheck.Count() == 0)
                        {
                            LoadSound("SOUND\\ok.wav");
                            System.Threading.Thread.Sleep(1500);
                            this.Close();
                        }
                    }
                }
                else
                {
                    txtQrCode.SelectAll();
                    LoadSound("SOUND\\ng2.wav");
                }
            }
            else
            {
                MessageBox.Show("mã vạch không đúng!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQrCode.SelectAll();
            }
        }
        void LoadSound(string _filePatch)
        {
            WindowsMediaPlayer sound = new WindowsMediaPlayer();
            string _filePath = _filePatch;
            sound = new WindowsMediaPlayer();
            sound.URL = _filePath;
            sound.controls.play();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<CheckDeliveryDTO> listC = new List<CheckDeliveryDTO>();
            listC = BoxCheckDAO.Instance.GetCheckDeliveryDTOs(_checkCode, 1);
            if (listC.Count > 0)
            {
                MessageBox.Show("bạn chưa check hết số lượng.".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQrCode.SelectAll();
            }
            else
            {
                this.Close();
            }
        }
    }
}