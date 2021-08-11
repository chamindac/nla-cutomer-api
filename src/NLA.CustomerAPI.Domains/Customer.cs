using System;
using NLA.CustomerAPI.Domains.Enums;

namespace NLA.CustomerAPI.Domains
{
    public class Customer
    {
        /// <summary>
        /// Primary key for customer.
        /// </summary>
        public int Id {get;set;}
        
        /// <summary>
        /// Unique code for customer.
        /// </summary>
        public string Code {get;set;}
        
        /// <summary>
        /// First name of customer.
        /// </summary>
        public string FirstName {get;set;}
        
        /// <summary>
        /// Last name of cutomer.
        /// </summary>
        public string LastName {get;set;}
        /// <summary>
        /// Contact number of customer.
        /// </summary>
        public string ContactNo {get;set;}
        
        /// <summary>
        /// Email address of customer.
        /// </summary>
        public string Email {get;set;}
        
        /// <summary>
        /// Date the tax year starts for customer.
        /// </summary>
        public DateTime TaxStartDate { get; set; }
        
        /// <summary>
        /// Renewal date for the tax year for cutomer.
        /// </summary>
        public DateTime TaxRenewedOnDate { get; set; }
        
        /// <summary>
        /// Returns the tax year StartDate or RenewedOnDate based on demarcation method specified.
        /// </summary>
        /// <param name="demarcMethod">Demarcation method to use.</param>
        /// <returns>Demarcation date</returns>
        public DateTime GetDemarcDate(TaxYearDemarcationMethod demarcMethod)
        {
            if (demarcMethod == TaxYearDemarcationMethod.RenewedOnDate)
            {
                return TaxRenewedOnDate;
            }
            else
            {
                return TaxStartDate;
            }
        }
    }
}
