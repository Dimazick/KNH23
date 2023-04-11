using UnityEngine;
using System;

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
                TheEndOfCounts.Invoke();
            }
            _counter.DisplayDecrementAttemptCount(_countOfChanses);
        }

       // public void IncrementOfCounts()
        //{
         //   _countOfChanses++;
         //   _counter.DisplayIncrementAttemptCount(_countOfChanses);
       // }
        
        public int GetChances()
        {
            return  _countOfChanses;
        }

       
        
    }
}
