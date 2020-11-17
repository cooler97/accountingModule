using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.Components.AtLogWatcher;
using BrightIdeasSoftware;

namespace AccountingModule
{
    public class AccountListView : FastDataListView
    {
        Dictionary<string, double> totalDic;
        
        ALVColumn _balanceColumn = null;
        
        Panel _totalPanel = null;
        
        bool isGeneratedTotalBox = false;
        
        ComboBox _dateFilterBox = null;
        TextBoxWithBtn _customerCodeFilterBox = null;
        ComboBox _ManagerFilterBox = null;
        TextBoxWithBtn _customerNameFilterBox = null;
        ComboBox _accountingSignFilterBox = null;
        ComboBox _docTypeFilter = null;
        TextBox _nameDocFilterBox = null;
        
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
        public TextBoxWithBtn CustomerCodeFilterBox
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
        public TextBoxWithBtn CustomerNameFilterBox
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
        
        public AccountListView()
        {
            this.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.OnItemsChanged);
            
            _dateColumn = new ALVColumn();
            _dateColumn.Text = "Дата";
            _dateColumn.AspectName = "dtdoc";
            _dateColumn.IsEditable = false;
            //            _dateColumn.ClusteringStrategy =
            //                new DateTimeClusteringStrategy(DateTimePortion.Year | DateTimePortion.Month, "MMMM yyyy");
            _dateColumn.Width = 140;
            _dateColumn.UseFiltering = false;
            _dateColumn.AspectToStringFormat = "{0:g}";
            _dateColumn.Tag = 1;
            this.Columns.Add(_dateColumn);
            this.PrimarySortColumn = _dateColumn;
            
            _customerCodeColumn = new ALVColumn();
            _customerCodeColumn.Text = "№";
            _customerCodeColumn.AspectName = "customercode";
            _customerCodeColumn.IsEditable = false;
            _customerCodeColumn.Width = 100;
            _customerCodeColumn.Tag = 1;
            this.Columns.Add(_customerCodeColumn);
            
            _customerNameColumn = new ALVColumn();
            _customerNameColumn.Text = "Плательщик";
            _customerNameColumn.AspectName = "customername";
            _customerNameColumn.IsEditable = false;
            _customerNameColumn.Width = 120;
            _customerNameColumn.Tag = 2;
            this.Columns.Add(_customerNameColumn);
            
            _managerNameColumn = new ALVColumn();
            _managerNameColumn.Text = "Менеджер";
            _managerNameColumn.AspectName = "managername";
            _managerNameColumn.IsEditable = false;
            _managerNameColumn.Width = 120;
            _managerNameColumn.Tag = 2;
            this.Columns.Add(_managerNameColumn);
            
            _accountingSignColumn = new ALVColumn();
            _accountingSignColumn.Text = "Признак";
            _accountingSignColumn.AspectName = "accountingsign";
            _accountingSignColumn.IsEditable = false;
            _accountingSignColumn.TextAlign = HorizontalAlignment.Center;
            _accountingSignColumn.Width = 100;
            _accountingSignColumn.IsHeaderVertical = true;
            _accountingSignColumn.Tag = 1;
            this.Columns.Add(_accountingSignColumn);
            
            _typeDocNameColumn = new ALVColumn();
            _typeDocNameColumn.Text = "Документ";
            _typeDocNameColumn.AspectName = "typedocname";
            _typeDocNameColumn.IsEditable = false;
            _typeDocNameColumn.TextAlign = HorizontalAlignment.Center;
            _typeDocNameColumn.Width = 120;
            _typeDocNameColumn.Tag = 1;
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
            this.Columns.Add(_nameDocColumn);
            
            _quConstrColumn = new ALVColumn();
            _quConstrColumn.Text = "Кол-во окон";
            _quConstrColumn.AspectName = "quconstr";
            _quConstrColumn.IsEditable = false;
            _quConstrColumn.TextAlign = HorizontalAlignment.Right;
            _quConstrColumn.Width = 60;
            _quConstrColumn.ShowTotal = true;
            _quConstrColumn.UseFiltering = false;
            _quConstrColumn.Tag = 1;
            this.Columns.Add(_quConstrColumn);
            
