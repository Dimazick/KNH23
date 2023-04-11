using UnityEngine;
using System;
using System.Collections;

namespace KNH23.CoreGamePlay
{
    public class AttemptCounterFunctional : MonoBehaviour
    {
        [SerializeField]  private int _countOfChanses;
        [SerializeField] private int _startCounts;
        [SerializeField] private AttemptCounterVisual _counter;
        public static event Action TheEndOfCounts;

        
        private void OnEnable()
        {
            InputSystem.Touch.OnTouched += DecrementOfCounts;
        }

        private void OnDisable()
        {
            InputSystem.Touch.OnTouched -= DecrementOfCounts;
        }

        public int GetStartCounts()
        {
            return _startCounts;
        }

        public void SetCounts()
        {
            _countOfChanses = _startCounts;
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
