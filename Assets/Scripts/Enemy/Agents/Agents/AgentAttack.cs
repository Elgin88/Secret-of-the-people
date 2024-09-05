using Enemy.Agents.AgentsLaunchers;
using Enemy.Animations;
using Infrastructure.Services.Factory;
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
        private IGameFactory _gameFactory;
        private const float _radiusHitSphere = 0.3f;
        private Vector3 _playerPosition => _gameFactory.Player.transform.position;
        private int _damage => _staticData.Damage;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start() => Off();

        private void OnDisable()
        {
            StopPlayAnimation();
        }

        private void FixedUpdate()
        {
            PlayAnimation();
            SetRotation();
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
            if (IsHit(out Collider player))
            {
                GiveHit(player);
            }
        }

        private void OnAttackEnded()
        {
            _launcherAttack.StopAgent();
        }

        private void SetEnabled(bool status) => enabled = status;
        private void PlayAnimation() => _enemyAnimationSetter.PlayAttack();
        private void StopPlayAnimation() => _enemyAnimationSetter.StopPlayAttack();
        private void SetRotation() => transform.rotation = Quaternion.LookRotation(_playerPosition);

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