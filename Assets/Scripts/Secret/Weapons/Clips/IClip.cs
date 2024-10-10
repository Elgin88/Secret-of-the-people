using UnityEditor.Build;

namespace Secret.Weapons.Clips
{
    public interface IClip
    {
        public int CurrentBulletCount { get; set; }
    }
}