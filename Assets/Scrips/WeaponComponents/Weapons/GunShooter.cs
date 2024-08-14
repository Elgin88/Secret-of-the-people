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
                ResetColldawn();
            }
        }

        private void UpdateCooldawn() => _cooldawn -= Time.deltaTime;

        private void SetDelay() => _delay = _staticData.DelayBetweenShoots;

        private void ResetColldawn() => _cooldawn = _delay;

        private bool IsCooldawnEnd() => _cooldawn <= 0;
    }
}