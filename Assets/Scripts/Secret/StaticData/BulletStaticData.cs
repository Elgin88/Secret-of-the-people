using UnityEngine;

namespace Secret.StaticData
{
    [CreateAssetMenu(fileName = "BulletStaticData", menuName = "StaticData/BulletStaticData")]

    public class BulletStaticData : ScriptableObject
    {
        [Range(0, 100)] public int Damage = 50;

        [Range(0, 100)] public int MoveSpeed = 50;
    }
}