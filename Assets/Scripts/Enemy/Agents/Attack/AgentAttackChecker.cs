using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(AgentAttackSetter))]
    [RequireComponent(typeof(AgentAttack))]

    public class AgentAttackChecker : MonoBehaviour
    {
        [SerializeField] private AgentAttackSetter _attackSetter;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _results = new Collider[1];
        private const float _radius = 0.3f;
        private int _targetCount;
        private bool _isFind;

        private void FixedUpdate()
        {
            _isFind = GetIsFind();
            Debug.Log("1");

            if (!_agentAttack.enabled & _isFind)
            {
                _attackSetter.EnableAgent();
                Debug.Log("2");
            }

            if (_agentAttack.enabled & !_isFind)
            {
                Debug.Log("3");
                _attackSetter.DisableAgentAttack();
            }
        }

        private bool GetIsFind()
        {
            _targetCount = Physics.OverlapSphereNonAlloc(_hitPoint.position, _radius, _results, _target);

            return _targetCount > 0;
        }
    }
}