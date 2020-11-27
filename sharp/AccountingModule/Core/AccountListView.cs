using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Atechnology.Components.AtLogWatcher;
using BrightIdeasSoftware;

namespace AccountingModule
{
    public class AccountListView : FastDataListView
    {
        public static readonly string COLUMN_NAME_DATE = "Date";
        public static readonly string COLUMN_NAME_CUSTOMER_CODE = "CustomerCode";
        public static readonly string COLUMN_NAME_CUSTOMER_NAME = "CustomerName";
        public static readonly string COLUMN_NAME_MANAGER_NAME = "ManagerName";
        public static readonly string COLUMN_NAME_ACCOUNTING_SIGN_NAME = "AccountingSignName";
        public static readonly string COLUMN_NAME_TYPE_DOC_NAME = "TypeDocName";
        public static readonly string COLUMN_NAME_DOC_NAME = "DocName";
        public static readonly string COLUMN_NAME_QU_CONSTR = "QuConstrName";
        public static readonly string COLUMN_NAME_SM_ORDER = "SmOrderName";
        public static readonly string COLUMN_NAME_SM_DOC = "SmDocName";
        public static readonly string COLUMN_NAME_IS_SALE = "IsSaleName";
        public static readonly string COLUMN_NAME_COMMENT = "CommentName";
        
        ColorHightLightRenderer renderer = new ColorHightLightRenderer();
        
        public ColorHightLightRenderer Renderer {
            
            get {
                return renderer;
            }
            
        }
        
        Dictionary<string, double> totalDic = new Dictionary<string, double>();
        
        Dictionary<string, double> selectedDic = new Dictionary<string, double>();
        
        ALVColumn _balanceColumn;
        
        Panel _totalPanel;

        ComboBox _dateFilterBox;
        TextBox _customerCodeFilterBox ;
        ComboBox _ManagerFilterBox;
        TextBox _customerNameFilterBox;
        ComboBox _accountingSignFilterBox;
        ComboBox _saleFilterBox;
        ComboBox _docTypeFilter;
        TextBox _nameDocFilterBox;
        
        public ALVColumn _dateColumn;
        
        public ALVColumn DateColumn
        {
            get { return _dateColumn; }
        }
        
        ALVColumn _customerCodeColumn;
        
        public ALVColumn CustomerCodeColumn
        {
            
            get { return _customerCodeColumn; }
            
        }
        
        ALVColumn _customerNameColumn;
        
        public ALVColumn CustomerNameColumn
        {
            
            get { return _customerNameColumn; }
            
        }
        
        ALVColumn _managerNameColumn;
        
        public ALVColumn ManagerNameColumn
        {
            
            get { return _managerNameColumn; }
            
        }
        
        ALVColumn _accountingSignColumn;
        
        public ALVColumn AccountingSignColumn
        {
            
            get { return _accountingSignColumn; }
            
        }
        
        
        ALVColumn _typeDocNameColumn;
        
        public ALVColumn TypeDocNameColumn
        {
            
            get { return _typeDocNameColumn; }
            
        }
        
        ALVColumn _nameDocColumn;
        
        public ALVColumn NameDocColumn
        {
            
            get { return _nameDocColumn; }
            
        }
        
