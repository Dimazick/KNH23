using UnityEngine.SceneManagement;

namespace KNH23.UI.Buttons
{
    public class UIRestartButton : UIABaseButton
    {
        public override void OnClick()
        {
            
            SceneManager.LoadScene(0);
        }
    }
}
