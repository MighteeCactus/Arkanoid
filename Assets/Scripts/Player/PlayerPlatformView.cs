using System;
using Arkanoid.Data;
using DG.Tweening;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerPlatformView : PlayerPlatformViewAbstract, IPlayerPlatformConfig, IInitializable
    {
        [SerializeField, HideInInspector] private AudioSource _audio;
        private PlayerPlatformConfig _config;

        private Tween _shake;

        private void OnValidate()
        {
            if (_audio == null)
                _audio = GetComponent<AudioSource>();
        }

        public override void TakeImpact(Action onCompleted = null)
        {
            _audio.Play();
            _shake.Restart();
        }

        public void SetConfig(PlayerPlatformConfig config)
        {
            _config = config;
        }

        public void Initialize()
        {
            _audio.clip = _config.ImpactSound;
            _shake = transform.DOPunchPosition(Vector3.down * 0.5f, 0.1f).SetAutoKill(false).Pause();
        }
    }
}