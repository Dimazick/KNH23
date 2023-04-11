using KNH23.EfectSystem;
using UnityEngine;
using KNH23.CoreGamePlay;
using KNH23.UI;
using KNH23.UI.Buttons;
using System.Collections;
using UnityEngine.SceneManagement;

namespace KNH23
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private TargetMotionForce _targetPrefab;
        private Vector2 _targetPosition = new Vector2(0, 2.5f);
        [SerializeField] private ThrowObjectGenerator _throwObjectGenerator;
        [SerializeField] private EfectSystemController _effects;
        [SerializeField] private AttemptCounterFunctional _attemptCounterFunctional;
        [SerializeField] private AttemptCounterVisual _attemptCounterVisual;
        [SerializeField] private ButtonPanelController _buttonPanelController;
        [SerializeField] private ScoreCounter _score;
        public GameObject[] _oldTarget;


        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void SpawnTarget()
        {
           Instantiate(_targetPrefab, _targetPosition, Quaternion.identity);
        }
        private void StartGamePlay()
        {
            _buttonPanelController.DontShowStartButton();
            SpawnTarget();           
            _throwObjectGenerator.gameObject.SetActive(true);
            _effects.gameObject.SetActive(true);
            _attemptCounterFunctional.gameObject.SetActive(true);
            _attemptCounterFunctional.SetCounts();
            _attemptCounterVisual.gameObject.SetActive(true);
            _attemptCounterVisual.SetDisplayAttemptCount(_attemptCounterFunctional.GetStartCounts());
            _score.gameObject.SetActive(true);
            _throwObjectGenerator.SpawnThrowObject();

        }
        
        private void OnEnable()
        {
            UIStartButton.StartGameplay += StartGamePlay;
            UIRestartButton.ReStartGameplay += ResstartGamePlay;
            UIMainMenuButton.GoInMainMenu += GoToMainMenu;
            

        }
        private void ChangeTargerts()
        {
            _oldTarget = GameObject.FindGameObjectsWithTag("Target");
            Destroy(_oldTarget[0]);            
            SpawnTarget();
        }

        private void OnDisable()
        {
            UIStartButton.StartGameplay -= StartGamePlay;
            UIRestartButton.ReStartGameplay -= ResstartGamePlay;
            UIMainMenuButton.GoInMainMenu -= GoToMainMenu;
        }

        private void ResstartGamePlay()
        {
            _attemptCounterFunctional.SetCounts();
            _attemptCounterVisual.DisplayIncrementAttemptCount(_attemptCounterFunctional.GetStartCounts());
             ChangeTargerts();
            _buttonPanelController.DontShowResstartButton();
            _throwObjectGenerator.SpawnThrowObject();
            _score.ResetPoints();
           
        }
        private void GoToMainMenu()
        {
            _buttonPanelController.DontShowResstartButton();
            _buttonPanelController.ShowStartButton();
            _oldTarget = GameObject.FindGameObjectsWithTag("Target");
            Destroy(_oldTarget[0]);
            _throwObjectGenerator.DeleteSpawnObject();
            _throwObjectGenerator.gameObject.SetActive(false);            
            _attemptCounterFunctional.gameObject.SetActive(false);
            _attemptCounterVisual.DestroyAllIcons(_attemptCounterFunctional.GetStartCounts());
            _score.gameObject.SetActive(false);



        }

    }
}
