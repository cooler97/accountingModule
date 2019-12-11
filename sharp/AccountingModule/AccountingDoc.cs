/*
 * Created by SharpDevelop.
 * User: At
 * Date: 24.09.2019
 * Time: 15:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using Atechnology.Components.AtLogWatcher;
using Atechnology.DBConnections2;

namespace AccountingModule
{
    /// <summary>
    /// Description of AccountingDoc.
    /// </summary>
    public class AccountingDoc
    {
        private dbconn db;
        
        private AccountingTable accountingTable = new AccountingTable();
        
        private AccountListView view;
        
        public AccountingTable AccountingTable
        {
            get { return accountingTable; }
        }
        
        public AccountingDoc()
        {
        }
        
        public AccountingDoc(dbconn db, AccountListView view)
        {
            this.db = db;
            this.view = view;
            
            try
            {
                
                if (db != null)
                {
                    this.FillAccountingTable(null);
                    this.view.DataSource = accountingTable;
                }
                else
                {
                    AtLog.AddMessage("db is null");
                }
            }
            catch (Exception e)
            {
                AtLog.AddMessage(e.ToString());
            }
        }
        
        public void FillAccountingTable(FilterParam filterParam)
        {
            accountingTable.Clear();
            db.command.CommandText = "SELECT * FROM dbo.view_accounting";
            db.OpenDB();
            db.adapter.Fill(accountingTable);
            db.CloseDB();
            accountingTable.AcceptChanges();
            AtLog.AddMessage("FillAccountingTable");
        }
        
        public void SaveAccountingTable()
        {
            if(db == null || accountingTable.GetChanges() == null)
                return;
            
            try
            {
                DataTable dt = accountingTable.GetChanges();
                foreach(DataRow dr in dt.Rows){
                    if((int)dr["typedoc"] == 0 && dr["smorder"] != DBNull.Value) {
                        dr["smdoc"] = dr["smorder"];
                    }
                }
                
                if(!db.SaveDatatableAndAccept(dt))
                {
                    AtLog.AddMessage("Error: SaveDatatableAndAccept");
                }
                
            }
            catch(Exception ex) {
                AtLog.AddMessage(ex.ToString());
            }
        }
        
        public bool HaveChanges() {
            return accountingTable.GetChanges() != null;
        }
    }
}
