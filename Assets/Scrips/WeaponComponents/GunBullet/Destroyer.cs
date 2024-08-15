using UnityEngine;

namespace Scripts.WeaponsComponents.GunBullet
{
    public class Destroyer : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}