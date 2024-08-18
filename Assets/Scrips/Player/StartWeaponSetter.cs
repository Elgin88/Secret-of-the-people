using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Player
{
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

        private void AddClipInGun() => _inventory.GetGun().SetcCurrentClip(_inventory.GetGunClip());

        private void AddGunInInventory() => _inventory.AddWeapon(_objectCreator.GetGun());

        private void AddGunClipsInInventory()
        {
            for (int i = 0; i < _startGunClipCount; i++)
            {
                _inventory.AddClip(_objectCreator.GetGunClip());
            }
        }
    }
}