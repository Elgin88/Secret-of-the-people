using UnityEngine;

namespace CodeBase.PlayerComponents
{
    internal class Player: MonoBehaviour
    {
        internal void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        internal void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}