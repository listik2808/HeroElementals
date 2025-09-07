using Screpts.Data;

namespace Screpts.Infrastructure.Services.PersistenProgress
{
    public class PersistenProgressService : IPersistenProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}