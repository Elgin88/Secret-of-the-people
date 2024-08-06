using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunClip : MonoBehaviour, IClip
    {
        [SerializeField] private WeaponStaticData _staticData;

        private int _countBulletsInClip;

        public int CountBulletsInClip => _countBulletsInClip;

        private void Start()
        {
            SetCountBulletsInClip();
        }

        public void Reload()
        {
        }

        public void RemoveBullet()
        {
        }

        private void SetCountBulletsInClip() => _countBulletsInClip = _staticData.CountBulletsInClip;
    }
}