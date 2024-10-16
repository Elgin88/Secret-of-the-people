using System.Collections.Generic;
using Secret.Infrastructure.Services;
using Secret.Player.Inventory;
using UnityEngine;

namespace Secret.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject Player { get; }

        public Transform PlayerShootPoint { get; }

        public Container PlayerContainer { get; }

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