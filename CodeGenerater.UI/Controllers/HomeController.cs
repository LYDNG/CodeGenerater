using MyCodeGenerater.Core;
using MyCodeGenerater.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CodeGenerater.UI.Controllers
{
    public class HomeController : Controller
    {
        static string defalutConn = "gongdan";
        string defalutConnstr = System.Configuration.ConfigurationManager.ConnectionStrings[defalutConn].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JsonFormart()
        {
            return View();
        }

        public ActionResult EntityTemplate(string conn = "", string tableName = "")
        {
            var table = new TableEntity()
            {
                Columns = new List<ColumnEntity>(),
                Comments = "N/A",
                Name = "UNTABLE"
            };
            string connstr = "";
            if (string.IsNullOrEmpty(conn))
            {
                conn = defalutConn;
                connstr = defalutConnstr;
            }
            else
            {
                connstr = System.Configuration.ConfigurationManager.ConnectionStrings[conn].ConnectionString;
            }
            ViewBag.Conn = conn;
            ViewBag.TableName = tableName;
            tableName = tableName.Trim().ToUpper();
            try
            {
                if (!string.IsNullOrEmpty(tableName))
                {
                    var facade = new GeneraterFacade(connstr);
                    table = facade.GetTable(tableName);
                    if (table.Columns.Count <= 0)
                    {
                        table.Comments = "不存在的表名，或者没有列";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View(table);
        }
        public ActionResult RegisterMapping(string conn = "", string tableName = "")
        {
            var table = new TableEntity()
            {
                Columns = new List<ColumnEntity>(),
                Comments = "N/A",
                Name = "UNTABLE"
            };
            string connstr = "";
            if (string.IsNullOrEmpty(conn))
            {
                conn = defalutConn;
                connstr = defalutConnstr;
            }
            else
            {
                connstr = System.Configuration.ConfigurationManager.ConnectionStrings[conn].ConnectionString;
            }
            ViewBag.Conn = conn;
            ViewBag.TableName = tableName;
            tableName = tableName.Trim().ToUpper();
            try
            {
                if (!string.IsNullOrEmpty(tableName))
                {
                    var facade = new GeneraterFacade(connstr);
                    table = facade.GetTable(tableName);
                    if (table.Columns.Count <= 0)
                    {
                        table.Comments = "不存在的表名，或者没有列";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View(table);
        }


        public ActionResult AllColumn(string conn = "", string tableName = "")
        {
            var table = new TableEntity()
            {
                Columns = new List<ColumnEntity>(),
                Comments = "N/A",
                Name = "UNTABLE"
            };
            string connstr = "";
            if (string.IsNullOrEmpty(conn))
            {
                conn = defalutConn;
                connstr = defalutConnstr;
            }
            else
            {
                connstr = System.Configuration.ConfigurationManager.ConnectionStrings[conn].ConnectionString;
            }
            ViewBag.Conn = conn;
            ViewBag.TableName = tableName;
            ViewBag.SelectStr = "";
            tableName = tableName.Trim().ToUpper();
            try
            {
                if (!string.IsNullOrEmpty(tableName))
                {
                    var facade = new GeneraterFacade(connstr);
                    table = facade.GetTable(tableName, true);
                    if (table.Columns.Count <= 0)
                    {
                        table.Comments = "不存在的表名，或者没有列";
                    }
                    var str = new StringBuilder();
                    str.Append("SELECT ");
                    foreach (var item in table.Columns)
                    {
                        str.Append("T.");
                        if (item.Name == table.Columns[table.Columns.Count - 1].Name)
                        {
                            str.Append(item.Name + " " + item.PascalName);
                        }
                        else
                        {
                            str.Append(item.Name + " " + item.PascalName + ",");
                        }
                    }

                    str.Append(" FROM " + table.Name);
                    str.Append(" T");

                    ViewBag.SelectStr = str.ToString();



                    var filedStr = new StringBuilder();
                    var pascalStr = new StringBuilder();
                    foreach (var item in table.Columns)
                    {
                        filedStr.Append(item.Name);
                        pascalStr.Append(":");
                        pascalStr.Append(item.PascalName);
                        if (item.Name != table.Columns[table.Columns.Count - 1].Name)
                        {
                            filedStr.Append(",");
                            pascalStr.Append(",");
                        }
                    }
                    ViewBag.InsertStr = $"INSERT INTO {table.Name} ({filedStr}) VALUES ({pascalStr})";
                }
            }
            catch (Exception)
            {

            }
            return View(table);
        }
    }
}