using Secret.Infrastructure.Factory;
using Secret.Player.Inventory;
using Secret.Weapons.GunClip;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunContainer : MonoBehaviour, IWeapon, IGun
    {
        private IGameFactory _gameFactory;
        private WeaponContainer _weaponContainer;

        public GameObject GunClip { get; private set; }

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _weaponContainer = _gameFactory.PlayerWeaponContainer;
        }

        public void AddClipFromInventory()
        {
            GunClip = _weaponContainer.GetGunClipFromInventory();
        }
    }
}