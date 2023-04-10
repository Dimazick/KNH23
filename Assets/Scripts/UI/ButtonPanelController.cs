using System.Collections;
using UnityEngine;


namespace KNH23.UI
{
    public class ButtonPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject _resstartButton;
        [SerializeField] private GameObject _startButton;
        [SerializeField] private GameObject _mainMenuButton;

        private void OnEnable()
        {
            CoreGamePlay.Detection.ObstacleCollisionDetector.OnCollisionWintobstacle += ShowResstartButton;
        }

        private void OnDisable()
        {
            CoreGamePlay.Detection.ObstacleCollisionDetector.OnCollisionWintobstacle -= ShowResstartButton;
        }


        private IEnumerator LittleBitWait()
        {
            yield return new WaitForSeconds(1);
            _resstartButton.SetActive(true);
        }

       
        public void ShowResstartButton()
        {
           StartCoroutine(LittleBitWait());

        }

        public void DontShowStartButton()
        {
            _startButton.SetActive(false);
        }

        public void DontShowResstartButton()
        {
            _resstartButton.SetActive(false);
        }
    }
}
