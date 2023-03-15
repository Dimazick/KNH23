using UnityEngine;
using UnityEngine.UI;

namespace KNH23
{
    public class AttemptCounter : MonoBehaviour
    {
        [SerializeField] private GameObject _panelOfThrow;
        [SerializeField] private GameObject _iconOfAttempt;
        [SerializeField] private Color _usedAttemptColor;
        private int _throwObjectIconIndexToChange = 0;

        public void SetDisplayAttemptCount(int count)
        {
            for (int i = 0; i < count; i++)
                Instantiate(_iconOfAttempt, _panelOfThrow.transform);
        }
                
        public void DecrementDisplayAttemptCount()
        {
            _panelOfThrow.transform.GetChild(_throwObjectIconIndexToChange++).GetComponent<Image>().color = _usedAttemptColor;
        }

    }
}
