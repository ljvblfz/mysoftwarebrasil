using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paulovich.Data.AppTest
{
    [Table("CustomerCustomerDemo")]
    public class CustomerCustomerDemo : Persist
    {

        #region fields & properties

        [PrimaryKeyField(typeof(Customer), "CustomerID")]
        public string CustomerID { get; set; }

        [PrimaryKeyField(typeof(CustomerDemographics), "CustomerTypeID")]
        public string CustomerTypeID { get; set; }

        #endregion

        #region constructors

        public CustomerCustomerDemo()
            : base()
        {
        }

        public CustomerCustomerDemo(params object[] keys)
            : base(keys)
        {
        }

        #endregion

    }

}
