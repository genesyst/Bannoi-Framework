using Microsoft.Data.ConnectionUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Services
{
    public enum dbStatus {dbAddNew,dbEdit,dbUpdate,dbInsert,dbDelete,dbFilter,dbCancel,dbNone }
    public partial class bnsServiceDb
    {
        public bnsServiceDb()
        {

        }

        public static bool TryGetDataConnectionStringFromUser(out string outConnectionString)
        {
            using (var dialog = new DataConnectionDialog())
            {
                // If you want the user to select from any of the available data sources, do this:
                DataSource.AddStandardDataSources(dialog);

                // OR, if you want only certain data sources to be available
                // (e.g. only SQL Server), do something like this instead: 
                dialog.DataSources.Add(DataSource.SqlDataSource);
                dialog.DataSources.Add(DataSource.SqlFileDataSource);

                // The way how you show the dialog is somewhat unorthodox; `dialog.ShowDialog()`
                // would throw a `NotSupportedException`. Do it this way instead:
                DialogResult userChoice = DataConnectionDialog.Show(dialog);

                // Return the resulting connection string if a connection was selected:
                if (userChoice == DialogResult.OK)
                {
                    outConnectionString = dialog.ConnectionString;
                    return true;
                }
                else
                {
                    outConnectionString = null;
                    return false;
                }
            }
        }

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

             // column names 
             PropertyInfo[] oProps = null; 

             if (varlist == null) return dtReturn;

             foreach (T rec in varlist)
             {
                  // Use reflection to get property names, to create table, Only first time, others 
                  //will follow 
                  if (oProps == null)
                  {
                       oProps = ((Type)rec.GetType()).GetProperties();
                       foreach (PropertyInfo pi in oProps)
                       {
                            Type colType = pi.PropertyType;

                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()      
                            ==typeof(Nullable<>)))
                             {
                                 colType = colType.GetGenericArguments()[0];
                             }

                            dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                       }
                  }

                  DataRow dr = dtReturn.NewRow();

                  foreach (PropertyInfo pi in oProps)
                  {
                       dr[pi.Name] = pi.GetValue(rec, null) == null ?DBNull.Value :pi.GetValue
                       (rec,null);
                  }

                  dtReturn.Rows.Add(dr);
             }
             return dtReturn;
        }
    }
}
