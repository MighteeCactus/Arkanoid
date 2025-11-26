using System;

namespace Arkanoid
{
    public interface IEnemyView
    {
        void Appear(Action onCompleted = null);
        void TakeImpact(Action onCompleted = null);
        void Die(Action onCompleted = null);
    }
}