using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunContainer : MonoBehaviour
    {
        public IClip Clip { get; private set; }

        public void SetClip(IClip clip)
        {
            Clip = clip;
        }

        public void RemoveClip()
        {
            Clip = null;
        }
    }
}