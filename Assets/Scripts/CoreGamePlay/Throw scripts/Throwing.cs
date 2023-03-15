using System;
using UnityEngine;

namespace KNH23.CoreGamePlay
{
    [RequireComponent (typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]

    public class Throwing : MonoBehaviour
    {
        [SerializeField] private bool _isActive = true;

        public BoxCollider2D ThrowCollider { get; private set; }
        public Rigidbody2D ThrowObjectBody { get; private set; }

        private ForceOfThrow _forceOfThrow;

        public static event Action OnCollisionWithTarget;
        public static event Action OnCollisionWintobstacle;


        void Awake()
        {
            _forceOfThrow = new ForceOfThrow();
            
            ThrowCollider = GetComponent<BoxCollider2D>();
            ThrowObjectBody = GetComponent<Rigidbody2D>();
           
        }

        public void ThrowThisObject()
        {
            if (_isActive)
            {
                ThrowObjectBody.AddForce(_forceOfThrow.MidForce(),
                    ForceMode2D.Impulse);
                ThrowObjectBody.gravityScale = 1;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(" Collision is complette");
            if (!_isActive)
                return;

            _isActive = false;

            if (collision.collider.tag == "Target")
            {

                Debug.Log(" Collision with TARGET");
                ThrowObjectBody.velocity = new Vector2(0, 0);
                ThrowObjectBody.bodyType = RigidbodyType2D.Kinematic;
                transform.SetParent(collision.collider.transform);

                ThrowCollider.offset = new Vector2(ThrowCollider.offset.x, -0.4f);
                ThrowCollider.size = new Vector2(ThrowCollider.size.x - 0.1f, 1.2f);

                OnCollisionWithTarget.Invoke();
                             
            }

            else if (collision.collider.tag != "Target")
            {
                ThrowObjectBody.velocity = new Vector2(ThrowObjectBody.velocity.x, -2);
                Debug.Log("GameOver!!!");
                OnCollisionWintobstacle.Invoke();
                
            }

            
        }
        
    }
}
