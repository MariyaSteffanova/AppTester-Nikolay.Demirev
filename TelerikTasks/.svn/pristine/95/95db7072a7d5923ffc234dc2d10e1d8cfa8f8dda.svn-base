using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Task03
{
	class Program
	{
		static void Main(string[] args)
		{
			NorthwindEntities database = new NorthwindEntities();
			var customers = (from c in database.Customers
							 join o in database.Orders
							 on c.CustomerID equals o.CustomerID
							 where o.OrderDate.Value.Year == 1997 &&
							 o.ShipCountry == "Canada"
							 select c).Distinct();
			string query = ((ObjectQuery)customers).ToTraceString();
			foreach (var customer in customers)
			{
				Console.WriteLine(customer.CustomerID);
			}
		}
	}
}