        ALVColumn _quConstrColumn;
        ALVColumn _smOrderColumn;
        ALVColumn _smDocColumn;
        ALVColumn _commentColumn;
        ALVColumn _saleColumn;
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public ComboBox DateFilter
        {
            get
            {
                return _dateFilterBox;
            }
            
            set
            {
                _dateFilterBox = value;
                _dateColumn.FilterControl = _dateFilterBox;
            }
        }
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public ComboBox DocTypeFilter
        {
            get
            {
                return _docTypeFilter;
            }
            
            set
            {
                _docTypeFilter = value;
                _typeDocNameColumn.FilterControl = _docTypeFilter;
            }
        }
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public TextBox NameDocFilterBox
        {
            get
            {
                return _nameDocFilterBox;
            }
            
            set
            {
                _nameDocFilterBox = value;
                _nameDocColumn.FilterControl = _nameDocFilterBox;
            }
        }
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public TextBox CustomerCodeFilterBox
        {
            get
            {
                return _customerCodeFilterBox;
            }
            
            set
            {
                _customerCodeFilterBox = value;
                _customerCodeColumn.FilterControl = _customerCodeFilterBox;
            }
        }
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public ComboBox ManagerFilterBox
        {
            get
            {
                return _ManagerFilterBox;
            }
            
            set
            {
                _ManagerFilterBox = value;
                _managerNameColumn.FilterControl = _ManagerFilterBox;
            }
        }
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public TextBox CustomerNameFilterBox
        {
            get
            {
                return _customerNameFilterBox;
            }
            
            set
            {
                _customerNameFilterBox = value;
                _customerNameColumn.FilterControl = _customerNameFilterBox;
            }
        }
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public ComboBox AccountingSignFilterBox
        {
            get
            {
                return _accountingSignFilterBox;
            }
            
            set
            {
                _accountingSignFilterBox = value;
                _accountingSignColumn.FilterControl = _accountingSignFilterBox;
            }
        }
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public ComboBox SaleFilterBox
        {
            get
            {
                return _saleFilterBox;
            }
            
            set
            {
                _saleFilterBox = value;
                _saleColumn.FilterControl = value;
            }
        }
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public Panel TotalPanel
        {
            
            get
            {
                return _totalPanel;
            }
            
            set
            {
                _totalPanel = value;
            }
            
        }
        
        Panel _filterPanel = null;
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public Panel FilterPanel
        {
            
            get
            {
                return _filterPanel;
            }
            
            set
            {
                _filterPanel = value;
            }
            
        }
        
        Panel _selectPanel = null;
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public Panel SelectPanel
        {
            
            get
            {
                return _selectPanel;
            }
            
            set
            {
                _selectPanel = value;
            }
            
        }
        
        Label totalSelectLabel = null;
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public Label TotalSelectLabel
        {
            
            get
            {
                return totalSelectLabel;
            }
            
            set
            {
                totalSelectLabel = value;
            }
            
        }
        
