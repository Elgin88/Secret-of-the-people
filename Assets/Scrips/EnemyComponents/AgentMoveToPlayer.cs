using Scripts.CodeBase.Infractructure;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(NavMeshAgent))]

    public class AgentMoveToPlayer : MonoBehaviour
    {
        private EnemyAnimator _enemyAnimator;
        private NavMeshAgent _navMeshAgent;
        private GameObject _player;
        private IGameFactory _gameFactory;
        private float _minDistance = 5;

        private void Awake()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            TryGetGameFactory();

            if (IsGameFactoryInittialize())
            {
                if (IsPlayerInitialize())
                {
                    SetPlayer();
                }
                else
                {
                    SetPlayerAfterInitialize();
                }
            }
        }

        private void Update()
        {
            if (IsOnNavMesh() & IsInitializePlayer())
            {
                if (CheckMinDistance())
                {
                    Move();
                    _enemyAnimator.PlayMove();
                }
                else
                {
                    StopMove();
                    _enemyAnimator.StopPlayMove();
                }
            }
        }

        private void Move()
        {
            _navMeshAgent.destination = _player.transform.position;
            _navMeshAgent.isStopped = false;
        }

        private void StopMove() => _navMeshAgent.isStopped = true;
        private bool CheckMinDistance() => Vector3.Distance(transform.position, _player.transform.position) > _minDistance;
        private bool IsInitializePlayer() => _player != null;
        private void TryGetGameFactory() => _gameFactory = AllServices.Container.Get<IGameFactory>();
        private void SetPlayerAfterInitialize() => _gameFactory.PlayerLoaded += SetPlayer;
        private bool IsPlayerInitialize() => _gameFactory.Player != null;
        private bool IsGameFactoryInittialize() => _gameFactory != null;
        private void SetPlayer() => _player = _gameFactory.Player;
        private bool IsOnNavMesh() => _navMeshAgent.isOnNavMesh;
        private bool IsMoving() => !_navMeshAgent.isStopped;
    }
}