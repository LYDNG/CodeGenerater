namespace MyCodeGenerater.Core
{
    using MyCodeGenerater.Core.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;

    internal class GeneraterService
    {
        private ModelEntity m_Model = null;

        public GeneraterService(ModelEntity model)
        {
            this.m_Model = model;
        }

        public List<ColumnEntity> FindColumns(string tableName, bool hasDefault)
        {
            var noList = new List<string>() {
                "CREATOR","CREATION_TIME","CREATE_USERID","MODIFIER","MODIFIED_TIME","MODIFIED_USERID"
            };
            List<ColumnEntity> list = new List<ColumnEntity>();
            if (this.m_Model != null)
            {
                DataTable table = new OracleHelper(this.m_Model.ConnectionString).GetTable("SELECT A.COLUMN_NAME,A.DATA_SCALE,A.DATA_TYPE,B.COMMENTS,A.NULLABLE,A.CHAR_COL_DECL_LENGTH\r\n                                            FROM (SELECT * FROM USER_TAB_COLS WHERE TABLE_NAME='" + tableName + "'  order by column_id) A \r\n                                            LEFT JOIN \r\n                                            (SELECT * FROM USER_COL_COMMENTS WHERE TABLE_NAME='" + tableName + "') B\r\n                                            ON A.COLUMN_NAME=B.COLUMN_NAME");
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (hasDefault)
                        {
                            ColumnEntity item = new ColumnEntity
                            {
                                Name = row["COLUMN_NAME"].ToString(),
                                DBType = row["DATA_TYPE"].ToString(),
                                Comments = row["COMMENTS"].ToString(),
                                DataScale = row["DATA_SCALE"].ToString(),
                                NullAble= row["NULLABLE"].ToString()
                            };
                            var l = row["CHAR_COL_DECL_LENGTH"];
                            if (l == null || l == DBNull.Value)
                            {
                                item.Length = null;
                            }
                            else
                            {
                                item.Length = Convert.ToInt32(l);
                            }
                            list.Add(item);
                        }
                        else
                        {
                            if (!noList.Contains(row["COLUMN_NAME"].ToString()))
                            {
                                ColumnEntity item = new ColumnEntity
                                {
                                    Name = row["COLUMN_NAME"].ToString(),
                                    DBType = row["DATA_TYPE"].ToString(),
                                    Comments = row["COMMENTS"].ToString(),
                                    DataScale = row["DATA_SCALE"].ToString(),
                                    NullAble = row["NULLABLE"].ToString()
                                };
                                var l = row["CHAR_COL_DECL_LENGTH"];
                                if (l == null || l == DBNull.Value)
                                {
                                    item.Length = null;
                                }
                                else
                                {
                                    item.Length = Convert.ToInt32(l);
                                }
                                list.Add(item);
                            }
                        }
                    }
                }
            }
            return list;
        }

        public ModelEntity FindModel()
        {
            DataTable table = new OracleHelper(this.m_Model.ConnectionString).GetTable("SELECT * FROM USER_TABLES");
            if (table.Rows.Count > 0)
            {
                List<string> list = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    list.Add(row["TABLE_NAME"].ToString());
                }
                this.m_Model.TableNames = list;
            }
            return this.m_Model;
        }

        public string GetTableComments(string table)
        {
            DataTable table2 = new OracleHelper(this.m_Model.ConnectionString).GetTable("SELECT COMMENTS FROM USER_TAB_COMMENTS WHERE TABLE_NAME='" + table + "' AND TABLE_TYPE='TABLE'");
            if (table2.Rows.Count > 0)
            {
                return table2.Rows[0][0].ToString();
            }
            return string.Empty;
        }
    }
}

