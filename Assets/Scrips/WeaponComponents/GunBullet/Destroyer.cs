using Scripts.EnemyComponents;
using UnityEngine;

namespace Scripts.WeaponsComponents.GunBullet
{
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Дописать здесь");
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}