using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public interface IEnemyFieldGenerator
    {
        public List<IEnemyObject> Generate();
        public void SetStartPosition(Vector3 pos);
    }
}