using CodeBase.Infrastructure.Data.PlayerData;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
    public class PersistentProgressService : IService
    {
        public PlayerProgress Progress { get; set; }

        public PersistentProgressService()
        {
            Progress = new PlayerProgress();
        }
    }
}