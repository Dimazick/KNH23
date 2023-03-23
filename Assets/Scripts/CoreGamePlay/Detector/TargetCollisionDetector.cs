using System;
using UnityEngine;

namespace KNH23.CoreGamePlay.Detection
{
    public class TargetCollisionDetector : MonoBehaviour, IDetectorCollision
    {
        public static event Action OnCollisionWithTarget;
        [SerializeField] private ObstacleCollisionDetector _obstacle;
        private Vector2 _obstacleSpawnPosition;

        public void BehaviourDetector()
        {
            Debug.Log(" Collision with TARGET");
            _obstacleSpawnPosition = new Vector2(transform.position.x, transform.position.y - 1.4f);
            ObstacleCollisionDetector obj = Instantiate(_obstacle, _obstacleSpawnPosition, Quaternion.identity);
            obj.transform.SetParent(transform);
            OnCollisionWithTarget.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(collision.gameObject);
        //    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //    collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        //    collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;

        //    collision.transform.SetParent(transform);
        //    collision.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.3f);
        //    collision.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 1.5f);
        }


    }
}
