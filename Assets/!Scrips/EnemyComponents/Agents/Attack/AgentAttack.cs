using Scripts.PlayerComponents;
using Scripts.Static;
using System.Collections;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private AgentMoveToPlayer _agentMoverToPlayer;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private HitArea _hitArea;

        private const float _startCooldown = 0.5f;
        private const float _damage = 10f;
        private float _currentColldown;
        private bool _isAtacking = false;
        private int _layerMask;
        private Transform _hitZoneTransform;
        private Collider[] _resultOfHit = new Collider[1];

        private void Awake()
        {
            SetPlayerLayerMask();
            SetHitZoneTransform();
            ResetCooldown();

            Disable();
        }

        public void EnableAgent()
        {
            Enable();
            PlayAttackAnimation();
        }

        public void DisableAgent() => Disable();

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
            while (_currentColldown > 0)
            {
                UpdateCooldown();
                yield return null;
            }

            ResetCooldown();
            SetIsAttackingFalse();
            PlayAttackAnimation();
        }

        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitZoneTransform.position, _hitArea.RadiusOfHitArea, _resultOfHit, _layerMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void PlayAttackAnimation()
        {
            if (!_isAtacking)
            {
                _enemyAnimator.PlayAttack();
                SetIsAttackingTrue();
            }
        }

        private static void PlayerTakeHit(Collider collider) => collider.GetComponent<PlayerHealth>().RemoveHealth(_damage);

        private void UpdateCooldown() => _currentColldown -= Time.deltaTime;

        private void SetIsAttackingTrue() => _isAtacking = true;

        private void SetIsAttackingFalse() => _isAtacking = false;

        private void SetPlayerLayerMask() => _layerMask = 1 << StaticLayersNames.Player;

        private void SetHitZoneTransform() => _hitZoneTransform = _hitArea.transform;

        private void ResetCooldown() => _currentColldown = _startCooldown;

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;
    }
}