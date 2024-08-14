using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using Scripts.PlayerComponents.InventoryComponents;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunShooter : MonoBehaviour
    {
        [SerializeField] private WeaponStaticData _staticData;

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
                Debug.Log(_chooserWeapon);

                ResetColldawn();
            }
        }

        private void UpdateCooldawn() => _cooldawn -= Time.deltaTime;

        private void SetDelay() => _delay = _staticData.DelayBetweenShoots;

        private void ResetColldawn() => _cooldawn = _delay;

        private bool IsCooldawnEnd() => _cooldawn <= 0;
    }
}