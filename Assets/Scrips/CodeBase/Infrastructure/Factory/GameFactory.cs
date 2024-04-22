using Scripts.CodeBase.Infractructure.AssetManagement;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _iAssetProvider;

        public GameFactory(IAssets iAssetProvider)
        {
            _iAssetProvider = iAssetProvider;
        }

        public GameObject CreatePlayer(GameObject initialPoint) =>
            _iAssetProvider.Instantiate(AssetsPath.PlayerPrefabLocation, initialPoint.transform.position);
         
        public void CreateCurtain() =>
            _iAssetProvider.Instantiate(AssetsPath.CurtainPrefabLocation);
    }
} 