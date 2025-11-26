using Arkanoid.States;
using UnityEngine;

namespace Arkanoid
{
    public abstract class PlayerBallObjectAbstract : MonoBehaviour, IPlayerBall
    {
        public abstract PlayerBallState BallState { get; set; }
        public abstract void Launch();
        public abstract void Stop();
    }
}