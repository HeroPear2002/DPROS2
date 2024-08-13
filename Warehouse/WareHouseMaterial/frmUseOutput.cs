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
using WareHouse.FParts;
using DevExpress.XtraReports.UI;
using static WareHouse.WareHouseMaterial.frmPourMaterial;

namespace WareHouse.WareHouseMaterial
{
    public partial class frmUseOutput : DevExpress.XtraEditors.XtraForm
    {
        public frmUseOutput()
        {
            InitializeComponent();
            LoadControl();
        }
        OutputMaterial Out = Kun_Static.outputMaterial;
        int check = 0;
        public EventHandler Refreshs;
        string employess = "";
        void LoadControl()
        {
            LoadData();
            txtBarCode.Focus();
            LoadMachineDry();
            LockControl();
        }
        void LoadData()
        {
            string materCode = Out.MaterialCode;
            string materName = MaterialDAO.Instance.GetNameMaterialByCode(materCode);
            int idWH = Out.IdWh;
            string name = WarehouseMaterialDAO.Instance.NameWH(idWH);
            txtMaterialCode.Text = materCode;
            txtMaterialName.Text = materName;
            txtName.Text = name;
            txtMachineCode.Text = Out.MachineCode;
            txtPartCode.Text = Out.PartCode;
            txtQuantityPlan.Text = Out.QuantityPlan.ToString();
            txtQuantityMixPlan.Text = Out.QuantityMixPlan.ToString();
            txtQuantityCyclePlan.Text = Out.QuantityCyclePlan.ToString();

            txtQuantity.Text = Out.QuantityPlan.ToString();

            txtQuantityMax.Text = Out.QuantityMax.ToString();
            txtQuantityMixMax.Text = Out.QuantityMixMax.ToString();
            txtQuantityCycleMax.Text = Out.QuantityCycleMax.ToString();
           

        }
        void LoadMachineDry()
        {
            glMachineDry.Properties.DataSource = MachineDAO.Instance.GetMachineDry();
            glMachineDry.Properties.DisplayMember = "DryCode";
            glMachineDry.Properties.ValueMember = "DryCode";
        }
        void LockControl()
        {
            txtQuantityCycle.Enabled = false;
            txtQuantityMix.Enabled = false;
     
        }
        void OpenControl()
        {
            txtQuantityMix.Enabled = true;
            txtQuantityCycle.Enabled = true;
        }
        void LoadReasonMix()
        {
            cbReasonMix.Properties.DataSource = MaterialDAO.Instance.GetReason("A");
            cbReasonMix.Properties.DisplayMember = "ReasonDetail";
            cbReasonMix.Properties.ValueMember = "ReasonDetail";
        }
        void LoadReasonCycle()
        {
            cbReasonCycle.Properties.DataSource = MaterialDAO.Instance.GetReason("A");
            cbReasonCycle.Properties.DisplayMember = "ReasonDetail";
            cbReasonCycle.Properties.ValueMember = "ReasonDetail";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string materialCode = txtMaterialCode.Text;
            int ratioDefault = MaterialDAO.Instance.RatioByCode(materialCode);
            float quantityPlan = (float)Convert.ToDouble(txtQuantityPlan.Text);
            float quantityMixPlan = (float)Convert.ToDouble(txtQuantityMixPlan.Text);
            float quantityCyclePlan = (float)Convert.ToDouble(txtQuantityCyclePlan.Text);

            float quantityReal = (float)Convert.ToDouble(txtQuantity.Text);
            float quantityMixReal = (float)Convert.ToDouble(txtQuantityMix.Text);
            float quantityCycleReal = (float)Convert.ToDouble(txtQuantityCycle.Text);

            float quantityMax = (float)Convert.ToDouble(txtQuantityMax.Text);
            float quantityMixMax = (float)Convert.ToDouble(txtQuantityMixMax.Text);
            float quantityCycleMax = (float)Convert.ToDouble(txtQuantityCycleMax.Text);

            string machineDry = glMachineDry.Text;
      
            if(quantityReal > quantityMax || quantityMixReal > quantityMixMax || quantityCycleReal > quantityCycleMax||
                (quantityReal+ quantityMixReal+ quantityCycleReal) > (quantityMax+ quantityMixMax+ quantityCycleMax))
            {
                MessageBox.Show("bạn không thể xuất quá số lượng tối đa".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string reasonMix = cbReasonMix.Text;
            string reasonCycle = cbReasonCycle.Text;
            float totalReal = quantityReal + quantityMixReal + quantityCycleReal;
            long IdInput = Out.IdInput;
            string MaterialCode = Out.MaterialCode;
            float totalQuantity = IventoryMaterialDAO.Instance.TotalIventoryByCodeByID(IdInput, MaterialCode);
            float totalreQuantity = IventoryMaterialDAO.Instance.ReQuantitybyIdInput(IdInput);
           if(((totalreQuantity-quantityCycleReal)*100)/(totalQuantity-quantityReal) > ratioDefault)
            {
                MessageBox.Show("bạn đã lấy nhựa sai tỷ lệ nhựa tái chế".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (quantityMixReal != quantityMixPlan && reasonMix.Trim().Length == 0)
            {
                MessageBox.Show("bạn đã chưa chọn lý do xuất nhựa hỗn hợp".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (quantityCycleReal != quantityCyclePlan && reasonCycle.Trim().Length == 0)
            {
                MessageBox.Show("bạn đã chưa chọn lý do xuất nhựa tái chế".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime dateOut = DateTime.Now;
            string style = "Xuất Kho";
            string partCode = Out.PartCode;
            string machineCode = Out.MachineCode;
            string lot = IventoryMaterialDAO.Instance.GetLotByID(IdInput);
            #region Output
            check = 1;
            var body = "<size=14><b><color= 0, 192, 192>Xuất vào máy sấy khay không?</color></size></b>";
            if (XtraMessageBox.Show(body.ToUpper(), "Thông báo",MessageBoxButtons.YesNo,
            MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True) == DialogResult.Yes)
            {
                // Xuất ra máy sấy khay
                List<DryingDTO> dryingDTOs = new List<DryingDTO>();
                if (machineDry.Length == 0)
                {
                    MessageBox.Show("bạn chưa chọn máy sấy khay".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = 0;
                }
                else
                {
                    #region xuất kho
                    if (quantityMixReal > 0)
                    {
                        List<ReIventoryMaterialHH> listR = IventoryMaterialDAO.Instance.GetListMaterialHHByIdInput(IdInput);
                        foreach (ReIventoryMaterialHH item in listR)
                        {
                            long idInputHH = item.Id;
                            float Iventory = item.QuantityInputHH;
                            float b = quantityMixReal - Iventory;
                            if (b <= 0)
                            {
                                IventoryMaterialDAO.Instance.InsertReOutputMaterialHH(idInputHH, dateOut, quantityMixReal, employess, partCode, machineCode, "Máy sấy khay " + machineDry, reasonMix, "", quantityMixPlan);
                                float IventoryHH = IventoryMaterialDAO.Instance.IventoryMaterialHH(item.Id);
                                if (IventoryHH == 0)
                                {
                                    IventoryMaterialDAO.Instance.UpdateStartReInputHH(idInputHH, 1);
                                }
                                break;
                            }
                            else
                            {

                                IventoryMaterialDAO.Instance.InsertReOutputMaterialHH(idInputHH, dateOut, Iventory, employess, partCode, machineCode, "Máy sấy khay " + machineDry, reasonMix, "", quantityMixPlan);
                                float IventoryHH = IventoryMaterialDAO.Instance.IventoryMaterialHH(item.Id);
                                if (IventoryHH == 0)
                                {
                                    IventoryMaterialDAO.Instance.UpdateStartReInputHH(idInputHH, 1);
                                }
                                quantityMixReal = b;
                            }
                        }
                    }
                    if (quantityReal > 0)
                    {
                        IventoryMaterialDTO iventoryMaterialDTO = IventoryMaterialDAO.Instance.GetItem(IdInput);
                        IventoryMaterialDAO.Instance.OutPutMaterial(IdInput, dateOut, quantityReal, employess, style, partCode, machineCode, lot);
                        float Iventory = IventoryMaterialDAO.Instance.IventoryMaterialById(IdInput);
                        if (Iventory == 0)
                        {
                            IventoryMaterialDAO.Instance.UpdateStatust(IdInput, 1);
                            WarehouseMaterialDAO.Instance.UpdateStatus((int)iventoryMaterialDTO.IdWH, 1);
                        }
                        if (quantityCycleReal > 0)
                        {
                            List<ReIventoryMaterial> listRe = IventoryMaterialDAO.Instance.GetListReMaterial().Where(x => x.IdInput == IdInput).ToList();
                            foreach (ReIventoryMaterial item in listRe)
                            {
                                long ReId = item.Id;
                                float ReIventory = item.Quantity;
                                float b = quantityCycleReal - ReIventory;
                                if (b <= 0)
                                {
                                    IventoryMaterialDAO.Instance.OutputMaterialCycle(ReId, dateOut, quantityCycleReal, employess, partCode, machineCode, "Máy sấy khay " + machineDry, reasonCycle, "", quantityCyclePlan);
                                    float IventoryTC = IventoryMaterialDAO.Instance.ReQuantitybyId(ReId);
                                    if (IventoryTC == 0)
                                    {
                                        IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(ReId, 1);
                                    }
                                    LoadControl();
                                    break;
                                }
                                else
                                {

                                    IventoryMaterialDAO.Instance.OutputMaterialCycle(ReId, dateOut, ReIventory, employess, partCode, machineCode, "Máy sấy khay " + machineDry, reasonCycle, "", quantityCyclePlan);
                                    float IventoryTC = IventoryMaterialDAO.Instance.ReQuantitybyId(ReId);
                                    if (IventoryTC == 0)
                                    {
                                        IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(ReId, 1);
                                    }
                                    quantityCycleReal = b;
                                }
                            }
                        }
                    }
                    #endregion
                    float weight = MachineDAO.Instance.WeightTray(machineDry);
                    float total = quantityReal + quantityMixReal + quantityCycleReal;
                    int n = (int)(total / weight);
                    float d = (float)Math.Round((total % weight), 1);
                    for (int i = 1; i <= n; i++)
                    {
                        float we = weight;
                        DryingAndPourDAO.Instance.IsinsertDrying(materialCode, machineDry, we, dateOut.AddMinutes(10), employess, partCode, machineCode, 0, "");
                        long MaxId = DryingAndPourDAO.Instance.MaxIdDrying();
                        DryingDTO dryingDTO = DryingAndPourDAO.Instance.GetItemDry(MaxId);
                        string qrCode = dryingDTO.MaterialCode + "&" + dryingDTO.Id;
                        dryingDTOs.Add(new DryingDTO(dryingDTO.Id, dryingDTO.MaterialCode, dryingDTO.MaterialName, dryingDTO.MachineDry,
                            dryingDTO.QuantityDry, dryingDTO.DateDrying, dryingDTO.DatePour, dryingDTO.Employess, dryingDTO.PartCode, dryingDTO.MachineCode,
                            dryingDTO.StatusDry, qrCode));
                    }
                    if (d > 0)
                    {
                        DryingAndPourDAO.Instance.IsinsertDrying(materialCode, machineDry, d, dateOut.AddMinutes(10), employess, partCode, machineCode, 0, "");
                        long MaxId = DryingAndPourDAO.Instance.MaxIdDrying();
                        DryingDTO dryingDTO = DryingAndPourDAO.Instance.GetItemDry(MaxId);
                        string qrCode = dryingDTO.MaterialCode + "&" + dryingDTO.Id;
                        dryingDTOs.Add(new DryingDTO(dryingDTO.Id, dryingDTO.MaterialCode, dryingDTO.MaterialName, dryingDTO.MachineDry,
                            dryingDTO.QuantityDry, dryingDTO.DateDrying, dryingDTO.DatePour, dryingDTO.Employess, dryingDTO.PartCode, dryingDTO.MachineCode,
                            dryingDTO.StatusDry, qrCode));
                    }
                    rpTemDryMaterial rpTemDry = new rpTemDryMaterial();
                    rpTemDry.DataSource = dryingDTOs;
                    rpTemDry.Print();
                }
            }
            else
            {

                frmPourMaterial f = new frmPourMaterial();
                f.ShowDialog();
                if (CheckPourMaterial.check != 1)
                {
                    MessageBox.Show("bạn chưa check Kangban!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Xuất đi đổ nhựa
                if (quantityMixReal > 0)
                {
                    List<ReIventoryMaterialHH> listR = IventoryMaterialDAO.Instance.GetListMaterialHHByIdInput(IdInput);
                    foreach (ReIventoryMaterialHH item in listR)
                    {
                        long idInputHH = item.Id;
                        float Iventory = item.QuantityInputHH;
                        float b = quantityMixReal - Iventory;
                        if (b <= 0)
                        {
                            IventoryMaterialDAO.Instance.InsertReOutputMaterialHH(idInputHH, dateOut, quantityMixReal, employess, partCode, machineCode, "Xuất đổ nhựa", reasonMix, "", quantityMixPlan);
                            float IventoryHH = IventoryMaterialDAO.Instance.IventoryMaterialHH(item.Id);
                            if (IventoryHH == 0)
                            {
                                IventoryMaterialDAO.Instance.UpdateStartReInputHH(idInputHH, 1);
                            }
                            break;
                        }
                        else
                        {
                            IventoryMaterialDAO.Instance.InsertReOutputMaterialHH(idInputHH, dateOut, Iventory, employess, partCode, machineCode, "Xuất đổ nhựa", reasonMix, "", quantityMixPlan);
                            float IventoryHH = IventoryMaterialDAO.Instance.IventoryMaterialHH(item.Id);
                            if (IventoryHH == 0)
                            {
                                IventoryMaterialDAO.Instance.UpdateStartReInputHH(idInputHH, 1);
                            }
                            quantityMixReal = b;
                        }
                    }
                }
                if (quantityReal > 0)
                {
                    IventoryMaterialDTO iventoryMaterialDTO = IventoryMaterialDAO.Instance.GetItem(IdInput);
                    IventoryMaterialDAO.Instance.OutPutMaterial(IdInput, dateOut, quantityReal, employess, style, partCode, machineCode, lot);
                    float Iventory = IventoryMaterialDAO.Instance.IventoryMaterialById(IdInput);
                    if (Iventory == 0)
                    {
                        IventoryMaterialDAO.Instance.UpdateStatust(IdInput, 1);
                        WarehouseMaterialDAO.Instance.UpdateStatus((int)iventoryMaterialDTO.IdWH, 1);
                    }
                    if (quantityCycleReal > 0)
                    {
                        List<ReIventoryMaterial> listRe = IventoryMaterialDAO.Instance.GetListReMaterial().Where(x => x.IdInput == IdInput).ToList();
                        foreach (ReIventoryMaterial item in listRe)
                        {
                            long ReId = item.Id;
                            float ReIventory = item.Quantity;
                            float b = quantityCycleReal - ReIventory;
                            if (b <= 0)
                            {
                                IventoryMaterialDAO.Instance.OutputMaterialCycle(ReId, dateOut, quantityCycleReal, employess, partCode, machineCode, "Xuất đổ nhựa", reasonCycle, "", quantityCyclePlan);
                                float IventoryTC = IventoryMaterialDAO.Instance.ReQuantitybyId(ReId);
                                if (IventoryTC == 0)
                                {
                                    IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(ReId, 1);
                                }
                                LoadControl();
                                break;
                            }
                            else
                            {

                                IventoryMaterialDAO.Instance.OutputMaterialCycle(ReId, dateOut, ReIventory, employess, partCode, machineCode, "Xuất đổ nhựa", reasonCycle, "", quantityCyclePlan);
                                float IventoryTC = IventoryMaterialDAO.Instance.ReQuantitybyId(ReId);
                                if (IventoryTC == 0)
                                {
                                    IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(ReId, 1);
                                }
                                quantityCycleReal = b;
                            }
                        }
                    }
                }
            }
            float weightOut = (float)Math.Round(CTSXDAO.Instance.GetItem(Out.Id).WeightOut+ totalReal,1);
            CTSXDAO.Instance.UpdateCTSX(Out.Id, weightOut);
            #endregion
            if(check == 1)
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUseOutput_FormClosing(object sender, FormClosingEventArgs e)
        { 
           if(check == 1)
            {
                Refreshs?.Invoke(sender, e);
            }
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = 300;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            CheckBarCode();
        }
        void CheckBarCode()
        {
            string barCode = txtBarCode.Text;
            if(barCode.Contains("&"))
            {
                string[] array = barCode.Split('&');
                string materialCode = Out.MaterialCode;
                int idWH = Out.IdWh;
                string name = WarehouseMaterialDAO.Instance.NameWH(idWH);
                if (materialCode.ToUpper() != array[0].ToUpper())
                {
                    timer1.Stop();
                    MessageBox.Show("mã nguyên liệu không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarCode.SelectAll();
                    return;
                }
                if(name.ToUpper() != array[1].ToUpper())
                {
                    timer1.Stop();
                    MessageBox.Show("vị trí không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarCode.SelectAll();
                    return;
                }
                frmEmployessCode f = new frmEmployessCode();
                f.ShowDialog();
                employess = Kun_Static.EmployessCode;
                int test = EmployessDAO.Instance.TestEmployessByCode(employess);
                if (test == -1)
                {
                    timer1.Stop();
                    MessageBox.Show("mã nhân viên không đúng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OpenControl();
                txtQuantityMix.Focus();
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("mã vạch không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBarCode.SelectAll();
            }
        }

        private void txtQuantityMix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
         (e.KeyChar == '.' && (txtQuantityMix.Text.Length == 0 || txtQuantityMix.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtQuantityCycle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
      (e.KeyChar == '.' && (txtQuantityCycle.Text.Length == 0 || txtQuantityCycle.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtQuantityMix_TextChanged(object sender, EventArgs e)
        {
            float quantityMixReal = (float)Convert.ToDouble(txtQuantityMix.Text);
            float quantityMixPlan = (float)Convert.ToDouble(txtQuantityMixPlan.Text);
            if (quantityMixReal != quantityMixPlan)
            {
                LoadReasonMix();
                cbReasonMix.Enabled = true;
            }
            else
            {
                cbReasonMix.Text = String.Empty;
                cbReasonMix.Enabled = false;
            }
        }

        private void txtQuantityCycle_TextChanged(object sender, EventArgs e)
        {
            float quantityCycleReal = (float)Convert.ToDouble(txtQuantityCycle.Text);
            float quantityCyclePlan = (float)Convert.ToDouble(txtQuantityCyclePlan.Text);
            if (quantityCycleReal != quantityCyclePlan)
            {
                LoadReasonCycle();
                cbReasonCycle.Enabled = true;
            }
            else
            {
                cbReasonCycle.Text = String.Empty;
                cbReasonCycle.Enabled = false;
            }
        }
    }
}