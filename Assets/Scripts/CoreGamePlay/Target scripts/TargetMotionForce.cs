using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class TargetMotionForce : MonoBehaviour
    {
        private CircleCollider2D _collider;
        private Rigidbody2D _logBody;
        private TargetMotionData _rotationVector;
        private float _rotationSpeed = 0.5f;


        private void Start()
        {
            _collider = GetComponent<CircleCollider2D>();
            _logBody = GetComponent<Rigidbody2D>();
            _rotationVector = new TargetMotionData();
        }

        public void GetRotationLeft()
        {
            _logBody.AddTorque(_rotationSpeed *_rotationVector.LeftDirection());
        }

        public void GetRotationRight()
        {
            _logBody.AddTorque(_rotationSpeed * _rotationVector.RightDirection());
        }

        private void Update()
        {
            GetRotationLeft();
        }
    }
}
