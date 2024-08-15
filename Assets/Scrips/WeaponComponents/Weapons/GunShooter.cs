using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents.InventoryComponents;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.WeaponsComponents
{
    [RequireComponent(typeof(GunClip))]
    [RequireComponent(typeof(GunReloader))]

    public class GunShooter : MonoBehaviour
    {
        [SerializeField] private WeaponStaticData _staticData;
        [SerializeField] private GunClipSetter _clipSetter;
        [SerializeField] private GunReloader _reloader;

        private ChooserWeapon _chooserWeapon;

        private float _cooldawn;
        private float _delay;

        public void Construct(IGameFactory gameFactory)
        {
            _chooserWeapon = gameFactory.Player.GetComponent<ChooserWeapon>();
        }

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
                _clipSetter.CurrentClip.GetTopBullet().Fly();
                _clipSetter.CurrentClip.RemoveTopBullet();

                ResetColldawn();
            }
        }

        private void UpdateCooldawn() => _cooldawn -= Time.deltaTime;

        private void SetDelay() => _delay = _staticData.DelayBetweenShoots;

        private void ResetColldawn() => _cooldawn = _delay;

        private bool IsCooldawnEnd() => _cooldawn <= 0;
    }
}