using Screpts.Data;

namespace Screpts.Infrastructure.Services.PersistenProgress
{
    public interface IPersistenProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}