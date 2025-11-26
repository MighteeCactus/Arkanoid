using System.Collections.Generic;
using System.Linq;
using Arkanoid.Data;
using Arkanoid.UI;
using UnityEngine;

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
        
        [Header("UI")]
        [SerializeField] private GameplayUiManager _uiManager;
        
        [Header("Debug")]
        [SerializeField] private int _enemiesAlive;
        
        private List<IEnemyObject> _enemies;

        private PlayerBallObjectAbstract _ball;
        private PlayerPlatformObjectAbstract _platform;

        private void Awake()
        {
            _platform = Instantiate(_platformConfig.Prefab, _platformSpot.position, Quaternion.identity);
            _platform.GetComponent<IPlayerPlatformConfig>().SetConfig(_platformConfig);
            
            _platform.GetComponentsInChildren<IPlayerPlatformConfig>().ToList()
                .ForEach(pl => pl.SetConfig(_platformConfig));
            _platform.GetComponentsInChildren<IInitializable>().ToList()
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
        }
        
        private void Start()
        {
            Initialize(EventDispatcherObject.Instance.Dispatcher);
        }

        /// <summary>
        /// Притворимся, что DI у нас есть.
        /// </summary>
        private void Initialize(EventDispatcher dispatcher)
        {
            dispatcher.OnWin += Win;
            dispatcher.OnLose += Lose;
        }

        private void OnEnemyDead(IEnemyObject enemy)
        {
            if (_enemies.Contains(enemy))
            {
                _enemies.Remove(enemy);
                _enemiesAlive--;

                if (_enemiesAlive <= 0)
                {
                    Win();
                }
            }
        }

        public void Win()
        {
            _platform.GetComponent<PlayerPlatformControl>().enabled = false;
            _ball.Stop();
            _uiManager.ShowVictory();
        }
        
        public void Lose()
        {
            _platform.GetComponent<PlayerPlatformControl>().enabled = false;
            _ball.Stop();
            _uiManager.ShowDefeat();
        }
    }
}
