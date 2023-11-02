using UnityEngine;

public class PlayerSpeedController : MonoBehaviour
{
    [SerializeField] private float _currentSpeed;

    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        if (_currentSpeed == 0)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }
    }
}
