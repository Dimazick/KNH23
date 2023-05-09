using System;
using UnityEngine;

namespace KNH23.CoreGamePlay.Detection
{
    public class TargetCollisionDetector : MonoBehaviour, IDetectorCollision
    {
        public static event Action OnCollisionWithTarget;
       

        public void BehaviourDetector()
        {
           OnCollisionWithTarget.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
           
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
           

            collision.transform.SetParent(transform);
            collision.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.3f);
            collision.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.22f, 1.5f);
        }


    }
}
