using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class TargetMotionData 
    {
        [SerializeField] private int _duration;
        [SerializeField] private int _rotarySpeed;

        public int GetRotationSpeed()
        {
            return _rotarySpeed;
        }

        public int GetDuration()
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
}
