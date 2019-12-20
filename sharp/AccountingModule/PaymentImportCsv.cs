using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Atechnology.ecad;

namespace AccountingModule
{

    public class PaymentImportCsv : PaymentImport
    {
        
        static string DATE = "Дата";
        static string CODE = "Код";
        static string CUSTOMER = "Контрагент";
        static string GRID = "#";
        static string SUM = "Приход";
        static string COMMENT = "Примечание";
        
        public DataColumn DATE_COLUMN = new DataColumn(DATE, typeof(DateTime));
        public DataColumn CODE_COLUMN = new DataColumn(CODE, typeof(int));
        public DataColumn CUSTOMER_COLUMN = new DataColumn(CUSTOMER, typeof(string));
        public DataColumn GRID_COLUMN = new DataColumn(GRID, typeof(string));
        public DataColumn SM_COLUMN = new DataColumn(SUM, typeof(double));
        public DataColumn COMMENT_COLUMN = new DataColumn(COMMENT, typeof(string));
        
        DataTable paymentCsv;
        
        DataColumn[] PaymentTableColumns;

        string path;
        
        public PaymentImportCsv(string path)
        {
            this.path = path;
            this.PaymentTableColumns = new [] {DATE_COLUMN,
                CODE_COLUMN,
                CUSTOMER_COLUMN,
                GRID_COLUMN,
                SM_COLUMN,
                COMMENT_COLUMN
            };
        }
        
        public override Payment GetPayment(int idPaymentGroup, AccountValut valut, DataRow paymentRow)
        {
            Payment payment = new Payment();
//            payment.Name = (string) paymentRow[PAYMENT_NUMBER];
            payment.DtCre = (DateTime) paymentRow[DATE];
            payment.DtDoc = (DateTime) paymentRow[DATE];
            payment.IdPeople = Settings.idpeople;
            payment.IdCustomer = (int) paymentRow[IDCUSTOMER_COLUMN];
            payment.loginCre = Settings.people_fio;
            payment.SmDoc = (double) paymentRow[SUM];
            payment.AddStr = (string) paymentRow[COMMENT];
            payment.Valut = valut;
            payment.SmBase = (double) paymentRow[SUM];
            payment.IdPaymentDocGroup = idPaymentGroup;
            payment.IdDocOper = Payment.DOCOPER_CREDIT_ORDER;
            return payment;
        }
        
        public override DataTable RowPaymentTable()
        {
            return paymentCsv;
        }
        
        public override void ImportPayment()
        {
            
            if(String.IsNullOrEmpty(path) || !File.Exists(path))
                throw new ArgumentNullException("Файл не существует или неверно указан путь!");
            
            paymentCsv = new DataTable();
            
            for(int count = 0; count < PaymentTableColumns.Length; count++)
            {
                paymentCsv.Columns.Add(PaymentTableColumns[count]);
            }

            using(var reader = new StreamReader(path, Encoding.GetEncoding("Windows-1251")))
            {
                string line = reader.ReadLine();
                
                string[] columns = line.Split(new char[] {';'});
                
                if(columns.Length != PaymentTableColumns.Length)
                {
                    throw new Exception("Не верный формат CSV файла");
                }
                
                int skipRow = 0;
                
                while(line != null && skipRow < 1)
                {
                    line = reader.ReadLine();
                    skipRow++;
                }
                
                while(line != null)
                {
                    columns = line.Split(new char[] {';'});
                    
                    DataRow row = paymentCsv.NewRow();
                    
                    for(int count = 0; count < paymentCsv.Columns.Count; count++)
                    {
                        DataColumn column = PaymentTableColumns[count];
                        
                        if(column.DataType == typeof(DateTime))
                        {
                            try
                            {
                                row[column] = DateTime.Parse(columns[count]);
                            }
                            catch(Exception exp)
                            {
                                row[column] = DateTime.Now.Date;
                            }
                        }
                        else if(column.DataType == typeof(int))
                        {
                            row[column] = Int32.Parse(columns[count]);
                        }
                        else if(column.DataType == typeof(double))
                        {
                            row[column] = Double.Parse(columns[count]);
                        }
                        else
                        {
                            row[column] = (string) columns[count];
                        }
                    }
                    
                    line = reader.ReadLine();
                    
                    paymentCsv.Rows.Add(row);
                }
            }
            
        }
    }
}
