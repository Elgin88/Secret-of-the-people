using System.Collections.Generic;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public interface IGameFactory : IService
    {
        public GameObject Player { get; }

        public GameObject HealthBar { get; }

        public GameObject CreateGraphy();

        public GameObject CreatePlayer();

        public GameObject CreateCanvasJoystick();

        public GameObject CreateHealthBar(IGameFactory iGameFactory);

        public List<GameObject> CreateSkeletons(IGameFactory iGameFactory);
    }
}