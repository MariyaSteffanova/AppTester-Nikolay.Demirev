using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
	class Program
	{
		static void Main(string[] args)
		{
			Customers customer = new Customers();
			customer.CustomerID = "NIDE";
			customer.ContactName = "niky";
			customer.Phone = "0883";
			customer.Address = "test";
			customer.City = "test";
			customer.CompanyName  = "test";
			customer.ContactTitle = "test";
			customer.Country = "test";
			customer.Fax = "test";
			customer.Phone = "test";
			customer.PostalCode = "test";
			customer.Region = "test";
			DAOClass.Insert(customer);

			NorthwindEntities database = new NorthwindEntities();
			var customerToModifyAndDelete = (from p in database.Customers where p.CustomerID == "NIDE" select p).First();
			database.Dispose();

			customerToModifyAndDelete.ContactName = "Nikolay";
			customerToModifyAndDelete.Phone = "088340";
			DAOClass.Modify(customerToModifyAndDelete.CustomerID, customerToModifyAndDelete);

			DAOClass.Delete(customerToModifyAndDelete.CustomerID);
		}
	}
}
