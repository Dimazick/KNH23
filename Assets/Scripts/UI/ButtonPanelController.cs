using System.Collections;
using UnityEngine;


namespace KNH23.UI
{
    public class ButtonPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject _resstartButton;
        [SerializeField] private GameObject _startButton;
        [SerializeField] private GameObject _mainMenuButton;
        [SerializeField] private GameObject _nextLevelButton;
        

        private void OnEnable()
        {
            CoreGamePlay.Detection.ObstacleCollisionDetector.OnCollisionWintobstacle += ShowResstartButton;
        }

        private void OnDisable()
        {
            CoreGamePlay.Detection.ObstacleCollisionDetector.OnCollisionWintobstacle -= ShowResstartButton;
        }


        private IEnumerator WaitingForWatch(GameObject _someObject)
        {
            yield return new WaitForSecondsRealtime(1);
            _someObject.SetActive(true);
        }

       
        public void ShowResstartButton()
        {
           StartCoroutine(WaitingForWatch(_resstartButton));

        }

        public void DontShowStartButton()
        {
            if (_startButton.gameObject.activeInHierarchy)
            {
                _startButton.SetActive(false);
                
            }
           
        }

        public void DontShowResstartButton()
        {
            if (_resstartButton.gameObject.activeInHierarchy)
            {
                _resstartButton.SetActive(false);
            }
           
        }

        public void ShowStartButton()
        {
            _startButton.SetActive(true);
           
        }

        public void ShowMenuButton()
        {
            _mainMenuButton.SetActive(true);
        }

        public void DontShowMenuButton()
        {
            if (_mainMenuButton.gameObject.activeInHierarchy)
            {
                _mainMenuButton.SetActive(false);
            }
        }

        

        public void ShowNextLevelButton()
        {
            StartCoroutine(WaitingForWatch(_nextLevelButton));
        }

        public void DontShowNextLevelButton()
        {
            if (_nextLevelButton.gameObject.activeInHierarchy)
            {
                _nextLevelButton.SetActive(false);
            }
        }


    }
}
