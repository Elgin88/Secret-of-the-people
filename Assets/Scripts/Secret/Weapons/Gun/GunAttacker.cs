using System;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunAttacker : MonoBehaviour, IWeapon
    {
        [SerializeField] private GunContainer _gunContainer;
        [SerializeField] private GunReloader _gunReloader;

        private bool _isCooldownEnd = true;

        public void Attack(Collider target, Transform shootPoint)
        {
            TryReload();

            if (NoClip())
            {
                return;
            }

            if (NoBulletInClip())
            {
                return;
            }

            if (_isCooldownEnd)
            {
                StartFlyBullet(GetBullet(), target, shootPoint);
                StartUpdateCooldown();
            }
        }

        private bool NoBulletInClip()
        {
            throw new NotImplementedException();
        }

        private IBullet GetBullet()
        {
            throw new NotImplementedException();
        }

        private bool NoClip() => _gunContainer.CurrentClip == null;

        private void Reload() => _gunReloader.Reload();

        private void StartFlyBullet(IBullet bullet, Collider target, Transform shootPoint)
        {
            bullet.SetPosition(shootPoint.position);
            bullet.SetRotation(Quaternion.LookRotation(target.transform.position));

            bullet.Fly(target);
        }

        private void TryReload()
        {
            if (_gunContainer.CurrentClip == null)
            {
                Reload();
            }
        }

        private void StartUpdateCooldown()
        {
            _isCooldownEnd = false;
        }
    }
}