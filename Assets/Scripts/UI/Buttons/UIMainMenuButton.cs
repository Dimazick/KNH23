using System;


namespace KNH23.UI.Buttons
{
    public class UIMainMenuButton : UIABaseButton
    {
       
        public static event Action GoInMainMenu;

        public override void OnClick()
        {
            GoInMainMenu.Invoke();
           
        }
    }
}
