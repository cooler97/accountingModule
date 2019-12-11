/*
 * Created by SharpDevelop.
 * User: At
 * Date: 18.09.2019
 * Time: 12:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.DBConnections2;
using Atechnology.Components.AtLogWatcher;
using BrightIdeasSoftware;

namespace AccountingModule
{

    public partial class MainForm : AtUserControl //Form
    {
        
        private Period period;
        
        private AccountingDoc accountingDoc;
        
        private Dictionary<TextBox, ALVColumn> filterLink = new Dictionary<TextBox, ALVColumn>();
        
        public MainForm() {
            InitializeComponent();
            accountingDoc = new AccountingDoc(this.db, accountingListView);
            period = new Period();
            
            toolStriPeriodSelect.Text = period.StringInterval;

            filterLink.Add(dateFilterBox, accountingListView.DateColumn);
            filterLink.Add(customerCodeFilterBox, accountingListView.CustomerCodeColumn);
            filterLink.Add(customerNameFilterBox, accountingListView.CustomerNameColumn);
            filterLink.Add(accountingSignFilterBox, accountingListView.AccountingSignColumn);
            filterLink.Add(docTypeFilter, accountingListView.TypeDocNameColumn);
            filterLink.Add(docNameFilter, accountingListView.NameDocColumn);
        }
        
        void RefreshBtnClick(object sender, EventArgs e)
        {
            ShowSaveDialogBox();
            accountingDoc.FillAccountingTable(null);
        }
        
        void SaveBtnClick(object sender, EventArgs e)
        {
            accountingDoc.SaveAccountingTable();
        }
        
        void ClsBtnClick(object sender, EventArgs e)
        {

        }
        
        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            ShowSaveDialogBox();
        }
        
        private void ShowSaveDialogBox() {
            if(accountingDoc.HaveChanges() &&
               MessageBox.Show("Сохранить изменения?", "Фин. учет", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK){
                accountingDoc.SaveAccountingTable();
            }
        }
        
        void DocNameFilterTextChanged(object sender, EventArgs e)
        {
            SetTextMatchFilter();
        }
        
        private void SetTextMatchFilter() {
            accountingListView.ModelFilter = GetModelFilter();
            accountingListView.DefaultRenderer = new BaseRenderer();
        }
        
        private TextMatchFilter GetModelFilter()
        {
            TextMatchFilter modelFilter = new TextMatchFilter(accountingListView);
            
            List<OLVColumn> columns = new List<OLVColumn>();
            List<string> fString = new List<string>();
            
            foreach(KeyValuePair<TextBox, ALVColumn> entry in filterLink) {
                if(!String.IsNullOrEmpty(entry.Key.Text)){
                    columns.Add(entry.Value);
                    fString.Add(entry.Key.Text);
                }
            }
            
            modelFilter.Columns = columns.ToArray();
            modelFilter.PrefixStrings = fString;
            
            return modelFilter;
        }
        
        void DocTypeFilterTextChanged(object sender, EventArgs e)
        {
            SetTextMatchFilter();
        }
        
        void AccountingSignFilterBoxTextChanged(object sender, EventArgs e)
        {
            SetTextMatchFilter();
        }
        
        void CustomerNameFilterBoxTextChanged(object sender, EventArgs e)
        {
            SetTextMatchFilter();
        }
        
        void CustomerCodeFilterBoxTextChanged(object sender, EventArgs e)
        {
            SetTextMatchFilter();
        }
        
        void DateFilterBoxTextChanged(object sender, EventArgs e)
        {
            SetTextMatchFilter();
        }
        void AccountingListViewItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            
        }
        
        void ToolStriPeriodSelectDropDown(object sender, EventArgs e)
        {
            ToolStripComboBox comboBox = (ToolStripComboBox) sender;
            comboBox.DroppedDown = false;
            period.ShowPeriodForm();
            comboBox.Text = period.StringInterval;            
        }
        
    }
}
