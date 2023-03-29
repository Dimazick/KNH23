using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class AttemptCounterFunctional : MonoBehaviour
    {
        [SerializeField] private int _countOfChanses;
        [SerializeField] private AttemptCounterVisual _counter;
        [SerializeField] private GameObject _target;
        private Vector2 _targetPosition = new Vector2(0, 2.5f);

        private void Awake()
        {
            _counter.SetDisplayAttemptCount(_countOfChanses);
            SpawnTarget();
        }

        private void OnEnable()
        {
            InputSystem.Touch.OnTouched += DecrementOfCounts;
        }

        private void OnDisable()
        {
            InputSystem.Touch.OnTouched -= DecrementOfCounts;
        }

        public int GetCounts()
        {
            return _countOfChanses;
        }

        public void DecrementOfCounts()
        {
            _countOfChanses--;
            _counter.DisplayDecrementAttemptCount(_countOfChanses);
        }

        public void IncrementOfCounts()
        {
            _countOfChanses++;
            _counter.DisplayIncrementAttemptCount(_countOfChanses);
        }

        private void SpawnTarget()
        {
            _target = Instantiate(_target, _targetPosition, Quaternion.identity);
        }
    }
}
