using UnityEngine;

namespace Scripts.Weapons
{
    public interface ISetterCurrentClip
    {
        public GameObject CurrentClip { get; }

        public void AddClipInGun();
    }
}