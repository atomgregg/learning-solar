using System.Threading.Tasks;
using ATG.Collector.Types.Collect;

namespace ATG.Collector.Types.Interfaces
{
    public interface ISolarSource
    {
        Task<CollectResult> CollectAsync();
    }
}
