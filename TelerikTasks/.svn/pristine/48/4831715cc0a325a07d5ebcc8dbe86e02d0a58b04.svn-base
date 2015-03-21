using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task04
{
	class Program
	{
		private static IEnumerable<string> selectCustomers(string country, string startDate, string endDate)
		{
			NorthwindEntities entities = new NorthwindEntities();
			string nativeSQLQuery =
				"SELECT Distinct CustomerID " +
				"FROM dbo.Orders " +
				"WHERE ShipCountry = {0} AND OrderDate BETWEEN {1} AND {2}";
			object[] parameters = { country, startDate, endDate };
			var employees = entities.ExecuteStoreQuery<string>(
				nativeSQLQuery, parameters);
			return employees;
		}

		static void Main(string[] args)
		{
			var customers = selectCustomers("Canada", "1/1/1997", "1/1/1998");
			foreach (var item in customers)
			{
				Console.WriteLine(item);
			}
		}
	}
}
