﻿using System;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public interface IGameFactory : IService
    {
        public GameObject Player { get; }

        public Action PlayerLoaded { get; set; }

        public GameObject CreateGraphy();

        public GameObject CreatePlayer();

        public GameObject CreateCanvas();

        public GameObject CreateSkeleton();
    }
}