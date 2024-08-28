using UnityEngine;

namespace Player.Logic
{
    public class ChooserSectorAttack : MonoBehaviour
    {
        private const float _maxAngle = 45;
        private Vector3 _vectorToTarget;
        private float _currentAngle;
        private bool _targetInSector = false;

        public bool GetTargetInSector(Collider target)
        {
            CheckTargetInSector(target);

            return _targetInSector;
        }

        private void CheckTargetInSector(Collider target)
        {
            SetVectorToTarget(target);
            SetCurrentAngleToTarget();
            SetIsTargetInSector();
        }

        private void SetVectorToTarget(Collider target) => _vectorToTarget = new Vector3(target.transform.position.x - transform.position.x,
            target.transform.position.y - transform.position.y,
            target.transform.position.z - transform.position.z).normalized;

        private void SetCurrentAngleToTarget() => _currentAngle = Vector3.Angle(transform.forward.normalized, _vectorToTarget);

        private void SetIsTargetInSector() => _targetInSector = _maxAngle > _currentAngle;
    }
}