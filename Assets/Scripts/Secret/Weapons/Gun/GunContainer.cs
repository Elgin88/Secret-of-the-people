using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunContainer : MonoBehaviour
    {
        public GameObject _currentClip;

        public void SetCurrentClip(GameObject currentClip)
        {
            _currentClip = currentClip;
        }
    }
}