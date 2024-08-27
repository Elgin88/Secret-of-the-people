using Scripts.StaticData;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Inventory))]
    [RequireComponent(typeof(ObjectsCreator))]
    public class StartWeaponSetter : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private ObjectsCreator _objectCreator;
        [SerializeField] private Inventory _inventory;

        private int _startGunClipCount;

        public void Construct()
        {
            SetStartClipCount();
            AddGunInInventory();
            AddGunClipsInInventory();
            AddClipInGun();
        }

        private void SetStartClipCount() => _startGunClipCount = _staticData.StartGunClipsCount;

        private void AddClipInGun() => _inventory.GetGun().SetCurrentClip(_inventory.GetGunClip());

        private void AddGunInInventory() => _inventory.AddWeapon(_objectCreator.GetGun());

        private void AddGunClipsInInventory()
        {
            for (var i = 0; i < _startGunClipCount; i++)
            {
                _inventory.AddClip(_objectCreator.GetGunClip());
            }
        }
    }
}