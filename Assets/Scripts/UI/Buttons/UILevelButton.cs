using System;


namespace KNH23.UI.Buttons
{
    public class UILevelButton : UIABaseButton
    {
        public static event Action NextLevel;

        public override void OnClick()
        {
            NextLevel.Invoke();
        }

    }
}
