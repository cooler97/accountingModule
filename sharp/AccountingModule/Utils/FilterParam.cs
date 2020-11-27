using System;

namespace AccountingModule
{
    public class FilterParam
    {
        public string customerName {get; set;}
        public string customerCode {get; set;}
        
        DateTime _dateFrom;
        
        public DateTime dateFrom {
            get {
                return _dateFrom;
            }
            
            set { _dateFrom = value; }
        }
        
        DateTime _dateTo;
        
        public DateTime dateTo {
            get {
                return _dateTo;
            }
            
            set { _dateTo = value; }
        }
        
        public string docType {get; set;}
        
        public FilterParam()
        {
        }
        
        public bool HaveParam()
        {
            if(!string.IsNullOrEmpty(customerName))
                return true;
            
            if(!string.IsNullOrEmpty(customerCode))
                return true;
            
            if(!string.IsNullOrEmpty(docType))
                return true;
            
            if(dateFrom != null)
                return true;
            
            if(dateTo != null)
                return true;
            
            return false;
        }

    }
}
