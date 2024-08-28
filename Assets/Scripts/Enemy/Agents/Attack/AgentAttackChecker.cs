using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(AgentAttackSetter))]
    
    public class AgentAttackChecker : MonoBehaviour
    {
        [SerializeField] private AgentAttackSetter _attackSetter;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _results = new Collider[1];
        private const float _radius = 0.3f;
        private int _targetCount;

        private void FixedUpdate()
        {
            if (GetIsFind())
            {
                _attackSetter.EnableAgent();
                Debug.Log("Упростить, слишком дорого");
            }
            else
            {
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