using ShopierService.Models;

namespace ShopierService;

public interface IShopier
{
    public string GetPaymentUrl();
    public void SetPaymentUrl(string paymentUrl);
    public string GetApiKey();
    public void SetApiKey(string apiKey);
    public string GetApiSecret();
    public void SetApiSecret(string apiSecret);
    public ShopierParamsModel GetParams();
    public void SetParams(ShopierParamsModel shopierParams);
    public void Go();
    public Shopier Prepare();
    public Shopier CalculateSignature();
    public bool ValidateResponse(Dictionary<string, string> responseData = null);
}