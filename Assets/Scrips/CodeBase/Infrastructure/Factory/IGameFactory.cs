using UnityEngine;

namespace Scripts.CodeBase.Infractructure.Factory
{
    public interface IGameFactory
    {
        public GameObject CreateHero(GameObject gameObject);

        public void CreateHud();
    }
}