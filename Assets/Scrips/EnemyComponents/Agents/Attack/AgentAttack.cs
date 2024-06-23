using Scripts.Static;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private AgentMoveToPlayer _agentMoverToPlayer;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private HitArea _hitZone;

        private const float _radiusOfSphereHit = 0.3f;
        private const float _attackCooldown = 1;
        private float _currentAttackColldown;
        private int _layerMask;
        private WaitForSeconds _attackCooldownWFS;
        private Transform _hitZoneTransform;
        private Collider[] _resultOfHit = new Collider[1];

        public void EnableAgent()
        {
            Enable();
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
            Disable();
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

        private void SetAttackCooldown() => _attackCooldownWFS = new WaitForSeconds(_attackCooldown);
        private void SetPlayerLayerMask() => _layerMask = 1 << LayerMask.NameToLayer(StaticLayersNames.Player);
        private void SetHitZoneTransform() => _hitZoneTransform = _hitZone.transform;
        private void PlayAttackAnimation() => _enemyAnimator.PlayAttack();
        private void Enable() => enabled = true;
        private void Disable() => enabled = true;
    }
}