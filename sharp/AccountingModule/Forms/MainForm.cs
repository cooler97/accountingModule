using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Atechnology.Components;
using Atechnology.Components.AtLogWatcher;
using Atechnology.ecad;
using Atechnology.ecad.Document;
using Logistic.ProductionSchedule.Scheduler;

namespace AccountingModule
{
    public partial class MainForm : AtUserControl
    {
        public static readonly string COMBOBOX_ITEM_ALL = "Все";
        
        public static readonly string COMBOBOX_ITEM_SALE_CKECK = "Продан";
        public static readonly string COMBOBOX_ITEM_SALE_UNCKECK = "Не продан";
        
        static readonly string[] DocTypeNames = { COMBOBOX_ITEM_ALL,
            "Заказ",
            "Бонус",
            "Сальдо",
            "Платеж" };
        
        static readonly string[] DocSignNames = { COMBOBOX_ITEM_ALL,
            DocSign.GRID,
            DocSign.NO_GRID };
        
        static readonly string[] SaleNames = { COMBOBOX_ITEM_ALL,
            COMBOBOX_ITEM_SALE_CKECK,
            COMBOBOX_ITEM_SALE_UNCKECK };
        
        Period periodForm = new Period();
        
        AccountingDoc accountingDoc;
        
        public MainForm() {
            
            InitializeComponent();
            
            dateComboBox.Items.Add(periodForm.StringInterval);
            
            dateComboBox.SelectedIndex = 0;
            
            paymentsLoadBtn.Enabled = Grant.Docs.Payment;
            closeFinPeriodBtn.Enabled = Grant.Docs.Payment;
            exportRealizationBtn.Enabled = Grant.Docs.Payment;

            docTypeComboBox.DataSource = DocTypeNames;
            
            accountingSignFilterBox.DataSource = DocSignNames;
            
            saleFilter.DataSource = SaleNames;
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
            foreach(DataRowView drv in mainListView.SelectedObjects)
            {
                accountingDoc.UpdatePeople((DataRow) drv.Row, idpeople);
            }
        }
        
        void UpdateChangeManagerMenu()
        {
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
            
            managerComboBox.SelectedIndex = 0;
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
        
        void LoadSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(AccountSettings));
            
            string path = Settings.Base.LayoutAndSettingsPath + "\\accountSettings.xml";
            
            if(!File.Exists(path))
                return;
            
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                AccountSettings settings = (AccountSettings)formatter.Deserialize(fs);
                
                for(int index = 0; index <= mainListView.Columns.Count - 1; index++)
                {
                    mainListView.Columns[index].Width = settings.columnList[index].width;
                }
            }
            
        }
        
        void SaveSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(AccountSettings));
            
            string path = Settings.Base.LayoutAndSettingsPath + "\\accountSettings.xml";
            
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                AccountSettings settings = new AccountSettings();
                
                foreach(ALVColumn c in mainListView.Columns)
                {
                    settings.columnList.Add(c.Name, c.Width);
                }
                
                try
                {
                    formatter.Serialize(fs, settings);
                }
                catch (Exception e)
                {
                    AtLog.AddMessage(e.Message);
                }
            }
        }
        
        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            ShowSaveDialogBox();
            SaveSettings();
        }
        
        void ShowSaveDialogBox() {
            if(accountingDoc.HaveChanges() &&
               MessageBox.Show("Сохранить изменения?", "Фин. учет", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK){
                accountingDoc.SaveAccountingTable();
            }
        }
        
        void DocNameFilterTextChanged(object sender, EventArgs e)
        {
            mainListView.UpdateFilteringView();
        }
        
        void DocTypeFilterTextChanged(object sender, EventArgs e)
        {
            mainListView.UpdateFilteringView();
        }
        
        void AccountingSignFilterBoxTextChanged(object sender, EventArgs e)
        {
            mainListView.UpdateFilteringView();
        }
        
        void CustomerNameFilterBoxTextChanged(object sender, EventArgs e)
        {
            mainListView.UpdateFilteringView();
        }
        
        void CustomerCodeFilterBoxTextChanged(object sender, EventArgs e)
        {
            mainListView.UpdateFilteringView();
        }
        
        void DateFilterBoxTextChanged(object sender, EventArgs e)
        {
            mainListView.UpdateFilteringView();
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
            if(mainListView.Items.Count < 1)
                return;
            
            using (AtUserControl.WithUIBlock)
            {          
                ReportUtil.exportFin(mainListView.FilteredObjects, periodForm.StringInterval);
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
            mainListView.AutoSizeColumn();
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
                mainListView.UpdateFilteringView();
            }
        }
        
        void ManagerComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            using (AtUserControl.WithUIBlock)
            {
                mainListView.UpdateFilteringView();
            }
        }
        
        void AccountingSignFilterBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            using (AtUserControl.WithUIBlock)
            {
                mainListView.UpdateFilteringView();
            }
        }
        
        void AccountingListViewDoubleClick(object sender, EventArgs e)
        {
            OpenDoc();
        }
        
        void OpenDoc()
        {
            if(mainListView.SelectedObject == null)
                return;
            
            DataRowView view = mainListView.SelectedObject as DataRowView;
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
        
        void HighlighetBtnClick(object sender, EventArgs e)
        {
            SetColorToRows();
        }
        
        void SetColorToRows()
        {
            ColorDialog colorDialog = new ColorDialog();
            
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                foreach(int index in mainListView.SelectedIndices)
                {
                    mainListView.Renderer.AddBackgroundColorToRow(index, colorDialog.Color);
                }
            }
        }
        
        void MainFormLoad(object sender, EventArgs e)
        {
            LoadSettings();
            
            mainListView.CreateSummaryTextBox();
            
            using (AtUserControl.WithUIBlock)
            {
                accountingDoc = new AccountingDoc(this.db, mainListView, GetFilter());
            }
            
            UpdateChangeManagerMenu();
        }
        
        void ОткрытьToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenDoc();
        }
        
        void ЗаливкаToolStripMenuItemClick(object sender, EventArgs e)
        {
            SetColorToRows();
        }
        
        void БезЗаливкиToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach(int index in mainListView.SelectedIndices)
            {
                mainListView.Renderer.RemoveRowBackgroundColor(index);
            }
        }
        
        void AccountingListViewSelectionChanged(object sender, EventArgs e)
        {
            mainListView.UpdateSelectedSummary();
        }
        
        void SaleFilterSelectedIndexChanged(object sender, EventArgs e)
        {
            using (AtUserControl.WithUIBlock)
            {
                mainListView.UpdateFilteringView();
            }
        }
        
        void ManagerComboBoxTextUpdate(object sender, EventArgs e)
        {
            using (AtUserControl.WithUIBlock)
            {
                mainListView.UpdateFilteringView();
            }
        }
        
        void ExportRealizationBtnClick(object sender, EventArgs e)
        {
            if(mainListView.SelectedObjects == null || mainListView.SelectedObjects.Count < 1)
                return;
            
            SaveFileDialog dialog = new SaveFileDialog();
            
            dialog.AddExtension = true;
            
            dialog.DefaultExt = ".xml";
            
            if(dialog.ShowDialog() != DialogResult.OK)
                return;
            
            
        }
    }
}
