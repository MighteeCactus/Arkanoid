using System;
using Arkanoid.Data;
using DG.Tweening;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemySimpleView : EnemyViewAbstract, IEnemyObjConfig, IInitializable
    {
        [SerializeField] private Color _flashColor;
        
        [SerializeField] private GameObject _alive;
        [SerializeField] private GameObject _dead;

        [SerializeField, HideInInspector] private AudioSource _audio;

        private Material _mat;
        private Color _initTint;

        private Tween _shake;
        private Sequence _flash;
        private EnemyConfig _config;

        public override void Appear(Action onCompleted = null)
        {
            _alive.SetActive(true);
            _dead.SetActive(false);
        }

        public override void TakeImpact(Action onCompleted = null)
        {
            _shake.Restart();
            _flash.Restart();            
            _audio.Play();
        }

        public override void Die(Action onCompleted = null)
        {
            _alive.SetActive(false);
            _dead.SetActive(true);
        }

        public void SetConfig(EnemyConfig config)
        {
            _config = config;
        }
        
        public void Initialize()
        {
            _audio.clip = _config.ImpactSound;

            _shake = transform.DOShakePosition(0.1f, 0.5f).SetAutoKill(false).Pause();
        }
        
        private void OnValidate()
        {
            if (_audio == null)
                _audio = GetComponent<AudioSource>();
        }

        private void Awake()
        {
            _mat = _alive.GetComponentInChildren<MeshRenderer>().material;
            _initTint = _mat.color;
            
            _flash = DOTween.Sequence()
                .AppendCallback(() => _mat.color = _flashColor)
                .AppendInterval(0.05f)
                .AppendCallback(() => _mat.color = _initTint)
                .SetAutoKill(false)
                .Pause();
        }

        private void OnDestroy()
        {
            _flash.Kill();
            _shake.Kill();
        }
    }
}