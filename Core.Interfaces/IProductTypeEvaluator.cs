using Core.Model;

namespace Core.Interfaces
{
    public interface IProductTypeEvaluator
    {
        bool IsBook(Product product);
    }
}