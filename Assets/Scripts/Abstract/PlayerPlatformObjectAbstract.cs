using UnityEngine;

namespace Arkanoid
{
    public abstract class PlayerPlatformObjectAbstract : MonoBehaviour, IPlayerPlatformObject
    {
        public abstract IPlayerPlatformView View { get; }
        public abstract void Impact(int amount);
    }
}