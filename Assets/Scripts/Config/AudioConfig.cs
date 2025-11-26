using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(fileName = "audio_999", menuName = "Arkanoid/Create Audio Config", order = 0)]
    public class AudioConfig : ScriptableObject
    {
        public AudioClip Ambient;
    }
}
