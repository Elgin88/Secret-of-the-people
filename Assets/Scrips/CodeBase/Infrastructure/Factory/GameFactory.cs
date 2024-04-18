using Scripts.CodeBase.Infractructure.AssetManagement;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _iAssetProvider;

        public GameFactory(IAssetProvider iAssetProvider)
        {
            _iAssetProvider = iAssetProvider;
        }

        public GameObject CreateHero(GameObject initialPoint) =>
            _iAssetProvider.Instantiate(AssetsPath.PlayerPrefabLocation, initialPoint.transform.position);

        public void CreateHud() =>
            _iAssetProvider.Instantiate(AssetsPath.CurtainPrefabLocation);
    }
} 