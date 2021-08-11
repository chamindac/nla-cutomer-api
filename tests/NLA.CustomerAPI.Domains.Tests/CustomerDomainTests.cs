using System;
using NLA.CustomerAPI.Domains.Enums;
using NLA.CustomerAPI.Domains;
using FluentAssertions;
using Xunit;

namespace NLA.CustomerAPI.Domains.Tests
{
    public class CustomerDomainTests
    {
        [Fact]
        public void GetDemarcDate_RenewedOnDate_ReturnsRenewedOnDate()
        {
            var cus = new Customer()
            {
                Code = "001",
                FirstName = "Chaminda",
                LastName = "Chandrasekara",
                TaxStartDate = new DateTime(2020, 10, 1),
                TaxRenewedOnDate = new DateTime(2020, 07, 1)
            };

            var demarcDate = cus.GetDemarcDate(TaxYearDemarcationMethod.RenewedOnDate);
            demarcDate.Should().BeSameDateAs(cus.TaxRenewedOnDate);
        }

        [Fact]
        public void GetDemarcDate_WhenStartDate_ReturnsStartDate()
        {
            var cus = new Customer()
            {
                Code = "001",
                FirstName = "Chaminda",
                LastName = "Chandrasekara",
                TaxStartDate = new DateTime(2020, 10, 1),
                TaxRenewedOnDate = new DateTime(2020, 07, 1)                
            };

            var demarcDate = cus.GetDemarcDate(TaxYearDemarcationMethod.StartDate);
            demarcDate.Should().BeSameDateAs(cus.TaxStartDate);
        }
    }
}
