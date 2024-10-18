using Secret.Infrastructure.Factory;
using Secret.Weapons.Bullets;
using Secret.Weapons.Clips;
using UnityEngine;

namespace Secret.Weapons.Weapons.Gun
{
    public class GunContainer : MonoBehaviour, IGun, IWeaponContainer
    {
        private IGameFactory _gameFactory;
        public GameObject _currentClip;

        public IClip ICurrentClip { get; set; }

        public IBulletMover BulletMover { get; set; }

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void SetCurrentClip()
        {
            _currentClip = _gameFactory.PlayerContainer.GetClip();
        }
    }
}