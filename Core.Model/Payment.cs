using System.Collections.Generic;

namespace Core.Model
{
    public class Payment
    {
        public IReadOnlyCollection<Product> Products { get; private set; }
        public PaymentOption PaymentOption { get; private set; }
        public PaymentSum PaymentSum { get; private set; }
    }
}
