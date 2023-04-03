using KNH23.EfectSystem;
using UnityEngine;
using KNH23.CoreGamePlay;
using KNH23.UI.Buttons;
using UnityEngine.SceneManagement;

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
        [SerializeField] private UIStartButton _startButton;
       


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
            _startButton.gameObject.SetActive(false);
        }
        
        private void OnEnable()
        {
            UIStartButton.StartGameplay += StartGamePlay;
            UIStartButton.StartGameplay += SpawnTarget;
            UIRestartButton.ReStartGameplay += ResstartGamePlay;

        }

        private void OnDisable()
        {
            UIStartButton.StartGameplay -= StartGamePlay;
            UIStartButton.StartGameplay -= SpawnTarget;
            UIRestartButton.ReStartGameplay -= ResstartGamePlay;

        }

        private void ResstartGamePlay()
        {
            SceneManager.LoadScene(0);
            StartGamePlay();

        }
    }
}
