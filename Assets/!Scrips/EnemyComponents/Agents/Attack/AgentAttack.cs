using System.Collections;
using Scripts.PlayerComponents;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private AgentMoveToPlayer _agentMoverToPlayer;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private HitSphere _hitArea;

        private float _attackCooldown;
        private float _damage;
        private float _currentAttackColldown;
        private bool _isAtacking = false;
        private Collider[] _resultOfHit = new Collider[1];

        private void Awake()
        {
            _attackCooldown = _staticData.AttackCooldawn;
            _damage = _staticData.Damage;
            _currentAttackColldown = _attackCooldown;

            Disable();
        }

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
            PlayAttackAnimation();
            ResetIsAttacking();
        }

        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitArea.transform.position, _hitArea.RadiusOfHitSphere, _resultOfHit, _layerMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void PlayAttackAnimation()
        {
            if (!_isAtacking)
            {
                _enemyAnimator.PlayAttack();
                SetIsAttacking();
            }
        }

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;

        private void PlayerTakeHit(Collider collider) => collider.GetComponent<PlayerHealth>().RemoveHealth(_damage);

        private void UpdateCooldown() => _currentAttackColldown -= Time.deltaTime;

        private void ResetCooldown() => _currentAttackColldown = _attackCooldown;

        private void SetIsAttacking() => _isAtacking = true;

        private void ResetIsAttacking() => _isAtacking = false;
    }
}