using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;

namespace xdcb.FormServices.BaseForm
{
    public static class LoadFormToJson
    {
        public static void GetValueControlByJson(GGScreen screen, string pathFile)
        {
            var fieldControl = Newtonsoft.Json.JsonConvert.DeserializeObject<FieldControl>(File.ReadAllText(pathFile));
            if (fieldControl != null)
            {
                screen.Location = new Point(fieldControl.LocationX, fieldControl.LocationY);
                screen.Size = new Size(fieldControl.SizeWidth, fieldControl.SizeHeight);
                ConvertFieldControlToControl(screen.Controls, fieldControl);
            }
        }

        public static void ConvertFieldControlToControl(Control.ControlCollection control, FieldControl fieldControl)
        {
            control.Clear();
            List<PropertyControl> list = fieldControl.propertyControl.ToList().Where(x => x.ParentName == ScreenName.ScreenDetail.ToString()
                                                                                         || x.ParentName == ScreenName.ScreenMain.ToString()
                                                                                         || x.ParentName == ScreenName.ScreenSearch.ToString()).ToList();
            if (list != null && list.Count > 0)
            {
                control = SetControl(control, list, fieldControl.propertyControl);
            }
        }

        private static Control.ControlCollection SetControl(Control.ControlCollection controls, List<PropertyControl> list, List<PropertyControl> propertyControList)
        {
            foreach (var item in list)
            {
                Control ctr = SetControl(item);
                if (ctr != null)
                {
                    //1
                    List<PropertyControl> list1 = propertyControList.ToList().Where(x => x.ParentName == item.Name).ToList();
                    if (list1 != null && list1.Count > 0)
                    {
                        foreach (var item1 in list1)
                        {
                            Control ctr1 = SetControl(item1);
                            if (ctr1 != null)
                            {
                                //2
                                List<PropertyControl> list2 = propertyControList.ToList().Where(x => x.ParentName == item1.Name).ToList();
                                if (list2 != null && list2.Count > 0)
                                {
                                    foreach (var item2 in list2)
                                    {
                                        Control ctr2 = SetControl(item2);
                                        if (ctr2 != null)
                                        {
                                            //3
                                            List<PropertyControl> list3 = propertyControList.ToList().Where(x => x.ParentName == item2.Name).ToList();
                                            if (list3 != null && list3.Count > 0)
                                            {
                                                foreach (var item3 in list3)
                                                {
                                                    Control ctr3 = SetControl(item3);
                                                    if (ctr3 != null)
                                                    {
                                                        //4
                                                        List<PropertyControl> list4 = propertyControList.ToList().Where(x => x.ParentName == item3.Name).ToList();
                                                        if (list4 != null && list4.Count > 0)
                                                        {
                                                            foreach (var item4 in list4)
                                                            {
                                                                Control ctr4 = SetControl(item4);
                                                                if (ctr4 != null)
                                                                {
                                                                    ctr4.Parent = ctr3;
                                                                    ctr3.Controls.Add(ctr4);
                                                                }
                                                            }
                                                        }
                                                        ctr3.Parent = ctr2;
                                                        ctr2.Controls.Add(ctr3);
                                                    }
                                                }
                                            }
                                            ctr2.Parent = ctr1;
                                            ctr1.Controls.Add(ctr2);
                                        }
                                    }
                                }
                                ctr1.Parent = ctr;
                                ctr.Controls.Add(ctr1);
                            }
                        }
                    }
                    controls.Add(ctr);
                }
            }
            return controls;
        }
        public static Control SetControl(PropertyControl p)
        {
            Control control = null;
            try
            {
                switch (p.TypeName)
                {
                    #region GGButton
                    case "xdcb.FormServices.Component.GGButton":
                        {
                            GGButton ctrl = new GGButton();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGButtonEdit
                    case "xdcb.FormServices.Component.GGButtonEdit":
                        {
                            GGButtonEdit ctrl = new GGButtonEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGCheckEdit
                    case "xdcb.FormServices.Component.GGCheckEdit":
                        {
                            GGCheckEdit ctrl = new GGCheckEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGColorEdit
                    case "xdcb.FormServices.Component.GGColorEdit":
                        {
                            GGColorEdit ctrl = new GGColorEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGComboBase
                    case "xdcb.FormServices.Component.GGComboBase":
                        {
                            GGComboBase ctrl = new GGComboBase();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGComboBoxEdit
                    case "xdcb.FormServices.Component.GGComboBoxEdit":
                        {
                            GGComboBoxEdit ctrl = new GGComboBoxEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGDateEdit
                    case "xdcb.FormServices.Component.GGDateEdit":
                        {
                            GGDateEdit ctrl = new GGDateEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGFontEdit
                    case "xdcb.FormServices.Component.GGFontEdit":
                        {
                            GGFontEdit ctrl = new GGFontEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGGridControl
                    case "xdcb.FormServices.Component.GGGridControl":
                        {
                            GGGridControl ctrl = new GGGridControl();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGGroupBox
                    case "xdcb.FormServices.Component.GGGroupBox":
                        {
                            GGGroupBox ctrl = new GGGroupBox();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGGroupControl
                    case "xdcb.FormServices.Component.GGGroupControl":
                        {
                            GGGroupControl ctrl = new GGGroupControl();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGHyperLinkEdit
                    case "xdcb.FormServices.Component.GGHyperLinkEdit":
                        {
                            GGHyperLinkEdit ctrl = new GGHyperLinkEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGLabel
                    case "xdcb.FormServices.Component.GGLabel":
                        {
                            GGLabel ctrl = new GGLabel();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGMemoEdit
                    case "xdcb.FormServices.Component.GGMemoEdit":
                        {
                            GGMemoEdit ctrl = new GGMemoEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGPanel
                    case "xdcb.FormServices.Component.GGPanel":
                        {
                            GGPanel ctrl = new GGPanel();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGPictureEdit
                    case "xdcb.FormServices.Component.GGPictureEdit":
                        {
                            GGPictureEdit ctrl = new GGPictureEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGRadioGroup
                    case "xdcb.FormServices.Component.GGRadioGroup":
                        {
                            GGRadioGroup ctrl = new GGRadioGroup();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGTabControl
                    case "xdcb.FormServices.Component.GGTabControl":
                        {
                            GGTabControl ctrl = new GGTabControl();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGTextEdit
                    case "xdcb.FormServices.Component.GGTextEdit":
                        {
                            GGTextEdit ctrl = new GGTextEdit();
                            ctrl.Properties.Mask.EditMask = p.EditMask;
                            ctrl.Properties.Mask.MaskType = (MaskType)Enum.Parse(typeof(MaskType), p.MaskType);
                            ctrl.Properties.CharacterCasing = (CharacterCasing)Enum.Parse(typeof(CharacterCasing), p.CharacterCase);
                            ctrl.Properties.ReadOnly = p.ReadOnly;
                            ctrl.RightToLeft = (RightToLeft)Enum.Parse(typeof(RightToLeft), p.RightToLeft);
                            ctrl.Properties.BorderStyle = (BorderStyles)Enum.Parse(typeof(BorderStyles), p.BorderStyle);
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGTimeEdit
                    case "xdcb.FormServices.Component.GGTimeEdit":
                        {
                            GGTimeEdit ctrl = new GGTimeEdit();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGTreeList
                    case "xdcb.FormServices.Component.GGTreeList":
                        {
                            GGTreeList ctrl = new GGTreeList();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                    #endregion

                    #region GGLine
                    case "xdcb.FormServices.Component.GGLine":
                        {
                            GGLine ctrl = new GGLine();
                            control = SetControlByProperties(ctrl, p);
                        }
                        break;
                        #endregion
                }
            }
            catch
            {

            }
            return control;
        }

        public static bool IsGetByControlCustom(Control control)
        {
            bool check = false;
            try
            {
                switch (control.GetType().ToString())
                {
                    #region GGButton
                    case "xdcb.FormServices.Component.GGButton":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGButtonEdit
                    case "xdcb.FormServices.Component.GGButtonEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGCheckEdit
                    case "xdcb.FormServices.Component.GGCheckEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGColorEdit
                    case "xdcb.FormServices.Component.GGColorEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGComboBase
                    case "xdcb.FormServices.Component.GGComboBase":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGComboBoxEdit
                    case "xdcb.FormServices.Component.GGComboBoxEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGDateEdit
                    case "xdcb.FormServices.Component.GGDateEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGFontEdit
                    case "xdcb.FormServices.Component.GGFontEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGGridControl
                    case "xdcb.FormServices.Component.GGGridControl":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    //#region GGGroupBox
                    //case "xdcb.FormServices.Component.GGGroupBox":
                    //    {
                    //        check = true;
                    //    }
                    //    break;
                    //#endregion

                    //#region GGGroupControl
                    //case "xdcb.FormServices.Component.GGGroupControl":
                    //    {
                    //        check = true;
                    //    }
                    //    break;
                    //#endregion

                    #region GGHyperLinkEdit
                    case "xdcb.FormServices.Component.GGHyperLinkEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGLabel
                    case "xdcb.FormServices.Component.GGLabel":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGMemoEdit
                    case "xdcb.FormServices.Component.GGMemoEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGPanel
                    case "xdcb.FormServices.Component.GGPanel":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGPictureEdit
                    case "xdcb.FormServices.Component.GGPictureEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGRadioGroup
                    case "xdcb.FormServices.Component.GGRadioGroup":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGTabControl
                    case "xdcb.FormServices.Component.GGTabControl":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGTextEdit
                    case "xdcb.FormServices.Component.GGTextEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGTimeEdit
                    case "xdcb.FormServices.Component.GGTimeEdit":
                        {
                            check = true;
                        }
                        break;
                    #endregion

                    #region GGTreeList
                    case "xdcb.FormServices.Component.GGTreeList":
                        {
                            check = true;
                        }
                        break;
                        #endregion
                }
            }
            catch
            {

            }
            return check;
        }

        public static Control SetControlByProperties(Control ctrl, PropertyControl property)
        {
            ctrl.Name = property.Name;
            if (ctrl.GetType() != typeof(GGPictureEdit))
            {
                ctrl.Text = property.Text;
            }
            ctrl.ForeColor = Color.FromArgb(property.ForeColor);
            ctrl.Font = new Font(property.FontName, (float)property.FontSize, (FontStyle)Enum.Parse(typeof(FontStyle), property.FontStyle));
            ctrl.Location = new Point(property.LocationX, property.LocationY);
            ctrl.Size = new Size(property.SizeWidth, property.SizeHeight);
            ctrl.Enabled = property.Enabled;
            ctrl.TabIndex = property.TabIndex;
            ctrl.Tag = property.Tag;
            if (!String.IsNullOrEmpty(property.Dock))
                ctrl.Dock = (DockStyle)Enum.Parse(typeof(DockStyle), property.Dock);
            ctrl.Visible = property.Visible;
            SetProperty.SetPropertyValue(ctrl, Customs.cstDataSource, property.GGDataSource);
            SetProperty.SetPropertyValue(ctrl, Customs.cstDataMember, property.GGDataMember);
            SetProperty.SetPropertyValue(ctrl, Customs.cstFieldGroup, property.GGFieldGroup);
            SetProperty.SetPropertyValue(ctrl, Customs.cstFieldRelation, property.GGFieldRelation);
            return ctrl;
        }
    }
}
