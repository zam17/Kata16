using Core.Model;

namespace Core.Interfaces
{
    public interface IProductTypeEvaluator
    {
        bool IsBook(Product product);
        bool IsPhysical(Product product);
        bool IsMembershipActivation(Product product);
        bool IsMembershipUpgrade(Product product);
        bool IsLuxury(Product product);
    }
}