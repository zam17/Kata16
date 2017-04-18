using Core.Model;

namespace Core.Interfaces
{
    public interface IProductBoundPurchaseProcessingCommand:IPurchaseProcessingCommand
    {
        Product Product { get; }
    }
}