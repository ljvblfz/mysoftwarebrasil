using Paulovich.Data;

namespace Paulovich.Business {

	[Table("Territories")]
	public class Cidade: Persist  {

		#region fields & properties

		[PrimaryKeyField]
		public string TerritoryID { get; set; } 

		[Field]
		public string TerritoryDescription { get; set; } 

		[Field(typeof(Paulovich.Business.Estado), "RegionID")]
		public int RegionID { get; set; }

        [OneToOne]
        public Estado Estado { get; set; }

		#endregion

		#region constructors

		public Cidade()
			: base() {
		}

		public Cidade(params object[] keys)
			: base(keys) {
		}

		#endregion

	}

}
