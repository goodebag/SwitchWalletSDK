using Microsoft.AspNetCore.Mvc;
using SwitchWalletSDK.Sdk.Models;
using SwitchWalletSDK.Sdk.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwitchWalletSDK.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SDKController : ControllerBase
    {

        private readonly ISwitchWalletClient _switchWalletClient;

        public SDKController(ISwitchWalletClient switchWalletClient)
        {
            _switchWalletClient = switchWalletClient;
        }

        // GET: api/<SDKController>
        [HttpGet]
        public IActionResult balance()
        {
            return Ok(_switchWalletClient.OriginAccountBalanceAsync("Your-Public-Key").Result);
        }
        [HttpGet]
        public IActionResult Transactions()
        {
            return Ok(_switchWalletClient.GetTransactionRecordAsync().Result);
        }
        [HttpGet]
        public IActionResult Last7DaysTransactions()
        {
            return Ok(_switchWalletClient.GetTimedTransactionRecordAsync().Result);
        }
        [HttpGet]
        public IActionResult RemitanceTransactions()
        {
            return Ok(_switchWalletClient.RemittanceRecordAsync().Result);
        }
        [HttpGet]
        public IActionResult UnremittedTransactions()
        {
            return Ok(_switchWalletClient.UnremittedTransactionAsync().Result);
        }
        // POST api/<SDKController>
        [HttpPost]
        public IActionResult MerchantClientWithdrawal([FromBody] InitiateWithdrawalPayload body)
        {
            return Ok(_switchWalletClient.MerchantClientWithdrawalAsync(body).Result);
        }
        // POST api/<SDKController>
        [HttpPost]
        public IActionResult GenerateWalletAddress([FromBody] GenerateAddressForPaymentPayload body)
        {
            return Ok(_switchWalletClient.GenerateWalletAddressAsync(body).Result);
        }
        // POST api/<SDKController>
        [HttpGet]
        public IActionResult ClientWithdrawalStatus(string merchantReference)
        {
            return Ok(_switchWalletClient.ClientWithdrawalStatusAsync(merchantReference).Result);
        }
        // POST api/<SDKController>
        [HttpPost]
        public IActionResult AddNetworkSupport([FromBody] AddSupportedNetworkDto body)
        {
            return Ok(_switchWalletClient.AddNetworkChainAsync(body).Result);
        }
        [HttpGet]
        public IActionResult GetActiveCurrenciesAsync()
        {
            return Ok(_switchWalletClient.GetActiveCurrenciesAsync().Result);
        }
        [HttpGet]
        public IActionResult GetSupportedNetworksAsync()
        {
            return Ok(_switchWalletClient.SupportedNetworksAsync().Result);
        }
        [HttpGet]
        public IActionResult SupportedCurrenciesAsync()
        {
            return Ok(_switchWalletClient.SupportedCurrenciesAsync().Result);
        }
        // POST api/<SDKController>
        [HttpPost]
        public  IActionResult SetCurrenciesAsync([FromBody] IEnumerable<Guid> body)
        {
           _switchWalletClient.SetCurrencesAsync(body);
            return Ok("Sucess");
        }
    }
}
