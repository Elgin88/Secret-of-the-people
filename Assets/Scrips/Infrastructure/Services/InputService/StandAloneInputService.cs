using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class StandAloneInputService : InputService, IInputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis;

                if (GetMobileAxis() == Vector2.zero)
                {
                    axis = GetUnityAxis().normalized;
                }
                else
                {
                    axis = GetMobileAxis().normalized;
                }

                return axis;
            }
        }
    }
}