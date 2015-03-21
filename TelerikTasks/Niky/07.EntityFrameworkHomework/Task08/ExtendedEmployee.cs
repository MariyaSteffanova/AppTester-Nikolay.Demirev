using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Task08
{
	public partial class Employees
	{
		private EntitySet<Territories> entityTerritories;

		public EntitySet<Territories> EntityTerritories
		{
			get
			{
				var employeeTerritories = this.Territories;
				EntitySet<Territories> entityTerritories = new EntitySet<Territories>();
				entityTerritories.AddRange(employeeTerritories);
				return entityTerritories;
			}
		}
	}
}
