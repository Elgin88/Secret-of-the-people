using UnityEngine;

namespace Infrastructure.Services.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 position, Quaternion quaternion)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, position, quaternion);
        }
    }
}