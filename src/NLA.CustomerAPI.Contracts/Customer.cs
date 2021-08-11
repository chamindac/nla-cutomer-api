using System;

namespace NLA.CustomerAPI.Contracts
{
    public class Customer
    {
        /// <summary>
        /// Primary key of customer.
        /// </summary>
        public int Id {get;set;}
        
        /// <summary>
        /// Unique code of customer.
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
    }
}
