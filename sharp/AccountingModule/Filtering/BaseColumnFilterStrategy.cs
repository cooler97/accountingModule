using System;

namespace AccountingModule
{
    public abstract class BaseColumnFilterStrategy
    {
        public abstract bool DoFilter(object rawValue);
        
        protected bool IsValueEqual(string value, string filterValue)
        {
            if(String.IsNullOrEmpty(filterValue))
                return true;
            
            return value.Equals(filterValue, StringComparison.InvariantCultureIgnoreCase);
        }
        
        protected bool IsValueStartsWith(string value, string filterValue)
        {
            if(String.IsNullOrEmpty(filterValue))
                return true;
            
            return value.StartsWith(filterValue, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
