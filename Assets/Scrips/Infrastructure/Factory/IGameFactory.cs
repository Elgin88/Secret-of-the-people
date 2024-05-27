using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public interface IGameFactory : IService
    {
        public GameObject CreateGraphy();
        public GameObject CreatePlayer();
    }
}