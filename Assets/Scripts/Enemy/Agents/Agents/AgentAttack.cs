using Enemy.Agents.AgentsLaunchers;
using Enemy.Animations;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.Agents
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]

    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private LauncherAttack _launcherAttack;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _resultOfHit = new Collider[1];
        private const float _radiusHitSphere = 0.3f;
        private int _damage => _staticData.Damage;

        private void OnEnable()
        {
            PlayAnimation();
        }

        private void OnDisable()
        {
            StopPlayAnimation();
        }

        private void FixedUpdate()
        {
            PlayAnimation();
        }

        public void On()
        {
            SetEnabled(true);
        }

        public void Off()
        {
            SetEnabled(false);
        }


        private void OnAttack()
        {
            if (IsHit(out Collider target))
            {
                GiveHit(target);
            }
        }

        private void OnAttackEnded()
        {
            StopPlayAnimation();
            AgentAttackOff();
        }
        
        private void SetEnabled(bool status) => enabled = status;
        private void AgentAttackOff() => _launcherAttack.StopAgent();
        private void PlayAnimation() => _enemyAnimationSetter.PlayAttack();
        private void StopPlayAnimation() => _enemyAnimationSetter.StopPlayAttack();

        private bool IsHit(out Collider target)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitPoint.position, _radiusHitSphere, _resultOfHit, _target);

            target = _resultOfHit[0];

            return count > 0;
        }

        private void GiveHit(Collider player)
        {
            player.GetComponent<IPlayerHealthChanger>().RemoveHealth(_damage);
            player.GetComponent<IPlayerAnimationsSetter>().PlayHit();
        }
    }
}