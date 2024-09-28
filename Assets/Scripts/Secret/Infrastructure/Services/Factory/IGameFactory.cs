using System.Collections.Generic;
using UnityEngine;

namespace Secret.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject Player { get; }

        public GameObject HealthBar { get; }

        public GameObject CreateGraphy();

        public GameObject CreatePlayer();

        public GameObject CreateCanvasJoystick();

        public GameObject CreatePlayerHealthBar();

        public List<GameObject> CreateSkeletons();

        public GameObject CreateGun();

        public GameObject CreateGunBullet();

        public GameObject CreateGunClip();
    }
}