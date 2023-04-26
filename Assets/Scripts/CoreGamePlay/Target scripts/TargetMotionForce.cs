using System.Collections;
using UnityEngine;

namespace KNH23.CoreGamePlay
{
    [RequireComponent(typeof(WheelJoint2D))]
    
    public class TargetMotionForce : MonoBehaviour
    {
               
            
        [SerializeField] private TargetMotionData _targetMotionData;
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
            var _endIndex = _targetMotionData.GetLevelMotionSettings(_targetMotionData.GetLevel()).GetThisLength();
            Debug.Log("_endIndex = "+ _endIndex);
            while (true)
            {
                yield return new WaitForFixedUpdate();

                _rotationMotor.motorSpeed = _targetMotionData.GetLevelMotionSettings(_targetMotionData.GetLevel()).GetThisSpeed(_rotationIndex);
                _rotationMotor.maxMotorTorque = 10000;
                _rotationJoint.motor = _rotationMotor;

                yield return new WaitForSecondsRealtime(_targetMotionData.GetLevelMotionSettings(_targetMotionData.GetLevel()).GetThisDuration(_rotationIndex));
                _rotationIndex++;

                _rotationIndex = _rotationIndex < _endIndex ? _rotationIndex : 0;

            }
        }
    }
}
