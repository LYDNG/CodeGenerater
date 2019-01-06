namespace MyCodeGenerater.Core
{
    using MyCodeGenerater.Core.Entity;
    using System;
    using System.Data;

    public class GeneraterFacade
    {
        private string m_ConnString = string.Empty;
        private GeneraterService service = null;

        public GeneraterFacade(string connstring)
        {
            this.m_ConnString = connstring;
            ModelEntity model = new ModelEntity {
                ConnectionString = connstring
            };
            this.service = new GeneraterService(model);
        }

        public ModelEntity GetModel()
        {
            return this.service.FindModel();
        }

        public TableEntity GetTable(string tableName,bool hasDefault=false)
        {
            return new TableEntity { Name = tableName, Comments = this.service.GetTableComments(tableName), Columns = this.service.FindColumns(tableName, hasDefault) };
        }


        public DataTable ExecuteDataTable(string commandText, params Oracle.DataAccess.Client.OracleParameter[] commandParameters)
        {
            return OracleHelper.ExecuteDataTable(m_ConnString, CommandType.Text, commandText, commandParameters);
        }
    }
}

