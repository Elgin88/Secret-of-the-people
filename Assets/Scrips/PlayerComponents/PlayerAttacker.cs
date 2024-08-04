using System.Collections;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private PlayerChooserWeapon _playerChooserWeapon;
        [SerializeField] private Transform _shootPoint;

        private const float _delay = 2f;
        private Coroutine _attacking;

        public Transform ShootPoint => _shootPoint;

        private void FixedUpdate()
        {
            Attack();
            Debug.Log(_attacking);
            Debug.Log(gameObject.name);
        }


        private IEnumerator Attacking()
        {
            if (_attacking == null)
            {
                Shoot();
                yield return GetDelay();
            }
        }

        private static WaitForSeconds GetDelay() => new WaitForSeconds(_delay);

        private void Attack() => _attacking = StartCoroutine(Attacking());
        private void Shoot() => _playerChooserWeapon.ICurrentWeapon.Shoot();
    }
}