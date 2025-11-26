using UnityEngine;

namespace Arkanoid.Data
{
    [CreateAssetMenu(fileName = "enemy_999", menuName = "Arkanoid/Create Enemy", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        [Range(1, 20)]
        public int Health = 1;

        public BounceAbstract Bounce;

        public AudioClip ImpactSound;
        public AudioClip DieSound;
        public EnemyObjectAbstract Prefab;
    }
    
    public interface IEnemyObjConfig : IAcceptConfig<EnemyConfig> { }
}
