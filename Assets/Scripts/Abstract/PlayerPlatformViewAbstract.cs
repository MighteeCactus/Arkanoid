using System;
using UnityEngine;

namespace Arkanoid
{
    public abstract class PlayerPlatformViewAbstract : MonoBehaviour, IPlayerPlatformView
    {
        public abstract void TakeImpact(Action onCompleted = null);
    }
}