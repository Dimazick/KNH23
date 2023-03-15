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

        public void ThrowingObject() // ��������� ���� �� ��� ���� � ������ � ����.
        {
           _activeThrowObject.Throw();              
        }

       
        private void SpawnThrowObject() // ��������� ���������� ��������� ����� �� ������ � ������� 1 �����.
        {
           _throwObjectsCount--;
            if (_throwObjectsCount == 0) return;
            
            Throwing obj = Instantiate(_objectForThrowPrefab, _spawnPosition, Quaternion.identity); // ������ ������ ���� � ������� � ������� ������.
            _activeThrowObject = obj;// ������������ ����������� ������ �� ���� ��������� ������.
        }
    }
}
