using Secret.Player.StaticData;
using UnityEngine;

namespace Secret.Player.Logic
{
    public class TargetFinder : MonoBehaviour
    {
        [SerializeField] private ChooserSectorAttack _chooserSectorAttack;
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private LayerMask _targetLayerMask;

        private Collider[] _targets = new Collider[1];
        private float _minDistance;
        private int _rangeToTarget => _staticData.RangeToNearestTarget;

        public Collider CurrentTarget { get; private set; }

        public void FixedUpdate()
        {
            SetMinDistance();
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
                    if (InSector(target))
                    {
                        float distance = GetDistanceToTarget(target);

                        if (distance < _minDistance)
                        {
                            _minDistance = distance;
                            CurrentTarget = target;
                        }
                    }
                }
            }
        }

        private bool InSector(Collider target) => _chooserSectorAttack.GetTargetInSector(target);

        private float GetDistanceToTarget(Collider target) => Vector3.Distance(transform.position, target.transform.position);

        private void SetMinDistance() => _minDistance = _rangeToTarget;

        private void ResetNearestTarget() => CurrentTarget = null;

        private void FindTargets() => Physics.OverlapSphereNonAlloc(transform.position, _rangeToTarget, _targets, _targetLayerMask);
    }
}