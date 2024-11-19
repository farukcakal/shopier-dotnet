using ShopierService.Enums;

namespace ShopierService.Models;

public class ShopierParamsModel
{
    public ShopierParamsModel()
    {
        Random random = new Random();
        RandomNr = random.Next(100000, 999999);
        ModuleVersion = "1.0.0";
    }
    
    public required string ApiKey { get; set; }
    public required WebsiteIndexEnum WebsiteIndex { get; set; } = WebsiteIndexEnum.Site1;
    public required string PlatformOrderId { get; set; }
    public required string ProductName { get; set; }
    public required ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.DefaultType;
    public required string BuyerName { get; set; }
    public required string BuyerSurname { get; set; }
    public required string BuyerEmail { get; set; }
    public required string BuyerPhone { get; set; }
    public int BuyerAccountAge { get; set; } = 0;
    public required string BuyerIdNr { get; set; }
    public required string BillingAddress { get; set; }
    public required string BillingCity { get; set; }
    public required string BillingCountry { get; set; }
    public required string ShippingAddress { get; set; }
    public required string ShippingCity { get; set; }
    public required string ShippingCountry { get; set; }
    public required string ShippingPostCode { get; set; }
    public required decimal TotalOrderValue { get; set; }
    public required CurrencyEnum Currency { get; set; } = CurrencyEnum.Tl;
    public required string Platform { get; set; }
    public required string IsInFrame { get; set; }
    public required LanguageEnum CurrentLanguage { get; set; } = LanguageEnum.Tr;
    public required string ModuleVersion { get; set; }
    public int RandomNr { get; private set; }
    public required string Signature { get; set; }
    public string? Callback { get; set; }

    // Sipariş Verileri Ayarlama
    public void SetOrderData(string platformOrderId, decimal totalOrderValue, string callback = null)
    {
        PlatformOrderId = platformOrderId;
        TotalOrderValue = totalOrderValue;
        Callback = callback;
    }

    // Ürün Verileri Ayarlama
    public void SetProductData(string productName, ProductTypeEnum productType)
    {
        ProductName = productName;
        ProductType = productType;
    }

    public void SetBuyer(BuyerModel buyer)
    {
        BuyerName = buyer.Name;
        BuyerSurname = buyer.Surname;
        BuyerEmail = buyer.Email;
        BuyerPhone = buyer.Phone;
        BuyerAccountAge = buyer.AccountAge;
    }

    public void SetAddress(AddressModel billingAddress, AddressModel shippingAddress)
    {
        BillingAddress = billingAddress.Address;
        BillingCity = billingAddress.City;
        BillingCountry = billingAddress.Country;
        ShippingAddress = shippingAddress.Address;
        ShippingCity = shippingAddress.City;
        ShippingCountry = shippingAddress.Country;
        ShippingPostCode = shippingAddress.PostCode;
    }

    // Hashleme için veri döndürme
    public string GetDataToBeHashed()
    {
        return $"{PlatformOrderId}{TotalOrderValue}{Currency}{Callback}";
    }
}