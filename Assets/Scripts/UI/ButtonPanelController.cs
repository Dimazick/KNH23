using System.Collections;
using UnityEngine;


namespace KNH23.UI
{
    public class ButtonPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject _resstartButton;

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
            yield return new WaitForSeconds(2);
            _resstartButton.SetActive(true);
        }

       
        public void ShowResstartButton()
        {
           StartCoroutine(LittleBitWait());
        }
    }
}
