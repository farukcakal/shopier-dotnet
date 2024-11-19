namespace ShopierService.Models;

public class AddressModel
{
    public required string Address { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public required string PostCode { get; set; }
}