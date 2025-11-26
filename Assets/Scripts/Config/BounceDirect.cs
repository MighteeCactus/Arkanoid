using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(fileName = "bounce_direct", menuName = "Arkanoid/Create Bounce Direct", order = 0)]
    public class BounceDirect : BounceAbstract
    {
        public override Vector3 BounceDirection(Transform bounceObj, Transform bounceFrom, Collision collision, Vector3 from, Vector3 normal)
        {
            normal.z = 0f;
            normal.Normalize();
            
            var proj = normal * Vector3.Dot(from, normal);
            var diff = proj - (from);
            return proj + diff;
        }
    }
}