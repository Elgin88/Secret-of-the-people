using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunReloader : MonoBehaviour
    {
        [SerializeField] private GunContainer _gunContainer;

        public void Reload()
        {
            _gunContainer.AddClipFromInventory();
        }
    }
}