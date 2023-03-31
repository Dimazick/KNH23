using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class TargetMotionForce : MonoBehaviour
    {
        
        private Rigidbody2D _logBody;
        private TargetMotionData _rotationVector;
        [SerializeField] [Range(0, 20)] private float _rotationSpeed;


        private void Start()
        {
           
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

        private void FixedUpdate()
        {
            GetRotationLeft();
        }
    }
}
