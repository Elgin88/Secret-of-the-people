using Scripts.Data;
using Scripts.Infractructure.Services;

namespace Scripts.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerGameProgress PlayerProgress { get; set; }
    }
}