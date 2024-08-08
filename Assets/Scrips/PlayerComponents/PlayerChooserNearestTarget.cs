using Scripts.StaticData;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserNearestTarget : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayerMask;
        [SerializeField] private PlayerStaticData _staticData;

        private Collider[] _targets;
        private Collider _nearestTarget;
        private const int _maxTargetsCount = 10;
        private int _currentCountTargets;
        private float _minDistance;
        private int _rangeToChooserNearestTarget;

        public Collider NearestTarget => _nearestTarget;

        public int CurrentTargetsCount => _currentCountTargets;

        private void Awake()
        {
            CreateArrayTargets();
            SetRangeFindTarget();
        }

        public void FixedUpdate()
        {
            ResetMinDistance();
            ResetNearestTarget();
            FindTargets();
            SetNearestTarget();
        }

        private void SetNearestTarget()
        {
            foreach (Collider target in _targets)
            {
                if (target != null)
                {
                    float distance = CalculateDistance(target);

                    if (distance < _minDistance)
                    {
                        _minDistance = distance;
                        _nearestTarget = target;
                    }
                }
            }
        }

        private void FindTargets()
        {
            _currentCountTargets = 0;

            _currentCountTargets = Physics.OverlapSphereNonAlloc(transform.position, _rangeToChooserNearestTarget, _targets, _targetLayerMask);
        }

        private float CalculateDistance(Collider target) => Vector3.Distance(transform.position, target.transform.position);

        private void ResetMinDistance() => _minDistance = _rangeToChooserNearestTarget;

        private void ResetNearestTarget() => _nearestTarget = null;

        private void SetRangeFindTarget() => _rangeToChooserNearestTarget = _staticData.RangeToChooserNearestTarget;

        private void CreateArrayTargets() => _targets = new Collider[_maxTargetsCount];
    }
}