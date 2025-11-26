using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Arkanoid.Data;
using Arkanoid.States;
using Arkanoid.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Позиции")]
        [SerializeField] private Transform _platformSpot;
        [SerializeField] private Transform _ballSpot;
        [SerializeField] private Transform _enemySpot;
        
        [Header("Всё остальное")]
        [SerializeField] private EnemyFieldGeneratorAbstract _enemyGenerator;
        [SerializeField] private PlayerPlatformConfig _platformConfig;
        [SerializeField] private PlayerBallConfig _ballConfig;
        
        [SerializeField] private int _enemiesAlive;
        
        private List<IEnemyObject> _enemies;

        private CoroutineProcessor _ballLauncher;
        private PlayerBallObjectAbstract _ball;

        private void Awake()
        {
            var platform = Instantiate(_platformConfig.Prefab, _platformSpot.position, Quaternion.identity);
            platform.GetComponent<IPlayerPlatformConfig>().SetConfig(_platformConfig);
            
            platform.GetComponentsInChildren<IPlayerPlatformConfig>().ToList()
                .ForEach(pl => pl.SetConfig(_platformConfig));
            platform.GetComponentsInChildren<IInitializable>().ToList()
                .ForEach(pl => pl.Initialize());
            
            _ball = Instantiate(_ballConfig.Prefab, _ballSpot.position, Quaternion.identity);
            _ball.GetComponent<IPlayerBallConfig>()?.SetConfig(_ballConfig);

            _enemyGenerator.SetStartPosition(_enemySpot.position);
            _enemies = _enemyGenerator.Generate();
            
            foreach (var e in _enemies)
            {
                e.OnDead += OnEnemyDead;
            }

            _enemiesAlive = _enemies.Count;

            _ballLauncher = new CoroutineProcessor(this);
            _ballLauncher.Run(LaunchBall);
        }

        private IEnumerator LaunchBall()
        {
            var wait = new WaitForEndOfFrame();
            while (true)
            {
                if (Input.GetMouseButton(0) && _ball.BallState == PlayerBallState.Idle)
                {
                    _ball.Launch();
                    yield break;
                }

                yield return wait;
            }
        }

        private void OnEnemyDead(IEnemyObject enemy)
        {
            if (_enemies.Contains(enemy))
            {
                _enemies.Remove(enemy);
                _enemiesAlive--;

                if (_enemiesAlive <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
