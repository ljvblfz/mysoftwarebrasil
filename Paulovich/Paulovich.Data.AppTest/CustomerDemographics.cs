using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paulovich.Data.AppTest
{
    [Table("CustomerDemographics")]
    public class CustomerDemographics : Persist
    {

        #region fields & properties

        [PrimaryKeyField]
        public string CustomerTypeID { get; set; }

        [Field]
        public string CustomerDesc { get; set; }

        #endregion

        #region constructors

        public CustomerDemographics()
            : base()
        {
        }

        public CustomerDemographics(params object[] keys)
            : base(keys)
        {
        }

        #endregion

    }

}
