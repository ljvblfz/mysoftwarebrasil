using System;
using System.Collections.Generic;
using Paulovich.Data;
using System.Collections.ObjectModel;

namespace Paulovich.Business {

	[Table("Region")]
	public class Estado: Persist  {

		#region fields & properties

		[PrimaryKeyField]
		public int RegionID { get; set; } 

		[Field]
		public string RegionDescription { get; set; } 

		#endregion

		#region constructors

		public Estado()
			: base() {
		}

		public Estado(params object[] keys)
			: base(keys) {
		}

		#endregion

		#region related tables

        //[ListToSave]
        //public Collection<Territories> Territories { get; set; }

		#endregion
	}

}
