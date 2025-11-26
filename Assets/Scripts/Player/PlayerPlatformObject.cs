using Arkanoid.Data;
using UnityEngine;

namespace Arkanoid
{
    public class PlayerPlatformObject : PlayerPlatformObjectAbstract, IBounce, IPlayerPlatformConfig
    {
        [SerializeField] private PlayerPlatformViewAbstract _view;
        public override IPlayerPlatformView View { get; }
        public override void Impact(int amount)
        {
            _view.TakeImpact();
        }

        private PlayerPlatformConfig _config;
        
        public void SetConfig(PlayerPlatformConfig config)
        {
            _config = config;
        }

        public Vector3 BounceDirection(Transform bounceObj, Transform bounceFrom, Collision collision, Vector3 from, Vector3 normal)
        {
            return _config.Bounce.BounceDirection(bounceObj, bounceFrom, collision, from, normal);
        }
    }
}