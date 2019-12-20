using System;
using System.Windows.Forms;
using Atechnology.Components;

namespace AccountingModule
{
    public class Period
    {
        private PeriodForm periodForm;
        
        public int Type {
            
            get {
                if(periodForm != null){
                    return periodForm.PeriodTyp;
                }
                return 0;
            }
            
        }
        
        public DateTime FromDate {
            
            get {
                return periodForm.DateTime1.Date;
            }
        }
        
        public DateTime ToDate {
            
            get {
                return periodForm.DateTime2.AddDays(1).Date;
            }
            
        }
        
        public string StringInterval {
            
            get {
                if(periodForm != null){
                    return periodForm.StringInterval;
                }
                return String.Empty;
            }
            
        }

        public Period()
        {
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddDays((double)(-(double)dateTime.Day + 1));
            
            DateTime dateTime2 = DateTime.Now;
            dateTime2 = dateTime2.AddDays((double)(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - dateTime2.Day));
            
            periodForm = new PeriodForm(dateTime, dateTime2);
            periodForm.PeriodTyp = 1;
        }
        
        public DialogResult ShowPeriodForm() {
            return periodForm.ShowDialog();
        }
    }
}
