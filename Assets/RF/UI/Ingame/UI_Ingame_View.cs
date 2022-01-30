using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RF.UI.Ingame
{
    public class UI_Ingame_View : SerializedMonoBehaviour
    {
        #region 플로어
        [BoxGroup("View")] public TMP_Text floor_Text;
        [BoxGroup("View")] public TMP_Text progress_Text;
        [BoxGroup("View")] public TMP_Text score_Text;
        [BoxGroup("View")] public RawImage elevator_Image;
        [BoxGroup("View")] public RawImage elevatorLine_Image;

        private float startPos;

        private void Awake()
        {
            var rect = elevator_Image.rectTransform;
            startPos = rect.anchoredPosition.y;
        }

        public void SetFloor(int floor)
        {
            floor_Text.text = floor + "층";
        }

        public void SetHeight(float height)
        {
            //Debug.Log(elevatorLine_Image.transform.localPosition.y);
            //Debug.Log(elevator_Image.rectTransform.anchoredPosition.y);
            
            var tr = elevator_Image.transform;
            var rect = elevator_Image.rectTransform;
            var rect2 = elevatorLine_Image.rectTransform;
            var max = startPos + rect2.rect.height - rect.rect.height - rect.rect.height/2;
            
            float per = height%(20+Mathf.Min(height/20*5, 5))/(20+Mathf.Min(height/20*5, 5));

            rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, rect.rect.height/2 + (max)*per, 0);
        }
        #endregion
    }
}
