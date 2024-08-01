using Scripts.StaticData;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserNearestTarget : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayerMask;
        [SerializeField] private PlayerStaticData _staticData;

        private int _rangeToChooserNearestTarget;
        private Collider[] _targets;
        private Collider _nearestTarget;
        private const int maxTargetsCount = 10;
        private float _minDistance;

        public Collider NearestTarget => _nearestTarget;

        private void Awake()
        {
            _targets = new Collider[maxTargetsCount];
            _rangeToChooserNearestTarget = _staticData.RangeToChooserNearestTarget;
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

        private void FindTargets() => Physics.OverlapSphereNonAlloc(transform.position, _rangeToChooserNearestTarget, _targets, _targetLayerMask);

        private float CalculateDistance(Collider target) => Vector3.Distance(transform.position, target.transform.position);

        private void ResetMinDistance() => _minDistance = _rangeToChooserNearestTarget;

        private void ResetNearestTarget() => _nearestTarget = null;
    }
}