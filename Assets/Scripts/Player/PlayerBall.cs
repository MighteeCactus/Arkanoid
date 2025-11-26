using Arkanoid.Data;
using Arkanoid.States;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerBall : PlayerBallObjectAbstract, IPlayerBallConfig
    {
        [SerializeField, HideInInspector] private Rigidbody _rb;
        private PlayerBallConfig _config;
        private Vector3 _lastVel;
        private ContactPoint[] _collContacts = new ContactPoint[1];
        
        #if UNITY_EDITOR
        private Vector3 _debug_dir;
        private Vector3 _debug_normal;
        private Vector3 _debug_vel;
        #endif

        public override PlayerBallState BallState { get; set; }

        public void SetConfig(PlayerBallConfig config)
        {
            _config = config;
        }

        public override void Launch()
        {
            _rb.isKinematic = false;
            
            var dir = Vector3.up;
            dir.x = .2f;
            dir = dir.normalized;
            _rb.AddForce(dir * _config.Speed, ForceMode.VelocityChange);

            BallState = PlayerBallState.Moving;
        }

        public override void RegisterCollision()
        {
            
        }
        
        private void OnValidate()
        {
            if (_rb == null)
            {
                _rb = GetComponent<Rigidbody>();
            }
        }

        private void Start()
        {
            BallState = PlayerBallState.Idle;
        }

        private void FixedUpdate()
        {
            _lastVel = _rb.velocity.normalized;
        }

        private void Bounce(Vector3 dir)
        {
            _rb.velocity = Vector3.zero;
            _rb.AddForce(dir * _config.Speed, ForceMode.VelocityChange);
        }

        private void OnCollisionEnter(Collision other)
        {
            other.GetContacts(_collContacts);

            var bounce = other.gameObject.GetComponent<IBounce>();
            Bounce(bounce.BounceDirection(
                transform, 
                other.transform, 
                other, -_lastVel, _collContacts[0].normal));
            
            #if UNITY_EDITOR
            _debug_dir = _rb.velocity.normalized;
            _debug_normal = _collContacts[0].normal;
            _debug_vel = -_lastVel;
            #endif
            
            var dmg = other.gameObject.GetComponent<IImpact>();
            if (dmg == null) return;
            
            dmg.Impact(1);
        }

        #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (!Application.isPlaying) return;
            
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, transform.position + _debug_dir * 2f);
            Gizmos.DrawWireSphere( transform.position + _debug_dir * 2f, 0.1f);
            
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + _debug_normal * 2f);
            Gizmos.DrawWireSphere( transform.position + _debug_normal * 2f, 0.1f);
            
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + _debug_vel * 2f);
            Gizmos.DrawWireSphere( transform.position + _debug_vel * 2f, 0.1f);
        }
        #endif
    }
}