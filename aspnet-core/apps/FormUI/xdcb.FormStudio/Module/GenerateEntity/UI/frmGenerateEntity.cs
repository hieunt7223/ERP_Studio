using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using DevExpress.XtraSplashScreen;
using xdcb.FormServices.Shared;
using xdcb.FormServices.Component;
using xdcb.FormServices.BaseForm;
using System.Text;
using System.IO;

namespace xdcb.FormStudio.GenerateEntity
{

    public partial class frmGenerateEntity : GGScreen
    {

        #region Property
        private OleDbConnection Conn = new OleDbConnection();
        private string AccessConnString;
        private List<ColumnTable> ColumnTableList = new List<ColumnTable>();
        private List<string> ListColumnBase;
        #endregion
        public frmGenerateEntity()
        {
            InitializeComponent();

            ListColumnBase = new List<string>();
            ListColumnBase.Add("Id");
            ListColumnBase.Add("ExtraProperties");
            ListColumnBase.Add("ConcurrencyStamp");
            ListColumnBase.Add("CreationTime");
            ListColumnBase.Add("CreatorId");
            ListColumnBase.Add("LastModificationTime");
            ListColumnBase.Add("LastModifierId");
            ListColumnBase.Add("IsDeleted");
            ListColumnBase.Add("DeleterId");
            ListColumnBase.Add("DeletionTime");
            ListColumnBase.Add("OrderIndex");
            ListColumnBase.Add("TenantId");

            txt_Project.Text = ConfigManager.NamespareProject();
            txt_SDK.Text = ConfigManager.NamespareSDK();
            txt_Service.Text = ConfigManager.NamespareService();
        }

        #region ConnectString
        private void btn_ConnectString_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            FillTablesAndFields();
            SplashScreenManager.CloseForm();
        }

        private void FillTablesAndFields()
        {
            try
            {
                lvTables.Items.Clear();
                string servername = ConfigManager.ServerName();
                string username = ConfigManager.UserName();
                string password = ConfigManager.Password();
                string database = ConfigManager.DatabaseName();
                AccessConnString = @"Provider=SQLOLEDB.1;Server=" + servername +
                ";Initial Catalog=" + database + "; UID=" + username + "; PWD=" + password;
                OpenConn(AccessConnString);
                DataTable schemaTable = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                foreach (DataRow row in schemaTable.Rows)
                {
                    string TableName = row["TABLE_NAME"].ToString();
                    lvTables.Items.Add(TableName);
                }
                CloseConn();
            }
            catch (Exception ex)
            {
                Conn.Close();
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Connection Function
        //Open DB Connection Function
        private void OpenConn(string ConnStr)
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.ConnectionString = ConnStr;
            Conn.Open();
        }
        //Close DB Connection Function
        private void CloseConn()
        {
            Conn.Close();
        }
        #endregion

        #region SelectedIndex ListBox Table
        private void lvTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OpenConn(AccessConnString);
                object[] objArrRestrict;
                if (lvTables.SelectedItem != null)
                {
                    string TableName = lvTables.SelectedItem.ToString();
                    objArrRestrict = new object[] { null, null, TableName, null };
                    DataTable schemaCols = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, objArrRestrict);
                    ColumnTableList.Clear();
                    int i = 1;
                    foreach (DataRow fieldrow in schemaCols.Rows)
                    {
                        ColumnTable info = new ColumnTable();
                        info.TableName = fieldrow["TABLE_NAME"].ToString();
                        if (!string.IsNullOrWhiteSpace(info.TableName))
                        {
                            info.TableName = info.TableName.Substring(0, info.TableName.Length - 1);
                        }
                        info.ColumnName = fieldrow["COLUMN_NAME"].ToString();
                        info.Schema = fieldrow["TABLE_SCHEMA"].ToString();
                        info.ColumnDefault = fieldrow["COLUMN_DEFAULT"].ToString();
                        info.TypeName = fieldtypename(int.Parse(fieldrow["DATA_TYPE"].ToString()));
                        //if (int.Parse(fieldrow["DATA_TYPE"].ToString()) == 130 && int.Parse(fieldrow["COLUMN_FLAGS"].ToString()) == 4)
                        //{
                        //    info.TypeName = "DateTime";
                        //}
                        string length = fieldrow["CHARACTER_MAXIMUM_LENGTH"].ToString();
                        info.ColumnLength = string.IsNullOrWhiteSpace(length) ? 0 : Convert.ToInt32(length);
                        info.IsNull = Convert.ToBoolean(fieldrow["IS_NULLABLE"].ToString());
                        if (i == 1)
                        {
                            info.Key = true;
                        }
                        else
                        {
                            info.Key = false;
                        }
                        ColumnTableList.Add(info);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
        #endregion

        #region Cấu hình

        public class ColumnTable
        {
            public string TableName;
            public string ColumnName;
            public string TypeName;
            public string Schema;
            public int ColumnLength;
            public string ColumnDefault;
            public bool IsNull;
            public bool Key;
        }

        private string fieldtypename(int parm1)
        {
            string fieldtypename;
            switch (parm1)
            {
                case 0:
                    fieldtypename = "adEmpty";
                    break;
                case 16:
                case 2:
                case 3:
                    fieldtypename = "int";
                    break;
                case 20:
                case 17:
                case 18:
                case 19:
                case 21:
                case 4:
                case 131:
                    fieldtypename = "decimal";
                    break;
                case 6:
                case 5:
                    fieldtypename = "double";
                    break;
                case 14:
                    fieldtypename = "decimal";
                    break;
                case 11:
                    fieldtypename = "bool";
                    break;
                case 133:
                case 135:
                case 134:
                case 7:
                    fieldtypename = "DateTime";
                    break;
                case 129:
                    fieldtypename = "string";
                    break;
                case 201:
                case 202:
                case 203:
                case 130:
                case 200:
                    fieldtypename = "string";
                    break;
                case 128:
                case 204:
                case 205:
                default:
                    fieldtypename = "Guid";
                    break;
            }
            return fieldtypename;
        }

        private enum GroupFile
        {
            Domain,
            EFCore,
            ApplicationContracts,
            Application,
            SDK
        }
        #endregion

        #region Action Domain
        private void bar_domain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lvTables.SelectedItem == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn table trước!");
                return;
            }
            if (ColumnTableList == null || ColumnTableList.Count == 0)
            {
                GGFunctions.ShowMessage("Không có tham số của table!");
                return;
            }
            string table = ColumnTableList[0].TableName;

            CreateFileRepositoryDomain(table, ColumnTableList);

            CreateFileBaseEntity(table, ColumnTableList);

            CreateFileDomain(table, ColumnTableList);

            GGFunctions.ShowMessage("Xuất file thành công!");
        }

