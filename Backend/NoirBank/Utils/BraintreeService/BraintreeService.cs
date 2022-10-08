using System;
using Braintree;
using Microsoft.Extensions.Configuration;

namespace NoirBank.Utils.BraintreeService
{
    public class BraintreeService : IBraintreeService
    {
        private readonly IConfiguration _config;

        public BraintreeService(IConfiguration config)
        {
            _config = config;
        }

        public BraintreeGateway GetGateway()
        {
            var merchantID = _config.GetSection("Braintree:MerchantID").Value;
            var publicKey = _config.GetSection("Braintree:PublicKey").Value;
            var privateKey = _config.GetSection("Braintree:PrivateKey").Value;

            return new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = merchantID,
                PublicKey = publicKey,
                PrivateKey = privateKey
            };
        }
    }
}

