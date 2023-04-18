
using KNH23.UI.Buttons;
using UnityEngine;


namespace KNH23.CoreGamePlay
{
    public class LevelMotionData : MonoBehaviour
    {
        [System.Serializable]
        public class MotionData
        {
            [SerializeField] public float _speed { get; private set; }
            [SerializeField] public float _duration { get; private set; }

            public void SetDuration(float value)
            {
                _duration = value;
            }

            public void SetSpeed(float value)
            {
                _speed = value;
            }
        }

        [SerializeField] private MotionData[] _motionPattern;
        [SerializeField] public int Level;
        [SerializeField] private int _dataLength;

        private void Start()
        {
            MotionData[] _motionPattern = new MotionData[_dataLength];
        }


        public void SetDataForLevel()
        {
           switch (Level)
            {
                case 1:
                    _dataLength = 4;                    
                    _motionPattern[0].SetDuration(2.5f);
                    _motionPattern[0].SetSpeed(250);
                    _motionPattern[1].SetDuration(1.5f);
                    _motionPattern[1].SetSpeed(-350);
                    _motionPattern[2].SetDuration(2.2f);
                    _motionPattern[2].SetSpeed(427);
                    _motionPattern[3].SetDuration(1.7f);
                    _motionPattern[3].SetSpeed(250);
                                        
                    break;

                case 2:
                    _dataLength = 6;
                    _motionPattern[0].SetDuration(2.7f);
                    _motionPattern[0].SetSpeed(350);
                    _motionPattern[1].SetDuration(1.8f);
                    _motionPattern[1].SetSpeed(-310);
                    _motionPattern[2].SetDuration(1.2f);
                    _motionPattern[2].SetSpeed(320);
                    _motionPattern[3].SetDuration(2.3f);
                    _motionPattern[3].SetSpeed(390);
                    _motionPattern[4].SetDuration(2.5f);
                    _motionPattern[4].SetSpeed(250);
                    _motionPattern[5].SetDuration(1.5f);
                    _motionPattern[5].SetSpeed(-350);
                    
                    break;

                default:
                    _dataLength = 6;
                    _motionPattern[0].SetDuration(_motionPattern[0]._duration +0.2f);
                    _motionPattern[0].SetSpeed(_motionPattern[0]._speed+33);
                    _motionPattern[1].SetDuration(_motionPattern[1]._duration + 0.2f);
                    _motionPattern[1].SetSpeed(_motionPattern[1]._speed - 43);
                    _motionPattern[2].SetDuration(_motionPattern[2]._duration + 0.3f);
                    _motionPattern[2].SetSpeed(_motionPattern[2]._speed + 83);
                    _motionPattern[3].SetDuration(_motionPattern[3]._duration + 0.1f);
                    _motionPattern[3].SetSpeed(_motionPattern[3]._speed + 35);
                    _motionPattern[4].SetDuration(_motionPattern[4]._duration + 0.4f);
                    _motionPattern[4].SetSpeed(_motionPattern[4]._speed + 33);
                    _motionPattern[5].SetDuration(_motionPattern[5]._duration + 0.1f);
                    _motionPattern[5].SetSpeed(_motionPattern[5]._speed - 53);

                    break;

           }
          
        }

        public float GetDurationFromData(int i)
        {
            return _motionPattern[i]._duration;
        }

        public float GetRotationSpeedFromData(int i)
        {
            return _motionPattern[i]._speed;
        }

        public int GetLengthOfData()
        {
            return _motionPattern.Length;
        }

        public void IncrementLevel()
        {
            Level += 1;
        }
        private void OnEnable()
        {
            LevelButton.NextLevel += IncrementLevel;
            LevelButton.NextLevel += SetDataForLevel;
            UIStartButton.StartGameplay += SetDataForLevel;
        }

        private void OnDisable()
        {
            LevelButton.NextLevel -= IncrementLevel;
            LevelButton.NextLevel -= SetDataForLevel;
            UIStartButton.StartGameplay -= SetDataForLevel;

        }
    }
}
