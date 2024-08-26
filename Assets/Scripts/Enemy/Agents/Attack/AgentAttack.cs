using System.Collections;
using Scripts.CodeBase.Logic;
using Scripts.Enemy;
using Scripts.StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private AnimationSetter _enemyAnimator;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private HitSphere _hitArea;

        private Player.Interfaces.IHealthChanger _healthChanger;
        private IGameFactory _gameFactory;
        private Collider[] _resultOfHit = new Collider[1];
        private float _currentCooldown;
        private float _attackCooldown;
        private bool _isAtacking = false;
        private int _damage;

        private void Start()
        {
            SetParameters();
            Disable();
        }

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        public void EnableAgent()
        {
            Enable();
            PlayAnimationAttack();
        }

        public void DisableAgent() => enabled = false;

        private void OnAttackEnded() => StartCoroutine(AttackAfterCooldown());

        private bool IsAlive() => _healthChanger.CurrentHealth > 0;

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;

        private void UpdateCooldown() => _currentCooldown -= Time.deltaTime;

        private void ResetCooldown() => _currentCooldown = _attackCooldown;

        private void SetIsAttacking() => _isAtacking = true;

        private void ResetIsAttacking() => _isAtacking = false;

        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitArea.transform.position, _hitArea.Radius, _resultOfHit, _layerMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void SetParameters()
        {
            _currentCooldown = _attackCooldown;
            _attackCooldown = _staticData.AttackCooldawn;
            _healthChanger = _gameFactory.Player.GetComponent<Player.Interfaces.IHealthChanger>();
            _damage = _staticData.Damage;
        }

        private void PlayAnimationAttack()
        {
            if (!_isAtacking & IsAlive())
            {
                _enemyAnimator.PlayAttack();
                SetIsAttacking();
            }
        }

        private void PlayerTakeHit(Collider player)
        {
            player.GetComponent<Player.Interfaces.IHealthChanger>().RemoveCurrentHealth(_damage);
            player.GetComponent<Player.HitTaker>().Hit();
        }

        private void OnAttack()
        {
            if (IsHit(out Collider player))
            {
                PlayerTakeHit(player);
            }
        }

        private IEnumerator AttackAfterCooldown()
        {
            while (_currentCooldown > 0)
            {
                UpdateCooldown();

                yield return null;
            }

            ResetCooldown();
            ResetIsAttacking();
            PlayAnimationAttack();
        }
    }
}