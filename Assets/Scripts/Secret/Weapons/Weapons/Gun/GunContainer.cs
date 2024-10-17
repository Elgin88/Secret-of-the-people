using Secret.Weapons.Bullets;
using Secret.Weapons.Clips;
using UnityEngine;

namespace Secret.Weapons.Weapons.Gun
{
    public class GunContainer : MonoBehaviour, IGun, IWeaponContainer
    {
        public IClip CurrentClip { get; set; }

        public IBulletMover BulletMover { get; set; }

        public void SetCurrentClip()
        {
        }
    }
}