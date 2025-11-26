using UnityEngine;

namespace Arkanoid
{
    public interface IBounce
    {
        Vector3 BounceDirection(Transform bounceObj, Transform bounceFrom, Collision collision, Vector3 from,
            Vector3 normal);
    }
}