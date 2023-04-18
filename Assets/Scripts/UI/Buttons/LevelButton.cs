using KNH23.CoreGamePlay;
using System;
using UnityEngine;

namespace KNH23.UI.Buttons
{
    public class LevelButton : UIABaseButton
    {
        public static event Action NextLevel;

        public override void OnClick()
        {
            NextLevel.Invoke();
        }

    }
}
