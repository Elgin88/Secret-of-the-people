using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Player
{
    public class NextTargetFinder : MonoBehaviour
    {
        [SerializeField] private ChooserSectorAttack _sectorAttack;
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private LayerMask _targetLayerMask;

        private Collider[] _targets;
        private Collider _currentTarget;
        private const int _maxTargetsCount = 10;
        private float _minDistance;
        private int _rangeToChooserNearestTarget;
        private int _currentCountTargets;

        public Collider CurrentTarget => _currentTarget;

        public int CurrentTargetsCount => _currentCountTargets;

        private void Awake()
        {
            CreateArrayTargets();
            SetRangeFindTarget();
        }

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
                if (IsFind(target))
                {
                    if (InSector(target))
                    {
                        float distance = GetDistanceToTarget(target);

                        if (distance < _minDistance)
                        {
                            _minDistance = distance;
                            _currentTarget = target;
                        }
                    }
                }
            }
        }

        private bool InSector(Collider target)
        {
            return _sectorAttack.GetTargetInSector(target);
        }

        private static bool IsFind(Collider target) => target != null;

        private void FindTargets()
        {
            _currentCountTargets = 0;

            _currentCountTargets = Physics.OverlapSphereNonAlloc(transform.position, _rangeToChooserNearestTarget, _targets, _targetLayerMask);
        }

        private float GetDistanceToTarget(Collider target) => Vector3.Distance(transform.position, target.transform.position);

        private void SetMinDistance() => _minDistance = _rangeToChooserNearestTarget;

        private void ResetNearestTarget() => _currentTarget = null;

        private void SetRangeFindTarget() => _rangeToChooserNearestTarget = _staticData.RangeToChooserNearestTarget;

        private void CreateArrayTargets() => _targets = new Collider[_maxTargetsCount];
    }
}