using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "BulletStaticData", menuName = "StaticData/BulletStaticData")]

    public class BulletStaticData : ScriptableObject
    {
        [Range(0, 100)] public float Speed;
    }
}