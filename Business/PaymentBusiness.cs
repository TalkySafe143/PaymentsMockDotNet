using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagosApp.Interfaces;
using PagosApp.Models;
using PagosApp.Context;

namespace PagosApp.Business;

public class PaymentBusiness : IPaymentBusiness {

    private AccountContext _accountContext;
    private PaymentContext _paymentContext;

    public PaymentBusiness(AccountContext accountContext, PaymentContext paymentContext)
    {
        _accountContext = accountContext;
        _paymentContext = paymentContext;
    }

    public async Task< ActionResult< IEnumerable<Payment> > > GetPayments()
    {
        return await _paymentContext.Payment.ToListAsync();
    }

    public async Task<Payment?> GetPayment(long id)
    {
        return await _paymentContext.Payment.FindAsync(id);
    }

    public async Task<bool> CreatePayment(Payment payment)
    {

        Console.WriteLine(payment.Status);
        var account = await _accountContext.Account.FindAsync(payment.AccountId);
        if (account == null) return false;

        if (account.Withdraw < payment.Value) {
            payment.Status = "REJECTED";
        } else {
            account.Withdraw -= payment.Value;
            _accountContext.Entry(account).State = EntityState.Modified;

            try {
                await _accountContext.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                return false;
            }
            payment.Status = "ACCEPTED";
        }
        _paymentContext.Payment.Add(payment);
        await _paymentContext.SaveChangesAsync();
        return true;
    }
}