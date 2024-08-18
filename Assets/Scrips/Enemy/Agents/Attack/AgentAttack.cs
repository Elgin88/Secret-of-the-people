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
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private HitSphere _hitArea;

        private float _currentAttackColldown;
        private float _attackCooldown;
        private bool _isAtacking = false;
        private int _damage;
        private Collider[] _resultOfHit = new Collider[1];
        private IGameFactory _iGameFactory;
        private Player.HealthSetter _playerHealth;

        private void Start()
        {
            SetParametrs();
            Disable();
        }

        public void Construct(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

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
            while (_currentAttackColldown > 0)
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
            int count = Physics.OverlapSphereNonAlloc(_hitArea.transform.position, _hitArea.RadiusOfHitSphere, _resultOfHit, _layerMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void PlayAttackAnimation()
        {
            if (!_isAtacking & !_playerHealth.IsDead)
            {
                _enemyAnimator.PlayAttack();
                SetIsAttacking();
            }
        }

        private void SetParametrs()
        {
            _playerHealth = _iGameFactory.Player.GetComponent<Player.HealthSetter>();
            _attackCooldown = _staticData.AttackCooldawn;
            _damage = _staticData.Damage;
            _currentAttackColldown = _attackCooldown;
        }

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;

        private void PlayerTakeHit(Collider collider) => collider.GetComponent<HealthSetter>().TakeDamage(_damage);

        private void UpdateCooldown() => _currentAttackColldown -= Time.deltaTime;

        private void ResetCooldown() => _currentAttackColldown = _attackCooldown;

        private void SetIsAttacking() => _isAtacking = true;

        private void ResetIsAttacking() => _isAtacking = false;
    }
}