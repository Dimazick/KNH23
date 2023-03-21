using UnityEngine;


namespace KNH23.EfectSystem
{
    public class EfectSystem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _successHit;
        [SerializeField] private ParticleSystem _gamover;

        private void OnEnable()
        {
           KNH23.CoreGamePlay.Throwing.OnCollisionWintobstacle += PlayGamover;
           KNH23.CoreGamePlay.TargetCollisionDetector.OnCollisionWithTarget += PlaySuccess;
        }

        private void OnDisable()
        {
            KNH23.CoreGamePlay.Throwing.OnCollisionWintobstacle -= PlayGamover;
            KNH23.CoreGamePlay.TargetCollisionDetector.OnCollisionWithTarget -= PlaySuccess;
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
