using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.ecad.Document;
using BrightIdeasSoftware;
using BrightIdeasSoftware.Design;
using Logistic.ProductionSchedule.Scheduler;

namespace AccountingModule
{
    public partial class MainForm : AtUserControl
    {
        private Period periodForm;
        
        private AccountingDoc accountingDoc;
        
        private Dictionary<TextBox, ALVColumn> filterLink = new Dictionary<TextBox, ALVColumn>();
        
        public MainForm() {
            InitializeComponent();
            
            periodForm = new Period();
            
            dateComboBox.Items.Add(periodForm.StringInterval);
            dateComboBox.SelectedIndex = 0;

//            filterLink.Add(dateComboBox, accountingListView.DateColumn);
            filterLink.Add(customerCodeFilterBox, accountingListView.CustomerCodeColumn);
            filterLink.Add(customerNameFilterBox, accountingListView.CustomerNameColumn);
            filterLink.Add(accountingSignFilterBox, accountingListView.AccountingSignColumn);
            filterLink.Add(docTypeFilter, accountingListView.TypeDocNameColumn);
            filterLink.Add(docNameFilter, accountingListView.NameDocColumn);
            
            accountingDoc = new AccountingDoc(this.db, accountingListView, GetFilter());
        }
        
        void RefreshAccountingDocView()
        {
            ShowSaveDialogBox();
            accountingDoc.FillAccountingTable(GetFilter());
        }
        
        void RefreshBtnClick(object sender, EventArgs e)
        {
            RefreshAccountingDocView();
        }
        
        FilterParam GetFilter()
        {
            FilterParam filterParam = new FilterParam();
            filterParam.dateFrom = periodForm.FromDate;
            filterParam.dateTo = periodForm.ToDate;
            return filterParam;
        }
        
        void SaveBtnClick(object sender, EventArgs e)
        {
            accountingDoc.SaveAccountingTable();
        }
        
        void ClsBtnClick(object sender, EventArgs e)
        {
            ShowSaveDialogBox();
            this.Close();
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
            accountingListView.UpdateFilteringView();
        }
        
        void DocTypeFilterTextChanged(object sender, EventArgs e)
        {
            accountingListView.UpdateFilteringView();
        }
        
        void AccountingSignFilterBoxTextChanged(object sender, EventArgs e)
        {
            accountingListView.UpdateFilteringView();
        }
        
        void CustomerNameFilterBoxTextChanged(object sender, EventArgs e)
        {
            accountingListView.UpdateFilteringView();
        }
        
        void CustomerCodeFilterBoxTextChanged(object sender, EventArgs e)
        {
            accountingListView.UpdateFilteringView();
        }
        
        void DateFilterBoxTextChanged(object sender, EventArgs e)
        {
            accountingListView.UpdateFilteringView();
        }
        
        void ToolStriPeriodSelectDropDown(object sender, EventArgs e)
        {
            ToolStripComboBox comboBox = (ToolStripComboBox) sender;
            comboBox.Items.Clear();
            if(periodForm.ShowPeriodForm() == DialogResult.OK)
            {
                comboBox.Items.Add(periodForm.StringInterval);
                comboBox.SelectedIndex = 0;
                comboBox.Focus();
                RefreshAccountingDocView();
            }
            SendKeys.Send("{Enter}");
        }
        void Button1Click(object sender, EventArgs e)
        {
            ReportUtil.exportFin(periodForm.FromDate, periodForm.ToDate);
        }
        void ToolStripButton1Click(object sender, EventArgs e)
        {
            AtUserControl paymentImport = new PaymentImportForm(this.accountingDoc);
            MdiManager.Add((AtUserControl)paymentImport);
            paymentImport.Show();
        }
        
        void ПодборШиринывсеКолонкиToolStripMenuItemClick(object sender, EventArgs e)
        {
            accountingListView.AutoSizeColumn();
        }
        void DateComboBoxDropDown(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            comboBox.Items.Clear();
            if(periodForm.ShowPeriodForm() == DialogResult.OK)
            {
                comboBox.Items.Add(periodForm.StringInterval);
                comboBox.SelectedIndex = 0;
                comboBox.Focus();
                RefreshAccountingDocView();
            }
            SendKeys.Send("{Enter}");
        }
        
    }
}
