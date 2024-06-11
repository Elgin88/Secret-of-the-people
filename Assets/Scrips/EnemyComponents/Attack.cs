using Scripts.CodeBase.Infractructure;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(EnemyAnimator))]

    public class Attack : MonoBehaviour
    {
        private const float _attackCooldawn = 2;
        private float _currentAttackCooldawn;
        private bool _isAttacking = false;
        private EnemyAnimator _enemyAnimator;
        private IGameFactory _gameFactory;
        private Transform _playerTransform;

        private void Awake()
        {
            GetComponents();

            _gameFactory.PlayerLoaded += OnPlayerLoaded;
        }

        private void Update()
        {
            UpdateCooldawn();

            if (CanAttack())
            {
                StartAttack();
            }
        }

        private void GetComponents()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _gameFactory = AllServices.Container.Get<IGameFactory>();
        }

        private void OnPlayerLoaded()
        {
            _playerTransform = _gameFactory.Player.transform;
            _gameFactory.PlayerLoaded -= OnPlayerLoaded;
        }

        private void ReduceCooldawn()
        {
            _currentAttackCooldawn -= -Time.deltaTime;
        }

        private void OnAttack()
        {

        }

        private void OnAttackEnded()
        {
            _currentAttackCooldawn = _attackCooldawn;
            _isAttacking = false;
        }

        private void UpdateCooldawn()
        {
            if (!CooldawnIsUp())
            {
                ReduceCooldawn();
            }
        }

        private bool CanAttack()
        {
            return CooldawnIsUp() & !_isAttacking;
        }

        private bool CooldawnIsUp()
        {
            return _currentAttackCooldawn <= 0;
        }

        private void StartAttack()
        {
            transform.LookAt(_playerTransform);
            _enemyAnimator.PlayAttack();
            _isAttacking = true;
        }
    }
}