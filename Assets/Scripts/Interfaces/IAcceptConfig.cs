using UnityEngine;

namespace Arkanoid
{
    public interface IAcceptConfig<T> where T : ScriptableObject
    {
        void SetConfig(T config);
    }
}