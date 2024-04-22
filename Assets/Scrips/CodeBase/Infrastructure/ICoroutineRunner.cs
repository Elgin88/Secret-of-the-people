using System.Collections;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public interface ICoroutineRunner : IService
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}