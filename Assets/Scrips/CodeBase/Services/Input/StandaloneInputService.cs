using UnityEngine;

namespace CodeBase.Services.Input
{
    internal class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axix = GetSimpleInputAxix();

                if (axix == Vector2.zero)
                {
                    axix = GetUnityAxix();
                }

                return axix;
            }
        }

        private Vector2 GetUnityAxix() => new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}