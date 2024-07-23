﻿using System.Collections.Generic;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public interface IGameFactory : IService
    {
        public GameObject Player { get; }

        public GameObject HealthBar { get; }

        public List<GameObject> Skeletons { get; }

        public GameObject CreateGraphy();

        public GameObject CreatePlayer();

        public GameObject CreateCanvasJoystick();

        public List<GameObject> CreateSkeletons(IGameFactory iGameFactory);

        public GameObject CreateHealthBar(IGameFactory iGameFactory);
    }
}