using System;
using System.Data;
using Atechnology.Components.AtLogWatcher;

namespace AccountingModule
{
    public class CheckColumnFilterStrategy : BaseColumnFilterStrategy
    {
        readonly ALVColumn owner = null;
        
        public CheckColumnFilterStrategy(ALVColumn column)
        {
            this.owner = column;
        }
        
        public override bool DoFilter(object rawValue)
        {
            if(rawValue == null)
                return true;
            
            DataRow row = (rawValue as DataRowView).Row;

            bool value = (row[owner.AspectName] == DBNull.Value) ? false : Convert.ToBoolean(row[owner.AspectName]);
            
            string filterValue = owner.FilterControl.Text;
            
            if(filterValue.Equals(MainForm.COMBOBOX_ITEM_ALL))
            {
                return true;
            }
            
            if(filterValue.Equals(MainForm.COMBOBOX_ITEM_SALE_UNCKECK))
            {
                return !value;
            }
            
            return value;

        }
    }
}
