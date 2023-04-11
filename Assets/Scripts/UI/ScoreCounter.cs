using UnityEngine;
using TMPro;

namespace KNH23.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        private int _points = 0;
        private TMP_Text _text;
        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponent<TMP_Text>();
            
        }

        private void OnEnable()
        {
            CoreGamePlay.Detection.TargetCollisionDetector.OnCollisionWithTarget += PointsIncrement;
        }

        private void OnDisable()
        {
            CoreGamePlay.Detection.TargetCollisionDetector.OnCollisionWithTarget -= PointsIncrement;
        }

        private void PointsIncrement()
        {
            _points += 1;
            _text.text = "Score: " + _points.ToString();
        }

        public void ResetPoints()
        {
            _points = 0;
            _text.text = "Score: " + _points.ToString();
        }

        public int GetPoints()
        {
            return _points;
        }
    }
}
