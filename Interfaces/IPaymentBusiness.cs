using Microsoft.AspNetCore.Mvc;
using PagosApp.Models;

namespace PagosApp.Interfaces;

public interface IPaymentBusiness
{
    Task< ActionResult< IEnumerable<Payment> > > GetPayments();

    Task<Payment?> GetPayment(long id);
    Task<bool> CreatePayment(Payment payment);
}