using Secret.Player.Inventory;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    [RequireComponent(typeof(GunAttacker))]
    [RequireComponent(typeof(GunContainer))]
    [RequireComponent(typeof(GunReloader))]

    public class GunRequireComponents : MonoBehaviour, IWeapon, IGun
    {
    }
}