using System;
using System.Data;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.Components.AtLogWatcher;
using Atechnology.ecad;
using Atechnology.ecad.Document;

namespace AccountingModule
{
    public partial class PaymentImportForm : AtUserControl
    {
        FileDialog openFileDialog = new OpenFileDialog();
        
        PaymentImport importStrategies;
        
        AccountingDoc accountingDoc;
        
        public PaymentImportForm(AccountingDoc accountingDoc)
        {
            InitializeComponent();
            this.accountingDoc = accountingDoc;
            paymentGridView.CellClick += new DataGridViewCellEventHandler(paymentGridView_CellClick);
        }
        
        void LoadSharpPaymentClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Csv file format (*.csv)|*.csv";
            
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importStrategies = new PaymentImportCsv(openFileDialog.FileName, Payment.DOCOPER_CREDIT_ORDER);
                Import();
            }
            
            DataTable customerTable = accountingDoc.GetCustomerTable(true);

            foreach(DataRow row in importStrategies.PaymentTable().Rows)
            {
                
                DataRow[] findedCustomer = customerTable.Select(
                    String.Format("code='{0}'", row[PaymentImportCsv.CODE])
                   );
                
                if(findedCustomer.Length == 0)
                {
                    row[PaymentImport.IDCUSTOMER_COLUMN] = null;
                    row[PaymentImport.CUSTOMERNAME_COLUMN] = "НЕ НАЙДЕН";
                }
                else
                {
                    row[PaymentImport.IDCUSTOMER_COLUMN] = findedCustomer[0][PaymentImport.IDCUSTOMER_COLUMN];
                    row[PaymentImport.CUSTOMERNAME_COLUMN] = findedCustomer[0][PaymentImport.CUSTOMERNAME_COLUMN];
                }
            }
        }
        
        void LoadNonCashPaymentClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Client bank exchange file format (*.txt)|*.txt";
            
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                DataRow seller = accountingDoc.GetSeller(Settings.Base.idseller);
                
                if(seller == null && seller["inn"] == DBNull.Value)
                {
                    throw new ArgumentException("Не найден продавец! Укажите в настройках продавца по-умолчанию!");
                }
                
                importStrategies = new ClientBankExchangeImport((string)seller["inn"], openFileDialog.FileName);
                
                Import();

                DataTable customerTable = accountingDoc.GetCustomerTable(false);

                foreach(DataRow row in importStrategies.PaymentTable().Rows)
                {
                    DataRow[] findedCustomer = customerTable.Select(
                        String.Format("inn='{0}'", row[ClientBankExchangeImport.PAYMENT_PAYER_INN])
                       );

                    row[PaymentImport.IDCUSTOMER_COLUMN] = (findedCustomer.Length == 0) ? null :
                        findedCustomer[0][PaymentImport.IDCUSTOMER_COLUMN];
                    
                    row[PaymentImport.CUSTOMERNAME_COLUMN] = (findedCustomer.Length == 0) ? "НЕ НАЙДЕН" :
                        findedCustomer[0][PaymentImport.CUSTOMERNAME_COLUMN];
                }
            }
        }
        
        void Import()
        {
            paymentGridView.Columns.Clear();
            
            try
            {
                importStrategies.ImportPayment();
                
                importStrategies.PaymentTable().Columns.Add(PaymentImport.IDCUSTOMER_COLUMN, typeof(object));
                importStrategies.PaymentTable().Columns.Add(PaymentImport.CUSTOMERNAME_COLUMN, typeof(object));
                
                paymentGridView.DataSource = importStrategies.PaymentTable();
                
                paymentGridView.Columns[PaymentImport.IDCUSTOMER_COLUMN].Visible = false;
                paymentGridView.Columns[PaymentImport.CUSTOMERNAME_COLUMN].HeaderText = "Контрагент";
                
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                paymentGridView.Columns.Add(btn);
                btn.HeaderText = "Изменить";
                btn.Text = "Изменить";
                btn.Name = "customerBtn";
                btn.UseColumnTextForButtonValue = true;
            }
            catch (Exception exp) {
                AtMessageBox.Show("Произошла ошибка при импортировании платежей, возможно файл имел не верный формат!",
                                  "Ошибка импортирования \\n" + exp.Message,
                                  MessageBoxButtons.OK);
                paymentGridView.DataSource = null;
            }

        }
        
        private void paymentGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if(e.ColumnIndex < 0)
                return;
            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataRowView paymentRowView = (DataRowView) senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningRow.DataBoundItem;
                
                DataRow paymentRow = paymentRowView.Row;
                DataRow customer = DocumentClass.GetCustomer(-1);
                
                if(customer == null)
                    return;
                
                paymentRow[PaymentImport.IDCUSTOMER_COLUMN] = customer["idcustomer"];
                paymentRow[PaymentImport.CUSTOMERNAME_COLUMN] = customer["name"];
            }
        }
        
        void AcceptBtnClick(object sender, EventArgs e)
        {
            if(importStrategies == null)
                return;
            
            try
            {
                
                foreach(DataRow row in importStrategies.PaymentTable().Rows)
                {
                    if(row[PaymentImport.IDCUSTOMER_COLUMN] == DBNull.Value)
                    {
                        AtMessageBox.Show("У одного или более платежей не указан контрагент!");
                        return;
                    }
                }
                
                string paymentGroupName = DateTime.Now.Date.ToString("yyyy-MM-dd");
                
                int paymentGroupId = accountingDoc.ExistPaymentGroup(paymentGroupName);
                
                if(paymentGroupId == -1)
                {
                    paymentGroupId = accountingDoc.AddPaymentGroup(paymentGroupName);
                }
                
                DataTable pTable = importStrategies.PaymentTable();
                
                AccountValut valut = accountingDoc.BaseValut();
                
                for(int count = pTable.Rows.Count - 1; count >= 0; count--)
                {
                    Payment payment = importStrategies.GetPayment(paymentGroupId, valut, pTable.Rows[count]);
                    
                    if(!accountingDoc.SavePayment(payment))
                        return;
                    
                    pTable.Rows.Remove(pTable.Rows[count]);
                }
                
                AtMessageBox.Show("Импортирование платежей закончено!");
                
            }
            catch (Exception exp)
            {
                AtLog.AddMessage(exp.Message + "  " + exp.StackTrace);
            }
        }
        void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }
        
        void ToolStripButton3Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Csv file format (*.csv)|*.csv";
            
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importStrategies = new PaymentImportCsv(openFileDialog.FileName, Payment.DOCOPER_OPENING_BALANCE);
                Import();
            }
        }
        
        void ToolStripButton4Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Csv file format (*.csv)|*.csv";
            
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importStrategies = new PaymentImportCsv(openFileDialog.FileName, Payment.DOCOPER_OPENING_BALANCE_CASH);
                Import();
            }
        }
    }
}
