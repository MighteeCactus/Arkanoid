using Arkanoid.Data;
using Arkanoid.States;
using UnityEngine;

namespace Arkanoid
{
    public class EnemySimpleObj : EnemyObjectAbstract, IEnemyObjConfig, IBounce, IInitializable
    {
        [SerializeField] private EnemyViewAbstract _view;
        public override IEnemyView View => _view;
        
        private BounceAbstract _bounce;
        private EnemyConfig _config;
        
        private Rigidbody _rb;
        
        private Vector3 _position;

        public override Vector3 Position {
            get => _position;
            set {
                transform.position = value;
                _position = value;
            }
        }

        public override EnemyState State { get; set; }
        public override int Health { get; set; }

        public override void Impact(int amount)
        {
            if (amount > 0 && State == EnemyState.Alive)
            {
                Health -= amount;
                _view.TakeImpact();
            } 
            
            if (State != EnemyState.Dead && Health <= 0)
            {
                State = EnemyState.Dead;
                _view.Die();
                GetComponent<Collider>().enabled = false;
                OnDead(this);
            }
        }

        public void SetConfig(EnemyConfig config)
        {
            _config = config;
        }
        
        public void Initialize()
        {
            Health = _config.Health;
        }

        private void OnValidate()
        {
            if (_rb == null)
            {
                _rb = GetComponent<Rigidbody>();
            }
        }

        private void Awake()
        {
            State = EnemyState.Alive;
        }

        public Vector3 BounceDirection(Transform bounceObj, Transform bounceFrom, Collision collision, Vector3 from, Vector3 normal)
        {
            return _config.Bounce.BounceDirection(bounceObj, bounceFrom, collision, from, normal);
        }
    }
}