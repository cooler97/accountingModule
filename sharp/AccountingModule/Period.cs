/*
 * Created by SharpDevelop.
 * User: At
 * Date: 28.11.2019
 * Time: 14:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Atechnology.Components;

namespace AccountingModule
{
    /// <summary>
    /// Description of Period.
    /// </summary>
    public class Period
    {
        
        private PeriodForm periodForm;
        
        private int _type = 0;
        
        public int Type {
            
            get {
                return _type;
            }
            
            set {
                _type = value;
            }
            
        }
        
        private DateTime _fromDate = new DateTime();
        
        public DateTime FromDate {
            
            get {
                return _fromDate;
            }
            
            set {
                _fromDate = value;
            }
            
        }
        
        private DateTime _toDate = new DateTime();
        
        public DateTime ToDate {
            
            get {
                return _toDate;
            }
            
            set {
                _toDate = value;
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
            this._type = 0;
            periodForm = new PeriodForm();
        }
        
        public void ShowPeriodForm() {
           
            if(periodForm.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                this._type = periodForm.PeriodTyp;
                this._fromDate = periodForm.DateTime1;
                this._toDate = periodForm.DateTime2;
            }
            
        }
    }
}
