using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Player.Inventory
{
    public class WeaponAdder : MonoBehaviour
    {
        [SerializeField] private WeaponContainer _weaponContainer;
        [SerializeField] private PlayerStaticData _staticData;

        private int _clipCount => _staticData.StartGunClipsCount;

        public void Construct()
        {
            _weaponContainer.AddGun();
            _weaponContainer.AddGunClip(_clipCount);
        }
    }
}