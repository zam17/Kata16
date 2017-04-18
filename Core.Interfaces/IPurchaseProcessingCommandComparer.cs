
namespace Core.Interfaces
{
    public interface IPurchaseProcessingCommandComparer
    {
        IPurchaseProcessingCommand[] Filter(IPurchaseProcessingCommand[] commands);
    }
}
