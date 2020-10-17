using System;
namespace xdcb.FormServices.Component
{
    public enum RepositoryItem
    {
        RepositoryItemTextEdit,
        RepositoryItemDateEdit,
        RepositoryItemCheckEdit
    }
    public interface IGGControl
    {
        String GGDataSource { get; set; }

        String GGDataMember { get; set; }

        String GGFieldGroup { get; set; }

        String GGFieldRelation { get; set; }

        void InitializeControl();

        void InitializeControlByDesign(string path,string strCreate);
    }

   
}
