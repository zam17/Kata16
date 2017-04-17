using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Model;

namespace Core.Impl
{
    public class ProductTypeEvaluator: IProductTypeEvaluator
    {
        private const string BooksCategoryName = "Books"; // This must be centralized.

        public bool IsBook(Product product)
        {
            return product.Categories.Any(p => p.Name == BooksCategoryName); 
        }
    }
}
