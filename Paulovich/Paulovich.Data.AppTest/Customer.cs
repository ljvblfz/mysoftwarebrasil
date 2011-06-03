using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paulovich.Data.AppTest
{
    [Table("Customers")]
    public class Customer : Persist
    {

        #region fields & properties

        [PrimaryKeyField]
        public string CustomerID { get; set; }

        [Field]
        public string CompanyName { get; set; }

        [Field]
        public string ContactName { get; set; }

        [Field]
        public string ContactTitle { get; set; }

        [Field]
        public string Address { get; set; }

        [Field]
        public string City { get; set; }

        [Field]
        public string Region { get; set; }

        [Field]
        public string PostalCode { get; set; }

        [Field]
        public string Country { get; set; }

        [Field]
        public string Phone { get; set; }

        [Field]
        public string Fax { get; set; }

        #endregion

        #region constructors

        public Customer()
            : base()
        {
        }

        public Customer(params object[] keys)
            : base(keys)
        {
        }

        #endregion

        #region related tables

        //[ManyToMany(typeof(CustomerCustomerDemo))]
        //public ICollection<CustomerDemographics> CustomerCustomerDemo { get; set; }

        #endregion
    }

}
