using UnityEngine;

namespace Secret.Player.Inventory
{
    public class StartWeaponAdder : MonoBehaviour
    {
        private Container _container;

        private void Awake()
        {
            _container = GetComponent<Container>();
        }

        public void Construct()
        {
            _container.AddGun();

            _container.AddGunClips();
            _container.AddGunClips();
            _container.AddGunClips();
        }
    }
}