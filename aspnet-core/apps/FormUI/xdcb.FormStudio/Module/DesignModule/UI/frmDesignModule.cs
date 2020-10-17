using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;

namespace xdcb.FormStudio
{
    public partial class frmDesignModule : GGScreen
    {
        #region Property
        private List<GGScreen> lstOpenScreens = new List<GGScreen>();
        public enum SamePosType { Left, Right, Top, Bottom };
        private Control CurrentControl = new Control();
        private Point ptCursorOffset = new Point();

        #endregion

        #region Resizing Control
        public enum ResizingOption
        {
            None,
            ResizeTop,
            ResizeRight,
            ResizeLeft,
            ResizeBottom,
            ResizeTopLeft,
            ResizeTopRight,
            ResizeBottomLeft,
            ResizeBottomRight
        }
        private ResizingOption CurrentResizingOption;
        private int endX;
        private int endY;
        #endregion
        public frmDesignModule()
        {
            InitializeComponent();
        }

        #region Thêm mới Screen
        private void item_ScreenMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            GGScreen scr = new GGScreen();
            string strTemplateScreenName = "gui" + "ScreenMain";
            scr.Name = InitScreenName(strTemplateScreenName);
            scr.Text = scr.Name;
            scr.Tag = "ScreenMain";
            scr.Module = Module;
            lstOpenScreens.Add(scr);
            ShowScreen(scr);
        }
        #endregion

        #region Cấu hình
        private string InitScreenName(string strTemplateScreenName)
        {
            int i = 0;
            string strScreenName = strTemplateScreenName;
            while (IsExistScreenName(strScreenName))
            {
                i++;
                strScreenName = strTemplateScreenName + i.ToString();
            }
            return strScreenName;
        }

        private bool IsExistScreenName(string strScreenName)
        {
            foreach (GGScreen scr in lstOpenScreens)
            {
                if (scr.Name.ToString() == strScreenName)
                {
                    return true;
                }
            }
            return false;
        }


        #endregion

        #region Cấu hình xử lý hiển thị
        private void ShowScreen(GGScreen scr)
        {
            InitializeControls(scr.Controls, scr);
            //scr.TopLevel = false;
            //this.IsMdiContainer = true;
            //pn_view.Controls.Add(scr);
            scr.MdiParent = this;
            scr.ControlBox = true;
            scr.AutoScroll = true;
            scr.AllowDrop = true;
            scr.DragDrop += new DragEventHandler(Screen_DragDrop);
            scr.DragEnter += new DragEventHandler(Screen_DragEnter);
            scr.MouseDown += new MouseEventHandler(Screen_MouseDown);
            scr.Activated += new EventHandler(Screen_Activated);
            scr.Show();
        }

