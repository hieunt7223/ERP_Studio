using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;

namespace xdcb.FormServices.BaseForm
{
    public static class ConvertListToJson
    {
        public static FieldControl GetValueJsonForList(Control.ControlCollection Control, string username, GGScreen screen)
        {
            FieldControl _file = new FieldControl();
            List<PropertyControl> propertyControlList = new List<PropertyControl>();
            GetAllControls(screen.Controls, propertyControlList);
            _file.id = Guid.NewGuid().ToString();
            _file.name = screen.Name;
            _file.key = screen.Name;
            _file.description = screen.Name;
            _file.version = "1.0.0";
            _file.lastUpdatedBy = username;
            _file.lastUpdated = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Point location = GetControlLocation(screen);
            _file.LocationX = location.X;
            _file.LocationY = location.X;
            _file.SizeWidth = screen.Size.Width;
            _file.SizeHeight = screen.Size.Height;
            _file.propertyControl = propertyControlList;
            return _file;
        }

        private static List<PropertyControl> GetAllControls(Control.ControlCollection controls, List<PropertyControl> list)
        {
            foreach (Control ctrl in controls)
            {
                PropertyControl pc = GetAllControls(ctrl);
                if (pc != null && !string.IsNullOrWhiteSpace(pc.Name))
                {
                    list.Add(GetAllControls(ctrl));
                }
                if (ctrl.Controls.Count > 0)
                    GetAllControls(ctrl.Controls, list);
            }
            return list;
        }

