using System;
using UnityEngine;

namespace Arkanoid
{
    public abstract class EnemyViewAbstract : MonoBehaviour, IEnemyView
    {
        public abstract void Appear(Action onCompleted = null);
        public abstract void TakeImpact(Action onCompleted = null);
        public abstract void Die(Action onCompleted = null);
    }
}