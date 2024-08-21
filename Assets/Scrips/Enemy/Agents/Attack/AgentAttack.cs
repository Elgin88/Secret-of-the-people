using System.Collections;
using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Enemy
{
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private AgentMoveToPlayer _agentMoverToPlayer;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private AnimationSetter _enemyAnimator;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private HitSphere _hitArea;

        private Player.IHealthChanger _healthChanger;
        private IGameFactory _gameFactory;
        private Collider[] _resultOfHit = new Collider[1];
        private float _currentCooldawn;
        private float _attackCooldown;
        private bool _isAtacking = false;
        private int _damage;

        private void Start()
        {
            SetParametrs();
            Disable();
        }

        public void Construct(IGameFactory iGameFactory) => _gameFactory = iGameFactory;

        public void EnableAgent()
        {
            Enable();
            PlayAttackAnimation();
        }

        public void DisableAgent() => enabled = false;

        private void OnAttack()
        {
            if (IsHit(out Collider collider))
            {
                PlayerTakeHit(collider);
            }
        }

        private void OnAttackEnded() => StartCoroutine(AttackAfterCooldown());

        private IEnumerator AttackAfterCooldown()
        {
            while (_currentCooldawn > 0)
            {
                UpdateCooldown();

                yield return null;
            }

            ResetCooldown();

            ResetIsAttacking();

            PlayAttackAnimation();
        }

        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitArea.transform.position, _hitArea.Radius, _resultOfHit, _layerMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void PlayAttackAnimation()
        {
            if (!_isAtacking & IsAlive())
            {
                _enemyAnimator.PlayAttack();
                SetIsAttacking();
            }
        }

        private bool IsAlive() => _healthChanger.CurrentHealth > 0;

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;

        private void PlayerTakeHit(Collider collider)
        {
            collider.GetComponent<Player.IHealthChanger>().RemoveCurrentHealth(_damage);
            collider.GetComponent<Player.HitTaker>().TakeHit();
        }

        private void UpdateCooldown() => _currentCooldawn -= Time.deltaTime;

        private void ResetCooldown() => _currentCooldawn = _attackCooldown;

        private void SetIsAttacking() => _isAtacking = true;

        private void ResetIsAttacking() => _isAtacking = false;

        private void SetParametrs()
        {
            _healthChanger = _gameFactory.Player.GetComponent<Player.IHealthChanger>();
            _attackCooldown = _staticData.AttackCooldawn;
            _damage = _staticData.Damage;
            _currentCooldawn = _attackCooldown;
        }
    }
}