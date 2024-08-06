using Scripts.CodeBase.Logic;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerInventory : MonoBehaviour
    {
        private List<GameObject> _iWeapons = new List<GameObject>();
        private IGameFactory _iGameFactory;

        private GameObject _gun;

        public void Construct(IGameFactory iGameFactory)
        {
            SetIGameFactory(iGameFactory);
            CreateGun();
            AddGunInInventory();
        }

        public GameObject GetStartWeaponGun() => _iWeapons[0];

        private void SetIGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private void AddGunInInventory() => _iWeapons.Add(_gun);

        private void CreateGun() => _gun = _iGameFactory.CreateGun();
    }
}