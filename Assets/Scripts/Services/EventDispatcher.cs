using System;

namespace Arkanoid
{
    /// <summary>
    /// Упрощенная версия.<br/>
    /// Более надежный вариант был бы <code>Dictionary[Enum.EventName] = Action (или EventHandler)</code> и отдельные методы на подписку отписку.
    /// </summary>
    public class EventDispatcher : IDisposable
    {
        public Action OnWin;
        public Action OnLose;

        public void Dispose()
        {
            OnWin = null;
            OnLose = null;
        }
    }
}