using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task07
{
	class Program
	{
		static void Main(string[] args)
		{
			NorthwindEntities database = new NorthwindEntities();
			NorthwindEntities database1 = new NorthwindEntities();

			var customer = (from p in database.Customers select p).First();
			var customer1 = (from p in database1.Customers select p).First();

			customer.CompanyName = "Telerik";
			customer1.CompanyName = "Infragistics";

			database.SaveChanges();
			database1.SaveChanges();
		}
	}
}
