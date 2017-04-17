using System.Collections.Generic;

namespace Core.Model
{
    public class Product
    {
        public Product(IReadOnlyCollection<ProductCategory> categories, ProductFlags productFlags)
        {
            Categories = categories;
            ProductFlags = productFlags;
        }

        public IReadOnlyCollection<ProductCategory> Categories { get; private set; }
        public ProductFlags ProductFlags { get; private set; }
    }
}