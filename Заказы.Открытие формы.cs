using Atechnology.Components;
using Atechnology.DBConnections2;
using Atechnology.ecad.Document.Classes;
using System;
using System.Data;

namespace Atechnology.ecad.Calc
{

	public class RunCalc
	{

		public void Run(dbconn _db, DataRow[] _dr, bool isAll, object Class)
		{
			DataRow dataRow = _dr[0];
			if (dataRow["name"].ToString() == string.Empty && Settings.isDealer)
				dataRow["name"] = (object) (DateTime.Now.Year.ToString().Remove(0, 3) + Settings.People.addstr + (int.MaxValue + Useful.GetInt32(dataRow["idorder"])).ToString("000"));
			OrderClass orderClass = Class as OrderClass;
			if (orderClass != null)
			{
				orderClass.IsRefreshNumpos = OrderClass.RefreshPosType.Refresh;
				orderClass.IsRefreshConstrNumpos = OrderClass.RefreshPosType.Refresh;
			}
			_db.command.CommandText = "select count(*) from seller where deleted is null and name = 'OOO \"Пластконструктор\"'";
			_db.OpenDB();
			int num = (int) _db.command.ExecuteScalar();
			_db.CloseDB();
			if ((num == 0 || Settings.isDealer) && Convert.ToInt32(_dr[0]["saved"]) == 1)
				orderClass.OrderItemForm.ReadOnlyOrder = true;
			if(_dr[0]["iddocstate"]!= DBNull.Value && Convert.ToInt32(_dr[0]["iddocstate"]) >= 3)
				orderClass.OrderItemForm.ReadOnlyOrder = true;
			if (num <= 0 || Settings.people_admin)
				return;
			orderClass.OrderItemForm.MenuItemlPriceChange.Enabled = false;
		}
	}
}
