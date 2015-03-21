using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
	public class DAOClass
	{
		public static void Insert(Customers customer)
		{
			NorthwindEntities database = new NorthwindEntities();
			database.Customers.AddObject(customer);
			database.SaveChanges();
		}

		public static void Modify(string oldCustomerId, Customers newCustomer)
		{
			NorthwindEntities database = new NorthwindEntities();
			var customer = (from p in database.Customers where p.CustomerID == oldCustomerId select p).First();
			customer.Address = newCustomer.Address;
			customer.City = newCustomer.City;
			customer.CompanyName = newCustomer.CompanyName;
			customer.ContactName = newCustomer.ContactName;
			customer.ContactTitle = newCustomer.ContactTitle;
			customer.Country = newCustomer.Country;
			customer.Fax = newCustomer.Fax;
			customer.Phone = newCustomer.Phone;
			customer.PostalCode = newCustomer.PostalCode;
			customer.Region = newCustomer.Region;

			database.SaveChanges();
		}

		public static void Delete(string customerId)
		{
			NorthwindEntities database = new NorthwindEntities();
			var customer = (from p in database.Customers where p.CustomerID == customerId select p).First();

			database.Customers.DeleteObject(customer);
			database.SaveChanges();
		}
	}
}
