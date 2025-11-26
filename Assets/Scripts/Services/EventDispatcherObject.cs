using UnityEngine;

namespace Arkanoid
{
    /// <summary>
    /// Одноразовый.<br/>
    /// Обычно доступом к объектам типа EventDispatcher занимается DI,<br/>
    /// но тут у нас его нет, поэтому делаем подобие ServiceLocator'a.
    /// </summary>
    public class EventDispatcherObject : MonoBehaviour
    {
        public EventDispatcher Dispatcher { get; } = new();
        
        private static EventDispatcherObject _instance;
        public static EventDispatcherObject Instance => _instance;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != null && _instance != this)
            {
                DestroyImmediate(gameObject);
            }
        }

        private void OnDestroy()
        {
            Dispatcher.Dispose();

            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}