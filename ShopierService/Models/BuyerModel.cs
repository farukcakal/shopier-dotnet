namespace ShopierService.Models;

public class BuyerModel
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public int AccountAge { get; set; } = 0;
}