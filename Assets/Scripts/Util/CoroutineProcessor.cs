using System;
using System.Collections;
using UnityEngine;

namespace Arkanoid.Util
{
    public class CoroutineProcessor
    {
        private readonly MonoBehaviour _host;
        private Coroutine _handle;
        private Func<IEnumerator> _action;

        public CoroutineProcessor(MonoBehaviour host)
        {
            _host = host;
        }

        public void Run(Func<IEnumerator> action)
        {
            if (_handle != null)
            {
                _host.StopCoroutine(_handle);
            }

            if (action == null) return;

            _action = action;
            _handle = _host.StartCoroutine(_action());
        }

        public void Run()
        {
            Run(_action);
        }

        public void Stop()
        {
            if (_handle != null)
            {
                _host.StopCoroutine(_handle);
            }
        }
    }
}