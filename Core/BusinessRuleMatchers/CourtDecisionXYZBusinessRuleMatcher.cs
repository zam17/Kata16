using System.Collections.Generic;
using System.Linq;
using Core.Impl.ProcessingCommands;
using Core.Interfaces;
using Core.Interfaces.Data;
using Core.Model;

namespace Core.Impl.BusinessRuleMatchers
{
    public class CourtDecisionNumber3417BusinessRuleMatcher:IBusinessRuleMatcher
    {
        private string ProductNameToSearchFor = "Learning to ski";

        private Product GetFreeProduct()
        {
            // TODO: get from relevant service, of course.
            return new Product(new [] {new ProductCategory("Free items"), new ProductCategory("Video") }, ProductFlags.None, "First Aid");
        }

        public IPurchaseProcessingCommand[] MatchPurchaseCommands(PurchaseBusinessRulesProcessingContext context)
        {
            IEnumerable<Product> products = context.Purchase.Products.Where(p => p.ProductName.DefaultEquals(ProductNameToSearchFor));
            if (!products.Any())
            {
                return new IPurchaseProcessingCommand[0];
            }

            // Only one per purchase.
            return new IPurchaseProcessingCommand[] {new AddFreeProductToPurchaseCommand(context.Purchase, GetFreeProduct()), };
        }
    }
}
