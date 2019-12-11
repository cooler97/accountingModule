/*
 * Created by SharpDevelop.
 * User: At
 * Date: 18.09.2019
 * Time: 12:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Collections;
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
        Dictionary<string, double> totalDic;
        
        ALVColumn _balanceColumn = null;
        
        Panel _totalPanel = null;
        
        bool isGeneratedTotalBox = false;
        
        TextBoxWithBtn _dateFilterBox = null;
        TextBoxWithBtn _customerCodeFilterBox = null;
        TextBoxWithBtn _customerNameFilterBox = null;
        TextBoxWithBtn _accountingSignFilterBox = null;
        TextBoxWithBtn _docTypeFilter = null;
        TextBox _nameDocFilterBox = null;
        
        ALVColumn _dateColumn;
        
        public ALVColumn DateColumn {
            
            get { return _dateColumn; }
            
        }
        
        ALVColumn _customerCodeColumn;
        
        public ALVColumn CustomerCodeColumn {
            
            get { return _customerCodeColumn; }
            
        }
        
        ALVColumn _customerNameColumn;
        
        public ALVColumn CustomerNameColumn {
            
            get { return _customerNameColumn; }
            
        }
        
        ALVColumn _accountingSignColumn;
        
        public ALVColumn AccountingSignColumn {
            
            get { return _accountingSignColumn; }
            
        }
        
        
        ALVColumn _typeDocNameColumn;
        
        public ALVColumn TypeDocNameColumn {
            
            get { return _typeDocNameColumn; }
            
        }
        
        ALVColumn _nameDocColumn;
        
        public ALVColumn NameDocColumn {
            
            get { return _nameDocColumn; }
            
        }
        
        ALVColumn _quConstrColumn;
        ALVColumn _smOrderColumn;
        ALVColumn _smDocColumn;
        ALVColumn _commentColumn;
        
        [Category("AccountListView"), TypeConverter("System.Windows.Forms.Panel, System.Design")]
        public TextBoxWithBtn DateFilter
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
        public TextBoxWithBtn DocTypeFilter
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
        public TextBoxWithBtn AccountingSignFilterBox
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
            _dateColumn.ClusteringStrategy =
                new DateTimeClusteringStrategy(DateTimePortion.Year | DateTimePortion.Month, "MMMM yyyy");
            _dateColumn.Width = 90;
            this.Columns.Add(_dateColumn);
            
            _customerCodeColumn = new ALVColumn();
            _customerCodeColumn.Text = "№";
            _customerCodeColumn.AspectName = "customercode";
            _customerCodeColumn.IsEditable = false;
            _customerCodeColumn.Width = 60;
            this.Columns.Add(_customerCodeColumn);
            
            _customerNameColumn = new ALVColumn();
            _customerNameColumn.Text = "Плательщик";
            _customerNameColumn.AspectName = "customername";
            _customerNameColumn.IsEditable = false;
            _customerNameColumn.Width = 120;
            this.Columns.Add(_customerNameColumn);
            
            _accountingSignColumn = new ALVColumn();
            _accountingSignColumn.Text = "Признак";
            _accountingSignColumn.AspectName = "accountingsign";
            _accountingSignColumn.IsEditable = false;
            _accountingSignColumn.Width = 60;
            _accountingSignColumn.IsHeaderVertical = true;
            this.Columns.Add(_accountingSignColumn);
            
            _typeDocNameColumn = new ALVColumn();
            _typeDocNameColumn.Text = "Документ";
            _typeDocNameColumn.AspectName = "typedocname";
            _typeDocNameColumn.IsEditable = false;
            _typeDocNameColumn.Width = 90;
            this.Columns.Add(_typeDocNameColumn);
            
            _nameDocColumn = new ALVColumn();
            _nameDocColumn.Text = "№ Документ";
            _nameDocColumn.AspectName = "namedoc";
            _nameDocColumn.IsEditable = false;
            _nameDocColumn.Width = 60;
            this.Columns.Add(_nameDocColumn);
            
            _quConstrColumn = new ALVColumn();
            _quConstrColumn.Text = "Кол-во окон";
            _quConstrColumn.AspectName = "quconstr";
            _quConstrColumn.IsEditable = false;
            _quConstrColumn.TextAlign = HorizontalAlignment.Right;
            _quConstrColumn.Width = 60;
            _quConstrColumn.ShowTotal = true;
            _quConstrColumn.UseFiltering = false;
            this.Columns.Add(_quConstrColumn);
            
            _smOrderColumn = new ALVColumn();
            _smOrderColumn.Text = "Сумма заказа";
            _smOrderColumn.AspectName = "smorder";
            _smOrderColumn.IsEditable = false;
            _smOrderColumn.TextAlign = HorizontalAlignment.Right;
            _smOrderColumn.Width = 90;
            _smOrderColumn.ShowTotal = true;
            _smOrderColumn.UseFiltering = false;
            _smOrderColumn.WordWrap = true;
            this.Columns.Add(_smOrderColumn);
            
            _smDocColumn = new ALVColumn();
            _smDocColumn.Text = "Сумма оплаты";
            _smDocColumn.AspectName = "smdoc";
            _smDocColumn.IsEditable = false;
            _smDocColumn.TextAlign = HorizontalAlignment.Right;
            _smDocColumn.Width = 90;
            _smDocColumn.ShowTotal = true;
            _smDocColumn.UseFiltering = false;
            this.Columns.Add(_smDocColumn);
            
            _commentColumn = new ALVColumn();
            _commentColumn.Text = "Примечание";
            _commentColumn.AspectName = "comment";
            _commentColumn.IsEditable = true;
            _commentColumn.Width = 250;
            _commentColumn.UseFiltering = false;
            _commentColumn.CalcBalance = true;
            _balanceColumn = _commentColumn;
            this.Columns.Add(_commentColumn);
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
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.ShortcutsEnabled = false;
            textBox.TextChanged += new TotalBoxDoubleFormatter().FormatEvent;
            textBox.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold);
            return textBox;
        }
        
        private void GetTotalValues(ListViewItemCollection collection)
        {
            if(collection == null || collection.Count < 1)
                return;
            
            totalDic = new Dictionary<string, double>();
            
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
            
            for (int count = 0; count < collection.Count; count++)
            {
                rowView = (DataRowView)(collection[count] as OLVListItem).RowObject;
                
                foreach (String key in keys)
                {
                    if (rowView.Row[key] is double)
                    {
                        totalDic[key] += (double)rowView.Row[key];
                    }
                    else if (rowView.Row[key] is int)
                    {
                        totalDic[key] += (int)rowView.Row[key];
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
        
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            ALVColumn column = e.Header as ALVColumn;
            
            base.OnDrawColumnHeader(e);
            
            if (!isGeneratedTotalBox && _totalPanel != null)
            {
                GenerateTotalTextBox();
                isGeneratedTotalBox = true;
                AtLog.AddMessage("Call: generateTotalTextBox");
            }
            
            if(column.FilterControl != null)
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
            control.Location = new System.Drawing.Point(bounds.Left + 1, 4);
            control.Size = new System.Drawing.Size(bounds.Width - 1, 32);
        }

        protected void OnItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            GetTotalValues(this.Items);
        }
        
        abstract class TotalBoxFormatter {
            
            public abstract void FormatEvent(object sender, EventArgs e);
            
        }
        
        class TotalBoxDoubleFormatter : TotalBoxFormatter {
            
            public override void FormatEvent(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox) sender;
                textBox.Text = string.Format("{0:#,##0.00}", double.Parse(textBox.Text));
            }
            
        }
        
        class TotalBoxIntFormatter : TotalBoxFormatter {
            
            public override void FormatEvent(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox) sender;
                textBox.Text = string.Format("{0:d}", int.Parse(textBox.Text));
            }
            
        }
        
    }
    

}
