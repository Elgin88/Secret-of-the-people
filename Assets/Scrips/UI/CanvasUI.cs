using UnityEngine;

namespace Shooter.UI
{
    public class CanvasUI : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _floatingJoystick;

        private void Start()
        {
            _floatingJoystick.gameObject.SetActive(true);
        }
    }
}