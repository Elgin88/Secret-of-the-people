using CodeBase.PlayerComponents;
using UnityEngine;
using Zenject;

namespace CodeBase.Zenject
{
    internal class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.QueueForInject(_player);
        }
    }
}