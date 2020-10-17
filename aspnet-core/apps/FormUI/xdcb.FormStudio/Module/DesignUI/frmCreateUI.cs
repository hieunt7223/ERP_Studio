using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.IO;
using System.Collections.Specialized;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;

namespace xdcb.FormStudio
{
    public partial class frmCreateUI : XtraUserControl
    {
        #region Attribute Design UI
        const int DRAG_HANDLE_SIZE = 7;
        int mouseX, mouseY;
        Control SelectedControl;
        Control copiedControl;
        Direction direction;
        Point newLocation;
        Size newSize;
        string[] gParam = null;
        Bitmap MemoryImage;
        String xmlFileName = "";
        String xmlFileName_Query = "";
        bool cutCheck = false;
        bool copyCheck = false;
        private ToolTip tt;
        // Adding a private font (Win2000 and later)
        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern IntPtr AddFontMemResourceEx(byte[] pbFont, int cbFont, IntPtr pdv, out uint pcFonts);

        // Cleanup of a private font (Win2000 and later)
        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern bool RemoveFontMemResourceEx(IntPtr fh);

        // Some private holders of font information we are loading
        static private IntPtr m_fh = IntPtr.Zero;
        static private PrivateFontCollection m_pfc = null;
        string[] gParamPop = null;
        // To set the SQL parameter.
        List<String> ControlNames = new List<String>();
        enum Direction
        {
            NW,
            N,
            NE,
            W,
            E,
            SW,
            S,
            SE,
            None
        }

        #endregion

        #region Attribute action
        public string btnAction;

        //ContextDb _context = new ContextDb();
        //Modules objModules;
        public int IDModule;

        public string PathUI;

        #endregion

        #region LoadForm
        public frmCreateUI()
        {
            InitializeComponent();

            pnControls.Controls.Clear();
            pnControls.Size = new Size(Convert.ToInt32(1000), Convert.ToInt32(500));
            InvalidateToolBar();

        }
        #endregion

        #region Action Control
        private void CheckboxTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String chkName = "chk_" + randNumber;

            GGCheckEdit ctrl = new GGCheckEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = chkName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGCheckEdit";
            ctrl.BringToFront();
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void TextEditTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "txt_" + randNumber;

            GGTextEdit ctrl = new GGTextEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGTextEdit";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void ComboBaseTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "cbb_" + randNumber;

            GGComboBase ctrl = new GGComboBase();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGComboBase";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void ComboBoxEditTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "cbe_" + randNumber;

            GGComboBoxEdit ctrl = new GGComboBoxEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGComboBoxEdit";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void FontEditTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "fed_" + randNumber;

            GGFontEdit ctrl = new GGFontEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGFontEdit";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void GridControlTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "gcl_" + randNumber;

            GGGridControl ctrl = new GGGridControl();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGGridControl";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void GroupControlTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "gcl_" + randNumber;

            GGGroupControl ctrl = new GGGroupControl();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGGroupControl";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void LabelTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "lbl_" + randNumber;

            GGLabel ctrl = new GGLabel();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGLabel";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void ButtonTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "btn_" + randNumber;

            GGButton ctrl = new GGButton();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGButton";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void ButtonEditTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "btne_" + randNumber;

            GGButtonEdit ctrl = new GGButtonEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGButtonEdit";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void DateEditTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "dte_" + randNumber;

            GGDateEdit ctrl = new GGDateEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGDateEdit";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void HyperLinkEditTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "hle_" + randNumber;

            GGHyperLinkEdit ctrl = new GGHyperLinkEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGHyperLinkEdit";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void GroupBoxTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "gbx_" + randNumber;

            GGGroupBox ctrl = new GGGroupBox();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGGroupBox";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void MemoEditTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "mme_" + randNumber;

            GGMemoEdit ctrl = new GGMemoEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGMemoEdit";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void PanelTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "pnl_" + randNumber;

