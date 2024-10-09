using Secret.Player.Inventory;
using Secret.Weapons.GunClip;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunAttacker : MonoBehaviour, IWeaponAttacker, IWeapon, IGun
    {
        [SerializeField] private GunContainer _gunContainer;
        
        public void Attack()
        {
        }
    }
}