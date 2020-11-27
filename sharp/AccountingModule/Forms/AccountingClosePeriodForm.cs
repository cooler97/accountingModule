using System;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.DBConnections2;

namespace AccountingModule
{
    public partial class СlosePeriodForm : Form
    {
        
        dbconn db;
        
        public СlosePeriodForm(dbconn db)
        {
            InitializeComponent();
            
            this.db = db;
            
            for(int i = 2018; i <= 2050; i++)
            {
                yearComboBox.Items.Add(i.ToString());
            }
        }
        
        void Button1Click(object sender, EventArgs e)
        {
            if(db == null)
            {
                AtMessageBox.Show("Ошибка подключения к базе данных");
                return;
            }
            
            if(String.IsNullOrEmpty(yearComboBox.Text))
            {
                AtMessageBox.Show("Не введен год");
                return;
            }
            
            string sql = String.Format("EXEC dbo.accounting_finperiod_close @dt = '{0}', @dtdoc = '{1}';",
                                       yearComboBox.Text,
                                       dtDocPicker.Value.ToString("yyyy-MM-dd"));
            
            using (AtUserControl.WithUIBlock)
            {
                if(db.Exec(sql, true))
                    AtMessageBox.Show("Завершено успешно");
            }
        }
    }
}
