using System.Threading.Tasks;

namespace ATG.Collector.Types
{
    public interface ISolarSource
    {
        Task<CollectResult> CollectAsync();
    }
}
