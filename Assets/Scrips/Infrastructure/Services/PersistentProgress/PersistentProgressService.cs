using Scripts.Data;

namespace Scripts.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerGameProgress PlayerProgress { get; set; }
    }
}