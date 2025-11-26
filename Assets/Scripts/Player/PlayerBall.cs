using Arkanoid.Data;
using Arkanoid.States;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerBall : PlayerBallObjectAbstract, IPlayerBallConfig
    {
        [SerializeField, HideInInspector] private Rigidbody _rb;
        
        private EventDispatcher _dispatcher;
        
        private PlayerBallConfig _config;
        private Vector3 _lastBounceDir;
        private ContactPoint[] _collContacts = new ContactPoint[1];

        private float _runningVelSqr;
        
        #if UNITY_EDITOR
        private Vector3 _debug_dir;
        private Vector3 _debug_normal;
        private Vector3 _debug_bounce_dir;
        #endif

        public override PlayerBallState BallState { get; set; }

        public void SetConfig(PlayerBallConfig config)
        {
            _config = config;
        }

        public override void Launch()
        {
            _rb.isKinematic = false;
            
            _rb.AddForce(Vector3.up * _config.Speed, ForceMode.VelocityChange);

            _lastBounceDir = Vector3.up;
            _runningVelSqr = 1f;

            BallState = PlayerBallState.Moving;
            
        }

        public override void Stop()
        {
            _rb.isKinematic = true;
            BallState = PlayerBallState.Stopped;
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
            
            // как бы DI.
            Initialize(EventDispatcherObject.Instance.Dispatcher);
        }

        private void FixedUpdate()
        {
            _runningVelSqr = (_runningVelSqr + _rb.velocity.sqrMagnitude) / 2f;

            if (BallState == PlayerBallState.Moving && _runningVelSqr < 0.01f)
            {
                Debug.Log("Ooops, we're stuck");
                _dispatcher.OnLose?.Invoke();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (BallState != PlayerBallState.Moving) return;
            
            other.GetContacts(_collContacts);

            var bounce = other.gameObject.GetComponent<IBounce>();
            _lastBounceDir = bounce.BounceDirection(
                transform,
                other.transform,
                other, -_lastBounceDir, _collContacts[0].normal);
            Bounce(_lastBounceDir);

            #if UNITY_EDITOR
            _debug_dir = _rb.velocity.normalized;
            _debug_normal = _collContacts[0].normal;
            _debug_bounce_dir = -_lastBounceDir;
            #endif
            
            var dmg = other.gameObject.GetComponent<IImpact>();
            if (dmg == null) return;
            
            dmg.Impact(_config.Damage);
        }
        
        private void Bounce(Vector3 dir)
        {
            _rb.AddForce(dir * _config.Speed, ForceMode.VelocityChange);
        }

        /// <summary>
        /// Притворимся, что DI у нас есть.
        /// </summary>
        private void Initialize(EventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
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
            Gizmos.DrawLine(transform.position, transform.position + _debug_bounce_dir * 2f);
            Gizmos.DrawWireSphere( transform.position + _debug_bounce_dir * 2f, 0.1f);
        }
        #endif
    }
}