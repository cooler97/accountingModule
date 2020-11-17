using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.ecad.Report;
using Stimulsoft.Report;

namespace Logistic.ProductionSchedule.Scheduler
{
    public class ReportUtil
    {
        private ReportUtil()	{	}
        
        public static bool exportFin(IEnumerable sourceData, string dateTimeInterval) {
            ArrayList vars = new ArrayList();
            vars.Add(new repVars("dateTimeInterval", dateTimeInterval, typeof(string)));
            return autoExportReportByName("Финансовый учет", vars, false, 1, sourceData);
        }
        
        public static bool autoExportReportByName(string name, ArrayList vars, bool autoPrint, short copies, IEnumerable sourceData)
        {
            AtUserControl atuc = new AtUserControl();
            
            atuc.db.command.CommandText = "SELECT TOP 1 idreport FROM dbo.report WHERE name LIKE '" + name + "' and deleted is null";
            
            DataTable dTbl = new DataTable();
            atuc.db.adapter.Fill(dTbl);
            
            int reportID = Useful.GetInt32(dTbl.Rows[0]["idreport"]);
            
            return autoExportReport(reportID, vars, autoPrint, copies, sourceData);
        }
        //
        
        //функция авто экспорта отчетов
        public static bool autoExportReport(int idreport, ArrayList vars, bool autoPrint, short copies, IEnumerable sourceData)
        {
            DataTable repTbl = new DataTable();
            repTbl.Clear();
            
            AtUserControl atuc = new AtUserControl();
            atuc.db.command.CommandText = "SELECT * FROM dbo.report WHERE idreport = " + idreport;
            atuc.db.adapter.Fill(repTbl);
            atuc.db.command.Parameters.Clear();
            
            if (repTbl.Rows.Count == 0)
            {
                MessageBox.Show("Не могу найти запись об отчете в БД.");
                return false;
            }
            
            DataRow dr = repTbl.Rows[0];
            
            AtReport rep = new AtReport(dr, vars);
            
            if(sourceData != null)
            {
                StiReport stiRep = rep.rep;
                stiRep.Dictionary.Databases.Clear();
                stiRep.Dictionary.DataSources.Clear();
                stiRep.RegData("Список", sourceData);
                stiRep.Dictionary.Synchronize();
            }
            
            if(autoPrint)
            {
                rep.PrintReport(copies);
            }
            else
            {
                rep.ShowReport();
            }
            
            return true;
        }
    }
}
