using System;
using System.Collections.Generic;
using Paulovich.Data;
using System.Collections.ObjectModel;

namespace Paulovich.Data.Generator
{
    [Table("Orders")]
	public class Orders: Persist  {

		#region fields & properties

        [PrimaryKeyField]
		public int OrderID { get; set; } 

		[Field]
		public string CustomerID { get; set; } 

		[Field]
		public int? EmployeeID { get; set; } 

		[Field]
		public DateTime? OrderDate { get; set; } 

		[Field]
		public DateTime? RequiredDate { get; set; } 

		[Field]
		public DateTime? ShippedDate { get; set; } 

		[Field]
		public int? ShipVia { get; set; } 

		[Field]
		public decimal? Freight { get; set; } 

		[Field]
		public string ShipName { get; set; } 

		[Field]
		public string ShipAddress { get; set; } 

		[Field]
		public string ShipCity { get; set; } 

		[Field]
		public string ShipRegion { get; set; } 

		[Field]
		public string ShipPostalCode { get; set; } 

		[Field]
		public string ShipCountry { get; set; } 

		#endregion

		#region constructors

		#endregion

    }
}
