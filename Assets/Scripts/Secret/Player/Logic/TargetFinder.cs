using Secret.StaticData;
using UnityEngine;

namespace Secret.Player.Logic
{
    public class TargetFinder : MonoBehaviour
    {
        [SerializeField] private ChooserSectorAttack _chooserSectorAttack;
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private LayerMask _targetLayerMask;

        private Collider[] _targets = new Collider[5];
        private float _minDistance;
        private int _range => _staticData.RangeToNearestTarget;

        public Collider CurrentTarget { get; private set; }

        public void FixedUpdate()
        {
            FindTarget();
            SetTarget();
        }

        private bool InSector(Collider target) => _chooserSectorAttack.GetTargetInSector(target);

        private float GetDistance(Collider target) => Vector3.Distance(transform.position, target.transform.position);

        private void FindTarget() => Physics.OverlapSphereNonAlloc(transform.position, _range, _targets, _targetLayerMask);

        private void SetTarget()
        {
            CurrentTarget = null;
            _minDistance = _range;

            foreach (Collider target in _targets)
            {
                if (target != null)
                {
                    if (InSector(target))
                    {
                        float distance = GetDistance(target);

                        if (distance < _minDistance)
                        {
                            _minDistance = distance;
                            CurrentTarget = target;
                        }
                    }
                }
            }
        }
    }
}