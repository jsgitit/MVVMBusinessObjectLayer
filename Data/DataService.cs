﻿using MVVMBusinessObjectLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVMBusinessObjectLayer.Data
{
    public class DataService
    {
        // just a basic service to setup dummy data
        public DataService()
        {
            products.Add(new ProductModel()
            {
                Id = 1,
                Name = "Football",
                Description = "Straight from the NFL",
                Price = (decimal)10.00
            });
            products.Add(new ProductModel()
            {
                Id = 2,
                Name = "Basketball",
                Description = "Straight from the NBA",
                Price = (decimal)12.00
            });
            products.Add(new ProductModel()
            {
                Id = 3,
                Name = "Baseball",
                Description = "Straight from the MLB",
                Price = (decimal)8.00
            });

            customers.Add(new CustomerModel()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones"
            });
            customers.Add(new CustomerModel()
            {
                Id = 2,
                FirstName = "Terri",
                LastName = "Berry"
            });
            customers.Add(new CustomerModel()
            {
                Id = 3,
                FirstName = "Lisa",
                LastName = "Smith"
            });
        }

        List<ProductModel> products = new();
        public List<ProductModel> Products
        {
            get
            {
                return products;
            }
        }
        
        List<CustomerModel> customers= new();
        public List<CustomerModel> Customers
        {
            get
            {
                return customers;
            }
        }



    }
}
