using System.Collections;
using Arkanoid.States;
using Arkanoid.Util;
using UnityEngine;

namespace Arkanoid
{
    /// <summary>
    /// Запускаем корутину и ждем первого клика.
    /// Корутина нужна, чтобы в пустую не гонять тот же Update. 
    /// </summary>
    [RequireComponent(typeof(IPlayerBall))]
    public class PlayerBallControl : MonoBehaviour
    {
        private void Awake()
        {
            var launcher = new CoroutineProcessor(this);
            launcher.Run(LaunchBall);
        }
        
        private IEnumerator LaunchBall()
        {
            var wait = new WaitForEndOfFrame();
            var ball = GetComponent<IPlayerBall>();
            while (true)
            {
                if (Input.GetMouseButton(0) && ball.BallState == PlayerBallState.Idle)
                {
                    ball.Launch();
                    yield break;
                }

                yield return wait;
            }
        }
    }
}