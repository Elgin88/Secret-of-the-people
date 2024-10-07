using System.Collections.Generic;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class WeaponContainer : MonoBehaviour
    {
        public List<GameObject> _weapons = new List<GameObject>();
        public List<GameObject> _gunClips = new List<GameObject>();

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
            throw new System.NotImplementedException();
        }
    }
}