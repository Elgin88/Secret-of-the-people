using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateGraphy()
        {
            return _assetProvider.Instantiate(AssetPath.Graphy);
        }

        public GameObject CreatePlayer()
        {
            Vector3 position = FindObjectByTag(ObjectsTags.Player);

            return CreateGameObject(AssetPath.Player, position);
        }

        public GameObject CreateCanvas()
        {
            return _assetProvider.Instantiate(AssetPath.Canvas);
        }

        public GameObject CreateSkeleton()
        {
            Vector3 position = FindObjectByTag(ObjectsTags.Enemy);

            return CreateGameObject(AssetPath.Sceleton, position);
        }

        private GameObject CreateGameObject(string path, Vector3 position)
        {
            if (position != null)
            {
                return _assetProvider.Instantiate(path, position, Quaternion.identity);
            }
            else
            {
                return _assetProvider.Instantiate(path);
            }
        }

        private static Vector3 FindObjectByTag(string path)
        {
            return GameObject.FindGameObjectWithTag(path).transform.position;
        }
    }
}