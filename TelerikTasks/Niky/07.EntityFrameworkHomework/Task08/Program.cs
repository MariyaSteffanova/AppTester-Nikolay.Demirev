using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task08
{
	class Program
	{
		static void Main(string[] args)
		{
			NorthwindEntities database = new NorthwindEntities();

			var emp = (from p in database.Employees select p).First();

			foreach (var teritory in emp.EntityTerritories)
			{
				Console.WriteLine(teritory.TerritoryDescription);
			}
		}
	}
}
