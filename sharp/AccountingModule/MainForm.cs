using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.DBConnections2;
using Atechnology.ecad;
using Atechnology.ecad.Document;
using Atechnology.ecad.Document.Classes;
using BrightIdeasSoftware;
using BrightIdeasSoftware.Design;
using Logistic.ProductionSchedule.Scheduler;

namespace AccountingModule
{
    public partial class MainForm : AtUserControl
    {
        
        public static readonly string COMBOBOX_ITEM_ALL = "Все";
        
        public static readonly string[] DocTypeNames = new[] { COMBOBOX_ITEM_ALL, "Заказ", "Бонус", "Сальдо", "Платеж" };
        
        private Period periodForm;
        
        private AccountingDoc accountingDoc;
        
        private Dictionary<Control, ALVColumn> filterLink = new Dictionary<Control, ALVColumn>();
        
        public MainForm() {
            InitializeComponent();
            
            periodForm = new Period();
            
            dateComboBox.Items.Add(periodForm.StringInterval);
            dateComboBox.SelectedIndex = 0;

            //            filterLink.Add(dateComboBox, accountingListView.DateColumn);
            /*filterLink.Add(customerCodeFilterBox, accountingListView.CustomerCodeColumn);
            filterLink.Add(customerNameFilterBox, accountingListView.CustomerNameColumn);
            filterLink.Add(managerFilterBox, accountingListView.ManagerNameColumn);
            filterLink.Add(accountingSignFilterBox, accountingListView.AccountingSignColumn);
            filterLink.Add(docTypeComboBox, accountingListView.TypeDocNameColumn);
            filterLink.Add(docNameFilter, accountingListView.NameDocColumn);*/
            
            paymentsLoadBtn.Enabled = Grant.Docs.Payment;
            closeFinPeriodBtn.Enabled = Grant.Docs.Payment;
            
            accountingDoc = new AccountingDoc(this.db, accountingListView, GetFilter());
            
            docTypeComboBox.DataSource = DocTypeNames;
            
            accountingSignFilterBox.DataSource = new[] {COMBOBOX_ITEM_ALL, DocSign.GRID, DocSign.NO_GRID};
            
            managerComboBox.Items.Add(COMBOBOX_ITEM_ALL);
            
            string peopleFio = "";
            
            foreach(DataRow peopleRow in accountingDoc.PeopleTable.Rows)
            {
                peopleFio = (string)peopleRow["lastname"] + " " + (string)peopleRow["name"];
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = peopleFio;
                item.Tag = peopleRow;
                item.Click += ChangeManagerClickHandler;
                changePeopleList.DropDownItems.Add(item);
                managerComboBox.Items.Add(peopleFio);
            }
        }
        
        void ChangeManagerClickHandler(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem) sender;
            
            if(item.Tag == null)
                return;
            
            DataRow dr = (DataRow)item.Tag;
            
            UpdateManager((int)dr["idpeople"]);
            
            RefreshAccountingDocView();
        }
        
        void UpdateManager(int idpeople)
        {
            foreach(DataRowView drv in accountingListView.SelectedObjects)
            {
                accountingDoc.UpdatePeople((DataRow) drv.Row, idpeople);
            }
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
            
            if(accountingListView.Items.Count < 1)
                return;
            
            using (AtUserControl.WithUIBlock)
            {
//                DataRowView rowView = (DataRowView)(accountingListView.Items[0] as OLVListItem).RowObject;
//                
//                DataTable sourceDt = rowView.Row.Table.Copy();
//                
//                for (int index = 0; index < accountingListView.Items.Count; index++)
//                {
//                    sourceDt.ImportRow(((DataRowView)(accountingListView.Items[index] as OLVListItem).RowObject).Row);
//                }
                
                ReportUtil.exportFin(accountingListView.FilteredObjects, periodForm.StringInterval);
            }
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
                using (AtUserControl.WithUIBlock)
                {
                    RefreshAccountingDocView();
                }
            }
            SendKeys.Send("{Enter}");
        }
        
        void ToolStripButton2Click(object sender, EventArgs e)
        {
            СlosePeriodForm frm = new СlosePeriodForm(this.db);
            frm.ShowDialog();
        }
        
        void DocTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            using (AtUserControl.WithUIBlock)
            {
                accountingListView.UpdateFilteringView();
            }
        }
        
        void ManagerComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            using (AtUserControl.WithUIBlock)
            {
                accountingListView.UpdateFilteringView();
            }
        }
        
        void AccountingSignFilterBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            using (AtUserControl.WithUIBlock)
            {
                accountingListView.UpdateFilteringView();
            }
        }
        
        void AccountingListViewDoubleClick(object sender, EventArgs e)
        {
            if(accountingListView.SelectedObject == null)
                return;
            
            DataRowView view = accountingListView.SelectedObject as DataRowView;
            DataRow dr = view.Row as DataRow;
            
            if(dr == null)
                return;
            
            int docType = (int) dr["typedoc"];
            
            if(DocType.ORDER == docType)
            {
                DataRow orderRow = accountingDoc.GetOrderDataRowById((int) dr["idorder"]);
                
                if (orderRow == null || !Grant.Docs.Order.Open)
                    return;
                
                //                LockType lockType = DocumentClass.CheckAndSetBlockAndPeople(dbconn._db, orderRow, 1);
                
                OrderItemForm orderItemForm = new OrderItemForm((int) dr["idorder"]);
                
                orderItemForm.ReadOnlyOrder = true;
                
                DocumentClass.SetTabPageName((AtUserControl) orderItemForm, orderRow, "idorder", "Заказ");
                
                MdiManager.Add((Control) orderItemForm);
                
                orderItemForm.Show();
            }
            else
            {
                if (!Atechnology.ecad.Grant.Docs.Payment)
                    return;
                
                if (new PaymentItemForm((int) dr["idpaymentdoc"]).ShowDialog(false) != DialogResult.OK)
                    return;
            }
        }
        
        
    }
}
