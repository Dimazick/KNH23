using UnityEngine;


namespace KNH23
{
    public class AttemptCounterVisual : MonoBehaviour
    {
        [SerializeField] private GameObject _panelOfThrow;
        [SerializeField] private GameObject _iconOfAttempt;
       

        public void SetDisplayAttemptCount(int count)
        {
            for (int i = 0; i < count; i++)
                Instantiate(_iconOfAttempt, _panelOfThrow.transform);
        }
                
        public void DisplayDecrementAttemptCount(int count)
        {
            _panelOfThrow.transform.GetChild(count).gameObject.SetActive(false);
        }

        public void DisplayIncrementAttemptCount(int _startCount )
        {
            for (int i = 0; i < _startCount; i++)
                _panelOfThrow.transform.GetChild(i).gameObject.SetActive(true);
        }

    }
}
