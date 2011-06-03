using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paulovich.Business;
using System.Diagnostics;

namespace Paulovich.Data.AppTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Command.Log = Console.Out;

            Customer customer = new Customer();
            customer.CustomerID = "ALFKI";


            //CustomerDemographics demo = new CustomerDemographics();
            //demo.CustomerTypeID = "282";
            //demo.CustomerDesc = "Ivan";


            var teste = customer.Join<CustomerDemographics>(typeof(CustomerCustomerDemo), typeof(Orders));
             

            //customer.CustomerID = DateTime.Now.Millisecond.ToString();
            //customer.CompanyName = "Ivan";
            //customer.ContactName = "asdas";
            //customer.ContactTitle = "vainas";
            //customer.Address = "asddasd";
            //customer.City = "asdasd";
            //customer.Region = "asdasd";
            //customer.PostalCode = "asdasd";
            //customer.Country = "asdasd";
            //customer.Phone = "asdasd";
            //customer.Fax = "asdasd";

            //CustomerDemographics demo = new CustomerDemographics();
            //demo.CustomerTypeID = DateTime.Now.Millisecond.ToString();
            //demo.CustomerDesc = "Ivan";

            //customer.CustomerCustomerDemo.Add(demo);

            //customer.Save(1);


            Console.ReadLine();


        }
    }
}
