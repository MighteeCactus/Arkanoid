using System;

namespace Arkanoid
{
    public interface IPlayerPlatformView
    {
        void TakeImpact(Action onCompleted = null);
    }
}