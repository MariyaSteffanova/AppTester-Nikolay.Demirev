using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task09
{
	class Program
	{
		static void Main(string[] args)
		{
			NorthwindEntities database = new NorthwindEntities();

			Orders order = new Orders();
			order.CustomerID = "ALFKI";
			order.EmployeeID = 1;
			order.OrderDate = DateTime.Now;
			order.RequiredDate = DateTime.Now;
			order.ShipAddress = "59 rue de l'Abbaye";
			order.ShipCity = "Reims";
			order.ShipCountry = "France";
			order.ShipName = "Vins et alcools Chevalier";
			order.ShippedDate = DateTime.Now;
			order.ShipPostalCode = "51100";
			order.ShipRegion = "RJ";
			order.ShipVia = 3;
			order.Order_Details.Add(new Order_Details { Discount = 13, ProductID = 1, Quantity = 10, UnitPrice = 14 });
			order.Order_Details.Add(new Order_Details { Discount = 13, ProductID = 1, Quantity = 10, UnitPrice = 14 });
			order.Order_Details.Add(new Order_Details { Discount = 13, ProductID = 1, Quantity = 10, UnitPrice = 14 });
			order.Order_Details.Add(new Order_Details { Discount = 13, ProductID = 1, Quantity = 10, UnitPrice = 14 });

			database.Orders.AddObject(order);

			database.SaveChanges();
		}
	}
}
