using UnityEngine;

public class PlayerSpeedController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;

    private float _currentSpeed;

    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        if (_maxSpeed == 0)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        _currentSpeed = _maxSpeed;
    }
}
