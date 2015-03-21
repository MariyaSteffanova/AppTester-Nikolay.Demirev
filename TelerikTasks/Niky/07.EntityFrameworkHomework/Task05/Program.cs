using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task05
{
	class Program
	{
		private static NorthwindEntities database = new NorthwindEntities();

		private static IQueryable<Orders> SelectSales(string region, DateTime startDate, DateTime endDate)
		{
			var sales = (from p in database.Orders
						 where
							p.ShipRegion == region &&
							p.OrderDate > startDate &&
							p.OrderDate < endDate
						 select p).Distinct();

			return sales;
		}

		static void Main(string[] args)
		{
			var sales = SelectSales("Nueva Esparta", DateTime.Now.AddYears(-33), DateTime.Now);

			foreach (var sale in sales)
			{
				Console.WriteLine("{0} {1} {2}", sale.OrderID, sale.ShipRegion, sale.OrderDate);
			}
		}
	}
}
