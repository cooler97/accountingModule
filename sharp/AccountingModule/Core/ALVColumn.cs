using System;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace AccountingModule
{
    public class ALVColumn : OLVColumn
    {        
        bool _showSelected;
        
        bool _showTotal;
        
        bool _calcBalance;
        
        bool _isPositionChanged;
        
        BaseColumnFilterStrategy _filteringStrategy;
        
        public BaseColumnFilterStrategy FilteringStrategy
        {
            get
            {
                return _filteringStrategy;
            }
            
            set
            {
                _filteringStrategy = value;
            }
        }
        
        public bool isPositionChanged
        {
            get
            {
                return _isPositionChanged;
            }
            
            set
            {
                _isPositionChanged = value;
            }
        }
        
        TextBox _textBox;
        
        TextBox _selectedTextBox;
        
        public bool ShowSelected 
        {
            get {
                return _showSelected;
            }
            
            set {
                _showSelected = value;
            }
        }
        
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
        
        public TextBox SelectedBox
        {
            get {
                return _selectedTextBox;
            }
            
            set {
                _selectedTextBox = value;
            }
        }
        
        Control _filterControl;
        
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
