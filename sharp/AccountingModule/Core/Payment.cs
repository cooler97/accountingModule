using System;

namespace AccountingModule
{
    public class Payment
    {
        public static int DOCOPER_CREDIT_ORDER = 5;
        public static int DOCOPER_INCOMING_PAYMENT_ORDER = 6;
        public static int DOCOPER_BONUS = 107;
        public static int DOCOPER_OPENING_BALANCE = 108;
        public static int DOCOPER_OPENING_BALANCE_CASH = 110;
        
        public string Name {get; set;}
        public DateTime DtDoc {get; set;}
        public DateTime DtCre {get; set;}
        public int IdCustomer {get; set;}
        public int IdPeople {get; set;}
        public int IdDocOper {get; set;}
        public string loginCre {get; set;}
        public double SmDoc {get; set;}
        public AccountValut Valut {get; set;}
        public double SmBase {get; set;}
        public int IdPaymentDocGroup {get; set;}
        public string AddStr {get; set;}
        
        public Payment()
        {
        }
    }
}
