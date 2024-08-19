using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class AnimationChooserDeathParametr : MonoBehaviour
    {
        private List<int> _parametrs = new List<int>();

        public int GetDeathHash()
        {
            AddParametrs();

            return _parametrs[GetRandomIndex()];
        }

        private int GetRandomIndex() => UnityEngine.Random.Range(0, _parametrs.Count - 1);

        private void AddParametrs()
        {
            _parametrs.Add(Static.AnimatorDeadA.GetHashCode());
            _parametrs.Add(Static.AnimatorDeadB.GetHashCode());
            _parametrs.Add(Static.AnimatorDeadC.GetHashCode());
            _parametrs.Add(Static.AnimatorDeadD.GetHashCode());
        }
    }
}