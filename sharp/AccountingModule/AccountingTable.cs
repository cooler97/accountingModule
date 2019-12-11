/*
 * Created by SharpDevelop.
 * User: At
 * Date: 24.09.2019
 * Time: 15:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;

namespace AccountingModule
{
    /// <summary>
    /// Description of AccountingTable.
    /// </summary>
    public class AccountingTable : DataTable
    {
        public AccountingTable()
        {
            this.TableName = "accounting";
            
            DataColumn primary = new DataColumn("idaccounting", typeof(int));
            
            Columns.Add(primary);
            Columns.Add(new DataColumn("idorder", typeof(int)));
            Columns.Add(new DataColumn("idcustomer", typeof(int)));
            Columns.Add(new DataColumn("dtdoc", typeof(DateTime)));
            Columns.Add(new DataColumn("typedoc", typeof(int)));
            Columns.Add(new DataColumn("namedoc", typeof(string)));
            Columns.Add(new DataColumn("quconstr", typeof(int)));
            Columns.Add(new DataColumn("idsign", typeof(int)));
            Columns.Add(new DataColumn("smorder", typeof(double)));
            Columns.Add(new DataColumn("smdoc", typeof(double)));         
            Columns.Add(new DataColumn("deleted", typeof(DateTime)));
            Columns.Add(new DataColumn("comment", typeof(string)));
            
            PrimaryKey = new DataColumn[] { primary };
        }
    }
}
