using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PagosApp.Models;

public class Account {

    [Key]
    public long Id {get; set;}

    [Column("name")]
    public string? Name {get; set;}

    [Column("card_number")]
    public string? CardNumber {get; set;}

    [Column("withdraw")]
    public double Withdraw {get; set;}
}