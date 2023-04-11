using UnityEngine;
using System.Collections;


namespace KNH23.EfectSystem
{
    public class EfectSystemController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _successHit;
        [SerializeField] private ParticleSystem _gamover;
        [SerializeField] private ParticleSystem _finishLevel;

        private void OnEnable()
        {
            CoreGamePlay.Detection.ObstacleCollisionDetector.OnCollisionWintobstacle += PlayGamover;
            CoreGamePlay.Detection.TargetCollisionDetector.OnCollisionWithTarget += PlaySuccess;
            SceneController.SuccesLevel += PlayFinish;
        }

        private void OnDisable()
        {
            CoreGamePlay.Detection.ObstacleCollisionDetector.OnCollisionWintobstacle -= PlayGamover;
            CoreGamePlay.Detection.TargetCollisionDetector.OnCollisionWithTarget -= PlaySuccess;
            SceneController.SuccesLevel -= PlayFinish;
        }

        private void PlayFinish()
        {
            StartCoroutine(ShowCongradilations());
        }


        private void PlayGamover()
        {
            _gamover.Play();
        }

        private void PlaySuccess()
        {
            _successHit.Play();

        }

        private IEnumerator ShowCongradilations()
        {
            yield return new WaitForSeconds(0.5f);
            _finishLevel.Play();
        }
    }
}
