using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using PagosApp.Business;
using PagosApp.Interfaces;
using PagosApp.Models;
using ZstdSharp.Unsafe;

namespace PagosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        
        private IPaymentBusiness _business;

        public PaymentController(IPaymentBusiness business)
        {
            _business = business;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _business.GetPayments();

        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(long id)
        {
            var payment = await _business.GetPayment(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // POST: api/Payment
        [HttpPost]
        public async Task<IActionResult> PostPayment(Payment payment)
        {
            var confirm = await _business.CreatePayment(payment);
            if (!confirm) return BadRequest();
            return Created();
        }
    }
}
