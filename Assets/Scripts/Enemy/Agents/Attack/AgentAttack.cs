using System.Collections;
using Enemy.Agents.MoveToPlayer;
using Enemy.Animations;
using Infrastructure.Services.Factory;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]

    public class AgentAttack : MonoBehaviour, IEnemyAgent
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationSetter;
        [SerializeField] private MoveToPlayerChecker _moveToPlayerChecker;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private HitSphere _hitArea;

        private IPlayerHealthChanger _playerHealthChanger;
        private readonly Collider[] _resultOfHit = new Collider[1];
        private IGameFactory _gameFactory;
        private Coroutine _disableAgentAfterCooldown;
        private float _attackCooldown;
        private int _damage;

        private void Start()
        {
            SetParameters();
            DisableAgent();
        }

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        public void EnableAgent()
        {
            Enable();
            PlayAttackAnimation();
            DisableMoveToPlayerChecker();
        }

        public void DisableAgent() => enabled = false;

        private void DisableMoveToPlayerChecker() => _moveToPlayerChecker.Disable();

        private bool IsAlive() => _playerHealthChanger.CurrentHealth > 0;

        private void Enable() => enabled = true;

        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitArea.transform.position, _hitArea.Radius, _resultOfHit, _targetMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void SetParameters()
        {
            _attackCooldown = _staticData.AttackCooldown;
            _damage = _staticData.Damage;

            _playerHealthChanger = _gameFactory.Player.GetComponent<IPlayerHealthChanger>();
        }

        private void PlayAttackAnimation() => _enemyAnimationSetter.PlayAttack();

        private void PlayerTakeHit(Collider player)
        {
            player.GetComponent<IPlayerHealthChanger>().RemoveHealth(_damage);
            player.GetComponent<IPlayerAnimationsSetter>().PlayHit();
        }

        private IEnumerator DisableAgentAfterCooldown()
        {
            yield return new WaitForSeconds(_attackCooldown);

            EnableMoveToPlayerChacker();
            DisableAgent();
        }

        private void EnableMoveToPlayerChacker() => _moveToPlayerChecker.Enable();

        private void OnAttack()
        {
            if (IsHit(out Collider player))
            {
                PlayerTakeHit(player);
            }
        }

        private void OnAttackEnded()
        {
            if (_disableAgentAfterCooldown == null)
            {
                _disableAgentAfterCooldown = StartCoroutine(DisableAgentAfterCooldown());
            }
        }
    }
}