        public AccountListView()
        {
            this.ItemsChanged += OnItemsChanged;

            this.DefaultRenderer = renderer;
            
            _dateColumn = new ALVColumn();
            _dateColumn.Name = COLUMN_NAME_DATE;
            _dateColumn.Text = "Дата";
            _dateColumn.AspectName = "dtdoc";
            _dateColumn.IsEditable = false;
            _dateColumn.Width = 140;
            _dateColumn.UseFiltering = false;
            _dateColumn.AspectToStringFormat = "{0:d}";
            _dateColumn.Tag = 1;
            this.Columns.Add(_dateColumn);
            this.PrimarySortColumn = _dateColumn;
            
            _customerCodeColumn = new ALVColumn();
            _customerCodeColumn.Name = COLUMN_NAME_CUSTOMER_CODE;
            _customerCodeColumn.Text = "№";
            _customerCodeColumn.AspectName = "customercode";
            _customerCodeColumn.IsEditable = false;
            _customerCodeColumn.Width = 100;
            _customerCodeColumn.Tag = 1;
            _customerCodeColumn.FilteringStrategy = new TextColumnFilterStrategy(_customerCodeColumn, false);
            this.Columns.Add(_customerCodeColumn);
            
            _customerNameColumn = new ALVColumn();
            _customerNameColumn.Name = COLUMN_NAME_CUSTOMER_NAME;
            _customerNameColumn.Text = "Плательщик";
            _customerNameColumn.AspectName = "customername";
            _customerNameColumn.IsEditable = false;
            _customerNameColumn.Width = 120;
            _customerNameColumn.Tag = 2;
            _customerNameColumn.FilteringStrategy = new TextColumnFilterStrategy(_customerNameColumn, false);
            this.Columns.Add(_customerNameColumn);
            
            _managerNameColumn = new ALVColumn();
            _managerNameColumn.Name = COLUMN_NAME_MANAGER_NAME;
            _managerNameColumn.Text = "Менеджер";
            _managerNameColumn.AspectName = "managername";
            _managerNameColumn.IsEditable = false;
            _managerNameColumn.Width = 120;
            _managerNameColumn.Tag = 2;
            _managerNameColumn.FilteringStrategy = new TextColumnFilterStrategy(_managerNameColumn, false);
            this.Columns.Add(_managerNameColumn);
            
            _accountingSignColumn = new ALVColumn();
            _accountingSignColumn.Name = COLUMN_NAME_ACCOUNTING_SIGN_NAME;
            _accountingSignColumn.Text = "Признак";
            _accountingSignColumn.AspectName = "accountingsign";
            _accountingSignColumn.IsEditable = false;
            _accountingSignColumn.TextAlign = HorizontalAlignment.Center;
            _accountingSignColumn.Width = 100;
            _accountingSignColumn.IsHeaderVertical = true;
            _accountingSignColumn.Tag = 1;
            _accountingSignColumn.FilteringStrategy = new TextColumnFilterStrategy(_accountingSignColumn, true);
            this.Columns.Add(_accountingSignColumn);
            
            _saleColumn = new ALVColumn();
            _saleColumn.Name = COLUMN_NAME_IS_SALE;
            _saleColumn.Text = "Продан";
            _saleColumn.AspectName = "sale";
            _saleColumn.IsEditable = false;
            _saleColumn.CheckBoxes = true;
            _saleColumn.TriStateCheckBoxes = false;
            _saleColumn.TextAlign = HorizontalAlignment.Center;
            _saleColumn.Width = 80;
            _saleColumn.UseFiltering = false;
            _saleColumn.Tag = 1;
            _saleColumn.FilteringStrategy = new CheckColumnFilterStrategy(_saleColumn);
            this.Columns.Add(_saleColumn);
            
            _typeDocNameColumn = new ALVColumn();
            _typeDocNameColumn.Name = COLUMN_NAME_TYPE_DOC_NAME;
            _typeDocNameColumn.Text = "Документ";
            _typeDocNameColumn.AspectName = "typedocname";
            _typeDocNameColumn.IsEditable = false;
            _typeDocNameColumn.TextAlign = HorizontalAlignment.Center;
            _typeDocNameColumn.Width = 120;
            _typeDocNameColumn.Tag = 1;
            _typeDocNameColumn.FilteringStrategy = new TextColumnFilterStrategy(_typeDocNameColumn, false);
            this.Columns.Add(_typeDocNameColumn);
            this.SecondarySortColumn = _typeDocNameColumn;
            this.SecondarySortOrder = SortOrder.Ascending;
            
            _nameDocColumn = new ALVColumn();
            _nameDocColumn.Text = "№ Документ";
            _nameDocColumn.AspectName = "namedoc";
            _nameDocColumn.IsEditable = false;
            _nameDocColumn.TextAlign = HorizontalAlignment.Center;
            _nameDocColumn.Width = 120;
            _nameDocColumn.Tag = 1;
            _nameDocColumn.FilteringStrategy = new TextColumnFilterStrategy(_nameDocColumn, false);
            this.Columns.Add(_nameDocColumn);
            
            _quConstrColumn = new ALVColumn();
            _quConstrColumn.Name = COLUMN_NAME_QU_CONSTR;
            _quConstrColumn.Text = "Кол-во окон";
            _quConstrColumn.AspectName = "quconstr";
            _quConstrColumn.IsEditable = false;
            _quConstrColumn.TextAlign = HorizontalAlignment.Right;
            _quConstrColumn.Width = 60;
            _quConstrColumn.ShowSelected = true;
            _quConstrColumn.ShowTotal = true;
            _quConstrColumn.UseFiltering = false;
            _quConstrColumn.Tag = 1;
            this.Columns.Add(_quConstrColumn);
            
            _smOrderColumn = new ALVColumn();
            _smOrderColumn.Name = COLUMN_NAME_SM_ORDER;
            _smOrderColumn.Text = "Сумма заказа";
            _smOrderColumn.AspectName = "smorder";
            _smOrderColumn.AspectToStringFormat = "{0:#,##0.00}";
            _smOrderColumn.IsEditable = false;
            _smOrderColumn.TextAlign = HorizontalAlignment.Right;
            _smOrderColumn.Width = 120;
            _smOrderColumn.ShowSelected = true;
            _smOrderColumn.ShowTotal = true;
            _smOrderColumn.UseFiltering = false;
            _smOrderColumn.Tag = 1;
            this.Columns.Add(_smOrderColumn);
            
            _smDocColumn = new ALVColumn();
            _smDocColumn.Name = COLUMN_NAME_SM_DOC;
            _smDocColumn.Text = "Сумма оплаты";
            _smDocColumn.AspectName = "smdoc";
            _smDocColumn.AspectToStringFormat = "{0:#,##0.00}";
            _smDocColumn.IsEditable = false;
            _smDocColumn.TextAlign = HorizontalAlignment.Right;
            _smDocColumn.Width = 120;
            _smDocColumn.ShowSelected = true;
            _smDocColumn.ShowTotal = true;
            _smDocColumn.UseFiltering = false;
            _smDocColumn.Tag = 1;
            this.Columns.Add(_smDocColumn);
            
            _commentColumn = new ALVColumn();
            _commentColumn.Name = COLUMN_NAME_COMMENT;
            _commentColumn.Text = "Примечание";
            _commentColumn.AspectName = "comment";
            _commentColumn.IsEditable = true;
            _commentColumn.Width = 250;
            _commentColumn.UseFiltering = false;
            _commentColumn.CalcBalance = true;
            _commentColumn.Tag = 3;
            _balanceColumn = _commentColumn;
            this.Columns.Add(_commentColumn);

        }

