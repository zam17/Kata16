using System.Linq;
using Core.Interfaces;
using Core.Model;

namespace Core.Impl
{
    public class ProductTypeEvaluator: IProductTypeEvaluator
    {
        // Isolating this information in evaluator for now. In a real application where context is more clear we would find a better place for it :)
        private const string BooksCategoryName = "Books";
        private const string LuxuryCategoryName = "Luxury";
        private const string MembershipUpgradeProductName = "MembershipUpgrade";
        private const string MembershipActivationProductName = "MembershipActivation";

        public bool IsBook(Product product)
        {
            return product.Categories.Any(p => p.Name.DefaultEquals(BooksCategoryName));
        }

        public bool IsMembershipActivation(Product product)
        {
            return product.ProductName.DefaultEquals(MembershipActivationProductName);
        }

        public bool IsMembershipUpgrade(Product product)
        {
            return product.ProductName.DefaultEquals(MembershipUpgradeProductName);
        }

        public bool IsLuxury(Product product)
        {
            return product.Categories.Any(p => p.Name.DefaultEquals(LuxuryCategoryName));
        }

        public bool IsPhysical(Product product)
        {
            return (product.ProductFlags & ProductFlags.Physical) == ProductFlags.Physical;
        }
    }
}
