using System;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunAttacker : MonoBehaviour, IWeapon
    {
        [SerializeField] private GunContainer _gunContainer;
        [SerializeField] private GunReloader _gunReloader;

        private Coroutine _checkCooldown;
        private bool _isCooldownEnd = true;

        public void Attack(Collider target, Transform shootPoint)
        {
            TryReload();

            if (_gunContainer.Clip == null)
            {
                return;
            }

            if (_gunContainer.Clip.BulletCount == 0)
            {
                return;
            }

            if (_isCooldownEnd)
            {
                IBullet bullet = _gunContainer.Clip.GetBullet();

                SetStartBulletPosition(bullet, shootPoint);
                SetStartBulletRotation(bullet, target);
                StartFlyBullet(bullet, target, shootPoint);
                StartUpdateCooldown();
                SetIsCooldownEnd(false);
            }
        }

        private void SetStartBulletPosition(IBullet bullet, Transform shootPoint) => bullet.SetPosition(shootPoint.position);

        private void SetStartBulletRotation(IBullet bullet, Collider target) => bullet.SetRotation(Quaternion.LookRotation(target.transform.position));

        private void StartFlyBullet(IBullet bullet, Collider target, Transform shootPoint) => bullet.Fly(target);

        private void SetIsCooldownEnd(bool status) => _isCooldownEnd = status;

        private void TryReload()
        {
            if (_gunContainer.Clip == null)
            {
                if (_gunContainer.Clip.BulletCount == 0)
                {
                    _gunReloader.Reload();
                }
            }
        }

        private void StartUpdateCooldown()
        {
            throw new NotImplementedException();
        }
    }
}