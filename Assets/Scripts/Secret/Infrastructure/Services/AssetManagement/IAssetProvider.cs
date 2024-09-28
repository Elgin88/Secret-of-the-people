using UnityEngine;

namespace Secret.Infrastructure.Services.AssetManagement
{
    public interface IAssetProvider : IService
    {
        public GameObject Instantiate(string path);
        public GameObject Instantiate(string path, Vector3 position, Quaternion quaternion);
    }
}