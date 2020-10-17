using System;
using System.Linq;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.KeHoachTongNguon
{
    public partial class guiCreate : GGScreenDetail
    {
        public string nam;
        public string loaikehoach;
        public guiCreate()
        {
            InitializeComponent();
            GetValueControl();
        }

        public void GetValueControl()
        {
            //Nam
            cbe_nam.Properties.Items.AddRange(GGFunctions.GetValueNam());

            //LoaiKeHoach
            cbb_LoaiKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_LoaiKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_LoaiKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_LoaiKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_LoaiKeHoach.DataSource = typeof(LoaiKeHoachTongNguon).ToList();
            cbb_LoaiKeHoach.ShowData();
        }

        private void btn_dongy_Click(object sender, EventArgs e)
        {
            if (cbe_nam.EditValue == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn năm!");
                return;
            }
            nam = cbe_nam.EditValue.ToString();
            if (cbb_LoaiKeHoach.EditValue == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn loại kế hoạch!");
                return;
            }
            loaikehoach = cbb_LoaiKeHoach.EditValue.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}