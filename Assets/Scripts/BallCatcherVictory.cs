using UnityEngine;

namespace Arkanoid
{
    public class BallCatcherVictory : MonoBehaviour, IBounce
    {
        private EventDispatcher _dispatcher;
        
        private void Start()
        {
            Initialize(EventDispatcherObject.Instance.Dispatcher);
        }

        /// <summary>
        /// Притворимся, что DI у нас есть.
        /// </summary>
        private void Initialize(EventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        private void OnCollisionEnter(Collision other)
        {
            _dispatcher.OnWin?.Invoke();
        }
        
        public Vector3 BounceDirection(Transform bounceObj, Transform bounceFrom, Collision collision, Vector3 from, Vector3 normal)
        {
            return Vector3.zero;
        }
    }
}
