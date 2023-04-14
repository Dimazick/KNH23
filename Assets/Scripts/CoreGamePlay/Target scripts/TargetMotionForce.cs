using System.Collections;
using UnityEngine;

namespace KNH23.CoreGamePlay
{
    [RequireComponent(typeof(WheelJoint2D))]
    public class TargetMotionForce : MonoBehaviour
    {

        [SerializeField] private TargetMotionData[] _motionData;
        private WheelJoint2D _rotationJoint;
        private JointMotor2D _rotationMotor;



        private void Awake()
        {
            _rotationJoint = GetComponent<WheelJoint2D>();
            _rotationMotor = new JointMotor2D();
            StartCoroutine(PlayRotation());
            
        }


        private IEnumerator PlayRotation()
        {
            int _rotationIndex = 0;
            while (true)
            {
                yield return new WaitForFixedUpdate();

                _rotationMotor.motorSpeed = _motionData[_rotationIndex].GetRotationSpeed();
                _rotationMotor.maxMotorTorque = 10000;
                _rotationJoint.motor = _rotationMotor;

                yield return new WaitForSecondsRealtime(_motionData[_rotationIndex].GetDuration());
                _rotationIndex++;

                _rotationIndex = _rotationIndex < _motionData.Length ? _rotationIndex : 0;

            }
        }
    }
}
