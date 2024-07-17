using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserNearestTarget : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayerMask;
        [SerializeField] private int _range;

        private const int maxTargetsCount = 10;
        private float _minDistance;
        private Collider[] _targets;
        private Collider _nearestTarget;

        public Collider NearestTargetCollider => _nearestTarget;

        private void Awake() => _targets = new Collider[maxTargetsCount];

        public void FixedUpdate()
        {
            SetTargets();
            ResetMinDistance();
            ResetNearestTarget();
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

        private void SetTargets() => Physics.OverlapSphereNonAlloc(transform.position, _range, _targets, _targetLayerMask);
        private float CalculateDistance(Collider target) => Vector3.Distance(transform.position, target.transform.position);
        private void ResetMinDistance() => _minDistance = _range;
        private void ResetNearestTarget() => _nearestTarget = null;
    }
}