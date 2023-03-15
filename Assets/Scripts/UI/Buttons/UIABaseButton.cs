using UnityEngine;
using UnityEngine.UI;

namespace KNH23.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class UIABaseButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        public abstract void OnClick();
    }
}
