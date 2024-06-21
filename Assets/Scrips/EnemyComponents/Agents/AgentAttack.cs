using Scripts.Logic;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private AgentMoveToPlayer _agentMoverToPlayer;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private HitZone _hitZone;

        private const float _radiusOfSphereHit = 0.3f;
        private Collider[] _resultOfHit = new Collider[1];
        private Transform _hitZoneTransform;
        private int _layerMask;

        public void EnableAgent()
        {
            Enable();
            PlayAnimatironAttack();
        }

        public void DisableAgent()
        {
            Disable();
        }

        private void Awake()
        {
            SetPlayerLayerMask();
            SetHitZoneTransform();
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

        private bool IsHit(out Collider collider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitZoneTransform.position, _radiusOfSphereHit, _resultOfHit, _layerMask);

            collider = _resultOfHit[0];

            return count > 0;
        }

        private void SetPlayerLayerMask() => _layerMask = 1 << LayerMask.NameToLayer(StaticLayersNames.Player);
        private void SetHitZoneTransform() => _hitZoneTransform = _hitZone.transform;
        private void PlayAnimatironAttack() => _enemyAnimator.PlayAttack();
        private void Enable() => enabled = true;
        private void Disable() => enabled = true;
    }
}