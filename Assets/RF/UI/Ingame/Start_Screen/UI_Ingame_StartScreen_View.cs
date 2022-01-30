using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace RF.UI.Ingame.Start_Screen
{
    public class UI_Ingame_StartScreen_View : SerializedMonoBehaviour
    {
        #region 스타트 스크린
        [BoxGroup("View")] public GameObject ingame_UI;

        public void Set_IngameUI(bool isOn)
        {
            ingame_UI.SetActive(isOn);
            this.gameObject.SetActive(false);
        }
        #endregion
    }
}