        public static PropertyControl GetAllControls(Control ctrl)
        {
            PropertyControl pc = new PropertyControl();
            pc.Name = ctrl.Name;
            pc.ParentName = ctrl.Parent.Name;
            pc.Type = ctrl.GetType().Name;
            pc.TypeName = ctrl.GetType().ToString();
            //Get common Properties
            pc.BackColor = ctrl.BackColor.ToArgb();
            pc.ForeColor = ctrl.ForeColor.ToArgb();
            pc.FontName = ctrl.Font.Name;
            pc.Text = ctrl.Text;
            pc.FontSize = Convert.ToDouble(ctrl.Font.Size);
            pc.FontStyle = ctrl.Font.Style.ToString();
            pc.Enabled = ctrl.Enabled;
            Point location = GetControlLocation(ctrl);
            pc.LocationX = location.X;
            pc.LocationY = location.Y;
            pc.SizeWidth = ctrl.Size.Width;
            pc.SizeHeight = ctrl.Size.Height;
            pc.TabIndex = ctrl.TabIndex;
            pc.Dock = ctrl.Dock.ToString();
            pc.Status = "Active";
            if (ctrl.Tag != null)
                pc.Tag = ctrl.Tag.ToString();
            pc.Visible = ctrl.Visible;
            pc.GGDataSource = GetProperty.GetPropertyStringValue(ctrl, GGScreen.cstDataSourcePropertyName);
            pc.GGDataMember = GetProperty.GetPropertyStringValue(ctrl, GGScreen.cstDataMemberPropertyName);
            pc.GGFieldGroup = GetProperty.GetPropertyStringValue(ctrl, GGScreen.cstFieldGroupPropertyName);
            pc.GGFieldRelation = GetProperty.GetPropertyStringValue(ctrl, GGScreen.cstRelationPropertyName);
            //Get specific properties
            #region case:GGTextEdit
            if (ctrl.GetType().Name == typeof(GGTextEdit).Name)
            {
                GGTextEdit txt = (GGTextEdit)ctrl;
                pc.EditMask = txt.Properties.Mask.EditMask;
                pc.MaskType = txt.Properties.Mask.MaskType.ToString();
                pc.CharacterCase = txt.Properties.CharacterCasing.ToString();
                pc.ReadOnly = txt.Properties.ReadOnly;
                pc.RightToLeft = txt.RightToLeft.ToString();
                pc.BorderStyle = txt.Properties.BorderStyle.ToString();
            }
            #endregion

            #region case:GGMemoEdit
            else if (ctrl.GetType().Name == typeof(GGMemoEdit).Name)
            {
                GGMemoEdit med = (GGMemoEdit)ctrl;
                pc.CharacterCase = med.Properties.CharacterCasing.ToString();
                pc.ReadOnly = med.Properties.ReadOnly;
                pc.ScrollBars = med.Properties.ScrollBars.ToString();
            }
            #endregion

            #region case:GGButton
            else if (ctrl.GetType().Name == typeof(GGButton).Name)
            {
                GGButton btn = (GGButton)ctrl;
            }
            #endregion

            #region case:GGComboBox
            else if (ctrl.GetType().Name == typeof(GGComboBoxEdit).Name)
            {
                GGComboBoxEdit cmb = (GGComboBoxEdit)ctrl;
                pc.TextEditStyle = cmb.Properties.TextEditStyle.ToString();
            }
            #endregion

            #region case:GGDateEdit
            else if (ctrl.GetType().Name == typeof(GGDateEdit).Name)
            {
                GGDateEdit dtp = (GGDateEdit)ctrl;
                pc.EditMask = dtp.Properties.Mask.EditMask;
            }
            #endregion

            #region case:GGTimeEdit
            else if (ctrl.GetType().Name == typeof(GGTimeEdit).Name)
            {
                GGTimeEdit ted = (GGTimeEdit)ctrl;
            }
            #endregion

            #region case:GGLabel
            else if (ctrl.GetType().Name == typeof(GGLabel).Name)
            {
                GGLabel lbl = (GGLabel)ctrl;
                pc.TextAlign = ContentAlignment.TopLeft.ToString();
            }
            #endregion

            #region case:GGCheckEdit
            else if (ctrl.GetType().Name == typeof(GGCheckEdit).Name)
            {
                GGCheckEdit chk = (GGCheckEdit)ctrl;
                pc.CheckedStyle = chk.Properties.CheckStyle.ToString();
            }
            #endregion

            #region case:Line
            else if (ctrl.GetType().Name == typeof(GGLine).Name)
            {
                GGLine line = (GGLine)ctrl;
            }
            #endregion

            #region case:PictureEdit
            else if (ctrl.GetType().Name == typeof(GGPictureEdit).Name)
            {
                GGPictureEdit pictureEdit = (GGPictureEdit)ctrl;
            }
            #endregion

            #region case: GGGridControl
            else if (ctrl.GetType().Name == typeof(GGGridControl).Name || ctrl.GetType().BaseType.Name == typeof(GGGridControl).Name)
            {
                GGGridControl gridControl = (GGGridControl)ctrl;
            }
            #endregion

            #region case:GGGroupControl
            else if (ctrl.GetType().Name == typeof(GGGroupControl).Name)
            {
                GGGroupControl grc = (GGGroupControl)ctrl;
            }
            #endregion

            #region case: GGTabControl
            else if (ctrl.GetType().Name == typeof(GGTabControl).Name)
            {
                GGTabControl tabControl = (GGTabControl)ctrl;
            }
            #endregion

            #region case: GGButtonEdit
            else if (ctrl.GetType().Name == typeof(GGButtonEdit).Name)
            {
                GGButtonEdit bed = (GGButtonEdit)ctrl;
                pc.EditMask = bed.Properties.Mask.EditMask;
                pc.MaskType = bed.Properties.Mask.MaskType.ToString();
                pc.CharacterCase = bed.Properties.CharacterCasing.ToString();
                pc.ReadOnly = bed.Properties.ReadOnly;
                pc.RightToLeft = bed.RightToLeft.ToString();
                pc.BorderStyle = bed.Properties.BorderStyle.ToString();
            }
            #endregion
            return pc;
        }

        #region Config

        private static Point GetControlLocation(Control ctrl)
        {
            Point location = new Point(ctrl.Location.X, ctrl.Location.Y);
            if (ctrl.Parent.GetType() != typeof(GGScreen) && ctrl.Parent.GetType().BaseType != typeof(GGScreen))
            {
                Point parentLocation = GetControlLocation(ctrl.Parent);
                location.X += parentLocation.X;
                location.Y += parentLocation.Y;
            }
            return location;
        }

        private static string FontToString(Font font)
        {
            return font.FontFamily.Name + ":" + font.Size + ":" + (int)font.Style;
        }

        private static byte[] imageToByteArray(Bitmap bmp)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }

        private static string GetImages(System.Windows.Forms.Control p)
        {
            PictureBox pic = p as PictureBox; //cast control into PictureBox
            byte[] bytes = null;
            string PicBitMapImages = "";
            if (pic != null) //if it is pictureBox, then it will not be null.
            {
                if (pic.Image != null)
                {
                    Bitmap img = new Bitmap(pic.Image);
                    bytes = imageToByteArray(img);
                    PicBitMapImages = Convert.ToBase64String(bytes);
                }
            }
            return PicBitMapImages;
        }
        #endregion
    }
}
