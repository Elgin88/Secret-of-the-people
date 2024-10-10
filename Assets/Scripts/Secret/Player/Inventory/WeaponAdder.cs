using Secret.Infrastructure.Factory;
using Secret.StaticData;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class WeaponAdder : MonoBehaviour
    {
        [SerializeField] private WeaponContainer _weaponContainer;
        [SerializeField] private PlayerStaticData _staticData;
        
        private IGameFactory _gameFactory;
        private int _startGunClipsCount => _staticData.StartGunClipsCount;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;

            CreateStartWeapons();
        }
        
        private void AddGun() => _weaponContainer.AddGun(_gameFactory.CreateGun());
        private void AddBulletsInClips() => _weaponContainer.AddBulletsInClips();

        private void CreateStartWeapons()
        {
            AddGun();
            AddClips();
        }

        private void AddClips()
        {
            for (int i = 0; i < _startGunClipsCount; i++)
            {
                _weaponContainer.AddClip(_gameFactory.CreateGunClip());
            }
            
            AddBulletsInClips();
        }
    }
}