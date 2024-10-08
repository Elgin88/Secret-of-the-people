using Secret.Infrastructure.Factory;
using Secret.Player.Inventory;
using Secret.Weapons.GunClip;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunContainer : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private WeaponContainer _weaponContainer;

        public GameObject CurrentClip { get; private set; }

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _weaponContainer = _gameFactory.Player.GetComponent<WeaponContainer>();
        }

        public void SetCurrentClip(GameObject currentClip)
        {
            CurrentClip = currentClip;
        }

        public void AddClipFromInventory()
        {
            CurrentClip = _weaponContainer.GetGunClip();
        }

        public GunClipContainer GetGunClipContainer()
        {
            return CurrentClip.GetComponent<GunClipContainer>();
        }
    }
}