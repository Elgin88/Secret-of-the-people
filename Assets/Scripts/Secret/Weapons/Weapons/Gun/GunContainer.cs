using Secret.Infrastructure.Factory;
using Secret.Weapons.Bullets;
using Secret.Weapons.Clips;
using UnityEngine;

namespace Secret.Weapons.Weapons.Gun
{
    public class GunContainer : MonoBehaviour, IWeapon, IGun, IWeaponContainer
    {
        private IGameFactory _gameFactory;

        public IClip ICurrentClip { get; set; }

        public IBulletMover IBulletMover { get; set; }

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void AddClipFromInventory()
        {
        }
    }
}