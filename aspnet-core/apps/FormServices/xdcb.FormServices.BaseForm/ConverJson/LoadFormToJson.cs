using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;

namespace xdcb.FormServices.BaseForm
{
    public static class LoadFormToJson
    {
        public static void GetValueControlByJson(System.Windows.Forms.Control.ControlCollection control, string pathFile)
        {

            var fieldControl = Newtonsoft.Json.JsonConvert.DeserializeObject<FieldControl>(File.ReadAllText(pathFile));
            ConvertFieldControlToControl(control, fieldControl);
        }

        public static void ConvertFieldControlToControl(System.Windows.Forms.Control.ControlCollection control, FieldControl fieldControl)
        {
            control.Clear();
            foreach (var p in fieldControl.propertyControl)
            {
                try
                {
                    switch (p.TypeName)
                    {
                        #region GGButton
                        case "xdcb.FormServices.Component.GGButton":
                            {
                                GGButton ctrl = new GGButton();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGButtonEdit
                        case "xdcb.FormServices.Component.GGButtonEdit":
                            {
                                GGButtonEdit ctrl = new GGButtonEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGCheckEdit
                        case "xdcb.FormServices.Component.GGCheckEdit":
                            {
                                GGCheckEdit ctrl = new GGCheckEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGColorEdit
                        case "xdcb.FormServices.Component.GGColorEdit":
                            {
                                GGColorEdit ctrl = new GGColorEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGComboBase
                        case "xdcb.FormServices.Component.GGComboBase":
                            {
                                GGComboBase ctrl = new GGComboBase();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGComboBoxEdit
                        case "xdcb.FormServices.Component.GGComboBoxEdit":
                            {
                                GGComboBoxEdit ctrl = new GGComboBoxEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGDateEdit
                        case "xdcb.FormServices.Component.GGDateEdit":
                            {
                                GGDateEdit ctrl = new GGDateEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGFontEdit
                        case "xdcb.FormServices.Component.GGFontEdit":
                            {
                                GGFontEdit ctrl = new GGFontEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGGridControl
                        case "xdcb.FormServices.Component.GGGridControl":
                            {
                                GGGridControl ctrl = new GGGridControl();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGGroupBox
                        case "xdcb.FormServices.Component.GGGroupBox":
                            {
                                GGGroupBox ctrl = new GGGroupBox();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGGroupControl
                        case "xdcb.FormServices.Component.GGGroupControl":
                            {
                                GGGroupControl ctrl = new GGGroupControl();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGHyperLinkEdit
                        case "xdcb.FormServices.Component.GGHyperLinkEdit":
                            {
                                GGHyperLinkEdit ctrl = new GGHyperLinkEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGLabel
                        case "xdcb.FormServices.Component.GGLabel":
                            {
                                GGLabel ctrl = new GGLabel();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGMemoEdit
                        case "xdcb.FormServices.Component.GGMemoEdit":
                            {
                                GGMemoEdit ctrl = new GGMemoEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGPanel
                        case "xdcb.FormServices.Component.GGPanel":
                            {
                                GGPanel ctrl = new GGPanel();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGPictureEdit
                        case "xdcb.FormServices.Component.GGPictureEdit":
                            {
                                GGPictureEdit ctrl = new GGPictureEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGRadioGroup
                        case "xdcb.FormServices.Component.GGRadioGroup":
                            {
                                GGRadioGroup ctrl = new GGRadioGroup();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGTabControl
                        case "xdcb.FormServices.Component.GGTabControl":
                            {
                                GGTabControl ctrl = new GGTabControl();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGTextEdit
                        case "xdcb.FormServices.Component.GGTextEdit":
                            {
                                GGTextEdit ctrl = new GGTextEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGTimeEdit
                        case "xdcb.FormServices.Component.GGTimeEdit":
                            {
                                GGTimeEdit ctrl = new GGTimeEdit();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                        #endregion

                        #region GGTreeList
                        case "xdcb.FormServices.Component.GGTreeList":
                            {
                                GGTreeList ctrl = new GGTreeList();
                                SetControlByProperties(ctrl, p);
                                control.Add(ctrl);
                            }
                            break;
                            #endregion
                    }
                }
                catch
                {

                }
            }
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

        public static void SetControlByProperties(System.Windows.Forms.Control ctrl, PropertyControl property)
        {
            ctrl.Name = property.Name;
            ctrl.Text = property.Text;
            ctrl.TabIndex = property.TabIndex;
            ctrl.Enabled = property.Enabled;
            //ctrl.Visible = property.Visible;
            ctrl.Location = new Point(property.LocationX, property.LocationY);
            ctrl.Size = new Size(property.SizeWidth, property.SizeHeight);
            SetProperty.SetPropertyValue(ctrl, Customs.cstDataSource, property.GGDataSource);
            SetProperty.SetPropertyValue(ctrl, Customs.cstDataMember, property.GGDataMember);
            SetProperty.SetPropertyValue(ctrl, Customs.cstFieldGroup, property.GGFieldGroup);
            SetProperty.SetPropertyValue(ctrl, Customs.cstFieldRelation, property.GGFieldRelation);
        }

        #region

        #endregion
    }
}
