using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Atechnology.Components.AtLogWatcher;
using Atechnology.DBConnections2;
using DbExtensions;

namespace AccountingModule
{
    public class AccountingDoc
    {
        public static int TYPEDOC_ORDER = 0;
        public static int TYPEDOC_BONUS = 1;
        public static int TYPEDOC_SALDO = 2;
        public static int TYPEDOC_PAYMENT = 3;
        
        private dbconn db;
        
        private DataTable AccountingView {get; set;}
        
        private AccountListView view;

        public AccountingDoc()
        {
        }
        
        public AccountingDoc(dbconn db, AccountListView view, FilterParam filterParam)
        {
            this.db = db;
            this.view = view;
            this.AccountingView = new DataTable();
            
            try
            {
                
                if (db != null)
                {
                    this.FillAccountingTable(filterParam);
                    this.view.DataSource = AccountingView;
//                    this.view.AutoSizeColumn();
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
            try
            {
                AccountingView.Clear();
                
                var query = new SqlBuilder()
                    .SELECT("idaccounting, idorder, idcustomer, " +
                            "dtdoc, typedoc, typedocname, namedoc, " +
                            "quconstr, idsign, smorder, smdoc, deleted, " +
                            "comment, name, accountingsign, " +
                            "customername, customercode")
                    .FROM("view_accounting")
                    .WHERE(" dtdoc BETWEEN '{0}' AND '{1}' ", new object[] {
                               filterParam.dateFrom.ToString(),
                               filterParam.dateTo.ToString()
                           }
                          );
                
                db.command.CommandText = String.Format(query.ToString(), ToGenericArray(query.ParameterValues));

                string debugSQL = db.command.CommandText;
                foreach (SqlParameter param in db.command.Parameters)
                {
                    debugSQL = debugSQL.Replace(param.ParameterName, param.Value.ToString());
                }
                AtLog.AddMessage(debugSQL);
                
                db.OpenDB();
                db.adapter.Fill(AccountingView);
                db.CloseDB();
                AccountingView.AcceptChanges();
                
            } catch(Exception e) {
                
                if(AccountingView.HasErrors)
                {
                    DataRow[] rowsInError = AccountingView.GetErrors();
                    for(int i = 0; i < rowsInError.Length; i++)
                    {
                        foreach(DataColumn column in AccountingView.Columns)
                        {
                            AtLog.AddMessage(column.ColumnName + " " +
                                             rowsInError[i].GetColumnError(column));
                        }
                        rowsInError[i].ClearErrors();
                    }
                    
                }
                else
                {
                    AtLog.AddMessage(e.Message);
                }
            }
        }
        
        public void SaveAccountingTable()
        {
            if(db == null || AccountingView.GetChanges() == null)
                return;
            
            try
            {
                var query = new SqlBuilder()
                    .UPDATE("accounting SET comment = '{0}'")
                    .WHERE("idaccounting = {1}");
                
                string sql = "";
                DataTable dt = AccountingView.GetChanges();
                foreach(DataRow dr in dt.Rows){
                    sql = String.Format(query.ToString(), dr["comment"], dr["idaccounting"]);
                    AtLog.AddMessage(sql);
                    db.Exec(sql, false);
                }
                
                dt.AcceptChanges();
                
            }
            catch(Exception ex) {
                AtLog.AddMessage(ex.ToString());
            }
        }
        
        public DataTable GetCustomerTable()
        {
            if(db == null)
                throw new ArgumentNullException("DB connection is null!");
            
            DataTable result = new DataTable();
            
            string sql = "SELECT idcustomer, name as customer_name, inn " +
                "FROM customer WHERE deleted IS NULL AND inn IS NOT NULL";
            
            AtLog.AddMessage(sql);
            
            db.command.CommandText = sql;
            
            db.OpenDB();
            db.adapter.Fill(result);
            db.CloseDB();
            
            return result;
        }
        
        public DataRow GetSeller(int idseller)
        {
            if(db == null)
                throw new ArgumentNullException("DB connection is null!");
            
            DataTable result = new DataTable();
            
            string sql = String.Format("SELECT idseller, name, inn " +
                                       "FROM seller WHERE idseller = {0}", idseller);
            
            AtLog.AddMessage(sql);
            
            db.command.CommandText = sql;
            
            db.OpenDB();
            db.adapter.Fill(result);
            db.CloseDB();
            
            return (result.Rows.Count > 0) ? result.Rows[0] : null;
        }
        
        public bool HaveChanges() {
            return AccountingView.GetChanges() != null;
        }
        
        public int GenPaymentId()
        {
            return dbconn.GetGenId("gen_payment");
        }
        
        public int GenPaymentGroupId()
        {
            return dbconn.GetGenId("gen_paymentdocgroup");
        }
        
        public int AddPaymentGroup(string name)
        {
            if(db == null)
                throw new ArgumentNullException("DB connection is null!");
            
            int idPaymentGroup = -1;
            
            try
            {
                idPaymentGroup = GenPaymentGroupId();
                
                string sql = String.Format("INSERT INTO paymentdocgroup " +
                                           "(idpaymentdocgroup, name, typ, isload, numpos) " +
                                           "VALUES({0},'{1}',{2},{3},{4});",
                                           new object[] {idPaymentGroup,
                                               name,
                                               0,
                                               1,
                                               1}
                                          );

                AtLog.AddMessage(sql);
                
                db.Exec(sql, true);
                
            }
            catch(Exception ex) {
                AtLog.AddMessage(ex.ToString());
            }
            
            return idPaymentGroup;
        }
        
        public int ExistPaymentGroup(string name)
        {
            if(db == null)
                throw new ArgumentNullException("DB connection is null!");
            
            int result = -1;
            
            try
            {
                string sql = String.Format("SELECT idpaymentdocgroup FROM paymentdocgroup WHERE name = '{0}' AND deleted IS NULL", name);
                
                AtLog.AddMessage(sql);
                
                db.ExecScalar(sql,
                              -1,
                              out result);
            }
            catch(Exception ex) {
                AtLog.AddMessage(ex.ToString());
            }
            
            return result;
        }
        
        public AccountValut BaseValut()
        {
            if(db == null)
                throw new ArgumentNullException("DB connection is null!");
            
            AccountValut val = new AccountValut();
            
            try
            {
                string sql = String.Format("SELECT * FROM valut WHERE deleted IS NULL AND isbase = 1");
                
                AtLog.AddMessage(sql);
                
                DataRow row = db.GetDataRow(sql);
                
                if(row == null)
                    return null;
                
                val.idvalut = (int)row["idvalut"];
                val.name = (string)row["name"];
                val.shortname = (string)row["shortname"];
                val.ValutRate = 1d;
            }
            catch(Exception ex) {
                AtLog.AddMessage(ex.ToString());
            }
            
            return val;
        }
        
        public bool SavePayment(Payment payment)
        {
            if(db == null)
                throw new ArgumentNullException("DB connection is null!");
            
            try
            {
                int idpayment = GenPaymentId();
                
                string sql = "INSERT INTO paymentdoc (" +
                    "idpaymentdoc, name, idpeople, " +
                    "idcustomer, dtcre, dtdoc, smdoc, logincre, " +
                    "iddocoper, idvalut, valutrate, smbase, " +
                    "idpaymentdocgroup, comment) VALUES (@idpaymentdoc, " +
                    "@name, @idpeople, @idcustomer, @dtcre, @dtdoc, @smdoc, @logincre, @iddocoper, " +
                    "@idvalut, @valutrate, @smbase, @idpaymentdocgroup, @comment)";

                AtLog.AddMessage(sql);
                
                db.command.Parameters.Clear();
                
                db.command.CommandText = sql;
                
                db.command.Parameters.AddWithValue("idpaymentdoc", idpayment);
                db.command.Parameters.AddWithValue("name", (String.IsNullOrEmpty(payment.Name)) ? "" : payment.Name);
                db.command.Parameters.AddWithValue("idpeople", payment.IdPeople);
                db.command.Parameters.AddWithValue("idcustomer", payment.IdCustomer);
                db.command.Parameters.AddWithValue("dtcre", payment.DtCre);
                db.command.Parameters.AddWithValue("dtdoc", payment.DtDoc);
                db.command.Parameters.AddWithValue("smdoc", payment.SmDoc);
                db.command.Parameters.AddWithValue("logincre", payment.loginCre);
                db.command.Parameters.AddWithValue("iddocoper", payment.IdDocOper);
                db.command.Parameters.AddWithValue("idvalut", payment.Valut.idvalut);
                db.command.Parameters.AddWithValue("valutrate", payment.Valut.ValutRate);
                db.command.Parameters.AddWithValue("smbase", payment.SmBase);
                db.command.Parameters.AddWithValue("idpaymentdocgroup", payment.IdPaymentDocGroup);
                db.command.Parameters.AddWithValue("comment", payment.AddStr);
                
                db.command.ExecuteNonQuery();
                
                return true;
            }
            catch(Exception exp) {
                dbconn.ShowErrors(exp.Message, "Ошибка выполнения");
            }
            
            return false;

        }
        
        public static T[] ToGenericArray<T>(Collection<T> collection)
        {
            if (collection == null)
            {
                return new T[] { };
            }

            return new List<T>(collection).ToArray();
        }
    }

}
