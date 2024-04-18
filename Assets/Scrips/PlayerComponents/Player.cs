using UnityEngine;

namespace CodeBase.PlayerComponents
{
    public class Player: MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        internal void SetPosition(Vector3 targetPosition) =>
            transform.position = targetPosition;

        public void SetRotation(Quaternion targetRotation) =>
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}