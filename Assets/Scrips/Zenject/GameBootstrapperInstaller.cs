using Scripts.CodeBase.Infractructure;
using UnityEngine;
using Zenject;

namespace CodeBase.Zenject
{
    public class GameBootstrapperInstaller : MonoInstaller
    {
        [SerializeField] private GameBootstrapper _gameBootstrapper;

        public override void InstallBindings()
        {
            Container.Bind<GameBootstrapper>().FromInstance(_gameBootstrapper).AsSingle();
            Container.QueueForInject(_gameBootstrapper);
        }
    }
}