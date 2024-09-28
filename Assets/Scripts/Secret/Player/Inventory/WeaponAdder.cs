using Secret.Player.StaticData;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class WeaponAdder : MonoBehaviour
    {
        [SerializeField] private WeaponContainer _weaponContainer;
        [SerializeField] private PlayerStaticData _staticData;

        private int _clipCount => _staticData.StartGunClipsCount;

        public void Construct()
        {
            _weaponContainer.AddGun();
            _weaponContainer.AddFullGunClip(_clipCount);
        }
    }
}