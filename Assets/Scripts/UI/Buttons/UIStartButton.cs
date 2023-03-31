using System;
using UnityEngine;

namespace KNH23.UI.Buttons
{
    public class UIStartButton : UIABaseButton
    {
        public static event Action StartGameplay;
        
        public override void OnClick()
        {
            Debug.Log("�� �������� ���");
            StartGameplay.Invoke();
            gameObject.SetActive(false);
        }
    }
}
