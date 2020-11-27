using System;
using System.Data;

namespace AccountingModule
{
    public class TextColumnFilterStrategy : BaseColumnFilterStrategy
    {
        readonly ALVColumn owner = null;
        
        bool fullCompare = false;
        
        public TextColumnFilterStrategy(ALVColumn column, bool fullCompare)
        {
            this.owner = column;
            this.fullCompare = fullCompare;
        }
        
        public override bool DoFilter(object rawValue)
        {
            if(rawValue == null)
                return true;
            
            DataRow row = (rawValue as DataRowView).Row;
            
            string value = Convert.ToString(row[owner.AspectName]);
            
            string filterValue = owner.FilterControl.Text;
            
            if(filterValue.Equals(MainForm.COMBOBOX_ITEM_ALL))
            {
                return true;
            }
            
            if(fullCompare)
            {                
                if(filterValue.Equals(DocSign.NO_GRID))
                {
                    return !IsValueEqual(value, DocSign.GRID);
                }
                
                return IsValueEqual(value, filterValue);
            }

            return IsValueStartsWith(value, filterValue);
        }
    }
}
