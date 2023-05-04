using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class TargetMotionData: MonoBehaviour
        
    {
               
        [SerializeField] private LevelMotionSettings[] _levelMotionSettings;
        [SerializeField] private int _level;

        public int GetLevel()
        {
            return _level;

        }
        public void SetLevel(int value)
        {
            _level = value;
        }

        public void IncrementLevel()
        {
            if (_level+1 < _levelMotionSettings.Length)
                _level += 1;
            else
            {
                _level = 0;
            }
            Debug.Log("now level is " + _level);
        }

        private void OnDisable()
        {
            UI.Buttons.UILevelButton.NextLevel -= IncrementLevel;
        }
        private void OnEnable()
        {
            UI.Buttons.UILevelButton.NextLevel += IncrementLevel;
        }

        public LevelMotionSettings GetLevelMotionSettings(int level)
        {
            return _levelMotionSettings[level];
        }

        
    }


}
