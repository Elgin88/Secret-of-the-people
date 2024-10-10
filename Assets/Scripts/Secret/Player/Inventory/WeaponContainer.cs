﻿using System.Collections.Generic;
using Secret.Weapons;
using Secret.Weapons.Clips.GunClip;
using Secret.Weapons.Weapons;
using Secret.Weapons.Weapons.Gun;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class WeaponContainer : MonoBehaviour
    {
        private List<GameObject> _weapons = new List<GameObject>();
        private List<GameObject> _gunClips = new List<GameObject>();

        public void AddClip(GameObject clip)
        {
            _gunClips.Add(clip);
        }

        public void AddGun(GameObject gun)
        {
            _weapons.Add(gun);
        }

        public void AddBulletsInClips()
        {
            foreach (var gunClip in _gunClips)
            {
                gunClip.GetComponent<GunClipContainer>().AddBullets();
            }
        }

        public GameObject GetGunClipFromInventory()
        {
            GameObject gunClip = _gunClips[0];

            _gunClips.Remove(gunClip);

            return gunClip;
        }

        public IWeaponAttacker GetGunIWeaponAttacker()
        {
            foreach (var weapon in _weapons)
            {
                if (weapon.GetComponent<IGun>() != null)
                {
                    return weapon.GetComponent<IWeaponAttacker>();
                }
            }

            return null;
        }
    }
}