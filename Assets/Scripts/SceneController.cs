using KNH23.EfectSystem;
using UnityEngine;
using KNH23.CoreGamePlay;
using KNH23.UI;
using TMPro;
using KNH23.UI.Buttons;
using System.Collections;

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
        [SerializeField] private TMP_Text _score;
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
            SpawnTarget();
            _buttonPanelController.DontShowStartButton();
            _throwObjectGenerator.gameObject.SetActive(true);
            _effects.gameObject.SetActive(true);
            _attemptCounterFunctional.gameObject.SetActive(true);
            _attemptCounterVisual.gameObject.SetActive(true);
            _attemptCounterVisual.SetDisplayAttemptCount(_attemptCounterFunctional.GetStartCounts());
            _score.gameObject.SetActive(true);
           
           
        }
        
        private void OnEnable()
        {
            UIStartButton.StartGameplay += StartGamePlay;
            UIRestartButton.ReStartGameplay += ResstartGamePlay;
            

        }
        private IEnumerator ChangeTargerts()
        {
            _oldTarget = GameObject.FindGameObjectsWithTag("Target");
            Destroy(_oldTarget[0]);
            yield return new WaitForSeconds(0.3f);
            SpawnTarget();
        }

        private void OnDisable()
        {
            UIStartButton.StartGameplay -= StartGamePlay;
            UIRestartButton.ReStartGameplay -= ResstartGamePlay;
            

        }

        private void ResstartGamePlay()
        {
            _attemptCounterFunctional.SetCounts();
            StartCoroutine(ChangeTargerts());
            _buttonPanelController.DontShowResstartButton();
            _throwObjectGenerator.SpawnThrowObject();
            _attemptCounterVisual.DisplayIncrementAttemptCount(_attemptCounterFunctional.GetChances(), _attemptCounterFunctional.GetStartCounts());

            Debug.Log("Resstart in scene manager");
        }
    }
}
