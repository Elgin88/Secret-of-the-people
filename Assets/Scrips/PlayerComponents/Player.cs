using UnityEngine;

namespace CodeBase.PlayerComponents
{
    internal class Player: MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        internal void SetPosition(Vector3 targetPosition)
        {
            transform.position = targetPosition;
        }

        internal void SetRotation(Quaternion targetRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}