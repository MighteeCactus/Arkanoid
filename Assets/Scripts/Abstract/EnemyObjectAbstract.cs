using System;
using Arkanoid.States;
using UnityEngine;

namespace Arkanoid
{
    public abstract class EnemyObjectAbstract : MonoBehaviour, IEnemyObject
    {
        public Action<IEnemyObject> OnDead { get; set; }
        
        public abstract IEnemyView View { get; }

        public abstract Vector3 Position { get; set; }
        public abstract EnemyState State { get; set; }
        public abstract int Health { get; set; }
        public abstract void Impact(int amount);
    }
}
