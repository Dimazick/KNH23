using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class ThrowObjectGenerator : MonoBehaviour
    {

        [SerializeField] int _throwObjectsCount;
        [SerializeField] Vector2 _spawnPosition = new Vector2(0, -3);
        [SerializeField] Throwing _objectForThrowPrefab;
        [SerializeField] Throwing _activeThrowObject;
        [SerializeField] GameplaySceneController _gamePlayController;

        private void Start()
        {
           SpawnThrowObject();
            _throwObjectsCount = _gamePlayController.GetCounts();
        }

        private void OnEnable()
        {
          InputSystem.Touch.OnTouched += ThrowingObject;
          Throwing.OnCollisionWithTarget += SpawnThrowObject;

        }

        private void OnDisable()
        {
            InputSystem.Touch.OnTouched -= ThrowingObject;
            Throwing.OnCollisionWithTarget -= SpawnThrowObject;          
        }

        public void ThrowingObject() // проверяет есть ли еще ножи и кидает в цель.
        {
           _activeThrowObject.Throw();              
        }

       
        private void SpawnThrowObject() // уменьшает количество доступных ножей на уровне и спавнит 1 новый.
        {
           _throwObjectsCount--;
            if (_throwObjectsCount == 0) return;
            
            Throwing obj = Instantiate(_objectForThrowPrefab, _spawnPosition, Quaternion.identity); // возьми префаб ножа и поставь в позицию спавна.
            _activeThrowObject = obj;// переписываем появившийся префаб на роль метаемого заряда.
        }
    }
}
