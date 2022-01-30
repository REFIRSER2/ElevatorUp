using UniRx;
using UnityEngine;

namespace RF.UI.Ingame.Start_Screen
{
    public class UI_Ingame_StartScreen_Model
    {
        public IntReactiveProperty startIndex;

        public UI_Ingame_StartScreen_Model()
        {
            startIndex = new IntReactiveProperty(-1);
        }
    }
}
