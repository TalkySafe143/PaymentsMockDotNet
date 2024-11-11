using Microsoft.EntityFrameworkCore;
using PagosApp.Models;
namespace PagosApp.Context;

public class AccountContext : DbContext 
{
    public AccountContext(DbContextOptions<AccountContext> options) : base(options)
    {

    }

    public DbSet<Account> Account {get; set;} = null;
}