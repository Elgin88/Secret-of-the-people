using Enemy.AI.Agents.Checkers;
using Enemy.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents
{
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private CheckerAttackEnded _checkerEndHit;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _targetMask;

        private Collider[] _results = new Collider[1];
        private Collider _target;
        private float _radiusHit = 1;
        private int _damage => _staticData.Damage;

        public bool IsEndHit { get; internal set; }

        private void FixedUpdate()
        {
            PlayAttackAnimation();
        }

        public void On()
        {
            Enable();
        }

        public void Off()
        {
            Disable();
        }

        private void OnHit()
        {
            SetTarget();
            HitTarget();
        }

        private void PlayAttackAnimation() => _enemyAnimationSetter.PlayAttack();

        private void HitTarget()
        {
            if (_target != null)
            {
                _target.GetComponent<IPlayerHealthChanger>().RemoveHealth(_damage);
            }
        }

        private void SetTarget()
        {
            Physics.OverlapSphereNonAlloc(_hitPoint.transform.position, _radiusHit, _results, _targetMask);

            _target = _results[0];
        }

        private void Enable()
        {
            if (!enabled)
            {
                enabled = true;
            }
        }

        private void Disable()
        {
            if (enabled)
            {
                enabled = false;
            }
        }
    }
}