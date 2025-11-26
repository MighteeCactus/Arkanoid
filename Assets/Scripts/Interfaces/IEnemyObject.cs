using System;
using Arkanoid.States;
using UnityEngine;

namespace Arkanoid
{
    public interface IEnemyObject : IImpact
    {
        Action<IEnemyObject> OnDead { get; set; }

        IEnemyView View { get; }
        
        Vector3 Position { get; set; }
        EnemyState State { get; set; }
        int Health { get; set; }
    }
}