using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerAgentAttack : MonoBehaviour
    {
        [SerializeField] private PlayerChooserWeapon _playerChooserWeapon;
        [SerializeField] private Transform _shootPoint;

        private float _cooldawn;
        private float _currentCooldawn;
        private bool _isAttack = false;

        public Transform ShootPoint => _shootPoint;

        private void FixedUpdate()
        {
            SetCooldawn();
            UpdateColdawn();

            if (IsCooldawnOut())
            {
                ResetCooldawn();
                ResetIsAttack();
            }

            if (!_isAttack)
            {
                SetIsAttack();
                Attack();
            }
        }

        private bool IsCooldawnOut() => _currentCooldawn < 0;

        private void SetCooldawn() => _cooldawn = _playerChooserWeapon.CurrentWeapon.GetComponent<IWeapon>().DelayBetweenShoots;

        private void ResetCooldawn() => _currentCooldawn = _cooldawn;

        private void UpdateColdawn() => _currentCooldawn -= Time.deltaTime;

        private void SetIsAttack() => _isAttack = true;
        
        private void ResetIsAttack() => _isAttack = false;

        private void Attack() => _playerChooserWeapon.ICurrentWeapon.Shoot();
    }
}