        private bool CreateFileRepositoryDomain(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using Volo.Abp.Domain.Repositories;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_Service.EditValue.ToString().Trim() + "." + TableName + "s" + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated Domain Repositories for Table : " + TableName + "." + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public interface I" + TableName + "Repository : IBasicRepository<" + TableName + ", " + htColumns[0].TypeName + ">" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");

                sb.Append("\t" + "}" + "\r\n");

                sb.Append("}" + "\r\n");
                //now we create the file with the TableName.cs
                WriteFile("I" + TableName + "Repository", GroupFile.Domain.ToString() + @"\Repositories", sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }

        private bool CreateFileDomain(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using Volo.Abp.Domain.Entities.Auditing;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_Service.EditValue.ToString().Trim() + "." + TableName + "s" + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated Domain for Table : " + TableName + "." + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public class " + TableName + " : BaseEntity" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "#region Generated By Column" + "\r\n" + "\r\n");
                foreach (ColumnTable col in htColumns)
                {
                    if (col.Key == false && !ListColumnBase.Contains(col.ColumnName.Trim()))
                    {
                        if (col.IsNull == true && col.TypeName.ToLower().Trim() != "string")
                        {
                            sb.Append("\t" + "\t" + "public " + col.TypeName + "? " + col.ColumnName.ToString() + " { get; set; }" + "\r\n" + "\r\n");
                        }
                        else
                        {
                            sb.Append("\t" + "\t" + "public " + col.TypeName + " " + col.ColumnName.ToString() + " { get; set; }" + "\r\n" + "\r\n");
                        }
                    }
                }
                sb.Append("\t" + "\t" + "#endregion" + "\r\n");
                //End Class
                sb.Append("\t" + "}" + "\r\n");
                //Ending Brace For Namespace
                sb.Append("}");
                //now we create the file with the TableName.cs
                WriteFile(TableName, GroupFile.Domain.ToString() + @"\Entities", sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }

        private bool CreateFileBaseEntity(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using Volo.Abp.Domain.Entities.Auditing;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_Service.EditValue.ToString().Trim() + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated BaseEntity" + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public abstract class BaseEntity : FullAuditedAggregateRoot<" + htColumns[0].TypeName + ">" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "#region Generated By Column" + "\r\n" + "\r\n");

                sb.Append("\t" + "public int OrderIndex { get; set; }" + "\r\n");
                sb.Append("\t" + "public Guid TenantId { get; set; }" + "\r\n");

                sb.Append("\t" + "\t" + "#endregion" + "\r\n");
                //End Class
                sb.Append("\t" + "}" + "\r\n");
                //Ending Brace For Namespace
                sb.Append("}");
                //now we create the file with the TableName.cs
                WriteFile("BaseEntity", GroupFile.Domain.ToString() + @"\Entities", sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }
        #endregion

        #region EFCore
        private void bar_EFCore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lvTables.SelectedItem == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn table trước!");
                return;
            }
            if (ColumnTableList == null || ColumnTableList.Count == 0)
            {
                GGFunctions.ShowMessage("Không có tham số của table!");
                return;
            }
            string table = ColumnTableList[0].TableName;

            CreateFileEFCore(table, ColumnTableList);

            CreateFileEFCoreRepository(table, ColumnTableList);