        bool MatchValue(object row)
        {
            foreach (ALVColumn c in Columns)
            {
                if (c == _dateColumn || c.FilterControl == null)
                    continue;
                
                if(c.FilteringStrategy == null)
                    continue;
                
                bool result = c.FilteringStrategy.DoFilter(row);
                
                if (!result)
                    return result;
            }
            
            return true;
        }

        TextBox SummaryBox(TotalBoxFormatter textFormatter)
        {
            TextBox textBox = new TextBox();
            
            textBox.ReadOnly = true;
            
            textBox.TextAlign = HorizontalAlignment.Right;
            
            textBox.BorderStyle = BorderStyle.FixedSingle;
            
            textBox.TextChanged += textFormatter.FormatEvent;
            
            textBox.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            
            return textBox;
        }
        
        void GetTotalValues(Dictionary<string, double> dictionary, IEnumerable collection)
        {
            dictionary.Clear();
            
            if (collection == null)
                return;
            
            foreach (ALVColumn c in Columns)
            {
                if (!c.ShowTotal && !c.ShowSelected)
                    continue;
                
                dictionary.Add(c.AspectName, 0d);
            }
            
            List<string> keys = new List<string>(dictionary.Keys);
            
            foreach(DataRowView item in collection)
            {
                foreach(string key in keys)
                {
                    if(item.Row[key] != DBNull.Value)
                    {
                        dictionary[key] += Convert.ToDouble(item.Row[key]);
                    }
                }
            }
        }
        
        double CalcBalance(string orderAspectName, string paymentAspectName)
        {
            double orderSm = (totalDic.ContainsKey(orderAspectName)) ? totalDic[orderAspectName] : 0d;
            
            double paymentSm = (totalDic.ContainsKey(paymentAspectName)) ? totalDic[paymentAspectName] : 0d;
            
            return orderSm - paymentSm;
        }
        
        string GetSummaryValue(Dictionary<string, double> dictionary, string name)
        {
            if(dictionary.ContainsKey(name))
            {
                return dictionary[name].ToString();
            }
            
            return String.Empty;
        }
        
        void MoveControlPosition(Control control, Rectangle bounds)
        {
            control.Location = new Point(bounds.Left + 3, 4);
            control.Size = new Size(bounds.Width - 1, 32);
        }
        
        void OnItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            UpdateTotalSummary();
        }
        
        void RefreshBoxValue()
        {
            foreach(ALVColumn c in Columns)
            {
                if (c.ShowTotal || c.CalcBalance)
                {
                    c.TotalBox.Text = GetSummaryValue(totalDic, c.AspectName);
                }
                
                if(c.ShowSelected)
                {
                    c.SelectedBox.Text = GetSummaryValue(selectedDic, c.AspectName);
                }
            }
        }
        
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            ALVColumn column = e.Header as ALVColumn;
            
