using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    [Serializable]
    public abstract class EnemyFieldGeneratorAbstract : ScriptableObject, IEnemyFieldGenerator
    {
        public abstract List<IEnemyObject> Generate();
        public abstract void SetStartPosition(Vector3 pos);
    }
}
