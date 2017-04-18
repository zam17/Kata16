using System.Collections.Generic;

namespace Core.Model
{
    public class Product
    {
        public Product(IReadOnlyCollection<ProductCategory> categories, ProductFlags productFlags, string productName)
        {
            Categories = categories;
            ProductFlags = productFlags;
            ProductName = productName;
        }

        public IReadOnlyCollection<ProductCategory> Categories { get; }
        public ProductFlags ProductFlags { get; }
        public string ProductName { get; }
    }
}