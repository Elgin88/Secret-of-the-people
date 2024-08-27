using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player.Animations
{
    public class AnimationChooserDeathHash : MonoBehaviour
    {
        private List<int> _hashs = new List<int>();

        private void Awake()
        {
            AddParameters();
        }

        public int GetRandomDeathHash() => _hashs[GetRandomIndex()];

        private int GetRandomIndex() => Random.Range(0, _hashs.Count - 1);

        private void AddParameters()
        {
            _hashs.Add(Static.DeathAHash);
            _hashs.Add(Static.DeathBHash);
            _hashs.Add(Static.DeathCHash);
            _hashs.Add(Static.DeathDHash);
            _hashs.Add(Static.DeathEHash);
        }
    }
}