using Secret.Infrastructure.Factory;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunContainer : MonoBehaviour, IWeapon, IGun, IWeaponContainer
    {
        private IGameFactory _gameFactory;

        public GameObject CurrentGunClip { get; private set; }

        public IBulletMover IBulletMover => CurrentGunClip.GetComponent<IBulletMover>();

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void AddClipFromInventory()
        {
            CurrentGunClip = _gameFactory.PlayerWeaponContainer.GetGunClipFromInventory();
        }

        public IBulletMover GetTopIBulletMover()
        {
            throw new System.NotImplementedException();
        }
    }
}