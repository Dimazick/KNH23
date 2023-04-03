using System;

namespace KNH23.UI.Buttons
{
    public class UIRestartButton : UIABaseButton
    {
        public static event Action ReStartGameplay;

        public override void OnClick()
        {
            ReStartGameplay.Invoke();           
        }
    }
}
