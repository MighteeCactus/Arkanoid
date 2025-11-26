using UnityEngine;

namespace Arkanoid.Data
{
    [CreateAssetMenu(fileName = "player_platform_999", menuName = "Arkanoid/Create Player Platform", order = 0)]
    public class PlayerPlatformConfig : ScriptableObject
    {
        public float MoveSpeed;
        public BounceAbstract Bounce;
        public AudioClip ImpactSound;
        public PlayerPlatformObjectAbstract Prefab;
    }
    
    public interface IPlayerPlatformConfig : IAcceptConfig<PlayerPlatformConfig> { }
}