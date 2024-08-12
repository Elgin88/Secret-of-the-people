using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunShooter : MonoBehaviour
    {
        [SerializeField] private WeaponStaticData _staticData;
        [SerializeField] private GunClipSetter _gunClipSetter;

        private float _cooldawn;
        private float _delay;

        private void Awake()
        {
            SetDelay();
        }

        private void FixedUpdate()
        {
            UpdateCooldawn();
        }

        public void Shoot()
        {
            if (IsCooldawnEnd())
            {
                Debug.Log("Shoot");
                IBullet bullet = GetBullet();
                bullet.SetStartPosition();
                bullet.Fly();
                RemoveBulletFromClip();

                ResetColldawn();
            }
        }

        private void RemoveBulletFromClip() => _gunClipSetter.ICurrentClip.RemoveTopBullet();

        private IBullet GetBullet() => _gunClipSetter.ICurrentClip.GetTopBullet();

        private void UpdateCooldawn() => _cooldawn -= Time.deltaTime;

        private void SetDelay() => _delay = _staticData.DelayBetweenShoots;

        private void ResetColldawn() => _cooldawn = _delay;

        private bool IsCooldawnEnd() => _cooldawn <= 0;
    }
}