            GGFunctions.ShowMessage("Xuất file thành công!");
        }

        private bool CreateFileEFCore(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using " + txt_Service.EditValue.ToString().Trim() + "." + TableName + "s" + ";" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("//DbContext\r\n");
                sb.Append("public DbSet<" + TableName + "> " + TableName + " { get; set; } " + "\r\n");
                sb.Append("\r\n");
                sb.Append("\r\n");
                sb.Append("//ApplicationAutoMapperProfile" + "\r\n");
                sb.Append("#region " + TableName + "" + "\r\n");
                sb.Append("CreateMap<" + TableName + "s." + TableName + ", " + TableName + "Dto>();" + "\r\n");
                sb.Append("CreateMap<CreateUpdate" + TableName + "Dto, " + TableName + "s." + TableName + ">();" + "\r\n");
                sb.Append("CreateMap<" + TableName + "Dto, CreateUpdate" + TableName + "Dto>();" + "\r\n");
                sb.Append("#endregion" + "\r\n");
                sb.Append("\r\n");
                sb.Append("\r\n");
                sb.Append("//DbContextModelCreatingExtensions\r\n");
                sb.Append("builder.Entity<" + TableName + ">(b =>" + "\r\n");
                sb.Append("{" + "\r\n");
                sb.Append("\t" + "b.ToTable(" + "\"" + TableName + "s" + "\"" + "," + "\"" + htColumns[0].Schema + "\"" + ");" + "\r\n" + "\r\n");
                foreach (ColumnTable col in htColumns)
                {
                    string defaultValue = string.Empty;
                    if (!string.IsNullOrWhiteSpace(col.ColumnDefault.ToString()))
                    {
                        defaultValue = col.ColumnDefault.ToString().Replace("((", "").Replace("))", "").ToString();
                        defaultValue = defaultValue.Replace("(", "").Replace(")", "").ToString();
                        defaultValue = defaultValue.Replace("'", "").ToString();
                    }
                    if (col.Key == true || ListColumnBase.Contains(col.ColumnName))//khóa chính
                    {
                        //sb.Append("\t" + "\t" + "\t" + "builder.HasKey(s => s." + col.ColumnName.Trim() + ");" + "\r\n" + "\r\n");
                        //sb.Append("\t" + "\t" + "\t" + "builder.Property(x => x." + col.ColumnName.Trim() + ").UseIdentityColumn();" + "\r\n" + "\r\n");
                    }
                    else if (col.TypeName.ToLower().Trim() == "string" || col.TypeName.ToLower().Trim() == "guid")
                    {
                        if (col.IsNull == false)
                        {
                            if (col.ColumnLength > 0)
                            {
                                if (!string.IsNullOrWhiteSpace(defaultValue))
                                {
                                    sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").IsRequired().HasMaxLength(" + col.ColumnLength + ").HasDefaultValue(" + "\"" + defaultValue + "\"" + ");" + "\r\n" + "\r\n");
                                }
                                else
                                {
                                    sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").IsRequired().HasMaxLength(" + col.ColumnLength + ");" + "\r\n" + "\r\n");
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(defaultValue))
                                {
                                    sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").IsRequired().HasDefaultValue(" + "\"" + defaultValue + "\"" + ");" + "\r\n" + "\r\n");
                                }
                                else
                                {
                                    sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").IsRequired();" + "\r\n" + "\r\n");
                                }
                            }
                        }
                        else if (col.ColumnLength > 0)
                        {
                            if (!string.IsNullOrWhiteSpace(defaultValue))
                            {
                                sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").HasMaxLength(" + col.ColumnLength + ").HasDefaultValue(" + "\"" + defaultValue + "\"" + ");" + "\r\n" + "\r\n");
                            }
                            else
                            {
                                sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").HasMaxLength(" + col.ColumnLength + ");" + "\r\n" + "\r\n");
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(defaultValue))
                        {
                            sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").HasDefaultValue(" + "\"" + defaultValue + "\"" + ");" + "\r\n" + "\r\n");
                        }
                    }
                    else if (col.IsNull == false)// bắt buộc
                    {
                        if (!string.IsNullOrWhiteSpace(defaultValue))
                        {
                            sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").IsRequired().HasDefaultValue(" + defaultValue + ");" + "\r\n" + "\r\n");
                        }
                        else
                        {
                            sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").IsRequired();" + "\r\n" + "\r\n");
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(defaultValue))
                    {
                        sb.Append("\t" + "b.Property(s => s." + col.ColumnName.Trim() + ").HasDefaultValue(" + defaultValue + ");" + "\r\n" + "\r\n");
                    }
                }
                sb.Append("\t" + "b.ConfigureByConvention();" + "\r\n");
                sb.Append("});" + "\r\n");
                WriteFileNotExport(sb.ToString());

                WriteFile(TableName + "EFCore", GroupFile.EFCore.ToString(), sb.ToString());

            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }

        private bool CreateFileEFCoreRepository(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using Volo.Abp.Domain.Repositories.EntityFrameworkCore;" + "\r\n");
                sb.Append("using Volo.Abp.EntityFrameworkCore;" + "\r\n");
                sb.Append("using " + txt_Service.EditValue.ToString().Trim() + ".EntityFrameworkCore;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_Service.EditValue.ToString().Trim() + "." + TableName + "s" + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated Repositories for Table : " + TableName + "." + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public class " + TableName + "Repository : EfCoreRepository<" + txt_Project.EditValue.ToString().Trim() + "DbContext, " + TableName + ", " + htColumns[0].TypeName + ">, I" + TableName + "Repository" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "public " + TableName + "Repository(IDbContextProvider<" + txt_Project.EditValue.ToString().Trim() + "DbContext> dbContextProvider): base(dbContextProvider)" + "\r\n");
                sb.Append("\t" + "\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "}" + "\r\n");
                sb.Append("\t" + "}" + "\r\n");

                sb.Append("}" + "\r\n");
                //now we create the file with the TableName.cs
                WriteFile(TableName + "Repository", GroupFile.EFCore.ToString() + @"\Repositories", sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }
        #endregion

        #region Application.Contracts.Dto
        private void bar_Dto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lvTables.SelectedItem == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn table trước!");
                return;
            }
            if (ColumnTableList == null || ColumnTableList.Count == 0)
            {
                GGFunctions.ShowMessage("Không có tham số của table!");
                return;
            }
            string table = ColumnTableList[0].TableName;

            CreateFileContractDtos(table, ColumnTableList);

            GGFunctions.ShowMessage("Xuất file thành công!");
        }
        private bool CreateFileContractDtos(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using Volo.Abp.Application.Dtos;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_Service.EditValue.ToString().Trim() + "." + TableName + ".Dtos" + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated Contracts Dto for Table : " + TableName + "." + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public class " + TableName + "Dto : FullAuditedEntityDto<" + htColumns[0].TypeName + ">" + "" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "#region Generated By Column" + "\r\n" + "\r\n");
                foreach (ColumnTable col in htColumns)
                {
                    if (col.ColumnName.ToString().Trim().ToLower() != "id" && !ListColumnBase.Contains(col.ColumnName))
                    {
                        if ((col.Key == false) && col.IsNull == true && col.TypeName.ToLower().Trim() != "string")
                        {
                            sb.Append("\t" + "\t" + "public " + col.TypeName + "? " + col.ColumnName.ToString() + " { get; set; }" + "\r\n" + "\r\n");
                        }
                        else
                        {
                            sb.Append("\t" + "\t" + "public " + col.TypeName + " " + col.ColumnName.ToString() + " { get; set; }" + "\r\n" + "\r\n");
                        }
                    }
                }
                sb.Append("\t" + "\t" + "#endregion" + "\r\n");
                //End Class
                sb.Append("\t" + "}" + "\r\n");
                //Ending Brace For Namespace
                sb.Append("}");
                //now we create the file with the TableName.cs
                WriteFile(TableName + "Dto", GroupFile.ApplicationContracts.ToString() + @"\Dtos\" + TableName, sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }
        #endregion

        #region Application.Contracts.CreateUpdateDto
        private void bar_CreateUpdateDto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lvTables.SelectedItem == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn table trước!");
                return;
            }
            if (ColumnTableList == null || ColumnTableList.Count == 0)
            {
                GGFunctions.ShowMessage("Không có tham số của table!");
                return;
            }
            string table = ColumnTableList[0].TableName;

            CreateFileCreateUpdateDto(table, ColumnTableList);

            GGFunctions.ShowMessage("Xuất file thành công!");
        }
        private bool CreateFileCreateUpdateDto(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using System.ComponentModel.DataAnnotations;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_Service.EditValue.ToString().Trim() + "." + TableName + ".Dtos" + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated CreateUpdateDto for Table : " + TableName + "." + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public class CreateUpdate" + TableName + "Dto" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "#region Generated By Column" + "\r\n" + "\r\n");

                foreach (ColumnTable col in htColumns)
                {
                    if (!ListColumnBase.Contains(col.ColumnName))
                        if (col.Key == false)
                        {
                            if (col.TypeName.ToLower().Trim() == "string")
                            {
                                if (col.IsNull == false)
                                {
                                    sb.Append("\t" + "\t" + "//[Required]" + "\r\n");
                                }
                                if (col.ColumnLength > 0)
                                {
                                    sb.Append("\t" + "\t" + "//[StringLength(" + col.ColumnLength + ")]" + "\r\n");
                                }
                                sb.Append("\t" + "\t" + "public " + col.TypeName + " " + col.ColumnName.ToString() + " { get; set; }" + "\r\n" + "\r\n");
                            }
                            else if (col.IsNull == false)
                            {
                                sb.Append("\t" + "\t" + "//[Required]" + "\r\n");
                                sb.Append("\t" + "\t" + "public " + col.TypeName + " " + col.ColumnName.ToString() + " { get; set; }" + "\r\n" + "\r\n");
                            }
                            else
                            {
                                sb.Append("\t" + "\t" + "public " + col.TypeName + " " + col.ColumnName.ToString() + " { get; set; }" + "\r\n" + "\r\n");
                            }
                        }
                }
                sb.Append("\t" + "\t" + "#endregion" + "\r\n");
                //End Class
                sb.Append("\t" + "}" + "\r\n");
                //Ending Brace For Namespace
                sb.Append("}");
                //now we create the file with the TableName.cs
                WriteFile("CreateUpdate" + TableName + "Dto", GroupFile.ApplicationContracts.ToString() + @"\Dtos\" + TableName, sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }
        #endregion

        #region Application.Contracts.IAppService
        private void bar_IAppService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lvTables.SelectedItem == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn table trước!");
                return;
            }
            if (ColumnTableList == null || ColumnTableList.Count == 0)
            {
                GGFunctions.ShowMessage("Không có tham số của table!");
                return;
            }
            string table = ColumnTableList[0].TableName;

            CreateFileIAppService(table, ColumnTableList);

            GGFunctions.ShowMessage("Xuất file thành công!");
        }

        private bool CreateFileIAppService(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using System.Collections.Generic;" + "\r\n");
                sb.Append("using System.Threading.Tasks;" + "\r\n");
                sb.Append("using Volo.Abp.Application.Services;" + "\r\n");
                sb.Append("using " + txt_Service.EditValue.ToString().Trim() + "." + TableName + ".Dtos;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_Service.EditValue.ToString().Trim() + "." + TableName + "s" + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated IAppService for Table : " + TableName + "." + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public interface I" + TableName + "AppService : IApplicationService" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "#region Generated By Column" + "\r\n" + "\r\n");

                sb.Append("\t" + "\t" + "Task<List<" + TableName + "Dto>> GetListAsync();" + "\r\n" + "\r\n");

                sb.Append("\t" + "\t" + "Task<" + TableName + "Dto> GetAsync(" + htColumns[0].TypeName + " id);" + "\r\n" + "\r\n");

                sb.Append("\t" + "\t" + "Task<" + TableName + "Dto> Create(CreateUpdate" + TableName + "Dto input);" + "\r\n" + "\r\n");

                sb.Append("\t" + "\t" + "Task<" + TableName + "Dto> Update(" + htColumns[0].TypeName + " id, CreateUpdate" + TableName + "Dto input);" + "\r\n" + "\r\n");

                sb.Append("\t" + "\t" + "Task Delete(" + htColumns[0].TypeName + " id);" + "\r\n" + "\r\n");

                foreach (ColumnTable col in htColumns)
                {
                    if (!ListColumnBase.Contains(col.ColumnName))
                        if ((col.Key == false) && col.ColumnName.Length > 2)
                        {
                            string fk_id = col.ColumnName.Substring(col.ColumnName.Length - 2, 2);
                            if (!string.IsNullOrWhiteSpace(fk_id) && fk_id.ToLower().Trim() == "id")
                            {
                                sb.Append("\t" + "\t" + "Task<List<" + TableName + "Dto>> GetListBy" + col.ColumnName.Trim() + "Async(" + col.TypeName + " " + col.ColumnName.Trim() + ");" + "\r\n" + "\r\n");

                                sb.Append("\t" + "\t" + "Task DeleteBy" + col.ColumnName.Trim() + "(" + col.TypeName + " " + col.ColumnName.Trim() + ");" + "\r\n" + "\r\n");

                            }
                        }
                }
                sb.Append("\t" + "\t" + "#endregion" + "\r\n");
                //End Class
                sb.Append("\t" + "}" + "\r\n");
                //Ending Brace For Namespace
                sb.Append("}");
                //now we create the file with the TableName.cs
                WriteFile("I" + TableName + "AppService", GroupFile.ApplicationContracts.ToString() + @"\Services", sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }
        #endregion

        #region Application.AppService
        private void bar_AppService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lvTables.SelectedItem == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn table trước!");
                return;
            }
            if (ColumnTableList == null || ColumnTableList.Count == 0)
            {
                GGFunctions.ShowMessage("Không có tham số của table!");
                return;
            }
            string table = ColumnTableList[0].TableName;

            AppServiceBase(table, ColumnTableList);

            CreateFileAppService(table, ColumnTableList);

            GGFunctions.ShowMessage("Xuất file thành công!");
        }

        private bool AppServiceBase(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using Volo.Abp.Application.Services;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_Service.EditValue.ToString().Trim() + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated AppServiceBase" + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public class " + txt_Project.EditValue.ToString().Trim() + "AppServiceBase : ApplicationService" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "protected " + txt_Project.EditValue.ToString().Trim() + "AppServiceBase()" + "\r\n");
                sb.Append("\t" + "\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "ObjectMapperContext = typeof(" + txt_Project.EditValue.ToString().Trim() + "ApplicationModule); " + "\r\n");

                sb.Append("\t" + "\t" + "}" + "\r\n");

                sb.Append("\t" + "}" + "\r\n");

                sb.Append("}" + "\r\n");

                WriteFile(txt_Project.EditValue.ToString().Trim() + "AppServiceBase", GroupFile.Application.ToString(), sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }

        private bool CreateFileAppService(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using System.Collections.Generic;" + "\r\n");
                sb.Append("using System.Linq;" + "\r\n");
                sb.Append("using System.Threading.Tasks;" + "\r\n");
                sb.Append("using " + txt_Service.EditValue.ToString().Trim() + "." + TableName + ".Dtos;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_Service.EditValue.ToString().Trim() + "." + TableName + "s" + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated AppService for Table : " + TableName + "." + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public class " + TableName + "AppService :" + txt_Project.EditValue.ToString().Trim() + "AppServiceBase, I" + TableName + "AppService" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "#region Generated By Column" + "\r\n" + "\r\n");

                sb.Append("\t" + "\t" + "private readonly I" + TableName + "Repository _i" + TableName + "Repository;" + "\r\n" + "\r\n");

                //khoitao
                sb.Append("\t" + "\t" + "public " + TableName + "AppService(I" + TableName + "Repository i" + TableName + "Repository)" + "\r\n");
                sb.Append("\t" + "\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "\t" + "_i" + TableName + "Repository = i" + TableName + "Repository;" + "\r\n");

                sb.Append("\t" + "\t" + "}" + "\r\n" + "\r\n");


                //GetListAsync
                sb.Append("\t" + "\t" + "public async Task<List<" + TableName + "Dto>> GetListAsync()" + "\r\n");
                sb.Append("\t" + "\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "var items = await _i" + TableName + "Repository.GetListAsync();" + "\r\n");

                sb.Append("\t" + "\t" + "\t" + "if (items != null && items.Count > 0)" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "\t" + "    items = items.Where(x => x.IsDeleted == false).ToList();" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "}" + "\r\n");

                sb.Append("\t" + "\t" + "\t" + "return new List<" + TableName + "Dto>(ObjectMapper.Map<List<" + TableName + ">, List<" + TableName + "Dto>>(items));" + "\r\n");
                sb.Append("\t" + "\t" + "}" + "\r\n" + "\r\n");

                //GetAsync
                sb.Append("\t" + "\t" + "public async Task<" + TableName + "Dto> GetAsync(" + htColumns[0].TypeName + " id)" + "\r\n");
                sb.Append("\t" + "\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "var items = await _i" + TableName + "Repository.GetAsync(id);" + "\r\n");

                sb.Append("\t" + "\t" + "\t" + "if (items != null && items.IsDeleted==true)" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "\t" + "items = null;" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "}" + "\r\n");

                sb.Append("\t" + "\t" + "\t" + "return ObjectMapper.Map<" + TableName + ", " + TableName + "Dto>(items);" + "\r\n");
                sb.Append("\t" + "\t" + "}" + "\r\n" + "\r\n");

                //Create
                sb.Append("\t" + "\t" + "public async Task<" + TableName + "Dto> Create(CreateUpdate" + TableName + "Dto input)" + "\r\n");
                sb.Append("\t" + "\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "\t" + "var item = ObjectMapper.Map<CreateUpdate" + TableName + "Dto, " + TableName + ">(input);" + "\r\n");

                sb.Append("\t" + "\t" + "\t" + "var data = await _i" + TableName + "Repository.InsertAsync(item,true);" + "\r\n");

                sb.Append("\t" + "\t" + "\t" + "return ObjectMapper.Map<" + TableName + ", " + TableName + "Dto>(data);" + "\r\n");

                sb.Append("\t" + "\t" + "}" + "\r\n" + "\r\n");


                //Update
                sb.Append("\t" + "\t" + "public async Task<" + TableName + "Dto> Update(" + htColumns[0].TypeName + " id, CreateUpdate" + TableName + "Dto input)" + "\r\n");
                sb.Append("\t" + "\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "var item = await _i" + TableName + "Repository.GetAsync(id);" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "if (item != null && item.IsDeleted==false)" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "{" + "\r\n");
                foreach (ColumnTable col in htColumns)
                {
                    if (!ListColumnBase.Contains(col.ColumnName))
                        if (col.Key == false)
                        {
                            sb.Append("\t" + "\t" + "\t" + " item." + col.ColumnName + " = input." + col.ColumnName + ";" + "\r\n");
                        }
                }
                sb.Append("\t" + "\t" + "\t" + "var data = await _i" + TableName + "Repository.UpdateAsync(item, true);" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "return ObjectMapper.Map<" + TableName + ", " + TableName + "Dto>(data);" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "}" + "\r\n");

                sb.Append("\t" + "\t" + "return ObjectMapper.Map<" + TableName + ", " + TableName + "Dto>(item);" + "\r\n");
                sb.Append("\t" + "\t" + "}" + "\r\n" + "\r\n");

                //Delete
                sb.Append("\t" + "\t" + "public async Task Delete(" + htColumns[0].TypeName + " id)" + "\r\n");
                sb.Append("\t" + "\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "var item = await _i" + TableName + "Repository.GetAsync(id);" + "\r\n");

                sb.Append("\t" + "\t" + "\t" + "if (item != null && item.IsDeleted==false)" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "{" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "\t" + "item.IsDeleted = true;" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "\t" + "await _i" + TableName + "Repository.UpdateAsync(item, true);" + "\r\n");
                sb.Append("\t" + "\t" + "\t" + "}" + "\r\n");
                sb.Append("\t" + "\t" + "}" + "\r\n" + "\r\n");

                //Get/Delete FK
                foreach (ColumnTable col in htColumns)
                {
                    if (!ListColumnBase.Contains(col.ColumnName))
                        if ((col.Key == false) && col.ColumnName.Length > 2)
                        {
                            string fk_id = col.ColumnName.Substring(col.ColumnName.Length - 2, 2);
                            if (!string.IsNullOrWhiteSpace(fk_id) && fk_id.ToLower().Trim() == "id")
                            {

                                //GetValue
                                sb.Append("\t" + "\t" + "public async Task<List<" + TableName + "Dto>> GetListBy" + col.ColumnName.Trim() + "Async(" + col.TypeName + " " + col.ColumnName.Trim() + ")" + "\r\n");
                                sb.Append("\t" + "\t" + "{" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "var items = await _i" + TableName + "Repository.GetListAsync();" + "\r\n");

                                sb.Append("\t" + "\t" + "\t" + "if (items != null && items.Count > 0)" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "{" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "\t" + "    items = items.Where(x => x.IsDeleted == false && x." + col.ColumnName.Trim() + "==" + col.ColumnName.Trim() + ").ToList();" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "}" + "\r\n");

                                sb.Append("\t" + "\t" + "\t" + "return new List<" + TableName + "Dto>(ObjectMapper.Map<List<" + TableName + ">, List<" + TableName + "Dto>>(items));" + "\r\n");
                                sb.Append("\t" + "\t" + "}" + "\r\n" + "\r\n");


                                //Delete

                                sb.Append("\t" + "\t" + "public async Task DeleteBy" + col.ColumnName.Trim() + "(" + col.TypeName + " " + col.ColumnName.Trim() + ")" + "\r\n");
                                sb.Append("\t" + "\t" + "{" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "var items = await _i" + TableName + "Repository.GetListAsync();" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "if (items != null && items.Count > 0)" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "{" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "\t" + "items = items.Where(x => x.IsDeleted == false && x." + col.ColumnName.Trim() + "==" + col.ColumnName.Trim() + ").ToList();" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "\t" + "items.ForEach(o =>" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "\t" + "{" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "\t" + "\t" + "o.IsDeleted = true;" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "\t" + "\t" + "_i" + TableName + "Repository.UpdateAsync(o, true);" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "\t" + "});" + "\r\n");
                                sb.Append("\t" + "\t" + "\t" + "}" + "\r\n");
                                sb.Append("\t" + "\t" + "}" + "\r\n");
                            }
                        }
                }

                //Thoat
                sb.Append("\t" + "\t" + "#endregion" + "\r\n");
                //End Class
                sb.Append("\t" + "}" + "\r\n");
                //Ending Brace For Namespace
                sb.Append("}");
                //now we create the file with the TableName.cs
                WriteFile(TableName + "AppService", GroupFile.Application.ToString() + @"\Services", sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }
        #endregion

        #region SDK
        private void bar_SDK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lvTables.SelectedItem == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn table trước!");
                return;
            }
            if (ColumnTableList == null || ColumnTableList.Count == 0)
            {
                GGFunctions.ShowMessage("Không có tham số của table!");
                return;
            }
            string table = ColumnTableList[0].TableName;

            CreateFileISDK(table, ColumnTableList);

            GGFunctions.ShowMessage("Xuất file thành công!");
        }

        private bool CreateFileISDK(string TableName, List<ColumnTable> htColumns)
        {
            bool check = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;" + "\r\n");
                sb.Append("using Refit;" + "\r\n");
                sb.Append("using System.Collections.Generic;" + "\r\n");
                sb.Append("using System.Threading.Tasks;" + "\r\n");
                sb.Append("using " + txt_Service.EditValue.ToString().Trim() + "." + TableName + ".Dtos;" + "\r\n");
                sb.Append("" + "\r\n");
                sb.Append("namespace " + txt_SDK.EditValue.ToString().Trim() + "\r\n");
                //Start Brace For Namespace
                sb.Append("{" + "\r\n");

                //just a quicky summary to identify it as a generated class
                sb.Append("\t" + "/// <summary>" + "\r\n");
                sb.Append("\t" + "/// Generated ISDK for Table : " + TableName + "." + "\r\n");
                sb.Append("\t" + "/// </summary>" + "\r\n");

                //start with our class name
                sb.Append("\t" + "public interface I" + TableName + "sApi" + "\r\n");
                sb.Append("\t" + "{" + "\r\n");

                sb.Append("\t" + "\t" + "#region Generated By Column" + "\r\n" + "\r\n");


                //GetListAsync

                sb.Append("\t" + "\t" + "[Get(" + "\"" + "/api/app/" + TableName + "" + "\"" + ")]" + "\r\n");
                sb.Append("\t" + "\t" + "Task<List<" + TableName + "Dto>> GetListAsync();" + "\r\n" + "\r\n");


                //Create
                sb.Append("\t" + "\t" + "[Post(" + "\"" + "/api/app/" + TableName + "" + "\"" + ")]" + "\r\n");
                sb.Append("\t" + "\t" + "Task<" + TableName + "Dto> Create([Body] CreateUpdate" + TableName + "Dto info);" + "\r\n" + "\r\n");

                //GetAsync
                sb.Append("\t" + "\t" + "[Get(" + "\"" + "/api/app/" + TableName + "/{" + htColumns[0].ColumnName + "}" + "\"" + ")]" + "\r\n");
                sb.Append("\t" + "\t" + "Task<" + TableName + "Dto> GetAsync(" + htColumns[0].TypeName + " " + htColumns[0].ColumnName + ");" + "\r\n" + "\r\n");

                //Update
                sb.Append("\t" + "\t" + "[Put(" + "\"" + "/api/app/" + TableName + "/{" + htColumns[0].ColumnName + "}" + "\"" + ")]" + "\r\n");
                sb.Append("\t" + "\t" + "Task<" + TableName + "Dto> Update(" + htColumns[0].TypeName + " " + htColumns[0].ColumnName + ", [Body] CreateUpdate" + TableName + "Dto info);" + "\r\n" + "\r\n");

                //Delete
                sb.Append("\t" + "\t" + "[Delete(" + "\"" + "/api/app/" + TableName + "/{" + htColumns[0].ColumnName + "}" + "\"" + ")]" + "\r\n");
                sb.Append("\t" + "\t" + "Task Delete(" + htColumns[0].TypeName + " " + htColumns[0].ColumnName + ");" + "\r\n" + "\r\n");

                foreach (ColumnTable col in htColumns)
                {
                    if (!ListColumnBase.Contains(col.ColumnName))
                        if ((col.Key == false) && col.ColumnName.Length > 2)
                        {
                            string fk_id = col.ColumnName.Substring(col.ColumnName.Length - 2, 2);
                            if (!string.IsNullOrWhiteSpace(fk_id) && fk_id.ToLower().Trim() == "id")
                            {
                                //GetByFKAsync
                                sb.Append("\t" + "\t" + "[Get(" + "\"" + "/api/app/" + TableName + "/by" + col.ColumnName + "/{" + col.ColumnName + "}" + "\"" + ")]" + "\r\n");
                                sb.Append("\t" + "\t" + "Task<List<" + TableName + "Dto>> GetListBy" + col.ColumnName.Trim() + "Async(" + col.TypeName + " " + col.ColumnName.Trim() + ");" + "\r\n" + "\r\n");

                                //DeleteByFK
                                sb.Append("\t" + "\t" + "[Delete(" + "\"" + "/api/app/" + TableName + "/by" + col.ColumnName + "/{" + col.ColumnName + "}" + "\"" + ")]" + "\r\n");
                                sb.Append("\t" + "\t" + "Task DeleteBy" + col.ColumnName.Trim() + "(" + col.TypeName + " " + col.ColumnName.Trim() + ");" + "\r\n" + "\r\n");
                            }
                        }
                }

                sb.Append("\t" + "\t" + "#endregion" + "\r\n");
                //End Class
                sb.Append("\t" + "}" + "\r\n");
                //Ending Brace For Namespace
                sb.Append("}");
                //now we create the file with the TableName.cs
                WriteFile("I" + TableName + "Api", GroupFile.SDK.ToString() + @"\" + txt_Project.EditValue.ToString().Trim(), sb.ToString());
            }
            catch (Exception ex)
            {
                GGFunctions.ShowMessage(ex.Message);
                check = false;
            }
            return check;
        }

        #endregion

        #region GenAll
        private void bar_GenAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lvTables.SelectedItem == null)
            {
                GGFunctions.ShowMessage("Vui lòng chọn table trước!");
                return;
            }
            if (ColumnTableList == null || ColumnTableList.Count == 0)
            {
                GGFunctions.ShowMessage("Không có tham số của table!");
                return;
            }
            string table = ColumnTableList[0].TableName;

            //1.Domain
            CreateFileDomain(table, ColumnTableList);
            //2.CreateFileBaseEntity
            CreateFileBaseEntity(table, ColumnTableList);
            //3.CreateFileRepositoryDomain
            CreateFileRepositoryDomain(table, ColumnTableList);
            //4.ContractDtos
            CreateFileContractDtos(table, ColumnTableList);
            //5.CreateFileCreateUpdateDto
            CreateFileCreateUpdateDto(table, ColumnTableList);
            //6.CreateFileIAppService
            CreateFileIAppService(table, ColumnTableList);
            //7.CreateFileAppService
            CreateFileAppService(table, ColumnTableList);
            //8.AppServiceBase
            AppServiceBase(table, ColumnTableList);
            //9.CreateFileISDK
            CreateFileISDK(table, ColumnTableList);
            //10.CreateFileEFCoreRepository
            CreateFileEFCoreRepository(table, ColumnTableList);
            //11.EFCore
            CreateFileEFCore(table, ColumnTableList);


            GGFunctions.ShowMessage("Xuất file thành công!");
        }
        #endregion

        #region WriteFile
        private void WriteFile(string FileName, string Group, string str)
        {
            string path = ConfigManager.PathGenerate() + @"\" + Group;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText(path + @"\" + FileName + ".cs", str);
            rtfClass.Clear();
            rtfClass.AppendText(str);
        }

        private void WriteFileNotExport(string str)
        {
            rtfClass.Clear();
            rtfClass.AppendText(str);
        }

        #endregion


    }
}