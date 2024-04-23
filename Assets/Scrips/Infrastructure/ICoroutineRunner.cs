using System.Collections;
using Scripts.Infractructure.Services;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public interface ICoroutineRunner : IService
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}