using System;
using System.Data;
using System.IO;
using System.Text;
using Atechnology.ecad;

namespace AccountingModule
{

    public class ClientBankExchangeImport : PaymentImport
    {
        static string FILE_HEADER = "1CClientBankExchange";
        static string FILE_END = "КонецФайла";
        
        static string FORMAT_VERSION = "ВерсияФормата";
        static string VERSION = "1.02";

        static string FILE_ENCODING = "Кодировка";
        static string ENCODING_WINDOWS = "Windows";
        
        static string DOCUMENT_TYPE_PAYMENT = "Платежное поручение";
        
        public static string PAYMENT_NUMBER = "Номер";
        public static string PAYMENT_DATE = "Дата";
        public static string PAYMENT_SUM = "Сумма";
        public static string PAYMENT_PAYER_INN = "ПлательщикИНН";
        public static string PAYMENT_PAYER_NAME = "Плательщик1";
        public static string PAYMENT_RECIPIENT_INN = "ПолучательИНН";
        public static string PAYMENT_DESCRIPTION = "НазначениеПлатежа";
        
        static string DOCUMENT_START = "СекцияДокумент";
        static string DOCUMENT_END = "КонецДокумента";
        
        static char DELIMETER = '=';
        
        string[] PAYMENT_ATTR_STRING = new string[] {
            PAYMENT_PAYER_INN,
            PAYMENT_PAYER_NAME,
            PAYMENT_RECIPIENT_INN,
            PAYMENT_DESCRIPTION
        };
        
        public DataColumn DATE_COLUMN = new DataColumn(PAYMENT_DATE, typeof(DateTime));
        public DataColumn NUMBER_COLUMN = new DataColumn(PAYMENT_NUMBER, typeof(string));
        public DataColumn PAYER_INN_COLUMN = new DataColumn(PAYMENT_PAYER_INN, typeof(string));
        public DataColumn PAYER_NAME_COLUMN = new DataColumn(PAYMENT_PAYER_NAME, typeof(string));
        public DataColumn RECIPIENT_INN_COLUMN = new DataColumn(PAYMENT_RECIPIENT_INN, typeof(string));
        public DataColumn SUM_COLUMN = new DataColumn(PAYMENT_SUM, typeof(double));
        public DataColumn DESCRIPTION_COLUMN = new DataColumn(PAYMENT_DESCRIPTION, typeof(string));
        
        private DataTable paymentTable;
        
        DataColumn[] PaymentTableColumns;

        string inn;
        string path;
        
        public ClientBankExchangeImport(string inn, string path)
        {
            this.inn = inn;
            this.path = path;
            
            this.PaymentTableColumns =
                new [] {
                DATE_COLUMN,
                NUMBER_COLUMN,
                PAYER_INN_COLUMN,
                PAYER_NAME_COLUMN,
                RECIPIENT_INN_COLUMN,
                SUM_COLUMN,
                DESCRIPTION_COLUMN
            };
            
            paymentTable = new DataTable();
            
            for(int count = 0; count < PaymentTableColumns.Length; count++)
            {
                paymentTable.Columns.Add(PaymentTableColumns[count]);
            }
        }
        
        public override DataTable RowPaymentTable()
        {
            return paymentTable;
        }
        
        public override Payment GetPayment(int idPaymentGroup, AccountValut valut, DataRow paymentRow)
        {
            Payment payment = new Payment();
            payment.Name = (string) paymentRow[PAYMENT_NUMBER];
            payment.DtCre = (DateTime) paymentRow[PAYMENT_DATE];
            payment.DtDoc = (DateTime) paymentRow[PAYMENT_DATE];
            payment.IdPeople = Settings.idpeople;
            payment.IdCustomer = (int) paymentRow[IDCUSTOMER_COLUMN];
            payment.loginCre = Settings.people_fio;
            payment.SmDoc = (double) paymentRow[PAYMENT_SUM];
            payment.AddStr = (string) paymentRow[PAYMENT_DESCRIPTION];
            payment.Valut = valut;
            payment.SmBase = (double) paymentRow[PAYMENT_SUM];
            payment.IdPaymentDocGroup = idPaymentGroup;
            payment.IdDocOper = Payment.DOCOPER_INCOMING_PAYMENT_ORDER;
            return payment;
        }
        
        public override void ImportPayment()
        {
            
            if(String.IsNullOrEmpty(inn))
                throw new ArgumentNullException("Пустой ИНН получателя!");
            
            if(String.IsNullOrEmpty(path) || !File.Exists(path))
                throw new ArgumentNullException("Файл не существует или неверно указан путь!");
            
            using(var reader = new StreamReader(path, Encoding.GetEncoding("Windows-1251")))
            {
                string line = reader.ReadLine();
                
                if(line != FILE_HEADER)
                {
                    throw new ArgumentException("Выберите файл выгрузки из клиент-банка!");
                }
                
                DataRow row = null;
                
                while(line != null && line != FILE_END)
                {
                    string[] attr = line.Split(new char[] {DELIMETER});
                    
                    if(attr == null)
                        continue;
                    
                    if(attr[0] == DOCUMENT_START && attr[1] == DOCUMENT_TYPE_PAYMENT)
                    {
                        row = paymentTable.NewRow();
                    }
                    else if(attr[0] == PAYMENT_NUMBER)
                    {
                        row[PAYMENT_NUMBER] = (string) attr[1];
                    }
                    else if(attr[0] == PAYMENT_DATE)
                    {
                        DateTime dt = new DateTime();
                        DateTime.TryParse(attr[1], out dt);
                        row[PAYMENT_DATE] = dt;
                    }
                    else if(attr[0] == PAYMENT_SUM)
                    {
                        Double value;
                        Double.TryParse(attr[1].Replace('.', ','), out value);
                        row[PAYMENT_SUM] = value;
                    }
                    else if(attr[0] == DOCUMENT_END)
                    {
                        paymentTable.Rows.Add(row);
                        row = null;
                    }
                    else
                    {
                        TakeStringAttr(row, attr);
                    }
                    
                    
                    line = reader.ReadLine();
                }
            }
            
            for(int count = paymentTable.Rows.Count - 1; count >= 0; count--)
            {
                if(!inn.Equals(paymentTable.Rows[count][PAYMENT_RECIPIENT_INN]))
                {
                    paymentTable.Rows.Remove(paymentTable.Rows[count]);
                }
            }
            
        }
        
        private bool TakeStringAttr(DataRow row, string[] attr)
        {
            for(int count = 0; count < PAYMENT_ATTR_STRING.Length; count++)
            {
                if(attr[0] == PAYMENT_ATTR_STRING[count])
                {
                    row[PAYMENT_ATTR_STRING[count]] = attr[1];
                    return true;
                }
            }
            return false;
        }
    }
}
