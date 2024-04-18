using UnityEngine;

namespace Scripts.CodeBase.Infractructure.AssetManagement
{
    public interface IAssetProvider
    {
        public GameObject Instantiate(string path);
        public GameObject Instantiate(string path, Vector3 position);
    }
}