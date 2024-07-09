using Scripts.CodeBase.Logic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    public class AgentMoveToPlayer : MonoBehaviour, IAgent
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private const float _minDistanceToPlayer = 0.1f;
        private const float _currentSpeed = 2;
        private IGameFactory _gameFactory;
        private Transform _playerTransform;
        private bool _isMoving = false;

        public float CurrentSpeed => _currentSpeed;

        public void EnableAgent()
        {
            Enable();
            NavMeshMoveOn();
        }

        public void DisableAgent()
        {
            NavMeshMoveOff();
            PlayAnimationIdle();
            Disable();
        }

        private void Awake()
        {
            SetComponents();
            Disable();
        }

        private void FixedUpdate()
        {
            if (!IsMinDistance())
            {
                Move();
                PlayAnimationMove();
            }
            else
            {
                StopMove();
                PlayAnimationIdle();
            }
        }

        private void SetComponents()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _gameFactory = AllServices.Container.Get<IGameFactory>();

            _navMeshAgent.speed = _currentSpeed;

            SetPlayer();
        }

        private void Move()
        {
            MoveToTarget();
        }

        private void StopMove()
        {
            if (_isMoving)
            {
                NavMeshMoveOff();
                SetIsMovingFalse();
            }
        }

        private void SetPlayer()
        {
            if (IsPlayerCreate())
            {
                SetPlayerTransfromFromGameFactory();
            }
            else
            {
                SetPlayerAfterCreate();
            }
        }

        private bool IsMinDistance() => _minDistanceToPlayer > Vector3.Distance(transform.position, _playerTransform.position);
        private bool IsPlayerInitialized() => _playerTransform.gameObject.transform != null;
        private void SetPlayerAfterCreate() => _gameFactory.PlayerLoaded += SetPlayerTransfromFromGameFactory;
        private bool IsPlayerCreate() => _gameFactory.Player != null;
        private void SetPlayerTransfromFromGameFactory() => _playerTransform = _gameFactory.Player.transform;
        private bool IsOnNavMesh() => _navMeshAgent.isOnNavMesh;
        private void NavMeshMoveOn() => _navMeshAgent.isStopped = false;
        private void NavMeshMoveOff() => _navMeshAgent.isStopped = true;
        private void Enable() => enabled = true;
        private void Disable() => enabled = false;
        private void PlayAnimationMove() => _enemyAnimator.PlayMove(_currentSpeed);
        private void PlayAnimationIdle() => _enemyAnimator.StopPlayMove();
        private void MoveToTarget() => _navMeshAgent.destination = _playerTransform.position;
        private void SetIsMovingTrue() => _isMoving = true;
        private void SetIsMovingFalse() => _isMoving = false;
    }
}