using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.ecad.Report;

namespace Logistic.ProductionSchedule.Scheduler
{
	public class ReportUtil
	{
		private ReportUtil()	{	}
		
		public static bool exportFin(DateTime fromDate, DateTime toDate) {
			ArrayList vars = new ArrayList();
			vars.Add(new repVars("fromDate", fromDate.ToString(), typeof(string)));
			vars.Add(new repVars("toDate", toDate.ToString(), typeof(string)));
			return autoExportReportByName("Финансовый учет", vars, false, 1);
		}
		
		public static bool autoExportReportByName(string name, ArrayList vars, bool autoPrint, short copies)
		{
			AtUserControl atuc = new AtUserControl();
	
			atuc.db.command.CommandText = "SELECT TOP 1 idreport FROM dbo.report WHERE name LIKE '" + name + "' and deleted is null";
	
			DataTable dTbl = new DataTable();
			atuc.db.adapter.Fill(dTbl);
	
			int reportID = Useful.GetInt32(dTbl.Rows[0]["idreport"]);
	
			return autoExportReport(reportID, vars, autoPrint, copies);
		}
		//
	
		//функция авто экспорта отчетов
		public static bool autoExportReport(int idreport, ArrayList vars, bool autoPrint, short copies)
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