            _smOrderColumn = new ALVColumn();
            _smOrderColumn.Text = "Сумма заказа";
            _smOrderColumn.AspectName = "smorder";
            _smOrderColumn.IsEditable = false;
            _smOrderColumn.TextAlign = HorizontalAlignment.Right;
            _smOrderColumn.Width = 120;
            _smOrderColumn.ShowTotal = true;
            _smOrderColumn.UseFiltering = false;
            _smOrderColumn.WordWrap = true;
            _smOrderColumn.AspectToStringFormat = "{0:#,##0.00}";
            _smOrderColumn.Tag = 1;
            this.Columns.Add(_smOrderColumn);
            
            _smDocColumn = new ALVColumn();
            _smDocColumn.Text = "Сумма оплаты";
            _smDocColumn.AspectName = "smdoc";
            _smDocColumn.AspectToStringFormat = "{0:#,##0.00}";
            _smDocColumn.IsEditable = false;
            _smDocColumn.TextAlign = HorizontalAlignment.Right;
            _smDocColumn.Width = 120;
            _smDocColumn.ShowTotal = true;
            _smDocColumn.UseFiltering = false;
            _smDocColumn.Tag = 1;
            this.Columns.Add(_smDocColumn);
            
            _commentColumn = new ALVColumn();
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
        
        public void UpdateFilteringView()
        {
            Predicate<object> filterPredicate = MatchText;
            this.ModelFilter = new ModelFilter(filterPredicate);
        }
        
        private bool MatchText(object o)
        {
            DataRowView rowView = (DataRowView)o;
            DataRow dataRow = rowView.Row;
            
            bool result = true;
            
            string str = string.Empty;
            string filterValue = string.Empty;
            
            foreach (ALVColumn col in Columns)
            {
                if (col == _dateColumn || col.FilterControl == null)
                    continue;
                
                str = dataRow[col.AspectName].ToString();
                
                if (col.FilterControl.GetType() == typeof(ComboBox))
                {
                    filterValue = (col.FilterControl as ComboBox).Text;
                    
                    if(filterValue.Equals(MainForm.COMBOBOX_ITEM_ALL))
                    {
                        result = true;
                    }
                    else if(filterValue.Equals(DocSign.NO_GRID))
                    {
                        result = !IsValueEqual(str, DocSign.GRID);
                    }
                    else
                    {
                        result = IsValueEqual(str, filterValue);
                    }
                }
                
                if (col.FilterControl.GetType() == typeof(TextBoxWithBtn) ||
                    col.FilterControl.GetType() == typeof(TextBox))
                {
                    filterValue = (col.FilterControl as TextBox).Text;
                    result = IsValueStartsWith(str, filterValue);
                }
                
                if (!result)
                    return result;
            }
            
            return true;
        }
        
        private bool IsValueEqual(string inputString, string filter)
        {
            return (string.IsNullOrEmpty(filter)) ? true : inputString.Equals(filter, StringComparison.InvariantCultureIgnoreCase);
        }
        
        private bool IsValueStartsWith(string inputString, string filter)
        {
            return (string.IsNullOrEmpty(filter)) ? true : inputString.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase);
        }
        
        private void GenerateTotalTextBox()
        {
            foreach (ALVColumn c in this.Columns)
            {
                if (c.ShowTotal || c.CalcBalance)
                {
                    c.TotalBox = NewTotalTextBox();
                    _totalPanel.Controls.Add(c.TotalBox);
                }
            }
        }
        
