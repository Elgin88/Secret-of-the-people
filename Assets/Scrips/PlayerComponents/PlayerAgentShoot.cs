using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerAgentShoot : MonoBehaviour
    {
        [SerializeField] private PlayerChooserWeapon _playerChooserWeapon;
        [SerializeField] private Transform _shootPoint;

        private float _cooldawn;
        private float _currentCooldawn;
        private bool _isAttack = false;

        public Transform ShootPoint => _shootPoint;

        private void FixedUpdate()
        {
            Debug.Log("Сделать GunStaticData");

            SetCooldawn();
            UpdateColdawn();
            ResetCooldawn();

            if (!_isAttack)
            {
                SetIsAttack();
                Shoot();
            }
        }

        private void SetCooldawn() => _cooldawn = _playerChooserWeapon.CurrentWeapon.GetComponent<IWeapon>().DelayBetweenShoots;

        private void ResetCooldawn()
        {
            if (_currentCooldawn < 0)
            {
                ResetIsAttack();
                _currentCooldawn = _cooldawn;
            }
        }

        private void UpdateColdawn() => _currentCooldawn -= Time.deltaTime;

        private void SetIsAttack() => _isAttack = true;
        
        private void ResetIsAttack() => _isAttack = false;

        private void Shoot() => _playerChooserWeapon.ICurrentWeapon.Shoot();
    }
}