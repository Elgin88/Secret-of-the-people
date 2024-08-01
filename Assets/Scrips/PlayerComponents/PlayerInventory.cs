using Scripts.CodeBase.Logic;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerInventory : MonoBehaviour
    {
        private List<GameObject> _iWeapons = new List<GameObject>();
        private IGameFactory _iGameFactory;

        public void Construct(IGameFactory iGameFactory)
        {
            SetIGameFactory(iGameFactory);
            AddStartWeapon();
        }

        public GameObject GetStartWeapon() => _iWeapons[0];

        private void SetIGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private void AddStartWeapon() => _iWeapons.Add(CreateGun());

        private GameObject CreateGun() => Instantiate(_iGameFactory.Gun);
    }
}