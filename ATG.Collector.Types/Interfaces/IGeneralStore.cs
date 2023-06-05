using System.Threading.Tasks;
using ATG.Collector.Types.Collect;

namespace ATG.Collector.Types.Interfaces
{
    public interface IGeneralStore
    {
        Task OpenConnectionAsync();
        Task CloseConnectionAsync();
        Task<StoreResult> StoreAsync(CollectResult data);
    }
}
