using Core.Interfaces.Data;
using Core.Model;

namespace Core.Interfaces
{
    public interface IPurchaseProcessor
    {
        PurchaseCommandSet ProcessPurchase(Purchase purchase);
    }
}
