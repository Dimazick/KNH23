using System.Collections;
using UnityEngine;
using KNH23.CoreGamePlay;

namespace KNH23.UI
{
    public class PanelController : MonoBehaviour
    {
        [SerializeField] private GameObject _resstartButton;

        private void OnEnable()
        {
            Throwing.OnCollisionWintobstacle += ShowResstartButton;
        }

        private void OnDisable()
        {
            Throwing.OnCollisionWintobstacle -= ShowResstartButton;
        }


        private IEnumerator LittleBitWait()
        {
            yield return new WaitForSeconds(5);
            _resstartButton.SetActive(true);
        }

       
        public void ShowResstartButton()
        {
           StartCoroutine(LittleBitWait());
        }
    }
}