        private TextBox NewTotalTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.ReadOnly = true;
            //            textBox.BackColor = Color.White;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.ShortcutsEnabled = false;
            textBox.TextChanged += new TotalBoxDoubleFormatter().FormatEvent;
            textBox.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            return textBox;
        }
        
        private void GetTotalValues(ListViewItemCollection collection)
        {
            totalDic = new Dictionary<string, double>();
            
            if (collection == null || collection.Count < 1)
                return;
            
            foreach (ALVColumn column in this.Columns)
            {
                if (!column.ShowTotal)
                    continue;
                
                if (!totalDic.ContainsKey(column.AspectName))
                {
                    totalDic.Add(column.AspectName, 0d);
                }
            }
            
            List<string> keys = new List<string>(totalDic.Keys);
            
            DataRowView rowView = null;
            Type rowType;
            
            for (int count = 0; count < collection.Count; count++)
            {
                rowView = (DataRowView)(collection[count] as OLVListItem).RowObject;
                foreach (String key in keys)
                {
                    rowType = rowView.Row[key].GetType();
                    if (Utils.IsNumericType(rowType))
                    {
                        totalDic[key] += Convert.ToDouble(rowView.Row[key]);
                    }
                }
            }

            if (_balanceColumn != null)
            {
                if (!totalDic.ContainsKey(_balanceColumn.AspectName))
                {
                    totalDic.Add(_balanceColumn.AspectName, 0d);
                }
                totalDic[_balanceColumn.AspectName] = GetBalance("smorder", "smdoc");
            }

        }
        
        private double GetBalance(string orderAspectName, string paymentAspectName)
        {
            double orderSm = 0d;
            double paymentSm = 0d;
            
            orderSm = (totalDic.ContainsKey(orderAspectName)) ? totalDic[orderAspectName] : orderSm;
            paymentSm = (totalDic.ContainsKey(paymentAspectName)) ? totalDic[paymentAspectName] : paymentSm;
            return orderSm - paymentSm;
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
        
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            ALVColumn column = e.Header as ALVColumn;
            
            base.OnDrawColumnHeader(e);
            
            if (this.PrimarySortColumn == column)
            {
                column.HeaderImageKey = (this.PrimarySortOrder == SortOrder.Ascending) ? "asc" : "desc";
            }
            
            if (this.SecondarySortColumn == column)
            {
                column.HeaderImageKey = (this.SecondarySortOrder == SortOrder.Ascending) ? "asc" : "desc";
            }
            
            if (!isGeneratedTotalBox && _totalPanel != null)
            {
                GenerateTotalTextBox();
                isGeneratedTotalBox = true;
            }
            
            if (column.FilterControl != null)
            {
                CalcControlPosition(column.FilterControl, e.Bounds);
            }
            
            if (column.ShowTotal || column.CalcBalance)
            {
                CalcControlPosition(column.TotalBox, e.Bounds);
                column.TotalBox.Text = (totalDic.ContainsKey(column.AspectName)) ? totalDic[column.AspectName].ToString() : String.Empty;
            }
            
            column.IsColumnWidthChanged = false;
        }
        
        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            (this.Columns[e.ColumnIndex] as ALVColumn).IsColumnWidthChanged = true;
        }
        
        private void CalcControlPosition(Control control, Rectangle bounds)
        {
            control.Location = new System.Drawing.Point(bounds.Left + 3, 4);
            control.Size = new System.Drawing.Size(bounds.Width - 1, 32);
        }

        protected void OnItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            try
            {
                GetTotalValues(this.Items);
            }
            catch (Exception ex)
            {
                AtLog.AddMessage(ex.Message + "  \\n\\r " +
                                 ex.StackTrace);
            }
        }
        
        abstract class TotalBoxFormatter
        {
            
            public abstract void FormatEvent(object sender, EventArgs e);
            
        }
        
        class TotalBoxDoubleFormatter : TotalBoxFormatter
        {
            
            public override void FormatEvent(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                textBox.Text = string.Format("{0:#,##0.00}", double.Parse(textBox.Text));
            }
            
        }
        
        class TotalBoxIntFormatter : TotalBoxFormatter
        {
            
            public override void FormatEvent(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                textBox.Text = string.Format("{0:d}", int.Parse(textBox.Text));
            }
            
        }
        
    }
    

}