        public void InitializeControls(Control.ControlCollection controls, GGScreen scr)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl, scr);
                if (ctrl.Controls.Count > 0)
                    InitializeControls(ctrl.Controls, scr);
            }
        }

        public Control InitializeControl(Control ctrl, GGScreen scr)
        {
            //GGControlUtil.RemoveControlEvents(ctrl);

            //Set control's properties for customization
            ctrl.Enabled = true;
            if (!String.IsNullOrEmpty(ctrl.Name))
            {
                ctrl.MouseDown += new MouseEventHandler(Ctrl_MouseDown);
                ctrl.MouseMove += new MouseEventHandler(Ctrl_MouseMove);
                ctrl.MouseMove += new MouseEventHandler(Ctrl_Resize);
                ctrl.MouseUp += new MouseEventHandler(Ctrl_MouseUp);
                ctrl.KeyDown += new KeyEventHandler(Ctrl_KeyDown);
                ctrl.KeyUp += new KeyEventHandler(Ctrl_KeyUp);

                if (ctrl.GetType() == typeof(GGTabControl))
                    ctrl.ControlAdded += new ControlEventHandler(TabControl_ControlAdded);
                //if (ctrl.GetType() == typeof(GGLookupEdit))
                //{
                //    GGDbUtil dbUtil = new GGDbUtil();
                //    GGLookupEdit lookupEdit = (GGLookupEdit)(ctrl);
                //    if (dbUtil.IsForeignKey(lookupEdit.GGDataSource, lookupEdit.GGDataMember))
                //    {
                //        lookupEdit.Screen = scr;
                //        lookupEdit.InitLookupEditColumns();
                //    }
                //}
            }
            return ctrl;
        }

        private bool SetParentControl(Control ctrl, Point location)
        {
            return SetParentControl(ctrl, ctrl.Parent, location, 1);
        }
        private bool SetParentControl(Control ctrl, Control originalParent, Point location, int level)
        {
            bool changeParent = false;
            Point upperLeft = new Point(ctrl.Bounds.X, ctrl.Bounds.Y);
            if (ctrl.GetType() != typeof(XtraTabPage))
            {
                //Bring control out of its parent
                if (!ctrl.Parent.ClientRectangle.Contains(upperLeft))
                {
                    if (ctrl.Parent.GetType() != typeof(GGScreen) && ctrl.Parent.GetType().BaseType != typeof(GGScreen))
                    {
                        if (ctrl.Parent.GetType() == typeof(XtraTabPage))
                            ctrl.Parent = ctrl.Parent.Parent.Parent;
                        else
                            ctrl.Parent = ctrl.Parent.Parent;
                        changeParent = true;
                    }
                }
                //Find a new parent
                upperLeft = new Point(ctrl.Bounds.X, ctrl.Bounds.Y);
                foreach (Control ctrl1 in ctrl.Parent.Controls)
                {
                    if (ctrl1.Name != ctrl.Name && ctrl1.Name != originalParent.Name)
                    {
                        if (ctrl1 is GGGroupControl || ctrl1 is XtraTabPage || ctrl1 is GGLine || ctrl1 is GGPanel)
                        {
                            if (ctrl1.Bounds.Contains(upperLeft))
                            {
                                ctrl1.Controls.Add(ctrl);
                                changeParent = true;
                            }
                        }
                        else if (ctrl1 is GGTabControl)
                        {
                            XtraTabPage tabPage = (ctrl1 as GGTabControl).SelectedTabPage;
                            if (tabPage.Name != originalParent.Name)
                            {
                                if (ctrl1.Bounds.Contains(upperLeft))
                                {
                                    tabPage.Controls.Add(ctrl);
                                    changeParent = true;
                                }
                            }
                        }
                    }
                }
            }
            if (changeParent)
            {
                ctrl.Location = ctrl.Parent.PointToClient(location);
                level++;
                if (level <= 5)
                {
                    SetParentControl(ctrl, originalParent, location, level);
                }
            }
            return changeParent;
        }
        #endregion

        #region Screen DragDrop
        public void Screen_DragDrop(object sender, DragEventArgs e)
        {
            GGScreen screen = (GGScreen)sender;
            NavBarItemLink navBarItemLinkControl = GetItemLink(e.Data);
            Point ptLocation = new Point(e.X, e.Y);
            Control ctrl = GenerateControlFromToolbox(navBarItemLinkControl, this.ActiveMdiChild.PointToClient(ptLocation));
            InitializeControl(ctrl, screen);
            SetProperty.SetPropertyValue(ctrl, GGScreen.cstFieldGroupPropertyName, GGScreen.cstFieldGroupCustom);
            this.ActiveMdiChild.Controls.Add(ctrl);
            SetParentControl(ctrl, ptLocation);
        }

        public void Screen_DragEnter(object sender, DragEventArgs e)
        {
            NavBarItemLink link = GetItemLink(e.Data);
            if (link != null && link.Item.Enabled)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.Scroll;
        }

        private void Screen_MouseDown(object sender, MouseEventArgs e)
        {
            fld_prodgcProperty.SelectedObject = sender;
            fld_prodgcProperty.Refresh();
        }

        private void Screen_Activated(object sender, EventArgs e)
        {
            fld_prodgcProperty.SelectedObject = sender;
            fld_prodgcProperty.Refresh();
        }

        private NavBarItemLink GetItemLink(IDataObject data)
        {
            NavBarItemLink ret = data.GetData(typeof(NavBarItemLink)) as NavBarItemLink;
            return ret;
        }

        public Control GenerateControlFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            if (navBarItemLinkControl != null && navBarItemLinkControl.Item.Enabled)
            {
                switch (navBarItemLinkControl.Item.Tag.ToString())
                {
                    case "TextEdit":
                        {
                            GGTextEdit txt = GenerateTextBoxFromToolbox(navBarItemLinkControl, ptLocation);
                            return txt;
                        }
                    case "MemoEdit":
                        {
                            GGMemoEdit med = GenerateMemoEditFromToolbox(navBarItemLinkControl, ptLocation);
                            return med;
                        }
                    case "Button":
                        {
                            GGButton btn = GenerateButtonFromToolbox(navBarItemLinkControl, ptLocation);
                            return btn;
                        }
                    case "Label":
                        {
                            GGLabel lbl = GenerateLabelFromToolbox(navBarItemLinkControl, ptLocation);
                            return lbl;
                        }
                    case "ComboBox":
                        {
                            GGComboBoxEdit cmb = GenerateComboBoxFromToolbox(navBarItemLinkControl, ptLocation);
                            return cmb;
                        }
                    case "DateEdit":
                        {
                            GGDateEdit dte = GenerateDateEditFromToolbox(navBarItemLinkControl, ptLocation);
                            return dte;
                        }
                    case "PictureEdit":
                        {
                            GGPictureEdit pte = GeneratePictureEditFromToolbox(navBarItemLinkControl, ptLocation);
                            return pte;
                        }
                    case "CheckEdit":
                        {
                            GGCheckEdit chk = GenerateCheckEditFromToolbox(navBarItemLinkControl, ptLocation);
                            return chk;
                        }
                    case "GridControl":
                        {
                            GGGridControl grd = GenerateGridControlFromToolbox(navBarItemLinkControl, ptLocation);
                            return grd;
                        }
                    case "TreeList":
                        {
                            GGTreeList tree = GenerateTreeListFromToolbox(navBarItemLinkControl, ptLocation);
                            return tree;
                        }
                    case "GroupControl":
                        {
                            GGGroupControl grp = GenerateGroupControlFromToolbox(navBarItemLinkControl, ptLocation);
                            return grp;
                        }
                    case "TabControl":
                        {
                            GGTabControl tab = GenerateTabControlFromToolbox(navBarItemLinkControl, ptLocation);
                            return tab;
                        }
                    case "RadioGroup":
                        {
                            GGRadioGroup radio = GenerateRadioGroupFromToolbox(navBarItemLinkControl, ptLocation);
                            return radio;
                        }
                    case "ComboBase":
                        {
                            GGComboBase lookup = GenerateComboBaseFromToolbox(navBarItemLinkControl, ptLocation);
                            return lookup;
                        }
                }
            }
            return null;
        }

        #region Generate Controls from Toolbox
        private GGTextEdit GenerateTextBoxFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGTextEdit txt = new GGTextEdit();
            txt.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            txt.Location = ptLocation;
            return txt;
        }

        private GGMemoEdit GenerateMemoEditFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGMemoEdit med = new GGMemoEdit();
            med.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            med.Location = ptLocation;
            return med;
        }

        private GGButton GenerateButtonFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGButton btn = new GGButton();
            btn.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            btn.Location = ptLocation;
            btn.Text = btn.Name.Substring(13);
            return btn;
        }

        private GGLabel GenerateLabelFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGLabel lbl = new GGLabel();
            lbl.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            lbl.Location = ptLocation;
            lbl.Text = lbl.Name.Substring(13);
            return lbl;
        }

        private GGComboBoxEdit GenerateComboBoxFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGComboBoxEdit cmb = new GGComboBoxEdit();
            cmb.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            cmb.Location = ptLocation;
            return cmb;
        }

        private GGDateEdit GenerateDateEditFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGDateEdit dte = new GGDateEdit();
            dte.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            dte.Location = ptLocation;
            return dte;
        }

        private GGPictureEdit GeneratePictureEditFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGPictureEdit pte = new GGPictureEdit();
            pte.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            pte.Location = ptLocation;
            return pte;
        }

        private GGCheckEdit GenerateCheckEditFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGCheckEdit chk = new GGCheckEdit();
            chk.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            chk.Location = ptLocation;
            return chk;
        }

        private GGGridControl GenerateGridControlFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGGridControl grd = new GGGridControl();
            GridView gridView = (GridView)grd.MainView;
            //gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            grd.UseEmbeddedNavigator = true;
            grd.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            grd.Location = ptLocation;
            return grd;
        }

        private GGTreeList GenerateTreeListFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGTreeList grd = new GGTreeList();
            grd.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            grd.Location = ptLocation;
            return grd;
        }

        private GGGroupControl GenerateGroupControlFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGGroupControl grp = new GGGroupControl();
            grp.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            grp.Location = ptLocation;
            return grp;
        }

        private GGRadioGroup GenerateRadioGroupFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGRadioGroup grp = new GGRadioGroup();
            grp.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            grp.Location = ptLocation;
            return grp;
        }

        private GGComboBase GenerateComboBaseFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGComboBase grp = new GGComboBase();
            grp.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            grp.Location = ptLocation;
            return grp;
        }

        private GGTabControl GenerateTabControlFromToolbox(NavBarItemLink navBarItemLinkControl, Point ptLocation)
        {
            GGTabControl tab = new GGTabControl();
            tab.Name = GenerateControlName(navBarItemLinkControl.Item.Tag.ToString());
            tab.Location = ptLocation;
            tab.ControlAdded += new ControlEventHandler(TabControl_ControlAdded);
            DevExpress.XtraTab.XtraTabPage page = new DevExpress.XtraTab.XtraTabPage();
            page.Name = GenerateControlName("TabPage");
            page.Text = "tabPage";
            tab.TabPages.Add(page);
            return tab;
        }
        #endregion

        /// <summary>
        /// Set properties to TabPage when it is added to TabControl manually
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Name = GenerateControlName("TabPage");
            e.Control.Text = "tabPage";
            e.Control.Tag = GGScreen.cstFieldGroupCustom;
        }

        private String GenerateControlNamePrefix(String strControlType)
        {
            String strControlNamePrefix = "fld_";
            switch (strControlType)
            {
                case "TextBox":
                    {
                        strControlNamePrefix += "txt";
                        break;
                    }
                case "MemoEdit":
                    {
                        strControlNamePrefix += "med";
                        break;
                    }
                case "Button":
                    {
                        strControlNamePrefix += "btn";
                        break;
                    }
                case "Label":
                    {
                        strControlNamePrefix += "lbl";
                        break;
                    }
                case "ComboBox":
                    {
                        strControlNamePrefix += "cmb";
                        break;
                    }
                case "DateEdit":
                    {
                        strControlNamePrefix += "dte";
                        break;
                    }
                case "PictureEdit":
                    {
                        strControlNamePrefix += "pte";
                        break;
                    }
                case "CheckEdit":
                    {
                        strControlNamePrefix += "chk";
                        break;
                    }
                case "GridControl":
                    {
                        strControlNamePrefix += "dgc";
                        break;
                    }
                case "GroupControl":
                    {
                        strControlNamePrefix += "grc";
                        break;
                    }
                case "TabControl":
                    {
                        strControlNamePrefix += "tab";
                        break;
                    }
                case "TabPage":
                    {
                        strControlNamePrefix += "tpg";
                        break;
                    }
            }
            return strControlNamePrefix;
        }
        private String GenerateControlName(String templateControlName)
        {
            int i = 1;
            String strTemplateControlName = String.Empty;
            strTemplateControlName = GenerateControlNamePrefix(templateControlName) + GGScreen.cstFieldGroupCustom + templateControlName;
            String strControlName = strTemplateControlName;
            while (true)
            {
                bool flag = false;
                foreach (GGScreen scr in lstOpenScreens)
                {
                    if (scr.Controls.Find(strControlName, true).Length > 0)
                    {
                        strControlName = strTemplateControlName + i.ToString();
                        i++;
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                    break;
            }
            return strControlName;
        }
        #endregion

        #region Control Event Handlers
        private void Ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ptCursorOffset = e.Location;
                Control ctrl = sender as Control;
                if (CurrentResizingOption == ResizingOption.None)
                    ctrl.Cursor = Cursors.SizeAll;
                fld_prodgcProperty.SelectedObject = ctrl;
                fld_prodgcProperty.Refresh();
                UndrawControl(CurrentControl);
                DrawControl(ctrl);
                CurrentControl = ctrl;
            }
        }

        private void Ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (e.Button == MouseButtons.Left && CurrentResizingOption == ResizingOption.None)
            {
                UndrawControl(ctrl);

                //Set new location to control
                Point clientPosition = ctrl.Parent.PointToClient(Cursor.Position);
                int left = clientPosition.X - ptCursorOffset.X;
                int right = left + ctrl.Width;
                int top = clientPosition.Y - ptCursorOffset.Y;
                int bottom = top + ctrl.Height;
                if (ctrl.Left != left || ctrl.Top != top)
                {
                    int minDisX = Int32.MaxValue;
                    int minDisY = Int32.MaxValue;
                    foreach (Control ctrl1 in ctrl.Parent.Controls)
                        if (ctrl1.Visible && ctrl1.Name != ctrl.Name)
                        {
                            if (Math.Abs(ctrl1.Left - left) < Math.Abs(minDisX))
                                minDisX = ctrl1.Left - left;
                            if (Math.Abs(ctrl1.Right - right) < Math.Abs(minDisX))
                                minDisX = ctrl1.Right - right;
                            if (Math.Abs(ctrl1.Top - top) < Math.Abs(minDisY))
                                minDisY = ctrl1.Top - top;
                            if (Math.Abs(ctrl1.Bottom - bottom) < Math.Abs(minDisY))
                                minDisY = ctrl1.Bottom - bottom;
                        }
                    if (Math.Abs(minDisX) <= 5)
                        ctrl.Left = left + minDisX;
                    else
                        ctrl.Left = left;
                    if (Math.Abs(minDisY) <= 5)
                        ctrl.Top = top + minDisY;
                    else
                        ctrl.Top = top;
                }

                if (!SetParentControl(ctrl, new Point(Cursor.Position.X - e.X, Cursor.Position.Y - e.Y)))
                {
                    DrawLineSamePos(ctrl, SamePosType.Left);
                    DrawLineSamePos(ctrl, SamePosType.Top);
                    DrawLineSamePos(ctrl, SamePosType.Right);
                    DrawLineSamePos(ctrl, SamePosType.Bottom);
                }
            }
        }

        private void Ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                UndrawControl(ctrl);
                DrawControl(ctrl);
                CurrentResizingOption = ResizingOption.None;
            }
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            Control ctrl = CurrentControl;
            if (!String.IsNullOrEmpty(ctrl.Name))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        UndrawControl(ctrl);
                        ctrl.Top -= 1;
                        SetParentControl(ctrl, ctrl.Parent.PointToScreen(ctrl.Location));
                        break;
                    case Keys.Down:
                        UndrawControl(ctrl);
                        ctrl.Top += 1;
                        SetParentControl(ctrl, ctrl.Parent.PointToScreen(ctrl.Location));
                        break;
                    case Keys.Left:
                        UndrawControl(ctrl);
                        ctrl.Left -= 1;
                        SetParentControl(ctrl, ctrl.Parent.PointToScreen(ctrl.Location));
                        break;
                    case Keys.Right:
                        UndrawControl(ctrl);
                        ctrl.Left += 1;
                        SetParentControl(ctrl, ctrl.Parent.PointToScreen(ctrl.Location));
                        break;
                }
            }
        }

        private void Ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            Control ctrl = CurrentControl;
            if (!String.IsNullOrEmpty(ctrl.Name))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Left:
                    case Keys.Right:
                        DrawControl(ctrl);
                        break;
                    case Keys.Delete:
                        if (ctrl.Visible)
                        {
                            RemoveControl(ctrl);
                            UndrawControl(ctrl);
                            AddAvailableFields(ctrl);
                        }
                        break;
                }
            }
        }

        private void Ctrl_Resize(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.GetType() != typeof(GGLabel))
            {
                endX = e.X + ctrl.Location.X;
                endY = e.Y + ctrl.Location.Y;
                if (e.Button == MouseButtons.Left)
                {
                    UndrawControl(ctrl);
                    ResizeControl(ctrl, e);
                }
                else
                {
                    SetResizingOption(ctrl, e);
                }
            }
        }

        private void SetResizingOption(Control ctrl, MouseEventArgs e)
        {
            //TopLeft
            if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y, 5, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeTopLeft;
            //TopRight
            else if (new Rectangle(ctrl.Bounds.X + ctrl.Bounds.Width - 2, ctrl.Bounds.Y, 5, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeTopRight;
            //BottomRight
            else if (new Rectangle(ctrl.Bounds.X + ctrl.Bounds.Width - 2, ctrl.Bounds.Y + ctrl.Bounds.Height - 2, 5, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeBottomRight;
            //BottomLeft
            else if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y + ctrl.Bounds.Height - 2, 5, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeBottomLeft;
            //Top
            else if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y, ctrl.Bounds.Width, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeTop;
            //Right
            else if (new Rectangle(ctrl.Bounds.X + ctrl.Bounds.Width - 2, ctrl.Bounds.Y, 5, ctrl.Bounds.Height).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeRight;
            //Bottom
            else if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y + ctrl.Bounds.Height - 2, ctrl.Bounds.Width, 5).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeBottom;
            //Left
            else if (new Rectangle(ctrl.Bounds.X, ctrl.Bounds.Y, 5, ctrl.Bounds.Height).Contains(endX, endY))
                CurrentResizingOption = ResizingOption.ResizeLeft;
            else
                CurrentResizingOption = ResizingOption.None;

            switch (CurrentResizingOption)
            {
                case ResizingOption.ResizeTopLeft:
                    ctrl.Cursor = Cursors.SizeNWSE;
                    break;
                case ResizingOption.ResizeTop:
                    ctrl.Cursor = Cursors.SizeNS;
                    break;
                case ResizingOption.ResizeTopRight:
                    ctrl.Cursor = Cursors.SizeNESW;
                    break;
                case ResizingOption.ResizeRight:
                    ctrl.Cursor = Cursors.SizeWE;
                    break;
                case ResizingOption.ResizeBottomRight:
                    ctrl.Cursor = Cursors.SizeNWSE;
                    break;
                case ResizingOption.ResizeBottom:
                    ctrl.Cursor = Cursors.SizeNS;
                    break;
                case ResizingOption.ResizeBottomLeft:
                    ctrl.Cursor = Cursors.SizeNESW;
                    break;
                case ResizingOption.ResizeLeft:
                    ctrl.Cursor = Cursors.SizeWE;
                    break;
                default:
                    ctrl.Cursor = Cursors.Arrow;
                    break;
            }
        }

        private void ResizeControl(Control ctrl, MouseEventArgs e)
        {
            int height, width;
            width = e.X - ctrl.Width;
            height = e.Y - ctrl.Height;

            if (e.Button == MouseButtons.Left)
            {
                //New location of the ctrl
                int x, y;
                switch (CurrentResizingOption)
                {
                    case ResizingOption.ResizeBottom:
                        if (endY <= ctrl.Location.Y + 4)
                            height = 4;
                        else
                            height = endY - ctrl.Location.Y;
                        ctrl.Height = height;
                        break;
                    case ResizingOption.ResizeBottomLeft:
                        if (endX >= ctrl.Location.X + ctrl.Width - 4)
                        {
                            x = ctrl.Location.X + ctrl.Width - 4;
                            width = 4;
                        }
                        else
                        {
                            x = endX;
                            width = Math.Abs(ctrl.Location.X + ctrl.Width - endX);
                        }
                        if (endY <= ctrl.Location.Y + 4)
                            height = 4;
                        else
                            height = Math.Abs(endY - ctrl.Location.Y);
                        ctrl.Location = new System.Drawing.Point(x, ctrl.Location.Y);
                        ctrl.Width = width;
                        ctrl.Height = height;
                        break;
                    case ResizingOption.ResizeBottomRight:
                        if (endY <= ctrl.Location.Y + 4)
                            height = 4;
                        else
                            height = Math.Abs(endY - ctrl.Location.Y);
                        if (endX <= ctrl.Location.X + 4)
                            width = 4;
                        else
                            width = Math.Abs(endX - ctrl.Location.X);
                        ctrl.Width = width;
                        ctrl.Height = height;
                        break;
                    case ResizingOption.ResizeLeft:
                        if (endX >= ctrl.Location.X + ctrl.Width - 4)
                        {
                            x = ctrl.Location.X + ctrl.Width - 4;
                            width = 4;
                        }
                        else
                        {
                            x = endX;
                            width = Math.Abs(ctrl.Location.X + ctrl.Width - endX);
                        }
                        ctrl.Location = new System.Drawing.Point(x, ctrl.Location.Y);
                        ctrl.Width = width;
                        break;
                    case ResizingOption.ResizeRight:
                        if (endX <= ctrl.Location.X + 4)
                            width = 4;
                        else
                            width = Math.Abs(endX - ctrl.Location.X);
                        ctrl.Width = width;
                        break;
                    case ResizingOption.ResizeTop:
                        if (endY >= ctrl.Location.Y + ctrl.Height - 4)
                        {
                            height = 4;
                            y = ctrl.Location.Y + ctrl.Height - 4;
                        }
                        else
                        {
                            height = Math.Abs(ctrl.Height + ctrl.Location.Y - endY);
                            y = endY;
                        }
                        ctrl.Location = new System.Drawing.Point(ctrl.Location.X, y);
                        ctrl.Height = height;
                        break;
                    case ResizingOption.ResizeTopLeft:
                        if (endY >= ctrl.Location.Y + ctrl.Height - 4)
                        {
                            height = 4;
                            y = ctrl.Location.Y + ctrl.Height - 4;
                        }
                        else
                        {
                            height = Math.Abs(ctrl.Height + ctrl.Location.Y - endY);
                            y = endY;
                        }
                        if (endX >= ctrl.Location.X + ctrl.Width - 4)
                        {
                            x = ctrl.Location.X + ctrl.Width - 4;
                            width = 4;
                        }
                        else
                        {
                            x = endX;
                            width = Math.Abs(ctrl.Location.X + ctrl.Width - endX);
                        }
                        ctrl.Location = new System.Drawing.Point(x, y);
                        ctrl.Width = width;
                        ctrl.Height = height;
                        break;
                    case ResizingOption.ResizeTopRight:
                        if (endY >= ctrl.Location.Y + ctrl.Height - 4)
                        {
                            height = 4;
                            y = ctrl.Location.Y + ctrl.Height - 4;
                        }
                        else
                        {
                            height = Math.Abs(ctrl.Height + ctrl.Location.Y - endY);
                            y = endY;
                        }
                        if (endX <= ctrl.Location.X + 4)
                            width = 4;
                        else
                            width = Math.Abs(endX - ctrl.Location.X);
                        ctrl.Location = new System.Drawing.Point(ctrl.Location.X, y);
                        ctrl.Width = width;
                        ctrl.Height = height;
                        break;
                    default:
                        break;
                }
            }
        }

        private void RemoveScreen(GGScreen screen)
        {
            RemoveControl(screen);
            AddAvailableFields(screen.Controls);
            screen.Visible = false;
        }

        private void RemoveControl(Control ctrl)
        {
            ctrl.Visible = false;
            foreach (Control childControl in ctrl.Controls)
                RemoveControl(childControl);
        }

        private void DrawLineSamePos(Control ctrl, SamePosType type)
        {
            Point minPos = new Point();
            Point maxPos = new Point();
            List<Control> lstSamePosControl = GetAllControlSamePos(ctrl, type, ref minPos, ref maxPos);
            if (lstSamePosControl.Count > 1)
            {
                Graphics grph = Graphics.FromHwnd(ctrl.Parent.Handle);
                grph.DrawLine(new Pen(Color.Blue, 2), minPos, maxPos);
            }
        }

        private List<Control> GetAllControlSamePos(Control ctrl, SamePosType type, ref Point minPos, ref Point maxPos)
        {
            //Get start, end position of line   
            minPos.X = Int32.MaxValue;
            minPos.Y = Int32.MaxValue;
            maxPos.X = 0;
            maxPos.Y = 0;
            foreach (Control ctrl1 in ctrl.Parent.Controls)
            {
                switch (type)
                {
                    case SamePosType.Left:
                        minPos.X = ctrl.Left;
                        maxPos.X = ctrl.Left;
                        if (ctrl1.Left == ctrl.Left)
                        {
                            if (minPos.Y > ctrl1.Top)
                                minPos.Y = ctrl1.Top;
                            if (maxPos.Y < ctrl1.Bottom)
                                maxPos.Y = ctrl1.Bottom;
                        }
                        break;
                    case SamePosType.Top:
                        minPos.Y = ctrl.Top;
                        maxPos.Y = ctrl.Top;
                        if (ctrl1.Top == ctrl.Top)
                        {
                            if (minPos.X > ctrl1.Left)
                                minPos.X = ctrl1.Left;
                            if (maxPos.X < ctrl1.Right)
                                maxPos.X = ctrl1.Right;
                        }
                        break;
                    case SamePosType.Right:
                        minPos.X = ctrl.Right;
                        maxPos.X = ctrl.Right;
                        if (ctrl1.Right == ctrl.Right)
                        {
                            if (minPos.Y > ctrl1.Top)
                                minPos.Y = ctrl1.Top;
                            if (maxPos.Y < ctrl1.Bottom)
                                maxPos.Y = ctrl1.Bottom;
                        }
                        break;
                    case SamePosType.Bottom:
                        minPos.Y = ctrl.Bottom;
                        maxPos.Y = ctrl.Bottom;
                        if (ctrl1.Bottom == ctrl.Bottom)
                        {
                            if (minPos.X > ctrl1.Left)
                                minPos.X = ctrl1.Left;
                            if (maxPos.X < ctrl1.Right)
                                maxPos.X = ctrl1.Right;
                        }
                        break;
                }
            }

            //Get all relative controls of line
            List<Control> rs = new List<Control>();
            foreach (Control ctrl1 in ctrl.Parent.Controls)
            {
                switch (type)
                {
                    case SamePosType.Left:
                        if (ctrl1.Left <= ctrl.Left && ctrl1.Right >= ctrl.Left && ctrl1.Top >= minPos.Y && ctrl1.Bottom <= maxPos.Y)
                            rs.Add(ctrl1);
                        break;
                    case SamePosType.Top:
                        if (ctrl1.Top <= ctrl.Top && ctrl1.Bottom >= ctrl.Top && ctrl1.Left >= minPos.X && ctrl1.Right <= maxPos.X)
                            rs.Add(ctrl1);
                        break;
                    case SamePosType.Right:
                        if (ctrl1.Left <= ctrl.Right && ctrl1.Right >= ctrl.Right && ctrl1.Top >= minPos.Y && ctrl1.Bottom <= maxPos.Y)
                            rs.Add(ctrl1);
                        break;
                    case SamePosType.Bottom:
                        if (ctrl1.Top <= ctrl.Bottom && ctrl1.Bottom >= ctrl.Bottom && ctrl1.Left >= minPos.X && ctrl1.Right <= maxPos.X)
                            rs.Add(ctrl1);
                        break;
                }
            }
            return rs;
        }

        private void DrawControl(Control ctrl)
        {
            Graphics grph = Graphics.FromHwnd(ctrl.Parent.Handle);
            grph.DrawRectangle(new Pen(Color.Red, 2), ctrl.Bounds);
        }

        private void UndrawControl(Control ctrl)
        {
            if (ctrl != null && ctrl.Parent != null)
            {
                ctrl.Parent.Refresh();
            }
            else
                this.Refresh();
        }
        #endregion

        #region AvailableFields
        private void AddAvailableFields(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                AddAvailableFields(ctrl);
            }
        }

        private void AddAvailableFields(Control ctrl)
        {
            //If its container is TabPage, show TabPage first to invalidate control's visibility
            if (ctrl.Parent != null && ctrl.Parent.GetType() == typeof(DevExpress.XtraTab.XtraTabPage))
                ctrl.Parent.Show();

            if (ctrl.Visible == false)
            {
                if (!String.IsNullOrEmpty(GetProperty.GetPropertyStringValue(ctrl, GGScreen.cstDataSourcePropertyName)))
                {
                    //Create new item link
                    NavBarItem item = new NavBarItem();
                    item.Caption = GetProperty.GetPropertyStringValue(ctrl, GGScreen.cstDescriptionPropertyName);
                    if (String.IsNullOrEmpty(item.Caption))
                        item.Caption = GetProperty.GetPropertyStringValue(ctrl, GGScreen.cstDataMemberPropertyName);
                    if (String.IsNullOrEmpty(item.Caption))
                        item.Caption = GetProperty.GetPropertyStringValue(ctrl, GGScreen.cstDataSourcePropertyName);
                    if (!String.IsNullOrEmpty(item.Caption))
                    {
                        item.Hint = ctrl.Name;
                        String controlTypeName = ctrl.GetType().Name;
                        if (controlTypeName.Contains("GridControl"))
                            item.SmallImage = fld_imgcltImage.Images["GGGridControl.png"];
                        else if (controlTypeName.Contains("TreeListControl"))
                            item.SmallImage = fld_imgcltImage.Images["GGTreeListControl.png"];
                        else
                            item.SmallImage = fld_imgcltImage.Images[ctrl.GetType().Name + ".png"];
                    }
                }
                else
                {
                    ctrl.Location = new Point(Int32.MaxValue, Int32.MaxValue);
                }
            }
            if (ctrl.Controls.Count > 0)
                AddAvailableFields(ctrl.Controls);
        }
        #endregion
    }
}