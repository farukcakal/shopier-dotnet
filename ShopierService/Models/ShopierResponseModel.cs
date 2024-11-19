using System.Security.Cryptography;
using System.Text;

namespace ShopierService.Models;

public class ShopierResponseModel
{
    private static readonly Dictionary<string, bool> Requirement = new()
    {
        { "platform_order_id", true },
        { "status", true },
        { "installment", true },
        { "payment_id", true },
        { "random_nr", true },
        { "signature", true }
    };

    public string PlatformOrderId { get; private set; }
    public string ApiKey { get; private set; }
    public string Status { get; private set; }
    public int Installment { get; private set; }
    public int PaymentId { get; private set; }
    public int RandomNr { get; private set; }
    public string Signature { get; private set; }

    public static ShopierResponseModel FromPostData(Dictionary<string, string> postData)
    {
        return new ShopierResponseModel(postData);
    }

    public ShopierResponseModel(Dictionary<string, string> values = null)
    {
        if (values != null)
        {
            PlatformOrderId = values.ContainsKey("platform_order_id") ? values["platform_order_id"] : null;
            ApiKey = values.ContainsKey("API_key") ? values["API_key"] : null;
            Status = values.ContainsKey("status") ? values["status"] : null;
            Installment = values.ContainsKey("installment") ? int.Parse(values["installment"]) : 0;
            PaymentId = values.ContainsKey("payment_id") ? int.Parse(values["payment_id"]) : 0;
            RandomNr = values.ContainsKey("random_nr") ? int.Parse(values["random_nr"]) : 0;
            Signature = values.ContainsKey("signature") ? values["signature"] : null;
        }
    }

    public bool IsSuccess()
    {
        return Status == "success";
    }

    public string GetDecodedSignature()
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(Signature));
    }

    public string GetExpectedSignature(string apiSecret)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecret));
        var data = Encoding.UTF8.GetBytes($"{RandomNr}{PlatformOrderId}");
        var hash = hmac.ComputeHash(data);
        return Convert.ToBase64String(hash);
    }

    public bool HasValidSignature(string apiSecret)
    {
        try
        {
            Validate();
        }
        catch (Exception)
        {
            return false;
        }

        return GetDecodedSignature() == GetExpectedSignature(apiSecret);
    }

    private void Validate()
    {
        foreach (var (key, isRequired) in Requirement)
        {
            if (isRequired && string.IsNullOrEmpty(GetType().GetProperty(key)?.GetValue(this)?.ToString()))
            {
                throw new Exception($"Required parameter {key} is missing.");
            }
        }
    }
}