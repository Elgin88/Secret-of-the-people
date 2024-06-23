using UnityEngine;

namespace Scripts.Static
{
    public static class StaticDebug
    {
        public static void ShowCros(Vector3 position, float radius)
        {
            Debug.DrawRay(position, Vector3.up * radius, Color.red, 0.3f);
            Debug.DrawRay(position, Vector3.down * radius, Color.red, 0.3f);
            Debug.DrawRay(position, Vector3.left * radius, Color.red, 0.3f);
            Debug.DrawRay(position, Vector3.right * radius, Color.red, 0.3f);
            Debug.DrawRay(position, Vector3.forward * radius, Color.red, 0.3f);
            Debug.DrawRay(position, Vector3.back * radius, Color.red, 0.3f);
        }
    }
}