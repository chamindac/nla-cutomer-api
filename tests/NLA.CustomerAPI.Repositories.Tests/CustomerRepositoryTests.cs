using System;
//using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Collections.Generic;
using FluentAssertions;
using NLA.CustomerAPI.Domains;
using Xunit;
using Moq.EntityFrameworkCore;
using Moq;
using NLA.CustomerAPI.Repositories.Data;

namespace NLA.CustomerAPI.Repositories.Tests
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public void GetAllCustomers_ReturnsAllCustomers()
        {
            var data = new List<Customer>
            {
                new Customer {
                    Id = 1,
                    FirstName = "Chaminda",
                    LastName = "Chandrasekara",
                    ContactNo = "1234567890",
                    Email = "chaminda@codification.io",
                    TaxStartDate = new DateTime(2018,3,31),
                    TaxRenewedOnDate = new DateTime(2021,3,31)
                },
                new Customer {
                    Id = 1,
                    FirstName = "Donovan",
                    LastName = "Brown",
                    ContactNo = "1234567890",
                    Email = "donovan@codification.io",
                    TaxStartDate = new DateTime(2016,3,31),
                    TaxRenewedOnDate = new DateTime(2021,3,31)
                },
                new Customer {
                    Id = 1,
                    FirstName = "Scott",
                    LastName = "Hansalman",
                    ContactNo = "1234567890",
                    Email = "scott@codification.io",
                    TaxStartDate = new DateTime(2019,3,31),
                    TaxRenewedOnDate = new DateTime(2021,3,31)
                }
            }.AsQueryable();

            var mockContext = new Mock<CustomerDbContext>();
            mockContext.SetupSequence(x => x.Set<Customer>())
                .ReturnsDbSet(data);
                
            var repository = new CustomerRepository(mockContext.Object);
            var customers = repository.GetAllCustomers().Result;

            customers[0].FirstName.Should().BeSameAs("Chaminda");
            customers[1].FirstName.Should().BeSameAs("Donovan");
            customers[2].FirstName.Should().BeSameAs("Scott");
            customers.Count.Should().Be(3);
            
        }

    }
}
