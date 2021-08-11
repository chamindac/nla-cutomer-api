using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLA.CustomerAPI.Services;
using AutoMapper;
using NLA.CustomerAPI.Contracts;
using System.Threading;

namespace NLA.CustomerAPI.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        
        public CustomerController(ICustomerService customerService, IMapper mapper, ILogger<CustomerController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<Customer>>> GetAllAcutomers(CancellationToken cancellationToken = default)
        {
            List<Domains.Customer> searchResults = await _customerService.GetAllCustomers(cancellationToken);
            return Ok(_mapper.Map<List<Customer>>(searchResults));
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Customer>> RegisterCustomer(Customer customer, CancellationToken cancellationToken = default)
        {
            Domains.Customer registeredCustomer = await _customerService.RegisterCustomer(_mapper.Map<Domains.Customer>(customer), cancellationToken);
            return Ok(_mapper.Map<Customer>(registeredCustomer));
        }
    }
}
