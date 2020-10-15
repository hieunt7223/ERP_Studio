namespace ERP.Component.Libraries
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class ComboBase : XtraUserControl
    {
        private string objectName = "";
        private bool isLoading = false;
        private DataTable dtbBase = null;
        private int? iDBase;
        private float fontSize = 8.25f;
        private object dataSource = null;
        private string displayMember;
        private string valueMember;
        private string hiddenColumnName = string.Empty;
        private string[] columnsCaption = null;
        private string[] fieldsName = null;
        private bool _enterMove = true;
        private int widthOfDropdownGrid;
        private int widthOfIComboBox;
        private IContainer components = null;
        private object value;
        private GridView grvBase;
        public GridLookUpEdit cboBase;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;

        public event ButtonPressedEventHandler ButtonClick;

        public event EventHandler EditValueChanged;

        public ComboBase()
        {
            this.InitializeComponent();
            this.cboBase.EditValueChanged += new EventHandler(this.comboBase_EditValueChanged);
            this.cboBase.ButtonClick += new ButtonPressedEventHandler(this.cboBase_ButtonClick);
            this.cboBase.EnterMoveNextControl = this.EnterMoveNextControl;
            this.cboBase.CustomDisplayText += CboBase_CustomDisplayText;
        }

        private void CboBase_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void cboBase_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if ((e.Button.Kind == ButtonPredefines.Plus) && (this.ButtonClick != null))
            {
                this.ButtonClick(sender, e);
            }
        }

        private void cboBase_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                if (Functions.EditValueIsValid(this.cboBase.EditValue))
                {
                    if (this.cboBase.EditValue.GetType().Name.ToUpper().StartsWith("INT32"))
                    {
                        this.iDBase = (int?) this.cboBase.EditValue;
                    }
                    else
                    {
                        this.EditValue = this.cboBase.EditValue;
                    }
                }
                else
                {
                    this.iDBase = null;
                }
                this.EditValueChanged(sender, e);
            }
        }

        private void cboBase_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void cboBase_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.cboBase.EditValue = null;
            }
        }

        private void comboBase_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void ComboBase_Load(object sender, EventArgs e)
        {
            this.cboBase.Tag = base.Tag;
            this.cboBase.BackColor = Color.White;
            Functions.SetAppearanceDisabled(this.cboBase);
            if (!base.DesignMode)
            {
                this.columnsCaption = null;
                this.fieldsName = null;
                this.ShowData();
                this.cboBase.Properties.View.BestFitColumns();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SerializableAppearanceObject appearance = new SerializableAppearanceObject();
            this.cboBase = new GridLookUpEdit();
            this.grvBase = new GridView();
            this.gridColumn1 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.gridColumn4 = new GridColumn();
            this.gridColumn5 = new GridColumn();
            this.gridColumn6 = new GridColumn();
            this.gridColumn7 = new GridColumn();
            this.cboBase.Properties.BeginInit();
            this.grvBase.BeginInit();
            base.SuspendLayout();
            this.cboBase.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.cboBase.EditValue = "";
            this.cboBase.EnterMoveNextControl = true;
            this.cboBase.Location = new Point(0, 0);
            this.cboBase.Name = "cboBase";
            this.cboBase.Properties.Appearance.BackColor = Color.White;
            this.cboBase.Properties.Appearance.Options.UseBackColor = true;
            this.cboBase.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo), new EditorButton(ButtonPredefines.Plus, "Th\x00eam mới nh\x00e2n vi\x00ean", -1, true, true, false, ImageLocation.MiddleCenter, null, new KeyShortcut(Keys.None), appearance, "Th\x00eam mới nh\x00e2n vi\x00ean", null, null, false) });
            this.cboBase.Properties.NullText = "--Chọn --";
            this.cboBase.Properties.TextEditStyle = TextEditStyles.Standard;
            this.cboBase.Properties.View = this.grvBase;
            this.cboBase.Size = new Size(0xae, 20);
            this.cboBase.TabIndex = 0;
            this.cboBase.EditValueChanged += new EventHandler(this.cboBase_EditValueChanged);
            this.cboBase.KeyDown += new KeyEventHandler(this.cboBase_KeyDown);
            this.cboBase.KeyUp += new KeyEventHandler(this.cboBase_KeyUp);
            this.grvBase.Appearance.HeaderPanel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.grvBase.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBase.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvBase.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            this.grvBase.Columns.AddRange(new GridColumn[] { this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7 });
            this.grvBase.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.grvBase.Name = "grvBase";
            this.grvBase.OptionsBehavior.AllowIncrementalSearch = true;
            this.grvBase.OptionsDetail.SmartDetailHeight = true;
            this.grvBase.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvBase.OptionsView.ShowAutoFilterRow = true;
            this.grvBase.OptionsView.ShowGroupPanel = false;
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn2.Caption = "1";
            this.gridColumn2.FilterMode = ColumnFilterMode.DisplayText;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn3.Caption = "2";
            this.gridColumn3.FilterMode = ColumnFilterMode.DisplayText;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn4.Caption = "3";
            this.gridColumn4.FilterMode = ColumnFilterMode.DisplayText;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn5.Caption = "4";
            this.gridColumn5.FilterMode = ColumnFilterMode.DisplayText;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn6.Caption = "5";
            this.gridColumn6.FilterMode = ColumnFilterMode.DisplayText;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn7.Caption = "6";
            this.gridColumn7.FilterMode = ColumnFilterMode.DisplayText;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoValidate = AutoValidate.Disable;
            base.Controls.Add(this.cboBase);
            base.Name = "ComboBase";
            base.Size = new Size(0xc4, 0x15);
            base.Load += new EventHandler(this.ComboBase_Load);
            this.cboBase.Properties.EndInit();
            this.grvBase.EndInit();
            base.ResumeLayout(false);
        }

        public void RefreshData()
        {
            this.isLoading = true;
            this.cboBase.Properties.DataSource = this.dataSource;
            this.isLoading = false;
        }

        protected void SetToolTip(string toolTipText)
        {
            this.objectName = toolTipText;
            if (this.cboBase.Properties.Buttons.Count > 1)
            {
                this.cboBase.Properties.Buttons[1].ToolTip = $"Thêm mới {this.objectName}";
            }
            this.cboBase.Properties.NullText = $"--Chọn {this.objectName}--";
        }

        public void ShowData()
        {
            if ((((this.columnsCaption != null) && (this.columnsCaption.Length > 0)) && (this.fieldsName != null)) && (this.fieldsName.Length > 0))
            {
                int num2;
                if (this.columnsCaption.Length != this.fieldsName.Length)
                {
                    Functions.MsgBox_Warning("Lỗi load dữ liệu " + base.Name + ": Số captions v\x00e0 số fields phải bằng nhau!");
                    return;
                }
                int num = (this.columnsCaption.Length > this.grvBase.Columns.Count) ? this.grvBase.Columns.Count : this.columnsCaption.Length;
                for (num2 = 0; num2 < num; num2++)
                {
                    this.grvBase.Columns[num2].FieldName = this.fieldsName[num2];
                    this.grvBase.Columns[num2].Caption = this.columnsCaption[num2];
                }
                for (num2 = num; num2 < this.grvBase.Columns.Count; num2++)
                {
                    this.grvBase.Columns[num2].Visible = false;
                }
            }
            this.cboBase.Properties.DisplayMember = this.displayMember;
            this.cboBase.Properties.ValueMember = this.valueMember;
            this.RefreshData();
            if (!string.IsNullOrEmpty(this.hiddenColumnName))
            {
                this.grvBase.Columns[this.hiddenColumnName].Visible = false;
            }
        }

        public string ObjectName
        {
            get => 
                this.objectName;
            set
            {
                if (this.objectName != value)
                {
                    this.objectName = value;
                    this.SetToolTip(this.objectName);
                }
            }
        }

        public override Color BackColor
        {
            get => 
                base.BackColor;
            set => 
                cboBase.BackColor = value;
        }

        public int? IDBase
        {
            get => 
                this.iDBase;
            set
            {
                this.iDBase = value;
                if (!this.iDBase.HasValue)
                {
                    this.EditValue = null;
                }
            }
        }

        public float FontSize
        {
            get => 
                this.fontSize;
            set
            {
                if ((value != this.fontSize) && (value > 0f))
                {
                    this.fontSize = value;
                    this.cboBase.Font = new Font(this.cboBase.Font.FontFamily, this.fontSize);
                    base.Height = this.cboBase.Height;
                }
            }
        }

        public object EditValue
        {
            get => 
                this.cboBase.EditValue;
            set => 
                cboBase.EditValue = value;
        }

        public object DataSource
        {
            get => 
                this.dataSource;
            set
            {
                this.dataSource = value;
                this.cboBase.Properties.DataSource = this.dataSource;
            }
        }

        public string DisplayMember
        {
            get => 
                this.displayMember;
            set => 
                displayMember = value;
        }

        public string ValueMember
        {
            get => 
                this.valueMember;
            set => 
                valueMember = value;
        }

        public override string Text
        {
            get => 
                this.cboBase.Text.Trim();
            set => 
                cboBase.Text = value;
        }

        public string HiddenColumnName
        {
            get => 
                this.hiddenColumnName;
            set
            {
                this.hiddenColumnName = value;
                if (!string.IsNullOrEmpty(this.hiddenColumnName) && (this.grvBase.Columns.ColumnByFieldName(this.hiddenColumnName) != null))
                {
                    this.grvBase.Columns[this.hiddenColumnName].Visible = false;
                }
            }
        }

        public bool ShowButton
        {
            get => 
                this.cboBase.Properties.Buttons[1].Visible;
            set => 
                cboBase.Properties.Buttons[1].Visible = value;
        }

        public string[] ColumnsCaption
        {
            get => 
                this.columnsCaption;
            set
            {
                if (this.columnsCaption != value)
                {
                    this.columnsCaption = value;
                }
            }
        }

        public string[] FieldsName
        {
            get => 
                this.fieldsName;
            set
            {
                if (this.fieldsName != value)
                {
                    this.fieldsName = value;
                }
            }
        }

        public bool EnterMoveNextControl
        {
            get => 
                this._enterMove;
            set =>
                _enterMove = value;
        }

        public TextEditStyles TextEditStyle
        {
            get => 
                this.cboBase.Properties.TextEditStyle;
            set => 
                cboBase.Properties.TextEditStyle = value;
        }

        public DockStyle DockForIComboBox
        {
            get => 
                this.cboBase.Dock;
            set => 
                cboBase.Dock = value;
        }

        public int WidthOfDropdownGrid
        {
            get => 
                this.cboBase.Properties.PopupFormMinSize.Width;
            set
            {
                this.widthOfDropdownGrid = value;
                this.cboBase.Properties.PopupFormMinSize = new Size(this.widthOfDropdownGrid, this.cboBase.Properties.PopupFormMinSize.Height);
            }
        }

        public int WidthOfIComboBox
        {
            get => 
                this.cboBase.Width;
            set
            {
                this.widthOfIComboBox = value;
                this.cboBase.Width = this.widthOfIComboBox;
            }
        }

        public bool GridColumnAutoWidth
        {
            get => 
                this.grvBase.OptionsView.ColumnAutoWidth;
            set => 
                grvBase.OptionsView.ColumnAutoWidth = value;
        }

        public bool ShowAutoFilterRowOfGrid
        {
            get => 
                this.grvBase.OptionsView.ShowAutoFilterRow;
            set => 
                grvBase.OptionsView.ShowAutoFilterRow = value;
        }
    }
}

