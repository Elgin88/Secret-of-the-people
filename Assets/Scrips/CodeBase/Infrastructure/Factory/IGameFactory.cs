using UnityEngine;

namespace Scripts.CodeBase.Infractructure.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject CreatePlayer(GameObject gameObject);

        public void CreateCurtain();
    }
}