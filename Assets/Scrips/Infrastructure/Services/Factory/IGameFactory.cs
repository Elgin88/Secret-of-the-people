using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public interface IGameFactory : IService
    {
        public GameObject Player { get; }

        public GameObject HealthBar { get; }

        public Action PlayerLoaded { get; set; }

        public GameObject CreateGraphy();

        public GameObject CreatePlayer();

        public GameObject CreateCanvasJoystick();

        public List<GameObject> CreateSkeletons(IGameFactory _iGameFactory);

        public GameObject CreateHealthBar(IGameFactory _iGameFactory);
    }
}