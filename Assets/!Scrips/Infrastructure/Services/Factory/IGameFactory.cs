using System;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public interface IGameFactory : IService
    {
        public GameObject Player { get; }

        public Action PlayerLoaded { get; set; }

        public GameObject CreateGraphy();

        public GameObject CreatePlayer();

        public GameObject CreateCanvas();

        public GameObject CreateSkeleton();

        public GameObject CreateHealthBar();
    }
}