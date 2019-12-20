using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace AccountingModule
{

    public class ALVColumn : OLVColumn
    {
        
        private bool _showTotal;
        
        private bool _calcBalance;
        
        private bool _isColumnWidthChanged = false;
        
        public bool IsColumnWidthChanged
        {
            
            get
            {
                return _isColumnWidthChanged;
            }
            
            set
            {
                _isColumnWidthChanged = value;
            }
            
        }
        
        private TextBox _textBox;
        
        public bool ShowTotal
        {
            
            get
            {
                return _showTotal;
            }
            
            set
            {
                _showTotal = value;
            }
        }
        
        public bool CalcBalance
        {
            get
            {
                return  _calcBalance;
            }
            
            set
            {
                _calcBalance = value;
            }
        }
        
        public TextBox TotalBox
        {
            
            get
            {
                return _textBox;
            }
            
            set
            {
                _textBox = value;
            }
            
        }
        
        private Control _filterControl = null;
        
        public Control FilterControl
        {
            get
            {
                return _filterControl;
            }
            
            set
            {
                _filterControl = value;
            }
        }
        
        public ALVColumn()
        {

        }
        

    }


}
