using Arkanoid.States;

namespace Arkanoid
{
    public interface IPlayerBall
    {
        PlayerBallState BallState { get; set; }
        void Launch();
        void Stop();
    }
}