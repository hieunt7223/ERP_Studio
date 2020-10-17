using xdcb.FormServices.BaseForm;

namespace xdcb.FormStudio
{
    public partial class FrmOpenModule : DevExpress.XtraEditors.XtraForm
    {
        #region parameter
        //public Modules objModules { get; set; }
        //ContextDb _Context = new ContextDb();
        #endregion

        public FrmOpenModule()
        {
            InitializeComponent();
            SetProperty.InitializeControls(gb_thongtin.Controls);
        }
    }
}