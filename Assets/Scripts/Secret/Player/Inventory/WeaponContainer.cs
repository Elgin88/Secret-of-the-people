using System.Collections.Generic;
using Secret.Infrastructure.Factory;
using Secret.Weapons.GunClip;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class WeaponContainer : MonoBehaviour
    {
        private List<GameObject> _weapons = new List<GameObject>();
        private List<GameObject> _gunClips = new List<GameObject>();
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void AddClip()
        {
            _gunClips.Add(_gameFactory.CreateGunClip());
        }

        public void AddGun()
        {
            _weapons.Add(_gameFactory.CreateGun());
        }

        public void AddBulletsInClip()
        {
            foreach (GameObject gunClip in _gunClips)
            {
                gunClip.GetComponent<GunClipContainer>().CreateBullets();
            }
        }
    }
}