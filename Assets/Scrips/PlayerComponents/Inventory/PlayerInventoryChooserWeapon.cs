using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(PlayerInventory))]

    public class PlayerInventoryChooserWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;

        public IWeapon CurrentWeapon;

        public void Construct()
        {
            CurrentWeapon = _playerInventory.GetGun();

            Debug.Log(CurrentWeapon);
        }
    }
}