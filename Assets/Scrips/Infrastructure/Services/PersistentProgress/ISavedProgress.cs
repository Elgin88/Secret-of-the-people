using Scripts.Data;

namespace Scripts.Services.PersistentProgress
{
    public interface ISavedProgressReader
    {
        public void LoadProgress(PlayerGameProgress playerProgress);
    }

    public interface ISavedProgress : ISavedProgressReader
    {
        public void UpdateProgress(PlayerGameProgress playerProgress);
    }
}