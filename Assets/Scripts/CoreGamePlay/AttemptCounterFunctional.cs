using UnityEngine;
using System;
using System.Collections;

namespace KNH23.CoreGamePlay
{
    public class AttemptCounterFunctional : MonoBehaviour
    {
        [SerializeField] private int _countOfChanses;
        
        [SerializeField] private AttemptCounterVisual _counter;
        [SerializeField] private TargetMotionData _targetMotionData;

        public static event Action TheEndOfCounts;

        private void Awake()
        {
            _targetMotionData = GameObject.FindObjectOfType<TargetMotionData>();
        }

        public void SettingCounts()
        {
            int _startCountIndex = _targetMotionData.GetLevel();
            _countOfChanses = _targetMotionData.GetLevelMotionSettings(_startCountIndex).GetStartCounts();
            Debug.Log("Level = " + _targetMotionData.GetLevelMotionSettings(_startCountIndex) + " _countOf Chances = " + _countOfChanses);
        }

        private void OnEnable()
        {
            InputSystem.Touch.OnTouched += DecrementOfCounts;
        }

        private void OnDisable()
        {
            InputSystem.Touch.OnTouched -= DecrementOfCounts;
        }

        

        

        public void DecrementOfCounts()
        {
            _countOfChanses--;
            if(_countOfChanses == 0)
            {
                StartCoroutine(WaitToMessage());
            }
            _counter.DisplayDecrementAttemptCount(_countOfChanses);
        }

       private IEnumerator WaitToMessage()
       {
            yield return new WaitForSecondsRealtime(1.2f);
            TheEndOfCounts.Invoke();
       }
        
        public int GetChances()
        {
            return  _countOfChanses;
        }

       
        
    }
}
