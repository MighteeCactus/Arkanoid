using UnityEngine;

namespace Arkanoid
{
    public abstract class BounceAbstract : ScriptableObject, IBounce
    {
        public abstract Vector3 BounceDirection(Transform bounceObj, Transform bounceFrom, Collision collision, Vector3 from, Vector3 normal);
    }
}