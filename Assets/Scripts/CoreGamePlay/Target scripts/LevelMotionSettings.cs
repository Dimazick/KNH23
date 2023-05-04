using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class LevelMotionSettings : MonoBehaviour
    {
        
        [System.Serializable]
        private class MotionSettings
        {
            
            [SerializeField] private float _duration;
            [SerializeField] private float _rotarySpeed;
            
           

            public float GetRotationSpeed()
            {
                return _rotarySpeed;
            }

            public float GetDuration()
            {
                return _duration;
            }

            public void SetDuration(int data)
            {
                _duration = data;
            }

            public void SetRotationSpeed(int data)
            {
                _rotarySpeed = data;

            }
        }
                
        [SerializeField] private MotionSettings[] _motionData;

        public float GetThisSpeed(int index)
        {
            return _motionData[index].GetRotationSpeed();
        }

        public float GetThisDuration(int index)
        {
            return _motionData[index].GetDuration();
        }

        public int GetThisLength()
        {
            return _motionData.Length;
        }
        
        


    }
}
