using UnityEngine;

namespace Arkanoid.Data
{
    [CreateAssetMenu(fileName = "player_ball_999", menuName = "Arkanoid/Create Player Ball", order = 0)]
    public class PlayerBallConfig : ScriptableObject
    {
        public float Speed = 4f;
        public PlayerBallObjectAbstract Prefab;
    }
    
    public interface IPlayerBallConfig : IAcceptConfig<PlayerBallConfig> { }
}