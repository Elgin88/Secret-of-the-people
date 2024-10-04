using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunContainer : MonoBehaviour
    {
        public GameObject CurrentClip { get; private set; }

        public void SetCurrentClip()
        {
        }

        public void RemoveCurrentClip()
        {
            CurrentClip = null;
        }
    }
}