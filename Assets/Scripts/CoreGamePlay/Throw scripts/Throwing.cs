using KNH23.CoreGamePlay.Detection;
using UnityEngine;

namespace KNH23.CoreGamePlay
{
    [RequireComponent (typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Throwing : MonoBehaviour
    {
        [SerializeField] private bool _isActive = true;

        private BoxCollider2D _collider2d;
        private Rigidbody2D _rigidbody;

        private ForceOfThrow _forceOfThrow;
                
       
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

            var detector = collision.gameObject.GetComponent<IDetectorCollision>();
            if (detector == null) return;

            detector.BehaviourDetector();  

        }

    }
       
}
