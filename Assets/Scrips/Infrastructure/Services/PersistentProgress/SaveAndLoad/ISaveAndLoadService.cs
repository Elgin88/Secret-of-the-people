using Scripts.Data;
using Scripts.Infractructure.Services;

namespace Scripts.Services.PersistentProgress.SaveAndLoad
{
    public interface ISaveAndLoadService : IService
    {
        public void SaveProgress();

        PlayerGameProgress LoadProgress();
    }
}