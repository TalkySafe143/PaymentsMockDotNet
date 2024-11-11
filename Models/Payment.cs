using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PagosApp.Models;

public class Payment {

    [Key]
    public long Id {get; set;}

    [Column("account_id")]
    public long AccountId {get; set;}

    [Column("status")]
    public string? Status {get; set;}

    [Column("date")]
    public DateTime Date {get; set;}

    [Column("value")]
    public double Value {get; set;}
}