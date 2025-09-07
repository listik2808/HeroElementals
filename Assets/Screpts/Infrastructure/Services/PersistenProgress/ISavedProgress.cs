using Screpts.Data;

namespace Screpts.Infrastructure.Services.PersistenProgress
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
        
    }
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}