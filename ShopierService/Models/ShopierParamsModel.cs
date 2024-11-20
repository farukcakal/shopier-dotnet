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
    
    public void SetSignature(string signature)
    {
        Signature = signature;
    }

    public void SetApiKey(string apiKey)
    {
        ApiKey = apiKey;
    }
    
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(ApiKey))
            throw new ArgumentException("API Key is required.");

        if (string.IsNullOrWhiteSpace(PlatformOrderId))
            throw new ArgumentException("Platform Order ID is required.");

        if (string.IsNullOrWhiteSpace(ProductName))
            throw new ArgumentException("Product Name is required.");

        if (string.IsNullOrWhiteSpace(BuyerName))
            throw new ArgumentException("Buyer Name is required.");

        if (string.IsNullOrWhiteSpace(BuyerSurname))
            throw new ArgumentException("Buyer Surname is required.");

        if (string.IsNullOrWhiteSpace(BuyerEmail))
            throw new ArgumentException("Buyer Email is required.");

        if (string.IsNullOrWhiteSpace(BuyerPhone))
            throw new ArgumentException("Buyer Phone is required.");

        if (string.IsNullOrWhiteSpace(BuyerIdNr))
            throw new ArgumentException("Buyer ID Number is required.");

        if (string.IsNullOrWhiteSpace(BillingAddress))
            throw new ArgumentException("Billing Address is required.");

        if (string.IsNullOrWhiteSpace(BillingCity))
            throw new ArgumentException("Billing City is required.");

        if (string.IsNullOrWhiteSpace(BillingCountry))
            throw new ArgumentException("Billing Country is required.");

        if (string.IsNullOrWhiteSpace(ShippingAddress))
            throw new ArgumentException("Shipping Address is required.");

        if (string.IsNullOrWhiteSpace(ShippingCity))
            throw new ArgumentException("Shipping City is required.");

        if (string.IsNullOrWhiteSpace(ShippingCountry))
            throw new ArgumentException("Shipping Country is required.");

        if (string.IsNullOrWhiteSpace(ShippingPostCode))
            throw new ArgumentException("Shipping Post Code is required.");

        if (TotalOrderValue <= 0)
            throw new ArgumentException("Total Order Value must be greater than zero.");

        if (string.IsNullOrWhiteSpace(Signature))
            throw new ArgumentException("Signature is required.");
    }
    public Dictionary<string, string> ToDictionary()
    {
        var dictionary = new Dictionary<string, string>
        {
            { "ApiKey", ApiKey },
            { "WebsiteIndex", ((int)WebsiteIndex).ToString() },
            { "PlatformOrderId", PlatformOrderId },
            { "ProductName", ProductName },
            { "ProductType", ((int)ProductType).ToString() },
            { "BuyerName", BuyerName },
            { "BuyerSurname", BuyerSurname },
            { "BuyerEmail", BuyerEmail },
            { "BuyerPhone", BuyerPhone },
            { "BuyerAccountAge", BuyerAccountAge.ToString() },
            { "BuyerIdNr", BuyerIdNr },
            { "BillingAddress", BillingAddress },
            { "BillingCity", BillingCity },
            { "BillingCountry", BillingCountry },
            { "ShippingAddress", ShippingAddress },
            { "ShippingCity", ShippingCity },
            { "ShippingCountry", ShippingCountry },
            { "ShippingPostCode", ShippingPostCode },
            { "TotalOrderValue", TotalOrderValue.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) },
            { "Currency", ((int)Currency).ToString() },
            { "Platform", Platform },
            { "IsInFrame", IsInFrame },
            { "CurrentLanguage", ((int)CurrentLanguage).ToString() },
            { "ModuleVersion", ModuleVersion },
            { "RandomNr", RandomNr.ToString() },
            { "Signature", Signature }
        };

        if (!string.IsNullOrWhiteSpace(Callback))
        {
            dictionary.Add("Callback", Callback);
        }

        return dictionary;
    }
}