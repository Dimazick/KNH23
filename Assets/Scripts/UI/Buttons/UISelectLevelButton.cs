using System;


namespace KNH23.UI.Buttons
{
    public class UISelectLevelButton : UIABaseButton
    {
        public static event Action GoToSelectionLevel;

        public override void OnClick()
        {
            GoToSelectionLevel.Invoke();
        }
    }
}
