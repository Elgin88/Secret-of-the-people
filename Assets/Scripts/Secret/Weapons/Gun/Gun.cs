using System;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class Gun : MonoBehaviour, IWeapon
    {
        private Coroutine _checkCooldown;
        private IClip _currentClip;
        private bool _isCooldownEnd = true;

        public void Attack(Collider target, Transform shootPoint)
        {
            Debug.Log(target);
            Debug.Log(shootPoint);
            Debug.Log(_currentClip);


            if (_isCooldownEnd)
            {
                IBullet bullet = _currentClip.GetTopBullet();

                SetStartBulletPosition(bullet, shootPoint);
                SetStartBulletRotation(bullet, target);
                StartFlyBullet(bullet, target, shootPoint);
                StartUpdateCooldown();
                SetIsCooldownEnd(false);
            }
        }

        public void Reload(IClip clip)
        {
            _currentClip = clip;
        }

        private void SetStartBulletPosition(IBullet bullet, Transform shootPoint) => bullet.SetPosition(shootPoint.position);

        private void SetStartBulletRotation(IBullet bullet, Collider target) => bullet.SetRotation(Quaternion.LookRotation(target.transform.position));

        private void StartFlyBullet(IBullet bullet, Collider target, Transform shootPoint) => bullet.Fly(target);

        private void StartUpdateCooldown()
        {
            throw new NotImplementedException();
        }

        private void SetIsCooldownEnd(bool status) => _isCooldownEnd = status;
    }
}