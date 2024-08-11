using Scripts.PlayerComponents;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunSetterCurrentClip : MonoBehaviour, ISetterCurrentClip
    {
        [SerializeField] private Gun _gun;

        private PlayerInventory _playerInventory;

        private GameObject _currentClip;

        public GameObject CurrentClip => _currentClip;

        private void Start()
        {
            _playerInventory = _gun.IGameFactory.Player.GetComponent<PlayerInventory>();
        }

        public void AddClipInGun()
        {
            _currentClip = _playerInventory.GetGunClip();
        }
    }
}