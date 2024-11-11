using Microsoft.EntityFrameworkCore;
using PagosApp.Models;
namespace PagosApp.Context;

public class PaymentContext : DbContext
{
    public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
    {

    }

    public DbSet<Payment> Payment {get; set;} = null;
}