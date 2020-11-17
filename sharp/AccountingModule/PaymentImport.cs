using System;
using System.Data;

namespace AccountingModule
{

    public abstract class PaymentImport
    {        
        public static string IDCUSTOMER_COLUMN = "idcustomer";
        public static string CUSTOMERNAME_COLUMN = "customer_name";
        
        public abstract void  ImportPayment();
        
        public abstract DataTable PaymentTable();
        
        public abstract Payment GetPayment(int idPaymentGroup, AccountValut valut, DataRow paymentRow);
    }
}
