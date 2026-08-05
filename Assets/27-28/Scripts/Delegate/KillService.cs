using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _27_28.Scripts.Delegate
{
    public class KillService
    {
        private readonly MonoBehaviour _coroutineRunner;
        
        private List<IKillable> _killables = new();

        public KillService(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public int Count => _killables.Count;
        
        public void Kill(IKillable killable, Func<bool> func)
        {
            _killables.Add(killable);
            _coroutineRunner.StartCoroutine(KillCoroutine(killable, func));
        }

        private IEnumerator KillCoroutine(IKillable killable, Func<bool> func)
        {
            yield return new WaitUntil(func);
            killable.Kill();
            _killables.Remove(killable);
        }
    }
}
