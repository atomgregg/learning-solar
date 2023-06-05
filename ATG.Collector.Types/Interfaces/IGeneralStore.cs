using System.Threading.Tasks;
using ATG.Collector.Types.Collect;

namespace ATG.Collector.Types.Interfaces
{
    public interface IGeneralStore
    {
        void OpenConnection();
        void CloseConnection();
        StoreResult Store(CollectResult data);
    }
}
