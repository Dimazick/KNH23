using UnityEngine;


namespace KNH23.EfectSystem
{
    public class EfectSystem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _successHit;
        [SerializeField] private ParticleSystem _gamover;

        private void OnEnable()
        {
           CoreGamePlay.Detection.ObstacleCollisionDetector.OnCollisionWintobstacle += PlayGamover;
           CoreGamePlay.Detection.TargetCollisionDetector.OnCollisionWithTarget += PlaySuccess;
        }

        private void OnDisable()
        {
            CoreGamePlay.Detection.ObstacleCollisionDetector.OnCollisionWintobstacle -= PlayGamover;
            CoreGamePlay.Detection.TargetCollisionDetector.OnCollisionWithTarget -= PlaySuccess;
        }

       

        public void PlayGamover()
        {
            _gamover.Play();
        }

        public void PlaySuccess()
        {
            _successHit.Play();
           
        }
    }
}
