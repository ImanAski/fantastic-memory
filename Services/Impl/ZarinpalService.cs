using System.Text.Json.Nodes;
using Miro.Models;
using miro.Services.Interface;

namespace miro.Services.Impl;

public class ZarinpalService : IPaymentService
{

    private readonly HttpClient _httpClient;
    
    public ZarinpalService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> CreatePaymentRequest(PaymentRequest paymentRequest)
    {
        var request = new HttpRequestMessage(HttpMethod.Post,
            "https://www.zarinpal.com/pg/rest/WebGate/PaymentRequest.json");
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "MerchantID", paymentRequest.MerchantId },
            { "Amount", paymentRequest.Amount.ToString() },
            { "Description", paymentRequest.Description },
            { "CallbackURl", paymentRequest.CallbackUrl }
        });
        
        // Send the payemnt request to the desired url
        var response = await _httpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // Parsing the Content of the response
        var paymentUrl = JsonObject.Parse(responseContent)["Data"]["Authority"].ToString();
        return "https://www.zarinpal.com/pg/StartPay/" + paymentUrl;

    }

    public async Task<PaymentVerification> VerifyPayment(PaymentRequest paymentRequest, string paymentAuthority)
    {
        // Verify the payment with Zarinpal
        var request = new HttpRequestMessage(HttpMethod.Post, "https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "MerchantID", paymentRequest.MerchantId },
            { "Amount", paymentRequest.Amount.ToString() },
            { "Authority", paymentAuthority }
        });

        // Send the payment verification request to Zarinpal and get the response
        var response = await _httpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();

        // Parse the response and create a PaymentVerification object
        var statusCode = int.Parse(JsonObject.Parse(responseContent)["Status"].ToString());
        var paymentVerification = new PaymentVerification
        {
            IsSuccess = statusCode == 100,
            Status = (PaymentVerificationStatus)statusCode,
            RefId = JsonObject.Parse(responseContent)["RefID"].ToString()
        };

        return paymentVerification;
    }
}