            if (PrimarySortColumn == column)
            {
                column.HeaderImageKey = (PrimarySortOrder == SortOrder.Ascending) ? "asc" : "desc";
            }
            
            if (SecondarySortColumn == column)
            {
                column.HeaderImageKey = (SecondarySortOrder == SortOrder.Ascending) ? "asc" : "desc";
            }

            if (column.isPositionChanged && column.FilterControl != null )
            {
                MoveControlPosition(column.FilterControl, e.Bounds);
            }
            
            if (column.isPositionChanged && (column.ShowTotal || column.CalcBalance))
            {
                MoveControlPosition(column.TotalBox, e.Bounds);
            }
            
            if(column.isPositionChanged && column.ShowSelected)
            {
                MoveControlPosition(column.SelectedBox, e.Bounds);
            }

            column.isPositionChanged = false;
            
            base.OnDrawColumnHeader(e);
        }
        
        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            (Columns[e.ColumnIndex] as ALVColumn).isPositionChanged = true;
            
            if(e.ColumnIndex < Columns.Count)
            {
                for(int index = e.ColumnIndex; index < Columns.Count; index++)
                {
                    (Columns[index] as ALVColumn).isPositionChanged = true;
                }
            }
            
            base.OnColumnWidthChanged(e);
        }
        
        void UpdateTotalSummary()
        {
            GetTotalValues(totalDic, FilteredObjects);
            
            if (_balanceColumn != null)
            {
                string balanceName = _balanceColumn.AspectName;

                totalDic.Add(balanceName, CalcBalance("smorder", "smdoc"));
            }
            
            RefreshBoxValue();
        }
        
        public void UpdateSelectedSummary()
        {
            GetTotalValues(selectedDic, SelectedObjects);
            
            RefreshBoxValue();
        }
        
        public void CreateSummaryTextBox()
        {
            TextBox box = null;
            
            foreach(ALVColumn c in Columns)
            {
                TotalBoxFormatter formatter;
                
                if(c.Name == COLUMN_NAME_QU_CONSTR)
                {
                    formatter = new IntFormatter();
                }
                else
                {
                    formatter = new DoubleFormatter();
                }
                
                if(TotalPanel != null)
                {
                    if(c.CalcBalance || c.ShowTotal)
                    {
                        box = SummaryBox(formatter);
                        c.TotalBox = box;
                        TotalPanel.Controls.Add(box);
                    }
                }
                
                if(SelectPanel != null)
                {
                    if(c.ShowSelected)
                    {
                        box = SummaryBox(formatter);
                        c.SelectedBox = box;
                        SelectPanel.Controls.Add(box);
                    }
                }
            }
        }
        
        public void AutoSizeColumn()
        {
            float totalColumnWidth = 0;
            
            for (int i = 0; i < this.Columns.Count; i++)
                totalColumnWidth += Convert.ToInt32(this.Columns[i].Tag);
            
            for (int i = 0; i < this.Columns.Count; i++)
            {
                float colPercentage = (Convert.ToInt32(this.Columns[i].Tag) / totalColumnWidth);
                this.Columns[i].Width = (int)(colPercentage * this.ClientRectangle.Width);
            }
        }
        
        public void UpdateFilteringView()
        {
            Predicate<object> filterPredicate = MatchValue;
            
            ModelFilter = new ModelFilter(filterPredicate);
            
            UpdateTotalSummary();
        }
        
        abstract class TotalBoxFormatter
        {
            public abstract void FormatEvent(object sender, EventArgs e);
        }
        
        class DoubleFormatter : TotalBoxFormatter
        {
            public override void FormatEvent(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                textBox.Text = string.Format("{0:#,##0.00}", double.Parse(textBox.Text));
            }
        }
        
        class IntFormatter : TotalBoxFormatter
        {
            public override void FormatEvent(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                textBox.Text = string.Format("{0:d}", int.Parse(textBox.Text));
            }
        }
    }
}
