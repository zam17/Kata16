using System.Collections.Generic;

namespace Core.Model
{
    public class Purchase
    {
        public Purchase(IReadOnlyCollection<Product> products, Payment payment)
        {
            Products = products;
            Payment= payment;
        }

        public IReadOnlyCollection<Product> Products { get; }
        public Payment Payment{ get; }
    }
}
