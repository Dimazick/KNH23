using UnityEngine;
using KNH23.CoreGamePlay.Detection;

namespace KNH23.CoreGamePlay
{
    public class ThrowObjectGenerator : MonoBehaviour
    {

        [SerializeField] Vector2 _spawnPosition = new Vector2(0, -3);
        [SerializeField] Throwing _objectForThrowPrefab;
        [SerializeField] Throwing _activeThrowObject;
        [SerializeField] AttemptCounterFunctional __attemptCounter;

        private void Start()
        {
           SpawnThrowObject();
            
        }

        private void OnEnable()
        {
          InputSystem.Touch.OnTouched += ThrowingObject;
          TargetCollisionDetector.OnCollisionWithTarget += SpawnThrowObject;

        }

        private void OnDisable()
        {
            InputSystem.Touch.OnTouched -= ThrowingObject;
            TargetCollisionDetector.OnCollisionWithTarget -= SpawnThrowObject;          
        }

        public void ThrowingObject() // проверяет есть ли еще ножи и кидает в цель.
        {
           _activeThrowObject.Throw();              
        }

       
        public void SpawnThrowObject() // уменьшает количество доступных ножей на уровне и спавнит 1 новый.
        {
            
            if (__attemptCounter.GetChances() == 0) return;
            
            Throwing obj = Instantiate(_objectForThrowPrefab, _spawnPosition, Quaternion.identity); // возьми префаб ножа и поставь в позицию спавна.
            _activeThrowObject = obj;// переписываем появившийся префаб на роль метаемого заряда.
        }
    }
}
