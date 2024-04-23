using Scripts.Infractructure.Services;
using UnityEngine;

namespace Scripts.Infractructure.AssetManagement
{
    public interface IAssets : IService
    {
        public GameObject Instantiate(string path);
        public GameObject Instantiate(string path, Vector3 position);
    }
}