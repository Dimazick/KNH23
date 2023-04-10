using System;
using UnityEngine;

namespace KNH23.CoreGamePlay.Detection
{
    public class ObstacleCollisionDetector : MonoBehaviour, IDetectorCollision
    {
        public static event Action OnCollisionWintobstacle;
        private Vector2 _goDown = new Vector2(0, -3);

        public void BehaviourDetector()
        {
            Debug.Log("GameOver!!!");
            OnCollisionWintobstacle.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = _goDown;
        }



    }
}
