using Scripts.Static;
using System.Collections;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private AgentMoveToPlayer _agentMoverToPlayer;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private HitArea _hitZone;

        private const float _radiusOfSphereHit = 0.3f;
        private const float _cooldown = 3;
        private float _currentColldown;
        private bool _isAtacking = false;
        private int _layerMask;
        private WaitForSeconds _attackCooldownWFS;
        private Transform _hitZoneTransform;
        private Collider[] _resultOfHit = new Collider[1];

        public bool IsAtacking => _isAtacking;

        public void EnableAgent()
        {
            PlayAttackAnimation();
        }

        public void DisableAgent()
        {
            Disable();
        }

        private void Awake()
        {
            SetPlayerLayerMask();
            SetHitZoneTransform();
            SetAttackCooldown();
            ResetColldown();
            Disable();
        }

        private void FixedUpdate()
        {
            Debug.Log(_currentColldown);

            if (!_isAtacking)
            {
                PlayAttackAnimation();
                SetIsAttackingTrue();
                StartCoroutine(ReduceCoolDown());
            }
        }

        private IEnumerator ReduceCoolDown()
        {
            while (_currentColldown > 0)
            {
                _currentColldown -= Time.deltaTime;
            }

            ResetColldown();

            yield return null;
        }

        private void TrySetIsAttackingFalse()
        {
            if (_currentColldown <= 0)
            {
                SetIsAttackingFalse();
                ResetColldown();
            }
        }

        private void OnAttack()
        {
            if (IsHit(out Collider collider))
            {
            }
        }

        private void OnAttackEnded()
        {
        }

        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitZoneTransform.position, _radiusOfSphereHit, _resultOfHit, _layerMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void UpdateCooldown() => _currentColldown -= Time.deltaTime;
        private void PlayAttackAnimation() => _enemyAnimator.PlayAttack();
        private void SetAttackCooldown() => _attackCooldownWFS = new WaitForSeconds(_cooldown);
        private void SetPlayerLayerMask() => _layerMask = 1 << LayerMask.NameToLayer(StaticLayersNames.Player);
        private void SetHitZoneTransform() => _hitZoneTransform = _hitZone.transform;
        private void ResetColldown() => _currentColldown = _cooldown;
        private void SetIsAttackingTrue() => _isAtacking = true;
        private void SetIsAttackingFalse() => _isAtacking = false;
        private void Enable() => enabled = true;
        private void Disable() => enabled = false;
    }
}