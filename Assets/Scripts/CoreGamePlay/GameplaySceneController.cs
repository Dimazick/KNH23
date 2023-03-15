using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class GameplaySceneController : MonoBehaviour
    {
        [SerializeField] private int _countOfChanses;
        [SerializeField] private AttemptCounter _counter;

        private void Start()
        {
            _counter.SetDisplayAttemptCount(_countOfChanses);
        }

        private void OnEnable()
        {
            InputSystem.Touch.OnTouched += _counter.DecrementDisplayAttemptCount;
        }

        private void OnDisable()
        {
            InputSystem.Touch.OnTouched -= _counter.DecrementDisplayAttemptCount;
        }

        public int GetCounts()
        {
            return _countOfChanses;
        }




    }
}
