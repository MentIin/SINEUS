using CodeBase.Infrastructure.Data.PlayerData;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        public void SaveProgress();
        public PlayerProgress LoadProgress();
    }
}