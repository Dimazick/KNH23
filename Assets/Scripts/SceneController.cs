using KNH23.EfectSystem;
using UnityEngine;
using KNH23.CoreGamePlay;

namespace KNH23
{
    public class SceneController : MonoBehaviour
    {
       [SerializeField] private GameObject _target;
       private Vector2 _targetPosition = new Vector2(0, 2.5f);
       [SerializeField] private ThrowObjectGenerator _throwObjectGenerator;
       [SerializeField] private EfectSystemController _effects;
       [SerializeField] private AttemptCounterFunctional _attemptCounterFunctional;
       [SerializeField] private AttemptCounterVisual _attemptCounterVisual;


        private void SpawnTarget()
        {
            _target = Instantiate(_target, _targetPosition, Quaternion.identity);
        }
        private void StartGamePlay()
        {
            _throwObjectGenerator.gameObject.SetActive(true);
            _effects.gameObject.SetActive(true);
            _attemptCounterFunctional.gameObject.SetActive(true);
            _attemptCounterVisual.gameObject.SetActive(true);
        }
        
        private void OnEnable()
        {
            UI.Buttons.UIStartButton.StartGameplay += StartGamePlay;
            UI.Buttons.UIStartButton.StartGameplay += SpawnTarget;
            
        }

    }
}
