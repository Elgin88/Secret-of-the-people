using System.Collections;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}