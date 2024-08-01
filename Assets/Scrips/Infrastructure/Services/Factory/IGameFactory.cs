using System.Collections.Generic;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public interface IGameFactory : IService
    {
        public GameObject Player { get; }

        public GameObject HealthBar { get; }

        public GameObject Gun { get; }

        public GameObject GunBullet { get; }

        public GameObject CreateGraphy();

        public GameObject CreatePlayer();

        public GameObject CreateCanvasJoystick();

        public GameObject CreatePlayerHealthBar();

        public List<GameObject> CreateSkeletons();

        public GameObject CreateGun();

        public GameObject CreateGunBullet();
    }
}