            GGPanel ctrl = new GGPanel();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGPanel";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void RadioGroupTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "rgp_" + randNumber;

            GGRadioGroup ctrl = new GGRadioGroup();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGRadioGroup";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void PictureEditTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "pic_" + randNumber;

            GGPictureEdit ctrl = new GGPictureEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGPictureEdit";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void TabControlTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "tab_" + randNumber;

            GGTabControl ctrl = new GGTabControl();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGTabControl";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void TimeEditTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "tie_" + randNumber;

            GGTimeEdit ctrl = new GGTimeEdit();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGTimeEdit";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        private void TreeListTool_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String textName = "tre_" + randNumber;

            GGTreeList ctrl = new GGTreeList();
            ctrl.Location = new Point(30, 30);
            ctrl.Name = textName;
            ctrl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "GGTreeList";

            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
        }

        #endregion

        #region Kéo thả các Control
        /// <summary>
        /// RUN time Control Mouse Down Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pnControls.Invalidate();  //unselect other control
                SelectedControl = (Control)sender;
                Control control = (Control)sender;
                mouseX = -e.X;
                mouseY = -e.Y;
                control.Invalidate();
                DrawControlBorder(sender);
                propertyGrid1.SelectedObject = SelectedControl;
                //if (control is DataGridView)
                //{
                //    txtControltoBind.Text = control.Name.ToString();
                //}
                //else if (control is TextBox)
                //{
                //    txtTextBox1.Text = control.Name.ToString();
                //}
            }
        }

        /// <summary>
        /// RUN time Control Mouse Move Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                Point nextPosition = new Point();
                nextPosition = pnControls.PointToClient(MousePosition);
                nextPosition.Offset(mouseX, mouseY);
                control.Location = nextPosition;
                Invalidate();
            }
        }

        /// <summary>
        /// RUN time Control Mouse Up Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                Cursor.Clip = System.Drawing.Rectangle.Empty;
                control.Invalidate();
                DrawControlBorder(control);
            }
        }

        /// <summary>
        /// RUN time Control Mouse Enter Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            Cursor = Cursors.SizeAll;
            Control control = (Control)sender;
            tt = new ToolTip();
            tt.InitialDelay = 0;
            tt.IsBalloon = true;
            tt.Show(control.Name.ToString(), control);
        }

        /// <summary>
        /// RUN time Control Mouse Leave Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        private void control_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            tt.Dispose();
            timer1.Start();
        }

        /// <summary>
        /// Draw a border and drag handles around the control, on mouse down and up.
        /// </summary>
        /// <param name="sender"></param>
        private void DrawControlBorder(object sender)
        {
            Control control = (Control)sender;
            //define the border to be drawn, it will be offset by DRAG_HANDLE_SIZE / 2
            //around the control, so when the drag handles are drawn they will be seem
            //connected in the middle.
            Rectangle Border = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE / 2),
                new Size(control.Size.Width + DRAG_HANDLE_SIZE,
                    control.Size.Height + DRAG_HANDLE_SIZE));
            //define the 8 drag handles, that has the size of DRAG_HANDLE_SIZE
            Rectangle NW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle N = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle NE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle W = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle E = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle S = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));

            //get the form graphic
            Graphics g = pnControls.CreateGraphics();
            //draw the border and drag handles
            ControlPaint.DrawBorder(g, Border, Color.Gray, ButtonBorderStyle.Dotted);
            ControlPaint.DrawGrabHandle(g, NW, true, true);
            ControlPaint.DrawGrabHandle(g, N, true, true);
            ControlPaint.DrawGrabHandle(g, NE, true, true);
            ControlPaint.DrawGrabHandle(g, W, true, true);
            ControlPaint.DrawGrabHandle(g, E, true, true);
            ControlPaint.DrawGrabHandle(g, SW, true, true);
            ControlPaint.DrawGrabHandle(g, S, true, true);
            ControlPaint.DrawGrabHandle(g, SE, true, true);
            g.Dispose();
        }
        #endregion

        #region Event Panel Control

        private void pnControls_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedControl != null)
                DrawControlBorder(SelectedControl);
            timer1.Start();
        }

        private void pnControls_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedControl != null && e.Button == MouseButtons.Left)
            {
                timer1.Stop();
                Invalidate();

                if (SelectedControl.Height < 20)
                {
                    SelectedControl.Height = 20;
                    direction = Direction.None;
                    Cursor = Cursors.Default;
                    return;
                }
                else if (SelectedControl.Width < 20)
                {
                    SelectedControl.Width = 20;
                    direction = Direction.None;
                    Cursor = Cursors.Default;
                    return;
                }

                //get the current mouse position relative the the app
                Point pos = pnControls.PointToClient(MousePosition);

                #region resize the control in 8 directions
                if (direction == Direction.NW)
                {
                    //north west, location and width, height change
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Size.Width - (newLocation.X - SelectedControl.Location.X),
                        SelectedControl.Size.Height - (newLocation.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SE)
                {
                    //south east, width and height change
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Size.Width + (newLocation.X - SelectedControl.Size.Width - SelectedControl.Location.X),
                        SelectedControl.Height + (newLocation.Y - SelectedControl.Height - SelectedControl.Location.Y));
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.N)
                {
                    //north, location and height change
                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.S)
                {
                    //south, only the height changes
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(SelectedControl.Width,
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.W)
                {
                    //west, location and width will change
                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        SelectedControl.Height);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.E)
                {
                    //east, only width changes
                    newLocation = new Point(pos.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height);
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.SW)
                {
                    //south west, location, width and height change
                    newLocation = new Point(pos.X, SelectedControl.Location.Y);
                    newSize = new Size(SelectedControl.Width - (pos.X - SelectedControl.Location.X),
                        pos.Y - SelectedControl.Location.Y);
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                else if (direction == Direction.NE)
                {
                    //north east, location, width and height change
                    newLocation = new Point(SelectedControl.Location.X, pos.Y);
                    newSize = new Size(pos.X - SelectedControl.Location.X,
                        SelectedControl.Height - (pos.Y - SelectedControl.Location.Y));
                    SelectedControl.Location = newLocation;
                    SelectedControl.Size = newSize;
                }
                #endregion
            }
        }
        #endregion

        #region Event Time
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Get the direction and display correct cursor
            if (SelectedControl != null)
            {
                Point pos = pnControls.PointToClient(MousePosition);
                //check if the mouse cursor is within the drag handle
                if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                    pos.X <= SelectedControl.Location.X) &&
                    (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y))
                {
                    direction = Direction.NW;
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                {
                    direction = Direction.SE;
                    Cursor = Cursors.SizeNWSE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                    pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y)
                {
                    direction = Direction.N;
                    Cursor = Cursors.SizeNS;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width / 2 - DRAG_HANDLE_SIZE / 2) &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width / 2 + DRAG_HANDLE_SIZE / 2 &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE)
                {
                    direction = Direction.S;
                    Cursor = Cursors.SizeNS;
                }
                else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                    pos.X <= SelectedControl.Location.X &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                {
                    direction = Direction.W;
                    Cursor = Cursors.SizeWE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE &&
                    pos.Y >= SelectedControl.Location.Y + SelectedControl.Height / 2 - DRAG_HANDLE_SIZE / 2 &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height / 2 + DRAG_HANDLE_SIZE / 2))
                {
                    direction = Direction.E;
                    Cursor = Cursors.SizeWE;
                }
                else if ((pos.X >= SelectedControl.Location.X + SelectedControl.Width &&
                    pos.X <= SelectedControl.Location.X + SelectedControl.Width + DRAG_HANDLE_SIZE) &&
                    (pos.Y >= SelectedControl.Location.Y - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y))
                {
                    direction = Direction.NE;
                    Cursor = Cursors.SizeNESW;
                }
                else if ((pos.X >= SelectedControl.Location.X - DRAG_HANDLE_SIZE &&
                    pos.X <= SelectedControl.Location.X + DRAG_HANDLE_SIZE) &&
                    (pos.Y >= SelectedControl.Location.Y + SelectedControl.Height - DRAG_HANDLE_SIZE &&
                    pos.Y <= SelectedControl.Location.Y + SelectedControl.Height + DRAG_HANDLE_SIZE))
                {
                    direction = Direction.SW;
                    Cursor = Cursors.SizeNESW;
                }
                else
                {
                    Cursor = Cursors.Default;
                    direction = Direction.None;
                }
            }
            else
            {
                direction = Direction.None;
                Cursor = Cursors.Default;
            }
            #endregion
        }
        #endregion

        #region Xóa Control
        private void btn_DeleteControl_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Save UI
        private void btnSaveUI_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Tạo mới từ thiết kế có sẳn

        private void stm_CreateNewByUI_Click(object sender, EventArgs e)
        {
            btnAction = ButtonAction.btnNew.ToString();
            InvalidateToolBar();
            FrmOpenModule frm = new FrmOpenModule();
            if (frm != null)
            {
                frm.Dock = DockStyle.Fill;
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    btnAction = ButtonAction.btnCancel.ToString();
                    InvalidateToolBar();
                    return;
                }
                //objModules = frm.objModules;
            }
        }

        #endregion

        #region Thiết kế UI mới
        private void stm_CreateNew_Click(object sender, EventArgs e)
        {
            btnAction = ButtonAction.btnNew.ToString();
            InvalidateToolBar();
            frmAddModule frm = new frmAddModule();
            if (frm != null)
            {
                frm.Dock = DockStyle.Fill;
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    btnAction = ButtonAction.btnCancel.ToString();
                    InvalidateToolBar();
                    return;
                }
                //objModules = frm.objModules;
            }

        }
        #endregion

        #region sửa
        private void stm_Edit_Click(object sender, EventArgs e)
        {
            btnAction = ButtonAction.btnEdit.ToString();
            InvalidateToolBar();
        }
        #endregion

        #region Hủy thiết kế
        private void stm_Cancel_Click(object sender, EventArgs e)
        {
            btnAction = ButtonAction.btnCancel.ToString();
            InvalidateToolBar();
        }
        #endregion

        #region Xóa thiết kế
        private void stm_Delete_Click(object sender, EventArgs e)
        {
            btnAction = ButtonAction.btnDelete.ToString();
            InvalidateToolBar();
        }
        #endregion

        #region Lưu thiết kế
        private void smt_Save_Click(object sender, EventArgs e)
        {
            btnAction = ButtonAction.btnSave.ToString();
            if (pnControls.Controls.Count > 0)
            {
                Random rnd = new Random();
                int randNumber = rnd.Next(1, 1000);
                string SaveFileName = "File_" + randNumber.ToString();
                SaveToJson(pnControls.Controls);

                //objModules.ModuleHeight = pnControls.Height;
                //objModules.ModuleWidth = pnControls.Width;

                //_context.Modules.Add(objModules);
                //objModules.ModuleID = _context.SaveChanges();


                XtraMessageBox.Show("Lưu thành công!");
                InvalidateToolBar();
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu thiết kế để lưu");
            }
        }

        private void SaveToJson(ControlCollection control)
        {
            var fieldControl = ConvertListToJson.GetValueJsonForList(control);
            string json = SerializeObject.SerializeObjectByFieldControl(fieldControl);

            //NameValueCollection appSettings = ConfigurationManager.AppSettings;
            //string path = appSettings["PathDesignUI"] + objModules.ModuleLink;
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            //File.WriteAllText(path + @"\" + objModules.ModuleNo + ".json", json);

        }

        #endregion

        #region Hoạt động toolbar
        private void InvalidateToolBar()
        {
            if (!string.IsNullOrWhiteSpace(btnAction))
            {
                if (btnAction == ButtonAction.btnNew.ToString())
                {
                    ToolStrip.Enabled = true;
                    stm_New.Enabled = false;
                    stm_Cancel.Enabled = true;
                    stm_Delete.Enabled = true;
                    stm_Save.Enabled = true;
                    stm_Edit.Enabled = false;
                    stm_DeleteControl.Enabled = true;
                    //objModules = new Modules();
                    pnControls.Controls.Clear();
                }
                if (btnAction == ButtonAction.btnNewByUI.ToString())
                {
                    ToolStrip.Enabled = true;
                    stm_New.Enabled = false;
                    stm_Cancel.Enabled = true;
                    stm_Delete.Enabled = true;
                    stm_Save.Enabled = true;
                    stm_Edit.Enabled = false;
                    stm_DeleteControl.Enabled = true;
                    //objModules = new Modules();
                    pnControls.Controls.Clear();
                }
                else if (btnAction == ButtonAction.btnCancel.ToString())
                {
                    ToolStrip.Enabled = false;
                    stm_New.Enabled = true;
                    stm_Cancel.Enabled = false;
                    stm_Delete.Enabled = false;
                    stm_Save.Enabled = false;
                    pnControls.Controls.Clear();
                    stm_Edit.Enabled = true;
                    stm_DeleteControl.Enabled = false;
                }
                else if (btnAction == ButtonAction.btnDelete.ToString())
                {
                    ToolStrip.Enabled = false;
                    stm_New.Enabled = true;
                    stm_Cancel.Enabled = false;
                    stm_Delete.Enabled = false;
                    stm_Save.Enabled = false;
                    pnControls.Controls.Clear();
                    stm_Edit.Enabled = false;
                    stm_DeleteControl.Enabled = false;
                    //objModules = new Modules();
                    pnControls.Controls.Clear();
                }
                else if (btnAction == ButtonAction.btnSave.ToString())
                {
                    ToolStrip.Enabled = false;
                    stm_New.Enabled = true;
                    stm_Cancel.Enabled = false;
                    stm_Delete.Enabled = false;
                    stm_Save.Enabled = false;
                    stm_Edit.Enabled = true;
                    stm_DeleteControl.Enabled = false;
                }
                else if (btnAction == ButtonAction.btnEdit.ToString())
                {
                    ToolStrip.Enabled = true;
                    stm_New.Enabled = false;
                    stm_Cancel.Enabled = true;
                    stm_Delete.Enabled = true;
                    stm_Save.Enabled = true;
                    stm_Edit.Enabled = false;
                    stm_DeleteControl.Enabled = true;
                }
            }
            else
            {
                ToolStrip.Enabled = false;
                stm_New.Enabled = true;
                stm_Cancel.Enabled = false;
                stm_Delete.Enabled = false;
                stm_Save.Enabled = false;
                stm_DeleteControl.Enabled = false;
                stm_Edit.Enabled = false;
                //objModules = new Modules();
                pnControls.Controls.Clear();
            }
            //if (objModules.ModuleID > 0)
            //{
            //    tb_thietkegiaodien.Text = "Màn hình: " + objModules.ModuleName;
            //}
            //else
            //{
            //    tb_thietkegiaodien.Text = "Thiết kế giao diện";
            //}
        }

        #endregion

        #region Xóa Control
        private void smt_DeleteControl_Click(object sender, EventArgs e)
        {
            if (SelectedControl != null)
            {
                copiedControl = SelectedControl;
                cutCheck = true;
                //toolPastes.Enabled = true;
                //MenuPaste.Enabled = true;
            }

            if (SelectedControl != null)
            {
                pnControls.Controls.Remove(SelectedControl);
                propertyGrid1.SelectedObject = null;
                pnControls.Invalidate();
            }
        }
        #endregion


    }
}
