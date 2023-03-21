using System;
using UnityEngine;

namespace KNH23.CoreGamePlay
{
    [RequireComponent (typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Throwing : MonoBehaviour, IDetector
    {
        [SerializeField] private bool _isActive = true;

        private BoxCollider2D _collider2d;
        private Rigidbody2D _rigidbody;

        private ForceOfThrow _forceOfThrow;
                
        public static event Action OnCollisionWintobstacle;


        void Awake()
        {
            _forceOfThrow = new ForceOfThrow();
            
            _collider2d = GetComponent<BoxCollider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
           
        }

        
        public void Throw()
        {
            if (_isActive)
            {
                _rigidbody.AddForce(_forceOfThrow.MidForce(),
                    ForceMode2D.Impulse);
                _rigidbody.gravityScale = 1;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_isActive)
                return;

            _isActive = false;

            var detector = collision.gameObject.GetComponent<IDetector>();
            if (detector == null) return;

            detector.BehaviourDetector();            


        }

        public void BehaviourDetector()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -2);
            Debug.Log("GameOver!!!");
            OnCollisionWintobstacle.Invoke();
        }

        public void BecomeTheObstacle(Collision2D someObject)
        {
            _isActive = false;
            _rigidbody.velocity = new Vector2(0, 0);
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
            _rigidbody.simulated = false;
            transform.SetParent(someObject.collider.transform);

            _collider2d.offset = new Vector2(_collider2d.offset.x, -0.4f);
            _collider2d.size = new Vector2(_collider2d.size.x - 0.1f, 1.2f);
        }
    }

    public interface IDetector
    {
        void BehaviourDetector();
    }
}
