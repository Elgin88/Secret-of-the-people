using Secret.Player.Inventory;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunReloader : MonoBehaviour, IWeapon, IGun
    {
        [SerializeField] private GunContainer _gunContainer;

        public void Reload()
        {
            _gunContainer.AddClipFromInventory();
        }
    }
}