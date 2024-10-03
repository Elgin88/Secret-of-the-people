using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunContainer : MonoBehaviour
    {
        public IClip CurrentClip { get; private set; }

        public void SetCurrentClip(IClip clip)
        {
            CurrentClip = clip;
        }

        public void RemoveCurrentClip()
        {
            CurrentClip = null;
        }
    }
}