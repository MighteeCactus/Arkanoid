using UnityEngine;
using UnityEngine.Audio;

namespace Arkanoid.Util
{
    public class AudioAmbient : MonoBehaviour
    {
        private static AudioAmbient _instance;

        [SerializeField] private AudioMixerGroup _mixerGrp;
        [SerializeField] private AudioConfig _settings;

        private AudioSource _audio;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                
                DontDestroyOnLoad(gameObject);
                
                _audio = gameObject.AddComponent<AudioSource>();
                _audio.outputAudioMixerGroup = _mixerGrp;
                _audio.loop = true;
            }
            else if (_instance != null && _instance != this)
            {
                DestroyImmediate(gameObject);
            }
        }

        private void Start()
        {
            _audio.clip = _settings.Ambient;
            _audio.time = _settings.Ambient.length * Random.Range(0f, 0.7f);
            _audio.Play();
        }
    }
}
