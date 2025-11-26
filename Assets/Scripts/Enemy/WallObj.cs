using Arkanoid.Data;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(AudioSource))]
    public class WallObj : MonoBehaviour, IBounce, IImpact
    {
        [SerializeField] private EnemyConfig _config;
        private AudioSource _audio;

        public Vector3 BounceDirection(Transform bounceObj, Transform bounceFrom, Collision collision, Vector3 from, Vector3 normal)
        {
            return _config.Bounce.BounceDirection(bounceObj, bounceFrom, collision, from, normal);
        }

        public void Impact(int amount)
        {
            _audio.Play();
        }
        
        private void OnValidate()
        {
            if (_audio == null)
                _audio = GetComponent<AudioSource>();
        }

        private void Awake()
        {
            _audio.clip = _config.ImpactSound;
        }
    }
}