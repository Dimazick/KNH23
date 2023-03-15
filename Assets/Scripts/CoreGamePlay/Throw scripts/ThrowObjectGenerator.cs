using UnityEngine;

namespace KNH23.CoreGamePlay
{
    public class ThrowObjectGenerator : MonoBehaviour
    {

        [SerializeField] int _throwObjectsCount;
        [SerializeField] Vector2 _spawnPosition = new Vector2(0, -3);
        [SerializeField] GameObject _ObjectForThrowPrefab;
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
           _activeThrowObject.ThrowThisObject();              
        }

       
        private void SpawnThrowObject() // ��������� ���������� ��������� ����� �� ������ � ������� 1 �����.
        {
           _throwObjectsCount--; 
            if(_throwObjectsCount >= 0)
            Instantiate(_ObjectForThrowPrefab, _spawnPosition, Quaternion.identity); // ������ ������ ���� � ������� � ������� ������.
            _activeThrowObject = FindObjectOfType<Throwing>();// ������������ ����������� ������ �� ���� ��������� ������.
        }




    }
}
