using System;
using Braintree;

namespace NoirBank.Utils.BraintreeService
{
    public interface IBraintreeService
    {
        BraintreeGateway GetGateway();
    }
}

